namespace Common.Validation
{
    public class ValidationResultDetail
    {
        public bool IsValid { get; set; }
        public IEnumerable<ValidationErrorDetail> Errors { get; set; } = [];

        public ValidationResultDetail() { }

        public ValidationResultDetail(ValidationResultDetail result)
        {
            IsValid = result.IsValid;
            Errors = result.Errors.Select(x => (ValidationErrorDetail)x);
        }
    }
}
