namespace InterviewAssignments.IdentityService.Models
{
    public class RegistrationResult
    {
        private RegistrationResult(bool isSuccessful, RegistrationError? error = null)
        {
            IsSuccessful = isSuccessful;
            Error = error;
        }

        public bool IsSuccessful { get; }
        public RegistrationError? Error { get; }

        public static RegistrationResult Successful() => new RegistrationResult(true);

        public static RegistrationResult Failed(RegistrationError error) => new RegistrationResult(false, error);
    }
}