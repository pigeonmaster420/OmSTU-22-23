namespace SpaceBattle.lib;

public interface IFuelable
{
    int Level { get; set; }

    int BurnSpeed { get; }
}
