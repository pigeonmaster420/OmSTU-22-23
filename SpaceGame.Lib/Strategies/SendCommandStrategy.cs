namespace SpaceGame.Lib;


public class SendCommandStrategy : IStrategy
{
    public object Invoke(params object[] args)
    {
        return new SendCommand((int)args[0], (ICommand)args[1]);
    }
}
