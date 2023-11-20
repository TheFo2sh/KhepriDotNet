using System.Reflection;
using Castle.DynamicProxy;

namespace KhepriDotNet;

[Serializable]
internal class StoreInterceptor:IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        if (invocation.Method.GetCustomAttribute<ActionAttribute>() != null)
        {
            var store = (IStore)invocation.InvocationTarget;
            invocation.Proceed();
            var state = invocation.ReturnValue;
            store.Validate(state);
            store.Update(state);
        }
        else
        {
            invocation.Proceed();
            return;
        }
    }
}