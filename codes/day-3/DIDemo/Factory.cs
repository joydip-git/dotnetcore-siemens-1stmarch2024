namespace DIDemo
{
    public class Factory
    {
        private static Factory instance;
        private Factory()
        {
        }

        public static Factory CreateInstance()
        {
            if (instance == null)
                instance = new Factory();

            return instance;
        }

        public TInterface Create<TInterface, TClass>()
        {
            Type clsTypeInfo = typeof(TClass);
            if (clsTypeInfo != null)
            {
                object? obj = Activator.CreateInstance(clsTypeInfo);
                if (obj != null)
                {
                    return (TInterface)obj;
                }
                else
                    throw new Exception("object could not be created");
            }
            else
                throw new Exception("type information could not be extracted");
        }
    }
}
