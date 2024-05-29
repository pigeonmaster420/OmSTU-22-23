namespace SpaceGame.Lib;
using System.Collections.Concurrent;
using Hwdtech;

public class CreateAndStartServerThreadStrategy : IStrategy 
{
    public object Invoke(params object[] args)
    {

        Action action = () => { };
        int id = (int)args[0];
        if (args.Length == 2)
        {
            action = (Action)args[1];
        }
        var queue = new BlockingCollection<ICommand>();

        var register_sender_cmd = IoC.Resolve<ICommand>("Server.Register.Sender", id, new SenderAdapter(queue));

        var register_thread_cmd = IoC.Resolve<ICommand>("Server.Register.Thread", id, new ReceiverAdapter(queue));

        return new ActionCommand(() =>
        {
            register_sender_cmd.Execute();
            register_thread_cmd.Execute();
            IoC.Resolve<ConcurrentDictionary<int, ServerThread>>("Server.Thread.Map")[id].Start();
            action();
        }); 
    }
}
