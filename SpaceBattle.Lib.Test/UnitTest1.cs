namespace SpaceBattle.Lib.Test;
using Moq;

public class MoveTests
{
    [Fact]
    public void PositiveMoveCommand()
    {
        var mock = new Mock<IMovable>();
        mock.SetupProperty(m => m.pos, new System.Numerics.Vector2(0,0));
        mock.SetupGet<System.Numerics.Vector2>(m => m.spd).Returns(new System.Numerics.Vector2(1,1));
        MoveCommand move = new MoveCommand(mock.Object);
        
        move.execute();

        Assert.Equal(new System.Numerics.Vector2(1,1), mock.Object.pos);
    }
    [Fact]
    public void NegativeCantGetPos()
    {
        var mock = new Mock<IMovable>();
        mock.SetupProperty(m => m.pos, new System.Numerics.Vector2(0,0));
        mock.SetupGet<System.Numerics.Vector2>(m => m.spd).Returns(new System.Numerics.Vector2(1,1));
        mock.SetupGet(m => m.pos).Throws<Exception>();
        MoveCommand move = new MoveCommand(mock.Object);

        Assert.Throws<Exception>(() => move.execute());
    }
    [Fact]
    public void NegativeCantSetPos()
    {
        var mock = new Mock<IMovable>();
        mock.SetupProperty(m => m.pos, new System.Numerics.Vector2(0,0));
        mock.SetupGet<System.Numerics.Vector2>(m => m.spd).Returns(new System.Numerics.Vector2(1,1));
        mock.SetupSet(m => m.pos = It.IsAny<System.Numerics.Vector2>()).Throws<Exception>();
        MoveCommand move = new MoveCommand(mock.Object);

        Assert.Throws<Exception>(() => move.execute());

    }
    [Fact]
    public void NegativeCantGetSpd()
    {
        var mock = new Mock<IMovable>();
        mock.SetupProperty(m => m.pos, new System.Numerics.Vector2(0,0));
        mock.SetupGet<System.Numerics.Vector2>(m => m.pos).Returns(new System.Numerics.Vector2(0,0));
        mock.SetupGet(m => m.spd).Throws<Exception>();
        MoveCommand move = new MoveCommand(mock.Object);

        Assert.Throws<Exception>(() => move.execute());
    }
}