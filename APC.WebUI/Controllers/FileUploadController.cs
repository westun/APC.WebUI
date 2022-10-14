using Microsoft.AspNetCore.Mvc;

namespace APC.WebUI.Controllers
{
    [Route("api/fileupload")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetList()
        {
            var list = new List<string>() { "One", "TWO", "3", "FOUR!" };

            return this.Ok(list);
        }
    }

}
