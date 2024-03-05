namespace DIDemo
{
    public class Factory
    {
        private static Factory instance;
        //private readonly ICollection<Entry<int,object>> container;

        //class Entry<TKey, TValue>
        //{

        //}
        private Factory()
        {
            //container = new HashSet<Entry<int,object>>();
        }

        public static Factory CreateInstance()
        {
            if (instance == null)
                instance = new Factory();

            return instance;
        }

        public TInterface Create<TInterface, TClass>()
        {
            var obj = (TInterface)Activator.CreateInstance(typeof(TClass));
            //container.Add(new Entry<int, object>(1,obj));
            return obj;
        }
    }
}
