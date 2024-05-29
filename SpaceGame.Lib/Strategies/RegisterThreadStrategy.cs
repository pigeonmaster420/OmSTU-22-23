namespace SpaceGame.Lib;
using Hwdtech;
using System.Collections.Concurrent;


public class RegisterThreadStrategy : IStrategy 
{
    public object Invoke(params object[] args)
    {
        int id = (int)args[0];
        IReceiver receiver = (IReceiver)args[1];
        return new ActionCommand(() =>
        {
            IoC.Resolve<ConcurrentDictionary<int, ServerThread>>("Server.Thread.Map")[id] = new ServerThread(receiver);
        });
    }
}
