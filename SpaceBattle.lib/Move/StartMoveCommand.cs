namespace SpaceBattle.lib;

public class StartMoveCommand : ICommand {
    private IMoveCommandStartable startCommand;

    public StartMoveCommand(IMoveCommandStartable startCommand) {
        this.startCommand = startCommand;
    }
    
    public void execute() {
        Hwdtech.IoC.Resolve<ICommand>("Object.SetProperty", startCommand.uObject, "velocity", startCommand.velocity).execute();
        var moveCommand = Hwdtech.IoC.Resolve<ICommand>("Command.Move", startCommand.uObject);
        Hwdtech.IoC.Resolve<ICommand>("Queue.Push", startCommand.queue, moveCommand).execute();
    }
}