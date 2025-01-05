
namespace OnionArch.Application.Exceptions
{
    public class UserCreatedFailException : Exception
    {
        public UserCreatedFailException() : base("An error occurred while creating the user.")
        {
        }

        public UserCreatedFailException(string? message) : base(message)
        {
        }

        public UserCreatedFailException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
