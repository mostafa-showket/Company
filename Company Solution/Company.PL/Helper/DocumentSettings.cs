namespace Company.PL.Helper
{
    public static class DocumentSettings
    {
        // 1. Upload
        public static string Upload(IFormFile file, string folderName)
        {
            // 1. Get Location of Folder
            //string folderPath = $"C:\\Users\\mosta\\work\\Company\\Company Solution\\Company.PL\\wwwroot\\files\\images\\{folderName}";
            //string folderPath = Directory.GetCurrentDirectory() + $"\\wwwroot\\files\\images\\{folderName}";
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), $"\\wwwroot\\files\\images\\{folderName}");

            // 2. Get File Name and Make it Unique
            string fileName = $"{Guid.NewGuid()}{file.FileName}";

            // 3. Get File Path : FolderPath + FileName
            string filePath = Path.Combine(folderPath, fileName);

            // 4. File stream : Data Per Second
            using var fileStream = new FileStream(filePath, FileMode.Create);

            file.CopyTo(fileStream);

            return fileName;
        }

        // 2. Delete
        public static void Delete(string fileName, string folderName)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), $"\\wwwroot\\files\\images\\{folderName}", fileName);

            if (File.Exists(filePath)) File.Delete(filePath);
        }
    }
}
