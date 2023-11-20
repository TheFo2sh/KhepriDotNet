using FluentValidation;

namespace KhepriDotNet.Test.StudentRecordUseCase;

public class StudentRecordStore : Store<StudentRecord>
{
    private readonly StudentRecordValidator _studentValidator;
    public StudentRecordStore(StudentRecordValidator studentValidator) : base(new("John", 21))
    {
        _studentValidator = studentValidator;
    }
    
    [Action]
    public virtual StudentRecord UpdateName(string name) => CurrentState with { Name = name };

    [Action]
    public virtual StudentRecord UpdateAge(int age) => CurrentState with { Age = age };

    protected override void Validate(StudentRecord state)
    {
        _studentValidator.ValidateAndThrow(state);
    }
}