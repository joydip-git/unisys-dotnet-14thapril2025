namespace DependencyInjectionDemo
{
    public class Container
    {
        private static Container _container;
        private Container()
        {
            Console.WriteLine("container created...");
        }
        public static Container Create()
        {
            if (_container == null)
                _container = new Container();

            return _container;
        }

        public TInterface? GetService<TInterface, TImplementation>()
        {
            Type implType = typeof(TImplementation);
            Type contractType = typeof(TInterface?);

            Type[] interfaces = implType.GetInterfaces();
            bool doesImplement = false;
            foreach (Type item in interfaces)
            {
                if (item == contractType)
                {
                    doesImplement = true;
                    break;
                }
            }
            if (doesImplement)
            {
                return (TInterface?)Activator.CreateInstance(implType);
            }
            else
                return default(TInterface?);
        }
    }
}
