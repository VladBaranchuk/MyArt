
namespace MyArt.BusinessLogic.Models
{
    public class FluentFailure
    {
        public string PropertyName { get; set; }
        public string Message { get; set; }
        public object AttemptedValue { get; set; }
    }
}
