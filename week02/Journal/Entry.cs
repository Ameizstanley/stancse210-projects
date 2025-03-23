
public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public Entry(string Prompt, string Response,string Date)
    {
        Prompt = _promptText;
        Response = _entryText;
        Date = _date;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Response: {_entryText}");
        Console.WriteLine(); 

    }

    public string ConvertToString()
    {
        return $"{_date}~|~{_promptText}~|~{_entryText}";
    }

    

    public static Entry CreateFromString(string entryString)
    {
        string[] parts = entryString.Split("~|~");


        if (parts.Length >= 3)
        {
            string _date = parts[0];
            string _promptText = parts[1];
            string _entryText = parts[2];
            
            return new Entry(_promptText, _entryText, _date);
        }
        
        // Return a default entry if the string format is incorrect
        return new Entry("Invalid Entry", "This entry could not be loaded correctly", DateTime.Now.ToShortDateString());
    }
  
}
