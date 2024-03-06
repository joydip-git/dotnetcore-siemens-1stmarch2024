using PMSApp.Data;
using PMSApp.Entities;

namespace PMSApp.DAL
{
    public class CategoryDao : IDataAccess<CategoryCreateDto,CategoryReadDto>
    {
        private readonly SiemensDbContext inventory;

        public CategoryDao(SiemensDbContext inventory)
        {
            this.inventory = inventory;
        }

        public bool Add(CategoryCreateDto data)
        {
            return false;
        }

        public bool Delete(int id)
        {
            return false;
        }

        public CategoryReadDto Get(int id)
        {
            return new CategoryReadDto();
        }

        public IEnumerable<CategoryReadDto> GetAll()
        {
            return inventory.Categories.Select(c=>new CategoryReadDto { Id=c.Id, Name=c.Name });
        }

        public bool Update(int id, CategoryCreateDto data)
        {
            return false;
        }
    }
}
