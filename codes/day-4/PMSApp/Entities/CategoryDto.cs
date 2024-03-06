namespace PMSApp.Entities
{
    public class CategoryDto
    {
        private readonly int _id;
        public int Id { get => _id; }
        public string Name { get; set; } = string.Empty;

        public CategoryDto()
        {

        }

        public CategoryDto(int id, string name)
        {
            _id = id;
            Name = name;
        }

        public override bool Equals(object? obj)
        {
            if (obj != null)
            {
                if (obj is CategoryDto)
                {
                    CategoryDto other = obj as CategoryDto;

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
    }
}
