namespace SpaceBattle.lib.Strategies;

public class EmptyObjectCreateStrategy : IStrategy
{
    public object Run(params object[] argv)
    {
        return new Dictionary<string, object>();
    }
}