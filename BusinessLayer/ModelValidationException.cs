using System.ComponentModel.DataAnnotations;

public class ModelValidationException : Exception
{
    public ICollection<ValidationResult> Errors { get; }

    public ModelValidationException()
    {
    }

    public ModelValidationException(string message, ICollection<ValidationResult> errors) : base(message)
    {
        Errors = errors;
    }
}