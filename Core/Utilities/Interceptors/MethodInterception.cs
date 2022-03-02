﻿using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        //method çalışmadan önce çalış
        //invocation is method name
        protected virtual void OnBefore(IInvocation invocation)
        {

        }

        protected virtual void OnAfter(IInvocation invocation)
        {

        }
        protected virtual void OnException(IInvocation invocation)
        {

        }

        protected virtual void OnSuccess(IInvocation invocation)
        {

        }


        public  override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed(); //methodu çalıştır
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }

    }
}
