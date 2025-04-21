using Unisys.DotNet.PmsApp.BusinessLayer.Implementations;
using Unisys.DotNet.PmsApp.BusinessLayerCore.Abstractions;
using Unisys.DotNet.PmsApp.DataAccessLayerCore.Abstractions;
using Unisys.DotNet.PmsApp.DataAccessLayerCore.Implementation;
using Unisys.DotNet.PmsApp.IoC;
using Unisys.DotNet.PmsApp.ModelsCore;
using Unisys.DotNet.PmsApp.RepositoryCore;
using Unity;

namespace Unisys.DotNet.PmsApp.UserInterfaceCore
{
    [Obsolete($"do not ue this class, rather use {nameof(PmsUI)}")]
    internal class Program
    {
        [Obsolete($"do not use this method, use {nameof(RegisterServices)} from {nameof(PmsUI)}")]
        static IUnityContainer RegisterServices()
        {
            IUnityContainer container = UnityConfig.BuildUnityContainer();
            container.RegisterType<ProductRepository>();
            container.RegisterType<IDaoContract<Product, int>, ProductDao>();
            container.RegisterType<IBoContract<Product, int>, ProductBo>();

            return container;
        }
        [Obsolete($"do not use this Main method, use {nameof(Main)} from {nameof(PmsUI)}")]
        static void Main(string[] args)
        {
            try
            {
                IUnityContainer container = RegisterServices();
                var productBo = container.Resolve<IBoContract<Product, int>>();
                productBo.FetchAll()?.ToList().ForEach(p => Console.WriteLine(p.Name));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
