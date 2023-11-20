using FluentValidation;

namespace KhepriDotNet.Test.StudentClassUseCase;

public class StudentRecordValidator : AbstractValidator<Student>
{
    public StudentRecordValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Age).NotEmpty().WithMessage("Age is required");
        RuleFor(x => x.Age).GreaterThan(18).WithMessage("Age must be between 18 and 60");
    }
}