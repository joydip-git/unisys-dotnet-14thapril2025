using Unisys.DotNet.PmsApp.DataAccessLayer.Abstractions;
using Unisys.DotNet.PmsApp.DataAccessLayer.Implementations;
using Unisys.DotNet.PmsApp.BusinessLayer.Abstractions;
using Unisys.DotNet.PmsApp.BusinessLayer.Implementations;
using Unisys.DotNet.PmsApp.IoC;
using Unisys.DotNet.PmsApp.Models;
using Unisys.DotNet.PmsApp.Repository;
using Unity;
using System.Linq;
using System;

namespace Unisys.DotNet.PmsApp.UserInterface
{
    internal class Program
    {
        static IUnityContainer RegisterServices()
        {
            IUnityContainer container = UnityConfig.BuildUnityContainer();
            container.RegisterType<ProductRepository>();
            container.RegisterType<IDaoContract<Product, int>, ProductDao>();
            container.RegisterType<IBoContract<Product, int>, ProductBo>();

            return container;
        }
        static void Main(string[] args)
        {
            try
            {
                IUnityContainer container = RegisterServices();
                var productBo = container.Resolve<IBoContract<Product, int>>();
                productBo.FetchAll().ToList().ForEach(p => Console.WriteLine(p.Name));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }
    }
}
