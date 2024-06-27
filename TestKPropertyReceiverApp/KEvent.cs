namespace TestKPropertyReceiverApp;

public class KEvent
{
    public int Id { get; set; }
    public string Message { get; set; }
    public DateTime GenerationTimestamp { get; set; }
    public DateTime SourceTimestamp { get; set; }
    public DateTime ReactionTimestamp { get; set; }
    public int Priority { get; set; }
    public int StateNum { get; set; }
    public int StatusNum { get; set; }
    public string Source { get; set; }
    public bool Acked { get; set; }
    public string User { get; set; }
    public string? AckDescription { get; set; }
}