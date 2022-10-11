using System.Numerics;
namespace SpaceBattle.Lib;

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