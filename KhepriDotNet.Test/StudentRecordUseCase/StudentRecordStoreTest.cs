using FluentAssertions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace KhepriDotNet.Test.StudentRecordUseCase;

public class StudentRecordStoreTest
{
    private readonly ServiceProvider _provider;

    public StudentRecordStoreTest()
    {
        var services = new ServiceCollection();
        services.AddKhepri();
        services.AddSingleton<StudentRecordValidator>();
        services.AddStore<StudentRecordStore, StudentRecord>();
        this._provider = services.BuildServiceProvider();
    }
    
    [Fact]
    public void SubscriptionWillBeCalledAfterActionGetInvoked()
    {
        var store =_provider.GetRequiredService<StudentRecordStore>();
        var action = Substitute.For<Action<StudentRecord>>();
        store.Subscribe(action);
        store.UpdateName("Ahmed");
        action.Received(1).Invoke(Arg.Is<StudentRecord>(s => s.Name == "Ahmed"));
        store.GetState().Should().Be(new StudentRecord("Ahmed", 21));
    }
    
    [Fact]
    public void ValidationShouldBeCalledAndPreventStateUpdateInCaseOfInvalidValue()
    {
        var store =_provider.GetRequiredService<StudentRecordStore>();
        var action = Substitute.For<Action<StudentRecord>>();
        store.Subscribe(action);
        var modifyingAgeWithAnInvalidValue=()=>store.UpdateAge(10);
        modifyingAgeWithAnInvalidValue.Should().Throw<ValidationException>();
        action.Received(0);
        store.GetState().Should().Be(new StudentRecord("John", 21));

    }
}