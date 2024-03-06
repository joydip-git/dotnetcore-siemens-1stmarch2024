namespace PMSApp.Entities
{
    public class CategoryReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public CategoryReadDto()
        {

        }

        public CategoryReadDto(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override bool Equals(object? obj)
        {
            if (obj != null)
            {
                if (obj is CategoryReadDto)
                {
                    CategoryReadDto other = (CategoryReadDto)obj;

                    //if(ReferenceEquals(this, obj)) return true;
                    if (this == other)
                        return true;

                    if (!this.Id.Equals(other.Id))
                        return false;

                    if (!this.Name.Equals(other.Name))
                        return false;

                    return true;
                }
                else
                    throw new ArgumentException("obj must be of type Category");
            }
            else
                throw new NullReferenceException("obj is null");
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            return this.Id.GetHashCode() * prime;
        }
    }
}
