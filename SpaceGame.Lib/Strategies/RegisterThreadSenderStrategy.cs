namespace SpaceGame.Lib;
using Hwdtech;
using System.Collections.Concurrent;


public class RegisterThreadSenderStrategy : IStrategy 
{
    public object Invoke(params object[] args)
    {
        int id = (int)args[0];
        ISender sender = (ISender)args[1];
        return new ActionCommand(() =>
        {
            IoC.Resolve<ConcurrentDictionary<int, ISender>>("Server.Thread.Sender.Map")[id] = sender;
        });
    }
}
