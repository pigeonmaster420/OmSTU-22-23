namespace SpaceBattle.lib;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

public class ServerThread
{
    Thread thread;

    IReceiver queue;
    bool stop = false;
    Action strategy;

    internal void Stop() => stop = true;

    internal void HandleCommand()
    {
        var cmd = queue.Receive();
        cmd.execute();
    }
    public ServerThread(IReceiver queue)
    {
        this.queue = queue;
        strategy = () =>
        {
            HandleCommand();
        };

        thread = new Thread(() =>
        {
            while (!stop)
            strategy();
        });
    }
    public Thread getThread()
    {
        return this.thread;
    }
    internal void UpdateBehaviour(Action newBehaviour)
    {
        strategy = newBehaviour;
    }
    public void Execute()
    {
        thread.Start();
    }
}
