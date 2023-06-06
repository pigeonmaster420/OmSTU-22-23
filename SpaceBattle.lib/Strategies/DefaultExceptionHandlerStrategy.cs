namespace SpaceBattle.Strategies;


public class DefaultExceptionHandlerStrategy : IStrategy
{
    public object Run(params object[] argv)
    {
        Exception exception = (Exception)argv[1];

        throw exception;
    }
}