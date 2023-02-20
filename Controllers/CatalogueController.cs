using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TestCatalogue.DTO;
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
        public IActionResult GetCategory()
        {
            return Ok(_service.ShowAllCategories());
        }

        [HttpPost]
        [Route("/category")]
        public IActionResult PostCategory(CategoryCreationForm category)
        {
            return Ok(_service.CreateCategory(category));
        }

        [HttpPost]
        [Route("/deleteCategory")]
        public IActionResult DeleteCategory(int categoryId)
        {
            return Ok(_service.DeleteCategory(categoryId));
        }

        [HttpGet]
        [Route("/getGoodsForm")]
        public IActionResult GetGoodsForm(int categoryId)
        {
            return Ok(_service.CreateGoodsForm(categoryId));
        }

        [HttpPost]
        [Route("/goods")]
        public IActionResult PostGoods(GoodsCreationForm goods)
        {
            return Ok(_service.CreateGoods(goods));
        }

        [HttpGet]
        [Route("/goods")]
        public IActionResult GetGoods([FromQuery] int categoryId = 0)
        {
            return Ok(_service.ShowAllGoods(categoryId));
        }

        [HttpGet]
        [Route("/goods/id")]
        public IActionResult GetGoodsFullData([FromQuery][Required] int goodsId)
        {
            return Ok(_service.ShowFullGoodsData(goodsId));
        }
    }
}
