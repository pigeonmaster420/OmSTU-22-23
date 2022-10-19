namespace SpaceBattle.lib.Test;
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
public class RotateTests
{
    [Fact]
    public void PositiveRotateCommand()
    {
        var mock = new Mock<IRotatable>();
        mock.SetupProperty<float>(m => m.angle, 0);
        mock.SetupGet<float>(m => m.rotatespd).Returns(30);
        RotateCommand rotate = new RotateCommand(mock.Object);

        rotate.execute();

        Assert.Equal(30,mock.Object.angle);
    }
    [Fact]
    public void NegativeCantSetAngle()
    {
        var mock = new Mock<IRotatable>();
        mock.SetupProperty<float>(m => m.angle, 0);
        mock.SetupGet<float>(m => m.rotatespd).Returns(30);
        mock.SetupSet(m => m.angle = It.IsAny<float>()).Throws<Exception>();
        RotateCommand rotate = new RotateCommand(mock.Object);

        Assert.Throws<Exception>(() => rotate.execute());
    }
    [Fact]
    public void NegativeCantGetAngle()
    {
        var mock = new Mock<IRotatable>();
        mock.SetupProperty<float>(m => m.angle, 0);
        mock.SetupGet<float>(m => m.rotatespd).Returns(30);
        mock.SetupGet(m => m.angle).Throws<Exception>();
        RotateCommand rotate = new RotateCommand(mock.Object);

        Assert.Throws<Exception>(() => rotate.execute());
    }
    [Fact]
    public void NegativeCantGetRotateSpeed()
    {
        var mock = new Mock<IRotatable>();
        mock.SetupProperty<float>(m => m.angle, 0);
        mock.SetupGet(m => m.rotatespd).Throws<Exception>();
        RotateCommand rotate = new RotateCommand(mock.Object);

        Assert.Throws<Exception>(() => rotate.execute());
    }
}