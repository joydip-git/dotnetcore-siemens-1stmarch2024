namespace ObjectClassMethods
{
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Person()
        {

        }
        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name}, {Id}";
        }
        public override int GetHashCode()
        {
            const int prime = 31;
            int hashCode = 1;
            hashCode = this.Id.GetHashCode() * prime;
            hashCode = this.Name.GetHashCode() * hashCode;
            return hashCode;
        }
        public override bool Equals(object? obj)
        {
            //if(ReferenceEquals(this, obj)) return true;
            if (obj != null)
            {
                if (obj is Person)
                {
                    Person other = obj as Person;

                    if (this == other)
                        return true;

                    if (!this.Id.Equals(other.Id))
                        return false;

                    if (!this.Name.Equals(other.Name))
                        return false;

                    return true;
                }
                else
                    throw new ArgumentException("obj must be of type Person");
            }
            else
                throw new NullReferenceException("obj is null");
        }
    }
}
