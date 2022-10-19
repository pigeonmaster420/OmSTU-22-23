using System.Numerics;
namespace SpaceBattle.lib;
public class Ship: IMovable, IRotatable
{
    public float bufangle
    {
        get;
        set;
    }
    public float angle{
        get;
        set;
    }
    public float rotatespd{
        get;
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
        bufangle = angle;
        spd = a;
        pos = p;
    }
    void checkangle(){
        if (bufangle != angle)
        {
            spd = new Vector2(Convert.ToSingle(spd.X * Math.Cos(angle) + spd.Y * Math.Sin(angle)), Convert.ToSingle(-1*spd.X*Math.Sin(angle) + spd.Y * Math.Cos(angle)));
            bufangle = angle; 
        }
    }
}
