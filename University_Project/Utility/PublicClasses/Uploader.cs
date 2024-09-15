namespace University_Project.Utility.PublicClasses
{
    public class Uploader
    {
        private readonly IWebHostEnvironment _env;
        public Uploader(IWebHostEnvironment env)
        {
            _env = env;
        }
        public string? UploadFile(IFormFile? file, string folder)
        {
            if (file == null) return null;
            var uploadsRootFolder = Path.Combine(_env.WebRootPath, folder);
            if (!Directory.Exists(uploadsRootFolder))
            {
                Directory.CreateDirectory(uploadsRootFolder);
            }
            if (file == null || file.Length == 0) return null;
            string fileName = Guid.NewGuid().ToString()+file.FileName;
            var filePath = Path.Combine(uploadsRootFolder, fileName);
            using(var filestream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(filestream);
            }
            return filePath;
        }
    }
}
