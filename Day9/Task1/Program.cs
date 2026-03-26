
namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var manager = new FileManager();
            var info = new FileInfoProvider();
            manager.CreateFile("Привет, файл!");
            Console.WriteLine("Файл создан. Его содержимое: ");
            Console.WriteLine(manager.ReadOfFile());
            Console.WriteLine("Проверка существования файла: ");
            Console.WriteLine(manager.FileExistence());
            int num = Convert.ToInt32(Console.ReadLine());
            if (num == 1)
            {
                manager.DeleteFile();
            }
            Console.WriteLine("Данные файла sivuk.mv: ");
            Console.WriteLine(info.ReceivingInfo());
            Console.WriteLine("Проверка существования копии файла: ");
            Console.WriteLine(manager.CopyFile());
            manager.CreateDirectory();
            Console.WriteLine("Файл перемещен");
            Console.WriteLine("Хотите изменить имя файла sivuk.mv? (1-да, 2- нет): ");
            int numrename = Convert.ToInt32(Console.ReadLine());
            if (numrename == 1)
            {
                manager.RenameFile();
            }
            Console.WriteLine("Введите имя файла  который хотите удалить: ");
            string filename = Console.ReadLine();
            manager.ErrorHandling(filename);
            Console.WriteLine("Сравнение размера файла sivuk.mv и copy_file.ms.");
            Console.WriteLine(info.LengthFiles("sivuk.mv", "copy_file.ms"));
            manager.TemplateDelete();
            Console.WriteLine("Удалены все файлы с расширением: *.mv");
            Console.WriteLine("Список всех файлов в заданной директории: ");
            manager.NameFileDir();
            Console.WriteLine("Попытка записи в файл с запретом на запись: ");
            manager.RecordingProhibition();
            Console.WriteLine("Проверка: какие права доступны к файлу copy_file.ms в папке NewDirectory");
            info.FilePermissions();
        }
    }
}
