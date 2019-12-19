using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace InterviewAssignments.StreamProcessingService
{
    public interface IStreamService
    {
        double CalculateAverage(IEnumerable<IList<double>> dataStreams);
        Task<double> CalculateAverageAsync(IEnumerable<Stream> dataStreams);
        double CalculateAverage<T>(IList<T> data, int parallelismDegree, Func<T, double> valueExtractor);
        IEnumerable<double> JoinAndSort(Stream stream1, Stream stream2);
    }
}