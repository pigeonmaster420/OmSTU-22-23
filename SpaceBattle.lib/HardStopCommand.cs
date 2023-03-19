namespace SpaceBattle.lib;

class ThreadStopCommand : ICommand
{
    ServerThread stoppingThread;
    public ThreadStopCommand(ServerThread stoppingThread) => this.stoppingThread = stoppingThread;

    public void execute()
    {
        if (Thread.CurrentThread == stoppingThread.getThread())
        {
            stoppingThread.Stop();
        }
        else
        {
            throw new Exception();
        }
    }
}