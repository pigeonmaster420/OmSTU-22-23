namespace SpaceBattle.Lib;

public class MoveCommand:ICommand{
    IMovable obj;
    public MoveCommand(IMovable a)
    {
        this.obj = a;
    }
    public void execute(){
        obj.pos = obj.pos + obj.spd;
    }
}