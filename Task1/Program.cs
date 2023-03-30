using System;
using System.IO;
using System.Linq;

namespace Task1
{
    public class DeleteFromDisk
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к папке:"); // Путь к папке
            Delete(Console.ReadLine());

        }
        public static void Delete(string path) // Метод удаления
        {
            TimeSpan timeSpan = TimeSpan.FromMinutes(30); // Переменная для 30 минут
            try
            {
                var di = new DirectoryInfo(path);

                if (di.Exists)
                {
                    foreach (FileInfo file in di.GetFiles()) // Для каждого файла в папке
                    {
                        
                        if ((DateTime.Now - file.CreationTime) < timeSpan) // У которого дата создания менее 30 минут
                            file.Delete(); // Удаление файла
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories()) // Для каждой папки в корневой папке
                    {
                        if ((DateTime.Now - dir.CreationTime) < timeSpan) // У которой дата создания менее 30 минут
                            dir.Delete(true); // Удалить папку и все файлы в ней
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}