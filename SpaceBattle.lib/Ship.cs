using System.Numerics;
namespace SpaceBattle.Lib;
public class Ship: IMovable, IRotatable
{
    public float angle{
        get;
        set;
    }
    public Vector2 spd{
        get;
        set;
    }
    public Vector2 pos{
        get;
        set;
    }
    public Ship(Vector2 a, Vector2 p, float k)
    {
        angle = k;
        spd = a;
        pos = p;
    }
    public float getangle(){
        return angle;
    }
    public void setangle(float a)
    {
        angle = a;
    }
}
