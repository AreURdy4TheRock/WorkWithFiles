using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Task2
{
    public class SpaceOnDisk
    {
        public static void Main()
        {
            Console.WriteLine("Введите путь к папке:");
            string filePath = Console.ReadLine(); // Путь к папке
            double answer = Space(0, filePath); // Счётчик размера папки
            Console.WriteLine(answer);
        }
        public static double Space(double size, string filePath) // Метод подсчёта размера папки
        {
            double size1 = size; // Аккамулятор (переменная для подсчёта размера)
            var di = new DirectoryInfo(filePath);  
            try 
            {
                if (di.Exists)
                {
                    foreach (FileInfo file in di.GetFiles()) // Берём каждый файл из папки
                    {
                        size1 += file.Length; // Увеличить аккамулятор на величину файла
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories()) // Берём каждую папку
                    {
                        string path = dir.FullName; // Запоминаем её путь
                        size1 += Space(size, path); // Рекурсивно подсчитываем размер этой папки и суммируем в аккамулятор
                    }

                }
            } 
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return size1;
        }
    }
}