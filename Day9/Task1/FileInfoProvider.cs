using System.Security.AccessControl;
using System.Security.Principal;

namespace Task1
{
    internal class FileInfoProvider
    {
        private string filename = "sivuk.mv";
        private string filecopy = "NewDirectory\\copy_file.ms";
        public string ReceivingInfo()
        {
            var fileinfo = new FileInfo(filename);
            if (fileinfo.Exists)
            {
                return $"Размер файла: {fileinfo.Length}, дата/время создания: {fileinfo.CreationTime}";
            }
            return $"Не удалось найти файл";
        }
        public string LengthFiles(string file1, string file2)
        {
            var f1 = new FileInfo(file1);
            var f2 = new FileInfo(file2);
            if (f1.Length > f2.Length)
            {
                return $"Размер {f1.Name} больше размера {f2.Name}({f1.Length}, {f2.Length})";
            }
            else if (f1.Length < f2.Length)
            {
                return $"Размер {f2.Name} больше размера {f1.Name}({f1.Length}, {f2.Length})";
            }
            return "Они одинаковые";

        }
        public void FilePermissions()
        {
            FileInfo dirInfo = new FileInfo(filecopy);
            if (!dirInfo.Exists)
            {
                Console.WriteLine("Файл для проверки прав не найден.");
                return;
            }
            FileSecurity dirSecurity = dirInfo.GetAccessControl();
            foreach (FileSystemAccessRule rule in dirSecurity.GetAccessRules(true, true, typeof(NTAccount)))
            {
                Console.WriteLine($"{rule.IdentityReference}: {rule.FileSystemRights}");
            }
        }
    }
}