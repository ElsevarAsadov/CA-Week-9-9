namespace PartialViewTask.Areas.Admin.Service
{
    public static class FileService
    {

        public static string saveImage(IFormFile image) {

            string filename = $"{Guid.NewGuid().ToString()}.{new FileInfo(image.FileName).Extension}";

            FileStream stream = new FileStream("C:\\Users\\Es\\source\\repos\\HomeWork\\PartialViewTask\\PartialViewTask\\wwwroot\\" + filename, FileMode.Create);


            image.CopyTo(stream);

            return filename;
        }

        public static void delete(string filename)
        {
            try
            {
                File.Delete("C:\\Users\\Es\\source\\repos\\HomeWork\\PartialViewTask\\PartialViewTask\\wwwroot\\" + filename);
            }
            catch(Exception e)
            {
                //idle
            }
        }

    }
}

