namespace SpaceBattle.lib;

public class RotateCommand : ICommand
{
    IRotatable obj;
    public RotateCommand(IRotatable b)
    {
        obj = b;
    }
    public void execute()
    {
        obj.angle = obj.angle + obj.rotatespd;
    }
}