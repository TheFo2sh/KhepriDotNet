

# KhepriDotNet

KhepriDotNet is a state-of-the-art .NET library tailored for efficient and flexible state management. It leverages Functional Reactive Programming (FRP) principles to facilitate responsive and maintainable application states.

## Problem Definition
Managing state in applications can be challenging, especially in environments where state changes frequently and unpredictably. Traditional methods often lead to complicated and error-prone code.

## Solution: Reactive Functional Programming
KhepriDotNet solves these challenges by combining the principles of FRP. This approach allows for more predictable state management, making your code more maintainable and responsive.


## Features
- Reactive State Management with Observables
- Strong Emphasis on Immutability and Validation
- Easy Integration with .NET Dependency Injection

## Getting Started
To get started with KhepriDotNet, install the package via NuGet:
```bash
Install-Package KhepriDotNet
```


## Implementing a Store
To create a store, define a class inheriting from `Store<T>` and use the `[Action]` attribute to mark methods modifying the state.

```csharp
public class StudentRecordStore : Store<StudentRecord>
{
    [Action]
    public void UpdateName(string name) 
    {
        // Update name logic
    }

    [Action]
    public void UpdateAge(int age) 
    {
        // Update age logic
    }
}
```
Absolutely, here's an elaboration on the importance of validation for state consistency:

---

### Custom Validation for State Consistency
In KhepriDotNet, overriding the `Validate` method is crucial for maintaining state consistency. This custom validation process ensures that only valid data manipulates the state, preventing inconsistencies and potential errors in your application. It acts as a safeguard, allowing you to define rules and constraints that the state must adhere to.

```csharp
protected override void Validate(StudentRecord state)
{
    // Implement validation logic here
}
```

By performing these checks before any state update, KhepriDotNet helps in maintaining a robust and reliable application, where state transitions are safe and predictable.

---
## Registering a Store
Register your store with the .NET service collection for dependency injection:

```csharp
services.AddStore<StudentRecordStore, StudentRecord>();
```

## Subscribing to a Store
Subscribe to state changes in the store:

```csharp
var store = serviceProvider.GetRequiredService<StudentRecordStore>();
store.Subscribe(state => {
    // React to state updates
});
```


