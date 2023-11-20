namespace KhepriDotNet.Test.StudentClassUseCase;

public class Student:ICloneable
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public Student WithName(string value) => new Student(value,Age);
    public Student WithAge(int value) => new Student(Name, value);


    public object Clone()
    {
        return new Student(this.Name, this.Age);
    }
}
