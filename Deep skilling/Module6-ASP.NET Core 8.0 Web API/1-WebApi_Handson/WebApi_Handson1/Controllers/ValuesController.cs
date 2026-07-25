using Microsoft.AspNetCore.Mvc;

namespace WebApi_Handson1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new string[]
            {
                "Value1",
                "Value2",
                "Value3"
            });
        }
    }
}