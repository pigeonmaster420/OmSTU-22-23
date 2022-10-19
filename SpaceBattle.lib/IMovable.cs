using System.Numerics;
namespace SpaceBattle.lib;

public interface IMovable
{
    Vector2 pos{
        get;
        set;
    }
    Vector2 spd{
        get;
    }
}