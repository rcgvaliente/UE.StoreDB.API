using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UE.StoreDB.Domain.Core.Interfaces;

namespace UE.StoreDB.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var category = await _categoryRepository.GetAll();
            return Ok(category);

        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryRepository.GetById(id);
            if (category == null) 
                return NotFound();

            return Ok(category);
        }
    }
}
