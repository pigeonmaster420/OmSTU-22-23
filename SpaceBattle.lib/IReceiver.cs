namespace SpaceBattle.lib;

public interface IReceiver
{
    ICommand Receive();
    bool IsEmpty();
}