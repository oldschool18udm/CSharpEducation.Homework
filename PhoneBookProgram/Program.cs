using PhonebookLibrary;
using System.IO;

namespace PhoneBookProgram;

class Program
{
    static void Main(string[] args)
    {
        string command = "", name, phone;
        string bookfile;
        Console.Write("Укажите имя файла телефонной книжки: ");
        bookfile = Console.ReadLine();
        Phonebook phonebook = new Phonebook(bookfile);
        if (!File.Exists(bookfile))
        {
            phonebook.CreatePB();
        }
        phonebook.LoadAbonentsFromFile();
        
        while (command != "6")
        {
            Console.WriteLine(@"        Меню:
                    1. Показать Содержимое телефонной Книжки
                    2. Создать контакт 
                    3. Найти контакт по номеру телефона
                    4. Найти контакт по имени
                    5. Удалить контакт по имени
                    6. Выход из программы
                    ");
            command = Console.ReadLine();
            
            switch (command)
            {
                case "1":
                    Console.WriteLine("Содержимое телефонной Книжки:");
                    phonebook.ShowPB(phonebook.abonents);
                    break;
                case "2":
                    Console.WriteLine("Добавляем новый контакт в книжку:");
                    Console.Write("Введите имя: ");
                    name = Console.ReadLine();
                    Console.Write("Введите номер телефона: ");
                    phone = Console.ReadLine();
                    Abonent abonent1 = new Abonent(name, phone);
                    phonebook.AddItem(abonent1);
                    break;
                case "3":
                    Console.WriteLine("Поиск контакта по номеру телефона:");
                    Console.Write("Введите номер телефона: ");
                    phone = Console.ReadLine();
                    Console.WriteLine(phonebook.FindItemByPhone(phone));
                    break;
                case "4":
                    Console.WriteLine("Поиск контакта по имени");
                    Console.Write("Введите имя: ");
                    name = Console.ReadLine();
                    Console.WriteLine(phonebook.FindItemByName(name));
                    break;
                case "5":
                    Console.WriteLine("Удаление контакта по имени");
                    Console.Write("Введите имя: ");
                    name = Console.ReadLine();
                    phonebook.DeleteItem(name);
                    break;
                case "6": Console.WriteLine("Работа программы завершена"); break;
                default: Console.WriteLine("Неверная команда"); break;
            }
        }
    }
}