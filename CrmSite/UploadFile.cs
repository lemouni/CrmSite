using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace CrmSite
{
    public class UploadFile
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UploadFile(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public string Upload(IFormFile file)
        {
            if (file == null) return "";
            var path = _webHostEnvironment.WebRootPath + "\\images\\teacher\\" +file.FileName;
            using var f = System.IO.File.Create(path);
            file.CopyTo(f);


            return file.FileName;
        }
        public string uploadVideo(IFormFile file)
        {
            if (file == null) return "";
            var path = _webHostEnvironment.WebRootPath + "\\videos\\course\\" + file.FileName;
            using var f = System.IO.File.Create(path);
            file.CopyTo(f);

            path = path.Split("wwwroot")[1];

            return path;
        }
    }
}
