namespace SpaceBattle.Lib;

public class MoveCommand:ICommand{
    IMovable obj;
    public MoveCommand(IMovable a)
    {
        obj = a;
    }
    public void execute(){
        obj.setpos();
    }
}