namespace Task1
{
    internal class FileManager
    {
        private string filename = "sivuk.mv";
        private string filecopy = "copy_file.ms";
        private string path = "C:\\Users\\Маша\\Desktop\\Учеба\\Практика\\Day9\\Task1\\bin\\Debug\\net10.0";
        public void CreateFile(string text)
        {
            File.WriteAllText(filename, text);
        }
        public string ReadOfFile()
        {
            string filetext = File.ReadAllText(filename);
            return filetext;
        }
        public string FileExistence()
        {
            if (File.Exists(filename))
            {
                return "Файл существует, хотите его удалить?(1 - да, 2 - нет)";
            }
            return "Файла не существует";
        }
        public void DeleteFile()
        {
            File.Delete(filename);
        }
        public bool CopyFile()
        {
            try
            {
                File.Copy(filename, filecopy);
            }
            catch
            {}
            bool result = File.Exists(filecopy);
            return result;
        }
        public void CreateDirectory()
        {
            try
            {
                string str = "NewDirectory";
                Directory.CreateDirectory(str);
                string destPath = Path.Combine(str, Path.GetFileName(filecopy));
                File.Move(filecopy, destPath);
            }
            catch
            {
            }
        }
        public void RenameFile()
        {
            File.Move(filename, "familiya.io");
        }
        public void ErrorHandling(string fname)
        {
            if (!File.Exists(fname))
            {
                Console.WriteLine("Файла не существует");
                return;
            }
            File.Delete(fname);
        }
        public void TemplateDelete()
        {
            string template = "*.mv";
            string[] files = Directory.GetFiles(path, template);
            foreach (string file in files)
            {
                File.Delete(file);
            }
        }
        public void NameFileDir()
        {
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                Console.WriteLine($"{file}");
            }
        }
        public void RecordingProhibition()
        {
            var fileinfo = new FileInfo(filecopy);
            fileinfo.IsReadOnly = true;
            try
            {
                File.WriteAllText(filecopy, "Привет мир");
            }
            catch
            {
                Console.WriteLine("Невозможно записать в файл");
            }
        }
    }
}
