using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Race_Day.Data;
using Race_Day.Models.DTO;
using Race_Day.Models.Entities;

namespace Race_Day.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbcontext dbcontext;
        public CategoryController(ApplicationDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = dbcontext.categories.ToList();

            return Ok(categories);
        }
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetCategoryById(Guid id)
        {
            var category = dbcontext.categories.Find(id);
            if (category == null) return NotFound($"No category was found with {id}");
            return Ok(category);
        }
        [HttpPost]
        public IActionResult AddNewCategory(CategoryDTO categoryDTO)
        {
            var newCategory = new Category
            {
                CategoryName = categoryDTO.CategoryName,
                CategoryDescription = categoryDTO.CategoryDescription
            };
            dbcontext.categories.Add(newCategory);
            dbcontext.SaveChanges();
            return Ok("Category was added successfully");
        }
        [HttpPut("{id:guid}")]
        public IActionResult UpdateCategory(Guid id, CategoryDTO categoryDTO)
        {
            var category = dbcontext.categories.Find(id);
            if (category == null) return NotFound($"No category was found with {id}");
            if (categoryDTO.CategoryName != null) category.CategoryName = categoryDTO.CategoryName;
            if (categoryDTO.CategoryDescription != null) category.CategoryDescription = categoryDTO.CategoryDescription;
            dbcontext.SaveChanges();
            return Ok("Category was updated successfully");
        }
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteCategory(Guid id)
        {
            var category = dbcontext.categories.Find(id);
            if (category == null) return NotFound($"No category was found with {id}");
            dbcontext.categories.Remove(category);
            dbcontext.SaveChanges();
            return Ok("Category was deleted successfully");
        }

    }
}
