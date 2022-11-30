namespace SpaceBattle.lib.Test;
using Moq;

public class RotateTests
{
    [Fact]
    public void PositiveRotateCommand()
    {
        var mock = new Mock<IRotatable>();
        mock.SetupProperty<rational>(m => m.angle, new rational(45));
        mock.SetupGet<rational>(m => m.rotatespd).Returns(new rational(90));
        RotateCommand rotate = new RotateCommand(mock.Object);

        rotate.execute();

        Assert.Equal(135, mock.Object.angle.a);
        Assert.Equal(1, mock.Object.angle.b);
    }
    [Fact]
    public void NegativeCantSetAngle()
    {
        var mock = new Mock<IRotatable>();
        mock.SetupProperty<rational>(m => m.angle, new rational(0));
        mock.SetupGet<rational>(m => m.rotatespd).Returns(new rational(30));
        mock.SetupSet(m => m.angle = It.IsAny<rational>()).Throws<Exception>();
        RotateCommand rotate = new RotateCommand(mock.Object);

        Assert.Throws<Exception>(() => rotate.execute());
    }
    [Fact]
    public void NegativeCantGetAngle()
    {
        var mock = new Mock<IRotatable>();
        mock.SetupProperty<rational>(m => m.angle, new rational(0));
        mock.SetupGet<rational>(m => m.rotatespd).Returns(new rational(0,1));
        mock.SetupGet(m => m.angle).Throws<Exception>();
        RotateCommand rotate = new RotateCommand(mock.Object);

        Assert.Throws<Exception>(() => rotate.execute());
    }
    [Fact]
    public void NegativeCantGetRotateSpeed()
    {
        var mock = new Mock<IRotatable>();
        mock.SetupProperty<rational>(m => m.angle, new rational(0));
        mock.SetupGet(m => m.rotatespd).Throws<Exception>();
        RotateCommand rotate = new RotateCommand(mock.Object);

        Assert.Throws<Exception>(() => rotate.execute());
    }
    [Fact]
    public void NegativeInvalidRationalNumber()
    {
        var mock = new Mock<IRotatable>();
        Assert.Throws<Exception>(() => mock.SetupProperty<rational>(m => m.angle, new rational(0,0)));
    }
}