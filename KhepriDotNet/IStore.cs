namespace KhepriDotNet;

internal interface IStore
{
    public void Update(object state);
    
    public void Validate(object state);
}
