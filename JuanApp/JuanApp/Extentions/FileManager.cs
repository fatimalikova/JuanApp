namespace JuanApp.Extentions
{
    public static class FileManager
    {
        public static string SaveFile(IFormFile file, string rootPath)
        {
            if (file == null || file.Length == 0)
                return null;
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(rootPath, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return fileName;
        }
        public static void DeleteFile(string fileName, string rootPath)
        {
            if (string.IsNullOrEmpty(fileName))
                return;
            var filePath = Path.Combine(rootPath, fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
