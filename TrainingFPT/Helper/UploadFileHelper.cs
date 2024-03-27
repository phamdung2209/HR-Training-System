namespace TrainingFPT.Helper
{
    public static class UploadFileHelper
    {
        //public static string UploadFile(IFormFile file)
        //{
        //    string uniqueFileName = null;
        //    if (file != null)
        //    {
        //        string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
        //        uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
        //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            file.CopyTo(fileStream);
        //        }
        //    }
        //    return uniqueFileName;
        //}

        public static string UploadFile(IFormFile poster)
        {
            string fileName;
            try
            {
                fileName = Common.GenerateSlug(poster.FileName);
                Console.WriteLine("fileName: " + fileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", "images", fileName);
                string extension = Path.GetExtension(poster.FileName);

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName + extension;
                string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", "images", uniqueFileName);

                var stream = new FileStream(uploadPath, FileMode.Create);
                poster.CopyToAsync(stream);

                fileName = uniqueFileName;

                //Common.GenerateSlug('path');
                // Add method Common.GenerateSlug

            }
            catch (Exception e)
            {
                fileName = e.Message.ToString();
            }

            return fileName;
        }
    }
}
