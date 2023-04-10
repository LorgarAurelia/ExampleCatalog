using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TestCatalogue.DTO;
using TestCatalogue.Exceptions;
using TestCatalogue.WebSiteService;

namespace TestCatalogue.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class CatalogueController : ControllerBase
    {
        private readonly ICatalogueService _service;

        public CatalogueController(ICatalogueService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("/category")]
        public async Task<IActionResult> GetCategory()
        {
            try
            {
                return Ok(await _service.ShowAllCategories());
            }
            catch (NullResultException ex)
            {
                return Ok(new Responce<string>() { Body = new() { ex.Message} });
            }
        }

        [HttpPost]
        [Route("/category")]
        public async Task<IActionResult> PostCategory(CategoryCreationForm category)
        {
            try
            {
                return Ok( await _service.CreateCategory(category));
            }
            catch (NullResultException ex)
            {
                return Ok(new Responce<string>() { Body = new() { ex.Message } });
            }
            
        }

        [HttpPost]
        [Route("/deleteCategory")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            try
            {
                return Ok(await _service.DeleteCategory(categoryId));
            }
            catch (NullResultException ex)
            {
                return Ok(new Responce<string>() { Body = new() { ex.Message } });
            }
            
        }

        [HttpGet]
        [Route("/getGoodsForm")]
        public async Task<IActionResult> GetGoodsForm(int categoryId)
        {
            try
            {
                return Ok( await _service.CreateGoodsForm(categoryId));
            }
            catch (NullResultException ex)
            {
                return Ok(new Responce<string>() { Body = new() { ex.Message } });
            }
        }

        [HttpPost]
        [Route("/goods")]
        public async Task<IActionResult> PostGoods(GoodsCreationForm goods)
        {
            try
            {
                return Ok(await _service.CreateGoods(goods));
            }
            catch (NullResultException ex)
            {
                return Ok(new Responce<string>() { Body = new() { ex.Message } });
            }
        }

        [HttpGet]
        [Route("/goods")]
        public async Task<IActionResult> GetGoods([FromQuery] int categoryId = 0)
        {
            try
            {
                return Ok(await _service.ShowAllGoods(categoryId));
            }
            catch (NullResultException ex)
            {
                return Ok(new Responce<string>() { Body = new() { ex.Message } });
            }
        }

        [HttpGet]
        [Route("/goods/id")]
        public async Task<IActionResult> GetGoodsFullData([FromQuery][Required] int goodsId)
        {  
            try
            {
                return Ok( await _service.ShowFullGoodsData(goodsId));
            }
            catch (NullResultException ex)
            {
                return Ok(new Responce<string>() { Body = new() { ex.Message } });
            }
        }
    }
}
