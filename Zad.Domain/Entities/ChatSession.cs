using Zad.Domain.Common;

namespace Zad.Domain.Entities;

public class ChatSession : BaseEntity
{
    public const int MaxNameLength = 100;

    public int UserId { get; set; }
    public string? Name { get; set; }

    public User User { get; set; } = null!;
    public ICollection<Message> Messages { get; set; } = new List<Message>();

    public void SetName(string? name)
    {
        Name = NormalizeName(name);
    }

    public bool TrySetNameFromQuestion(string question)
    {
        if (!string.IsNullOrWhiteSpace(Name))
        {
            return false;
        }

        Name = NormalizeName(question);
        return !string.IsNullOrWhiteSpace(Name);
    }

    private static string? NormalizeName(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return null;
        }

        var normalized = name.Trim();
        if (normalized.Length > MaxNameLength)
        {
            normalized = normalized[..MaxNameLength];
        }

        return normalized;
    }
}
