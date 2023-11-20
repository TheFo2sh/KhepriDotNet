using FluentValidation;

namespace KhepriDotNet.Test.StudentClassUseCase;

public class StudentRecordStore : Store<Student>
{
    private readonly StudentRecordValidator _studentValidator;
    public StudentRecordStore(StudentRecordValidator studentValidator) : base(new("John", 21))
    {
        _studentValidator = studentValidator;
    }
    
    [Action]
    public virtual Student UpdateName(string name) => CurrentState.WithName(name);

    [Action]
    public virtual Student UpdateAge(int age) => CurrentState.WithAge(age);

    protected override void Validate(Student state)
    {
        _studentValidator.ValidateAndThrow(state);
    }
}