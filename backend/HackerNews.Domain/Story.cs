namespace HackerNews.Domain
{
    public class Story
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Url { get; set; }
        public string By { get; set; } = string.Empty;
        public int Score { get; set; }
        public long Time { get; set; }
    }
}
