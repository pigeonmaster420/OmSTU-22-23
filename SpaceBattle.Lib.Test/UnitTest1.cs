namespace SpaceBattle.Lib.Test;
using Moq;

public class UnitTest1
{
    [Fact]
    public void MoveCommandSuccessfullyExecuted()
    {
        var mock = new Mock<IMovable>();
        mock.Setup(a => a.getpos()).Returns(new System.Numerics.Vector2());
        MoveCommand move = new MoveCommand(mock.Object);

        
        
    }
}