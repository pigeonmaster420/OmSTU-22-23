namespace SpaceBattle.lib;

class UpdateBehaviourCommand : ICommand
{
    Action behaviour;
    ServerThread thread;

    public UpdateBehaviourCommand(ServerThread thread, Action newBehaviour)
    {
        this.behaviour = newBehaviour;
        this.thread = thread;
    }
    public void execute()
    {
        thread.UpdateBehaviour(this.behaviour);
    }
}