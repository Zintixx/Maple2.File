namespace Maple2.File.Parser.Flat;

public class FlatBehavior {
    public string Name { get; set; }
    public string Id { get; set; }

    public string Type { get; set; }
    public string Source { get; set; }

    public List<string> Trait { get; set; } = new();
}
