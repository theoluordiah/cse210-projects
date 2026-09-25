using System;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("How to Bake Sourdough Bread", "Baking with Sam", 842);
        video1.AddComment(new Comment("Mia", "This recipe changed my life, my loaves come out perfect every time."));
        video1.AddComment(new Comment("Leo", "Could you do a gluten-free version?"));
        video1.AddComment(new Comment("Ava", "I love the tip about the Dutch oven."));
        video1.AddComment(new Comment("Noah", "My starter finally worked thanks to you!"));

        Video video2 = new Video("10 Minute Full Body Workout", "Fit With Riley", 605);
        video2.AddComment(new Comment("Liam", "Great cardio session, I was sweating by minute 3."));
        video2.AddComment(new Comment("Emma", "The modifications made this accessible for me."));
        video2.AddComment(new Comment("Oliver", "Day 5 of doing this every morning."));

        Video video3 = new Video("Top 5 Budget Travel Tips", "Wanderlust Diaries", 1247);
        video3.AddComment(new Comment("Sophia", "Number 3 saved me so much money in Europe."));
        video3.AddComment(new Comment("James", "Can you do a guide for Southeast Asia next?"));
        video3.AddComment(new Comment("Isabella", "Flying midweek is the best hack."));

        Video video4 = new Video("How to Create a Vegetable Garden", "Green Thumb", 1832);
        video4.AddComment(new Comment("Lucas", "My tomatoes are thriving this year."));
        video4.AddComment(new Comment("Amelia", "Great advice for beginners."));
        video4.AddComment(new Comment("Henry", "When is the best time to plant peas?"));

        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthSeconds()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.GetName()}: {comment.GetText()}");
            }
            Console.WriteLine();
        }
    }
}