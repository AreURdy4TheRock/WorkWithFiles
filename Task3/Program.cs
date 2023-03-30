using Task1;
using Task2;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к папке:");
            string filePath = Console.ReadLine(); // Вводим путь к папке
            double beforeDelete = Task2.SpaceOnDisk.Space(0, filePath); // Переменная для запоминания размера папки до удаления. Заносим в неё значение при помощи метода из Задания 2
            Console.WriteLine("Исходный размер папки: {0} байт",beforeDelete); // Выводим результат
            Task1.DeleteFromDisk.Delete(filePath); // Выполняем удаление с помощью метода из Задания 1
            double afterDelete = Task2.SpaceOnDisk.Space(0, filePath); // Переменная для запоминания размера папки после удаления. Повторно выполняем метод из задания 2
            Console.WriteLine("Освобождено: {0} байт", beforeDelete - afterDelete); // Выводим разницу что было и что стало
            Console.WriteLine("Текущий размер папки: {0} байт", afterDelete); // Выводим размер папки после удаления
        }
    }
}