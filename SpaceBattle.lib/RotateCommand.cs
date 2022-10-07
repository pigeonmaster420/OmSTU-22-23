namespace SpaceBattle.lib

public class RotateCommand:ICommand{
    void execute(IRotatable obj)
    {
        obj.setangle();
    }
}