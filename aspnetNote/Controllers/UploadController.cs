using Microsoft.AspNetCore.Mvc;

namespace aspnetNote.Controllers
{
    public class UploadController : Controller
    {
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;

        public UploadController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _environment = environment;

        }
        [HttpPost,Route("api/upload")]
        public  async Task< IActionResult> ImageUpload(IFormFile file)
        {
            //#이미지나 파일을 업로드 할 때 필요한 구성
            //1.Path(경로) - 어디에다 저장할지 결정
            var path = Path.Combine(_environment.WebRootPath, @"images\upload");
            //2.Name(이름) - 중복되지 않게 저장하기 위해서
            //3.Extension(확장자) - 어떤 종류의 파일인지 알기 위해서
            var fileFullName = file.FileName.Split('.');
            var fileName = $"{Guid.NewGuid()}.{fileFullName[1]}";

            using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return Ok(new {file= "/images/upload/" + fileName, success = true});

            // # URL 접근 방식
            // ASP.NET - 호스트명/api/upload
            // JavaScript - 호스트명 + /api/upload => http://www.example.comapi/upload
            // JavaScript - 호스트명 + / + api/upload => http://www.example.comapi/upload
        }

    }
}
