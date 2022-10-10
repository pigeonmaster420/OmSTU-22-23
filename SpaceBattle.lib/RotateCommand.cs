namespace SpaceBattle.Lib;

public class RotateCommand:ICommand{
    IRotatable obj;
    float rttspd;
    RotateCommand(IRotatable a, float rotatespd)
    {
        obj = a;
        rttspd = rotatespd;
    }
    public void execute()
    {
        obj.setangle(rttspd);
    }
}