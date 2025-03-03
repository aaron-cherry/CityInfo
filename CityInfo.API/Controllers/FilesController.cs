using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _fileContentTypeProvider;

        public FilesController(FileExtensionContentTypeProvider fileContentTypeProvider)
        {
            _fileContentTypeProvider = fileContentTypeProvider ?? throw new System.ArgumentNullException(nameof(FileExtensionContentTypeProvider));
        }

        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {
            var pathToFile = "John_Martin_-_Joshua_Commanding_the_Sun_to_Stand_Still.jpg";

            if (!System.IO.File.Exists(pathToFile))
            {
                return NotFound();
            }

            if (!_fileContentTypeProvider.TryGetContentType(pathToFile, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = System.IO.File.ReadAllBytes(pathToFile);
            return File(bytes, contentType, Path.GetFileName(pathToFile));
        }

        [HttpPost]
        public async Task<ActionResult> CreateFile(IFormFile file)
        {
            Console.WriteLine("start");
            if (file.Length == 0 || file.Length > 20971520 || file.ContentType != "application/pdf")
            {
                return BadRequest("No file or invalid file has been inputted");
            }
            Console.WriteLine("isvalid check");

            //WARNING BAD PRACTICE - JUST FOR FILE CREATION DEMONSTRATION ONLY - SECURITY VULNERABILITY
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"uploaded_file_{Guid.NewGuid()}.pdf");

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            Console.WriteLine("After upload to path");

            return Ok("File upload succesful");
        }
    }
}
