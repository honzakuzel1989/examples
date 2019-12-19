using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InterviewAssignments.StreamProcessingService
{
    class StreamService : IStreamService
    {
        /// <summary>
        /// Calculate the arithmetic average (mean) of all doubles contained in the input collections
        /// </summary>
        /// <param name="dataStreams">Input streams of items</param>
        /// <returns>Arithmetic average (mean) </returns>
        public double CalculateAverage(IEnumerable<IList<double>> dataStreams)
        {
            // Create pair with sum and count for each stream - in parallel
            // INFO: Assume that sum for one list is not bigger then double.MaxValue
            var averagesAndCounts = dataStreams.AsParallel().Select(
                dataStream => (sum: dataStream.Sum(), count: dataStream.Count()));

            // Calculate average for sum of sums and sum of counts in parallel (hopefully better than serial version of sum)
            // INFO: It is not possible to use average of an average easily
            return averagesAndCounts.AsParallel().Sum(aac => aac.sum) /
                averagesAndCounts.AsParallel().Sum(aac => aac.count);
        }

        /// <summary>
        /// Calculate the arithmetic average (mean) of all doubles extracted from the input collection.
        /// </summary>
        /// <typeparam name="T">Type of data</typeparam>
        /// <param name="data">List of data</param>
        /// <param name="parallelismDegree">Parallelism degree</param>
        /// <param name="valueExtractor">Data extractor</param>
        /// <returns>Arithmetic average (mean)</returns>
        public double CalculateAverage<T>(IList<T> data, int parallelismDegree, Func<T, double> valueExtractor)
        {
            

            // Extracted values from data - we know the count of data in list (!)
            var extractedValues = new double[data.Count];

            // Options (!)
            var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = parallelismDegree };

            // Run in parallel in parallelismDegree maximally and extract value from data (CPU bound)
            Parallel.ForEach(data, parallelOptions, (item, _, index) => extractedValues[index] = valueExtractor(item));

            // Calculate mean, also in parallel, but efficiency also depends about avg algorithm (generally not very good for small list)
            return extractedValues.AsParallel().Average();
        }

        /// <summary>
        /// Calculate the arithmetic average (mean) of all doubles contained in the input collection of streams.
        /// </summary>
        /// <param name="dataStreams">Input streams</param>
        /// <returns>Arithmetic average (mean)</returns>
        public Task<double> CalculateAverageAsync(IEnumerable<Stream> dataStreams)
        {
            // Space for sum and average for each stream (assume that sum of number in stream is <= double.MaxValue)
            var streamsNumberSums = new ConcurrentBag<double>();
            var streamsNumberCounts = new ConcurrentBag<int>();

            // Async parallel work for each stream
            dataStreams.AsParallel().ForAll(async dataStream =>
            {
                // Initial values
                var streamNumberSum = 0.0;
                var streamNumberCounts = 0;

                // Create streamreader from stream and read to the end
                var dataStreamReader = new StreamReader(dataStream, Encoding.UTF8);
                while (!dataStreamReader.EndOfStream)
                {
                    // Get valid numbers from line
                    var validLineNumbers = await GetValidLineNumbers(dataStreamReader);

                    // Calculate sum and count for each stream
                    // INFO: Maybe will be better calculate the mean continuously (nextAvg = ((count * avg) + nextVal) / (count + 1))
                    streamNumberSum += validLineNumbers.Sum();
                    streamNumberCounts += validLineNumbers.Count();
                }

                // Add stream's sum and count to the bag - the final size is like dataStreams.Count()
                streamsNumberSums.Add(streamNumberSum);
                streamsNumberCounts.Add(streamNumberCounts);
            });

            // Run result as a task
            return Task.Run(() => streamsNumberSums.Sum() / streamsNumberCounts.Sum());
        }

        private static async Task<IEnumerable<double>> GetValidLineNumbers(StreamReader dataStreamReader)
        {
            // Read and split line by separator
            var line = await dataStreamReader.ReadLineAsync();
            var lineItems = line.Split(';', StringSplitOptions.RemoveEmptyEntries);

            // Get parsedInfo and parsedNumber like a pair
            var parsedLineItems = lineItems.Select(item =>
                (canParse: TryParseDoubleInvariant(item, out var number), parsedNumber: number));

            // Returns successfully parsed numbers
            return parsedLineItems.Where(lineItem => lineItem.canParse).Select(inputItem => inputItem.parsedNumber);
        }

        /// <summary>
        /// This method takes two input collections of doubles (encoded in streams) and return single collection of doubles in ascending order.
        /// </summary>
        /// <param name="stream1">stream ordered in the ascending order</param>
        /// <param name="stream2">stream ordered in the ascending order</param>
        /// <returns>Arithmetic average (mean) </returns>
        public IEnumerable<double> JoinAndSort(Stream stream1, Stream stream2)
        {
            // Stream readers
            var activeStreamReaders = new[]
            {
                new StreamReader(stream1, Encoding.UTF8),
                new StreamReader(stream2, Encoding.UTF8)
            };

            // Call more general method
            return JoinAndSort(activeStreamReaders);
        }

        private IEnumerable<double> JoinAndSort(StreamReader[] activeStreamReaders)
        {
            // Data from streams from one cycle
            var streamsData = new ConcurrentBag<(bool parsed, double number)>();

            // Read at least one stream (any is not at the end)
            while (activeStreamReaders.Any(sr => !sr.EndOfStream))
            {
                // Filter active streams
                activeStreamReaders = activeStreamReaders.Where(sr => !sr.EndOfStream).ToArray();

                // Get number from each stream
                activeStreamReaders.AsParallel().ForAll(async sr => streamsData.Add(await TryGetNextNumber(sr)));

                // Filter and sort them and yield result
                foreach (var data in streamsData.Where(streamData => streamData.parsed).OrderBy(streamData => streamData.number))
                    yield return data.number;

                // Clear sorted data
                streamsData.Clear();
            }
        }

        private async Task<(bool parsed, double number)> TryGetNextNumber(StreamReader sr)
        {
            // INFO: we can make method with generic of T instead of double

            // Read to the end
            while (!sr.EndOfStream)
            {
                // Get next line async (IO bound)
                var line = await sr.ReadLineAsync();

                // Try parse next number or continue
                if (TryParseDoubleInvariant(line, out double number))
                    return (true, number);
            }

            // Cannot parse next number
            return (false, default);
        }

        private static bool TryParseDoubleInvariant(string line, out double number)
        {
            // Because of separator, ...
            return double.TryParse(line, NumberStyles.Any, CultureInfo.InvariantCulture, out number);
        }
    }
}