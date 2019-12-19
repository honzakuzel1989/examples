using System;

namespace InterviewAssignments.StreamProcessingService
{
    public static class StreamServiceFactory
    {
        public static IStreamService CreateService() => new StreamService();
    }
}
