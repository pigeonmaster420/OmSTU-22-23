namespace SpaceBattle.Strategies;

using System.Diagnostics;


public class QuantumServerBehaviourStrategy : IStrategy
{
    public object Run(params object[] argv)
    {
        IPullable<ICommand> tasks = (IPullable<ICommand>)argv[0];

        // Millisecs
        long quantum = Container.Resolve<long>("Workers.Behaviour.Time.Quantum.Ms");

        var timer = new Stopwatch();

        timer.Start();

        while (timer.ElapsedMilliseconds < quantum)
        {
            ICommand cmd = tasks.Pull();
            try
            {
                cmd.Run();
            }
            catch (Exception e)
            {
                Container.Resolve<IStrategy>("Exception.Handle").Run(cmd, e);
            }
        }
        timer.Stop();

        return 0;
    }
}