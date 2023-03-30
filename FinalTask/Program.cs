using System.Xml.Linq;


namespace FinalTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            CreateFolder("NewFolder"); // Создаём папку
            DistributionStudents(); // Распределяем студентов
        }

        static void CreateFolder(string nameFolder) // Метод создания новой папки
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\Гсь Гдра\Desktop");
            if (!dirInfo.Exists) // Проверяем, существует ли папка
            {
                dirInfo.Create(); // Если нет - то создаём
            }
            dirInfo.CreateSubdirectory(nameFolder); // Создаём подпапку
        }

        static void DistributionStudents() // Метод распределения студентов по группам
        {
            string filePath = @"C:\Users\Гсь Гдра\Desktop\Students.dat"; // Берём исходный файл
            List<Person> people = new List<Person>(); // Создаём список объектов для студентов
            if (File.Exists(filePath)) // Проверяем существует ли файл по указанному пути
            {
                using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open))) // Открываем поток из файла
                {
                    try
                    {


                        while (reader.BaseStream.Position < reader.BaseStream.Length) // Пока не кончится файл
                        {
                            string name = reader.ReadString();
                            string group = reader.ReadString();
                            string birth = reader.ReadString();
                            people.Add(new Person(name, group, DateTime.Parse(birth))); // Считываем студентов и записываем их в список
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    reader.Close(); // закрываем поток


                }
                foreach (Person person in people) // Для каждого студента из списка
                {
                    
                    string NewfilePath = $@"C:\Users\Гсь Гдра\Desktop\NewFolder\{person.Group}.txt"; 
                    var fileInfo = new FileInfo(NewfilePath);
                    if (!File.Exists(NewfilePath)) // Проверим, существует ли файл по данному пути с номером группы студента
                    {
                        using (StreamWriter sw = File.CreateText(NewfilePath))  
                        {
                            sw.WriteLine($"{person.Name}, {person.Birth}"); //   Если не существует - создаём и записываем студента
                            sw.Close();
                        }
                        
                    }
                    else
                    {
                        using (StreamWriter sw = new StreamWriter(NewfilePath,true)) 
                        {
                            sw.WriteLine($"{person.Name}, {person.Birth}"); // Если существует, то записываем в этот файл студента
                            sw.Close();
                        }
                    }
                    //Console.WriteLine($"Name: {person.Name} Group: {person.Group} Birthday {person.Birth}");
                }

            }

        }

        public class Person
        {
            public string Name { get; set; }
            public string Group { get; set; }
            public DateTime Birth { get; set; }
            public Person(string name, string group, DateTime birth)
            {
                Name = name;
                Group = group;
                Birth = birth;
            }
        }
    }



}