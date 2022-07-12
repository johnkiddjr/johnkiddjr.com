//using Infrastructure.Contexts;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System.Linq;

//namespace API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class TestController : ControllerBase
//    {
//        private readonly MainSiteContext context;

//        public TestController(MainSiteContext context)
//        {
//            this.context = context;
//        }

//        [HttpPost]
//        public IActionResult UploadResume(IFormFile resume)
//        {
//            if (resume != null && resume.Length > 0)
//            {
//                using var fStream = resume.OpenReadStream();
//                byte[] bytes = new byte[fStream.Length];
//                fStream.Read(bytes, 0, (int)fStream.Length);

//                if (context.Files is not null && context.Files.Any())
//                {
//                    var file = context.Files.Where(x => x.FileId == Guid.Parse("7F5C1A59-2E32-4D85-841E-3BAFE737B39D")).FirstOrDefault();

//                    if (file is not null)
//                    {
//                        file.FileName = resume.FileName;
//                        file.FileData = bytes.ToArray();

//                        context.SaveChanges();

//                        return Ok("uploaded");
//                    }
//                }
//            }

//            return Ok();
//        }
//    }
//}
