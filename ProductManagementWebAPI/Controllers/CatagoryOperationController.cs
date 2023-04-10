using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagementWebAPI.Repositories.Class;
using Repository.Repositories.Interfaces;
using System.Threading.Tasks;

namespace ProductManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatagoryOperationController : ControllerBase
    {
        readonly ICatagoryOperation CataOp;
        public CatagoryOperationController(ICatagoryOperation cata)
        {
            CataOp = cata;
        }
        [HttpPut("Activate/{id}")]
        public async Task<IActionResult> Activation([FromRoute] int id )
        {
            bool check =  await  CataOp.ActivateAsync(id);

            if (check) { return Ok(); }
            return BadRequest();
        }

        [HttpPut("DeActivate/{id}")]
        public async Task<IActionResult> DeActivation([FromRoute] int id)
        {
           bool check = await CataOp.DeactivateAsync(id);
            if (check) { return Ok(); }
            return BadRequest();
        }

        [HttpGet("Report/{id}")]
        public async Task<IActionResult> GetReportByUser([FromRoute] int id)
        {
            var data = await CataOp.ReportAsync(id);

            return Ok(data);
        }

        [HttpGet("Report")]
        public async Task<IActionResult> GetAllReport()
        {
           var data = await CataOp.ReportAllAsync();
            return Ok(data);
        }


        [HttpPost("AddProductToCatagory/{Productid}/{CatagoryId}")]
        public async Task<IActionResult> InsertProductToCatagory([FromRoute]int Productid ,[FromRoute] int CatagoryId)
        {
          bool check = await CataOp.InsertProductInCatagoryAsync(Productid,CatagoryId);
            if (check) { return Ok(); } return BadRequest();

        }

        
    }
}
