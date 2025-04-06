using System;

using System.Collections.Generic;

class Comment
{
    private string _commentarName;
    private string _text;

    public Comment(string comentarName, string text)
    {
        _commentarName = comentarName;
        _text = text;
    }


    public string commentarName => _commentarName;
    public string text => _text;

}


class YouTubeVideos
{
    private string _title;
    private string _author;

    public string Title => _title;
    public string Author => _author;
    private int _lengthinSeconds;
    private List<Comment> _comments;
    public IReadOnlyList<Comment> Comments => _comments;

    public YouTubeVideos(string title, string author, int lengthInSeconds) 
    {
        _title = title;
        _author = author;
        _lengthinSeconds = lengthInSeconds;
        _comments = new List<Comment>();
    }

    public void Addcomment(Comment comment)
    {
        _comments.Add(comment);
    }


    public int GetCommentCount()
    {
        return _comments.Count;
    }



    public string GetFormattedLength()
    {
        int minutes = _lengthinSeconds / 60;
        int seconds = _lengthinSeconds %60;
        return $"{minutes:D2}:{seconds:D2}";
            
        
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        List<YouTubeVideos> videos = new List<YouTubeVideos>();

        YouTubeVideos videos1 = new YouTubeVideos("C# Tutorial", "John Doe", 3600);
        videos1.Addcomment(new Comment("james", "Great video!"));
        videos1.Addcomment(new Comment("susan", "I learned a lot!"));
        videos1.Addcomment(new Comment("mike", "Thanks for the tips!"));
        videos.Add(videos1);


        YouTubeVideos videos2 = new YouTubeVideos("Python Tutorial", "Jane Smith", 5400);
        videos2.Addcomment(new Comment("dorathy", "Very informative!"));
        videos2.Addcomment(new Comment("clinton","I've been coding for 15 years and still learned something new."));
        videos2.Addcomment(new Comment("stanley", "Can't wait for the next one!"));
        videos2.Addcomment(new Comment("blessing", "thanks for the video!"));
        videos.Add(videos2);


        YouTubeVideos videos3 = new YouTubeVideos("Building a Simple Web API with C#", "BackendDeveloper", 843);
        videos3.Addcomment(new Comment("peculiar", "this helped me connect and solve my problem."));
        videos3.Addcomment(new Comment("Ameiza", "I love the way you explain things."));
        videos3.Addcomment(new Comment("Adaugo", "I am a beginner and this was very helpful."));
        videos3.Addcomment(new Comment("Chidera", "your explanation of rest principles was excellent."));
        videos.Add(videos3);

        YouTubeVideos videos4 = new YouTubeVideos("Database Design Fundamentals", "DataArchitect", 732);
        videos4.Addcomment(new Comment("precious", "Great video! I learned a lot about normalization."));
        videos4.Addcomment(new Comment("joy", "The examples were very clear and easy to follow."));
        videos4.Addcomment(new Comment("victor", "This is the best video on database design I've seen."));
        videos.Add(videos4);
        videos4.Addcomment(new Comment("victor", "This is the best video on database design I've seen."));


        foreach (YouTubeVideos video in videos)
        {
            Console.WriteLine("==========================");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.GetFormattedLength()}");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.Comments)
            foreach (Comment innerComment in video.Comments)
            {
                Console.WriteLine($"- {innerComment.commentarName}: {innerComment.text}");
            }
        }
    }
}