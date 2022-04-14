using MyArt.BusinessLogic.Models;

namespace MyArt.API.Infrastructure.Models
{
    public class ErrorResponse
    {
        public string ErrorMessage { get; set; }

        public ErrorResponse(string message)
        {
            ErrorMessage = message;
        }

        public IEnumerable<FluentFailure> ValidationFailures { get; set; }

    }
}
