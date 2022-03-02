using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    //bütün sınıflarda ve methodlar inherit edilenlerde birden fazla kez kullanılabilir
    public abstract class MethodInterceptionBaseAttribute: Attribute, IInterceptor
    {

        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
