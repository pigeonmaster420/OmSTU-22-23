using Hwdtech;
using Moq;

namespace SpaceBattle.lib.test;

public class ServerThreadTest
{
    public ServerThreadTest()
    {
        new Hwdtech.Ioc.InitScopeBasedIoCImplementationCommand().Execute();
        IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();
    }
    [Fact]
    public void ServerThreadStart()
    {
        var thrd = new Mock<ServerThread>();


        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Create And Start Thread", (object[] args) => thrd.Object.Execute()).Execute();
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Send Command", (object[] args) => thrd.Object.()).Execute();
    }
}