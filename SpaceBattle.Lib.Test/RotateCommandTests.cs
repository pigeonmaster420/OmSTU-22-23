namespace SpaceBattle.lib.Test;
using Moq;

public class RotateTests
{
    [Fact]
    public void PositiveRotateCommand()
    {
        var mock = new Mock<IRotatable>();
        mock.SetupProperty<float>(m => m.angle, 45);
        mock.SetupGet<float>(m => m.rotatespd).Returns(90);
        RotateCommand rotate = new RotateCommand(mock.Object);

        rotate.execute();

        Assert.Equal(135, mock.Object.angle);
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