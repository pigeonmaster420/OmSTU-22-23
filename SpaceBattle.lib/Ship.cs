using System.Numerics;
namespace SpaceBattle.Lib;
public class Ship: IMovable, IRotatable
{
    private float angle;
    private Vector2 spd;
    private Vector2 pos;
    public Ship(Vector2 a, Vector2 p, float k)
    {
        angle = k;
        spd = a;
        pos = p;
    }
    public Vector2 getpos(){
        return pos;
    }
    public Vector2 getspd(){
        return spd;
    }
    public void setpos(){
        pos = pos + spd;
    }
    public float getangle(){
        return angle;
    }
    public void setangle(float a)
    {
        angle = a;
        spd.X = Convert.ToSingle(spd.X * Math.Cos(a) + spd.Y * Math.Sin(a));
        spd.Y = Convert.ToSingle(-spd.X * Math.Sin(a) + spd.Y * Math.Cos(a));;
    }
}
