namespace PhonebookLibrary;

public class Phonebook
{
    public string path;
    public Abonent abonent;
    public List<Abonent> abonents = new List<Abonent>();
    private string sep = ";";

    public Phonebook(string path)
    {
        this.path = path;
        this.abonent = abonent;
        this.abonents = abonents;
    }

    public void CreatePB()
    {
        File.Create(this.path);
    }

    public void LoadAbonentsFromFile()
    {
        using (StreamReader sr = new StreamReader(path))
        {
            string line = sr.ReadLine();
            while (line != null)
            {
                string[] parts = line.Split(sep);
                abonents.Add(new Abonent(parts[0], parts[1]));
                line = sr.ReadLine();
            }
        }
    }

    public void SaveAbonentsToFile()
    {
        string line = "";
        using (StreamWriter sw = new StreamWriter(path, false))
        {
            foreach (var item in abonents)
            {
                line = $"{item.name}{sep}{item.phone}";
                sw.WriteLine(line);
            }
        }
    }

    public void ShowPB(List<Abonent> abonent)
    {
        foreach (Abonent item in abonents)
        {
            Console.WriteLine($"{item.name} - {item.phone}");
        }
    }

    public void AddItem(Abonent abonent)
    {
        List<Abonent> temp = abonents.FindAll(item => item.name == abonent.name);
        if (temp.Count == 0)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                string line = abonent.name + sep + abonent.phone;
                sw.WriteLineAsync(line);
                abonents.Add(abonent);
            }
        }
        else
        {
            Console.WriteLine("Пользователь с такими данными уже существует");
        }
    }


    public string FindItemByPhone(string phone)
    {
        string result = "";
        List<Abonent> temp = abonents.FindAll(item => item.phone == phone);
        if (temp.Count == 0)
            return "Не найдено пользователей с таким номером телефона";
        foreach (Abonent item in temp)
        {
            result += $"{item.name} - {item.phone}\n";
        }

        return result;
    }

    public string FindItemByName(string name)
    {
        string result = "";
        List<Abonent> temp = abonents.FindAll(item => item.name == name);
        if (temp.Count == 0)
            return "Не найдено пользователей с таким имененм";
        foreach (Abonent item in temp)
        {
            result += $"{item.name} - {item.phone}\n";
        }

        return result;
    }

    public void DeleteItem(string name)
    {
        abonents.Remove(abonents.Find(x => x.name == name));
        SaveAbonentsToFile();
    }
}