using FluentValidation.Results;

namespace Common.Validation
{
    public class ValidationErrorDetail
    {
        public string Error { get; set; } = string.Empty;
        public string Detail { get; set; } = string.Empty;

        public static explicit operator ValidationErrorDetail(ValidationFailure failure)
        {
            return new ValidationErrorDetail
            {
                Error = failure.ErrorMessage,
                Detail = failure.ErrorCode
            };
        }
    }
}
