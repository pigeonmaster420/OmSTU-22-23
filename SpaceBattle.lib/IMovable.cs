using System.Numerics;
namespace SpaceBattle.lib;

public interface IMovable
{
    Vector2 getpos();
    Vector2 getspd();
    void setpos();
}