using FluentValidation;

namespace KhepriDotNet.Test.StudentRecordUseCase;

public class StudentRecordValidator : AbstractValidator<StudentRecord>
{
    public StudentRecordValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Age).NotEmpty().WithMessage("Age is required");
        RuleFor(x => x.Age).GreaterThan(18).WithMessage("Age must be between 18 and 60");
    }
}