using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");
        ScriptureLibrary library = new ScriptureLibrary();
        if (!library.LoadFromFile("scriptures.txt"))
        {
            library.AddScripture(new Scripture(new Reference("John", 3, 16),
                "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."));
            library.AddScripture(new Scripture(new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."));
            library.AddScripture(new Scripture(new Reference("1 Nephi", 3, 7),
                "I will go and do the things which the Lord hath commanded."));
        }

        bool continueMemorizing = true;
        while (continueMemorizing)
        {
            Console.Clear();
            Console.WriteLine("1. Choose a random scripture");
            Console.WriteLine("2. Choose a specific scripture");
            Console.WriteLine("3. Quit");
            Console.WriteLine("Enter your choice:");
            string choice = Console.ReadLine();
            Scripture scripture = null;

            if (choice == "1")
            {
                scripture = library.GetRandomScripture();
            }
            else if (choice == "2")
            {
                scripture = library.ChooseScripture();
            }
            else if (choice == "3")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Selecting a random scripture.");
                Thread.Sleep(2000);
                scripture = library.GetRandomScripture();
            }

            if (scripture != null)
            {
                MemorizeScripture(scripture);
            }
            else
            {
                Console.WriteLine("No scripture available. Please add scriptures first.");
                Thread.Sleep(2000);
                continue;
            }

            Console.WriteLine("Would you like to memorize another scripture? (yes/no):");
            string again = Console.ReadLine()?.ToLower();
            if (again != "yes")
            {
                continueMemorizing = false;
            }
        }
        
        library.SaveToFile("scriptures.txt");
        Console.WriteLine("Thank you for using the Scripture Memorizer Program!");
    }

    static void MemorizeScripture(Scripture scripture)
    {
        bool quit = false;
        Random random = new Random();
        
        while (!scripture.IsCompletelyHidden() && !quit)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            string input = Console.ReadLine();
            if (input?.ToLower() == "quit")
            {
                quit = true;
            }
            else
            {
                int wordsToHide = random.Next(1, 4);
                scripture.HideRandomWords(wordsToHide);
            }
        }
        
        if (!quit)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("All words are now hidden. Press enter to continue.");
            Console.ReadLine();
        }
    }
}

class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int? _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = null;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if (_endVerse.HasValue)
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}";
        }
    }
}

class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }
}

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        
        string[] wordArray = text.Split(' ');
        foreach (string wordText in wordArray)
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        
        int wordsToHide = Math.Min(count, visibleWords.Count);
        for (int i = 0; i < wordsToHide; i++)
        {
            if (visibleWords.Count == 0)
                break;
                
            int index = random.Next(0, visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public string GetDisplayText()
    {
        string wordDisplay = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()}\n{wordDisplay}";
    }
}

class ScriptureLibrary
{
    private List<Scripture> _scriptures;
    private Random _random;

    public ScriptureLibrary()
    {
        _scriptures = new List<Scripture>();
        _random = new Random();
    }

    public void AddScripture(Scripture scripture)
    {
        _scriptures.Add(scripture);
    }

    public Scripture GetRandomScripture()
    {
        if (_scriptures.Count == 0)
            return null;
            
        int index = _random.Next(0, _scriptures.Count);
        return _scriptures[index];
    }

    public Scripture ChooseScripture()
    {
        if (_scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures available.");
            return null;
        }

        Console.WriteLine("Available scriptures:");
        for (int i = 0; i < _scriptures.Count; i++)
        {
            Console.WriteLine($"{i+1}. {_scriptures[i].GetDisplayText().Split('\n')[0]}");
        }

        Console.WriteLine("Enter the number of the scripture you want to memorize:");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= _scriptures.Count)
        {
            return _scriptures[choice - 1];
        }
        else
        {
            Console.WriteLine("Invalid choice.");
            return null;
        }
    }

    public bool LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
            return false;

        try
        {
            string[] lines = File.ReadAllLines(filename);
            for (int i = 0; i < lines.Length; i += 2)
            {
                if (i + 1 >= lines.Length)
                    break;

                string referenceText = lines[i];
                string scriptureText = lines[i + 1];

                string[] referenceParts = referenceText.Split(' ');
                
                string book;
                int chapter, verse, endVerse = 0;
                bool hasEndVerse = false;
                
                if (referenceParts.Length < 2)
                    continue;
                
                string chapterVerse = referenceParts[referenceParts.Length - 1];
                book = string.Join(" ", referenceParts, 0, referenceParts.Length - 1);
                
                string[] chapterVerseParts = chapterVerse.Split(':');
                if (chapterVerseParts.Length != 2)
                    continue;
                
                if (!int.TryParse(chapterVerseParts[0], out chapter))
                    continue;
                
                string verseText = chapterVerseParts[1];
                if (verseText.Contains("-"))
                {
                    string[] verseParts = verseText.Split('-');
                    if (verseParts.Length != 2)
                        continue;
                    
                    if (!int.TryParse(verseParts[0], out verse) || !int.TryParse(verseParts[1], out endVerse))
                        continue;
                    
                    hasEndVerse = true;
                }
                else
                {
                    if (!int.TryParse(verseText, out verse))
                        continue;
                }

                Reference reference = hasEndVerse 
                    ? new Reference(book, chapter, verse, endVerse)
                    : new Reference(book, chapter, verse);
                
                Scripture scripture = new Scripture(reference, scriptureText);
                _scriptures.Add(scripture);
            }

            return _scriptures.Count > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool SaveToFile(string filename)
    {
        try
        {
            List<string> lines = new List<string>();
            foreach (Scripture scripture in _scriptures)
            {
                string[] parts = scripture.GetDisplayText().Split('\n');
                lines.Add(parts[0]); // Reference
                lines.Add(parts[1]); // Text
            }

            File.WriteAllLines(filename, lines);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}