using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>(); //eğer birisi IProductService türünde bişey isterse biz ProductManager veriyoruz
            builder.RegisterType<EfProductDal>().As<IProductDal>(); //eğer birisi IProductService türünde bişey isterse biz ProductManager veriyoruz
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>(); 
            builder.RegisterType<CategoryManager>().As<ICategoryService>(); 

        }
    }
}
