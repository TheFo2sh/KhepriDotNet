namespace KhepriDotNet;

/// <summary>
/// Marks methods within a store that represent actions which can mutate the state.
/// </summary>
/// <remarks>
/// Use this attribute to decorate methods in your store classes that are intended
/// to change the state. This ensures that state changes are tracked and managed
/// consistently. Methods marked with this attribute are intercepted to ensure 
/// proper state handling and validation.
/// </remarks>
public sealed class ActionAttribute : Attribute { }