using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to Bake Bread", "Chef Anna", 420);
        video1.AddComment(new Comment("John", "This was really helpful!"));
        video1.AddComment(new Comment("Sara", "Tried it and loved it!"));
        video1.AddComment(new Comment("Mike", "Can you do sourdough next?"));
        videos.Add(video1);

        Video video2 = new Video("10 Minute Yoga", "Yoga with Alex", 600);
        video2.AddComment(new Comment("Emma", "Perfect start to my day."));
        video2.AddComment(new Comment("Jake", "Great instructions, thanks!"));
        video2.AddComment(new Comment("Lily", "Loved it!"));
        videos.Add(video2);

        Video video3 = new Video("Beginner's Guitar Lesson", "Tom Strings", 900);
        video3.AddComment(new Comment("Chris", "I finally learned a song!"));
        video3.AddComment(new Comment("Nina", "Awesome teaching style."));
        video3.AddComment(new Comment("Leo", "Subscribed instantly."));
        videos.Add(video3);

        Video video4 = new Video("Top 5 Coding Tips", "CodeMaster", 480);
        video4.AddComment(new Comment("Zoe", "Tip #3 saved me hours."));
        video4.AddComment(new Comment("Dan", "Very practical tips."));
        video4.AddComment(new Comment("Kate", "Do a version for Python!"));
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length (sec): {video.Length}");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}
