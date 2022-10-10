using System.Numerics;
namespace SpaceBattle.Lib;

public interface IMovable
{
    Vector2 getpos();
    Vector2 getspd();
    void setpos();
}