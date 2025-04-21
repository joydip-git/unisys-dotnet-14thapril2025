using Unity;

namespace Unisys.DotNet.PmsApp.IoC
{
    public class UnityConfig
    {
        private static IUnityContainer unityContainer;        
        public static IUnityContainer BuildUnityContainer()
        {
            if(unityContainer == null)
                unityContainer = new UnityContainer();
            
            return unityContainer;  
        }        
    }
}
