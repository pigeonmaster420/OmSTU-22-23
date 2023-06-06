namespace SpaceBattle.lib.Strategies;

public class UuidGeneratorStrategy : IStrategy
{
    public object Run(params object[] argv)
    {
        return Guid.NewGuid().ToString();
    }
}
