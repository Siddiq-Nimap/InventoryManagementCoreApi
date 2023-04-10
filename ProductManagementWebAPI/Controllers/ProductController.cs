using AutoMapper;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using ProductManagementWebAPI.DTO;
using ProductManagementWebAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Repository.Repositories.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IGenericRepository<Products> product;
        readonly IMapper mapper;
        public ProductController(IGenericRepository<Products> Prod, IMapper map)
        {
            product = Prod;
            mapper = map;
        }


        [HttpGet("Products")]

        public async Task<ActionResult<Products>> GetProducts()
        {

            var data = await product.GetModel();

            var mapdata = mapper.Map<IEnumerable<Products>, IEnumerable<ProductDto>>(data);
            return Ok(mapdata);
        }

        [HttpGet("Product/{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var data = await product.GetModelById(id);

            if (data == null)
            {
                return NotFound();
            }

            var mapdata = mapper.Map<Products, ProductDto>(data);
            return Ok(mapdata);
        }

        [HttpPost("Product")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto cata)
        {

            var Mapcata = mapper.Map < ProductDto, Products>(cata);

            await product.InsertModel(Mapcata);
            var check = await product.Save();

            if (check)
            {
                return Created(new Uri(Request.GetDisplayUrl() + "/" + new { id = Mapcata.Id }), Mapcata);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("Product")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDto cata)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Mapcata = mapper.Map<ProductDto, Products>(cata);

            product.UpdateModel(Mapcata);
            var check = await product.Save();

            if (check)
            {
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpPatch("Product/{id}")]
        public async Task<IActionResult> UpdateProductPatch([FromBody] JsonPatchDocument cata, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var Mapcata = mapper.Map<CatagoryDto, Catagories>(cata);

            await product.UpdateModelPatch(id, cata);
            var check = await product.Save();

            if (check)
            {
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("Product/{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute]int id)
        {
            var data = await product.DeleteModel(id);

            if (data == false)
            {
                return BadRequest();
            }

            var check = await product.Save();

            if (check) { return Ok(); }
            else return BadRequest();

        }


    }
}
