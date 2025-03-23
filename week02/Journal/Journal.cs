
public class Journal
{
    public List<Entry> _entries{get; set;}
    private _PromptGenerator _promptGenerator;
    private object _promptText;
    private object _entryText;
    private object _date;

    public Journal()
    {
        _entries = new List<Entry>();
        _promptGenerator = new _PromptGenerator();
    }

    public void AddEntry(Entry newEntry)
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {_promptText}");

        Console.Write(">");
        string response = Console.ReadLine();

        string date = DateTime.Now.ToShortDateString();

        Entry AddEntry = new Entry(prompt, response, date);
        _entries.Add(newEntry);
        Console.WriteLine("your entry has been added to the journal !");
    }

    private string GetRandomPrompt()
    {
        throw new NotImplementedException();
    }

    // Display all entries
    public void Display()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("journal is empty.add some entries first");
            return;
        }

        Console.WriteLine("\n=====Journal Entries =====");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
  
    }

     
    public void SaveToFile(string filename)
    {
        Console.Write("Enter filename to save journal: ");
        string file = Console.ReadLine();

         try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine(entry.ConvertToString());
                }
            }
            
            Console.WriteLine($"Journal saved to {filename} successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }


        public void LoadFromFile()
    {
        Console.Write("Enter filename to load journal from: ");
        string filename = Console.ReadLine();
        
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found!");
                return;
            }
            
            // Clear current entries
            _entries.Clear();
            
            // Read all lines from the file
            string[] lines = File.ReadAllLines(filename);
            
            foreach (string line in lines)
            {
                Entry entry = Entry.CreateFromString(line);
                _entries.Add(entry);
            }
            
            Console.WriteLine($"Journal loaded from {filename} successfully! {_entries.Count} entries found.");
        
        else
        {
            Console.WriteLine($"Error loading journal.");
        }
            
    }
   
}

    private class _PromptGenerator
    {
        public _PromptGenerator()
        {
        }
    }
}


