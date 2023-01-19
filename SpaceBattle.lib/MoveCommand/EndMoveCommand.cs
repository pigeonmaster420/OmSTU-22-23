namespace SpaceBattle.lib;
using Hwdtech;
public class EndMoveCommand : ICommand
{
    public IMoveCommandEndable obj;
    public EndMoveCommand(MoveCommandEndable a)
    {
       obj = a;
    }
    public void Execute()
    {
        ICommand EndCommand = IoC.Resolve<ICommand>("Command.EmptyCommand");
        IoC.Resolve<ICommand>("Game.DeleteProperty", obj.UObject, "velocity").Execute();
        IoC.Resolve<ICommand>("Game.MyObject.GetUObj", obj).Execute();
        IoC.Resolve<ICommand>("Game.InjectCommand", obj.Queue, EndCommand).Execute();
    }
}