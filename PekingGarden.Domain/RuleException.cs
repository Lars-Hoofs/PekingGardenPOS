namespace PekingGarden.Domain;

public class RuleException : Exception
{
    public RuleException(string message) : base(message)
    {
    }
}