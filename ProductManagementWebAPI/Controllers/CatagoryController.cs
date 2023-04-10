using AutoMapper;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProductManagementWebAPI.Models;
using Repository.Repositories.Interfaces;
using ProductManagementWebAPI.DTO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatagoryController : ControllerBase
    {
        readonly IGenericRepository<Catagories> catagories;
        readonly IMapper mapper;
        public CatagoryController(IGenericRepository<Catagories> catagory, IMapper map)
        {
            catagories = catagory;
            mapper = map;
        }


        [HttpGet("Catagories")]

        public async Task<ActionResult<Catagories>> GetCatagory()
        {

            var data = await catagories.GetModel();

            var mapdata = mapper.Map<IEnumerable<Catagories>, IEnumerable<CatagoryDto>>(data);
            return Ok(mapdata);
        }

        [HttpGet("Catagory/{id}")]
        public async Task<IActionResult> GetCatagoryById([FromRoute] int id)
        {
            var data = await catagories.GetModelById(id);

            if (data == null)
            {
                return BadRequest();
            }

            var mapdata = mapper.Map<Catagories, CatagoryDto>(data);
            return Ok(mapdata);
        }

        [HttpPost("Catagory")]
        public async Task<IActionResult> CreateCatagory([FromBody] CatagoryDto cata)
        {

            var Mapcata = mapper.Map<CatagoryDto, Catagories>(cata);

            await catagories.InsertModel(Mapcata);
            var check = await catagories.Save();

            if (check)
            {
                return Created(new Uri(Request.GetDisplayUrl() + "/" + new { id = Mapcata.Id }), Mapcata);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("Catagory")]
        public async Task<IActionResult> UpdateCatagory([FromBody] CatagoryDto cata)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Mapcata = mapper.Map<CatagoryDto, Catagories>(cata);

            catagories.UpdateModel(Mapcata);
            var check = await catagories.Save();

            if (check)
            {
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpPatch("Catagory/{id}")]
        public async Task<IActionResult> UpdateCatagoryPatch([FromBody] JsonPatchDocument cata, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await catagories.UpdateModelPatch(id, cata);
            var check = await catagories.Save();

            if (check)
            {
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("Catagory/{id}")]
        public async Task<IActionResult> DeleteCatagory([FromRoute] int id)
        {
            var data = await catagories.DeleteModel(id);

            if (data == false)
            {
                return BadRequest();
            }
            var check = await catagories.Save();

            if (check) { return Ok(); }
            else return BadRequest();
        }





    }
}

