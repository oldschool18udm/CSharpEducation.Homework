namespace PhonebookLibrary;

public class Phonebook
{
    public string path;
    public Abonent abonent;
    public int lastId = 0;

    public Phonebook(string path)
    {
        this.path = path;
        this.abonent = abonent;
        this.lastId = lastId;
        
    }

    public  void CreatePB()
    {
        // string[] lines = ["1;маша;89124567896", "2;даша;89561234578", "3;наташа;89127418526", "4;саша;89127411234"];
        using (StreamWriter sw = new StreamWriter(this.path, false))
        {
        }
        // {
        //     foreach (string line in lines)
        //     {
        //         sw.WriteLineAsync(line);
        //     }
        // }

        // this.lastId = lines.Length;
    }

    public void ShowPB()
    {
        using (StreamReader sr = new StreamReader(path))
        {
            string line = sr.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = sr.ReadLine();
            }
        }
    }

    public void AddItem(Abonent abonent)
    {
        bool find = false;
        using (StreamReader sr = new StreamReader(path))
        {
            string lineToFind = sr.ReadLine();

            while (lineToFind != null)
            {
                if (lineToFind.Split(";")[1] == abonent.name && lineToFind.Split(";")[2] == abonent.phone)
                {
                    find = true;
                    break;
                }

                lineToFind = sr.ReadLine();
            }
        }

        using (StreamWriter sw = new StreamWriter(path, true))
        {
            if (!find)
            {
                this.lastId++;
                string line = this.lastId + ";" + abonent.name + ";" + abonent.phone;
                sw.WriteLineAsync(line);
            }
            else
            {
                Console.WriteLine("Пользователь с такими данными уже существует");
            }
        }
    }

    public string FindItemByPhone(string phone)
    {
        string result = "";
        using (StreamReader sr = new StreamReader(path))
        {
            string line = sr.ReadLine();
            while (line != null)
            {
                if (line.Split(";")[2] == phone)
                {
                    result += $"\n{line.Split(";")[2]}-{line.Split(";")[1]}";
                }

                line = sr.ReadLine();
            }
        }

        if (result != "")
            return result;
        return "Не найдено пользователей с таким номером телефона";
    }
    public string FindItemByName(string name)
    {
        string result = "";
        using (StreamReader sr = new StreamReader(path))
        {
            string line = sr.ReadLine();
            while (line != null)
            {
                if (line.Split(";")[1] == name)
                {
                    result += $"\n{line.Split(";")[1]}-{line.Split(";")[2]}";
                }

                line = sr.ReadLine();
            }
        }
        if (result != "")
            return result;
        return "Не найдено пользователей с таким именем";
    }
    public  void DeleteItem(string name)
    {
        List<string>people = new List<string>();
        using (StreamReader sr = new StreamReader(path))
        {
            string line = sr.ReadLine();
            while (line != null)
            {
                people.Add(line);
                line = sr.ReadLine();
            }
        }
        using (StreamWriter sw = new StreamWriter(path, false))
        {
            foreach (var line in people)
            {
                if (line.Split(";")[1] != name)
                {
                    sw.WriteLine(line);
                }
                
            }
        }
    }
}