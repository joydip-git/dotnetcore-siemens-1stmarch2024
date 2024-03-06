namespace PMSApp.Entities
{
    public class CategoryCreateDto
    {
        public string Name { get; set; } = string.Empty;

        public CategoryCreateDto()
        {

        }

        public CategoryCreateDto(string name)
        {
            Name = name;
        }
    }
}
