using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation) //transcion yaşam dongusu için intercept kullanılıyor transaction bir döngü
        {
            using (TransactionScope transactionalScope = new TransactionScope())
            {

                try
                {
                    invocation.Proceed();
                    transactionalScope.Complete();
                }
                catch (Exception e)
                {

                    transactionalScope.Dispose();
                    throw;
                }

            }
        }
    }
}
