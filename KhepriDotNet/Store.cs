using System.Reactive.Subjects;

namespace KhepriDotNet;

/// <summary>
/// Represents an abstract base class for a store that manages and observes state of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of the state object managed by the store.</typeparam>
/// <remarks>
/// The Store class provides mechanisms to manage state changes in a reactive manner.
/// It also supports cloning the state if it implements ICloneable, ensuring immutability.
/// </remarks>
public abstract class Store<T> : IStore, IObservable<T>, IDisposable
{
    private readonly BehaviorSubject<T> _state;

    /// <summary>
    /// Gets the current state. Returns a clone if the state is cloneable.
    /// </summary>
    protected T CurrentState => _state.Value is ICloneable cloned ? (T) cloned : _state.Value;

    /// <summary>
    /// Initializes a new instance of the Store with an initial state.
    /// </summary>
    /// <param name="initialState">The initial state of the store.</param>
    protected Store(T initialState)
    {
        _state = new(initialState);
    }

    void IStore.Update(object state)
    {
        _state.OnNext((T)state);
    }

    void IStore.Validate(object state)
    {
        Validate((T)state);
    }

    /// <summary>
    /// Validates the provided state.
    /// </summary>
    /// <param name="state">The state to validate.</param>
    protected virtual void Validate(T state)
    {
        // Validation logic...
    }

    /// <summary>
    /// Subscribes an observer to the state.
    /// </summary>
    /// <param name="observer">The observer to subscribe.</param>
    /// <returns>The disposable reference to the subscription.</returns>
    public IDisposable Subscribe(IObserver<T> observer)
    {
        return _state.Subscribe(observer);
    }

    /// <summary>
    /// Gets the current state of the store.
    /// </summary>
    /// <returns>The current state.</returns>
    public T GetState() => CurrentState;

    /// <summary>
    /// Disposes the store, releasing all resources.
    /// </summary>
    public void Dispose()
    {
        _state.Dispose();
    }
}
