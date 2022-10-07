namespace SpaceBattle.lib;

public class MoveCommand:ICommand{
    
    public void execute(IMovable obj){
        obj.setpos();
    }
}