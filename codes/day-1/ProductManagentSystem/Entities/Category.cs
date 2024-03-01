namespace ProductManagentSystem.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;

        public Category()
        {
            
        }

        public Category(int id, string name)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
