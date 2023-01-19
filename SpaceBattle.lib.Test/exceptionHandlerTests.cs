namespace BattleSpace.Lib.Test;
using SpaceBattle;
using Moq;
using System.Collections.Generic;
using System;
public class Tests_exceptionHandler 
{
    [Fact]
    public Test1() 
    {
        еxceptionHandler handler = new еxceptionHandler();
        Mock<ICommand> command = new Mock<ICommand>();
        command.Setup(x => x.execute()).Throws<FileNotFoundException>().Verifiable();
        handler.Add("Key", new FileNotFoundException(), command.Object);
        Mock<IStrategy> strategy = new Mock<IStrategy>();
        strategy.Setup(x => x.execute()).Returns(command);
        try
        {
            Hwdtech.IoC.Resolve<ICommand>("Key").execute();
        }
        catch (Exception exception)
        {
            handler.Handle("Key", exception);
        }
        command.Verify();
    }
    [Fact]
    public Test2() 
    {
        еxceptionHandler handler = new еxceptionHandler();
        Mock<ICommand> command = new Mock<ICommand>();
        command.Setup(x => x.execute()).Verifiable();
        handler.AddAny(new FileNotFoundException(), command.Object);
        Mock<IStrategy> strategy = new Mock<IStrategy>();
        strategy.Setup(x => x.execute()).Returns(command);
        try
        {
            Hwdtech.IoC.Resolve<ICommand>("Any").execute();
        }
        catch (Exception exception)
        {
            handler.Handle("Any", exception);
        }
            command.Verify();
    }
    [Fact]
    public Test3() 
    {
        еxceptionHandler handler = new еxceptionHandler();
        Mock<ICommand> command = new Mock<ICommand>();
        command.Setup(x => x.execute()).Verifiable();
        handler.AddDefault("Key", command.Object);
        Mock<IStrategy> strategy = new Mock<IStrategy>();
        strategy.Setup(x => x.execute()).Returns(command);
        try
        {
            Hwdtech.IoC.Resolve<ICommand>("Key").execute();
        }
        catch (Exception exception)
        {
            handler.Handle("Key", exception);
        }
        command.Verify();
    }
    public Test4() 
    {
        еxceptionHandler handler = new еxceptionHandler();
        Mock<ICommand> command = new Mock<ICommand>();
        command.Setup(x => x.execute()).Verifiable();
        Mock<IStrategy> strategy = new Mock<IStrategy>();
        strategy.Setup(x => x.execute()).Returns(command);
        Action action = () =>
        {
            try
            {
                Hwdtech.IoC.Resolve<ICommand>("Key").execute();
            }
            catch (Exception exception)
            {
                handler.Handle("Key", exception);
            }
        };
        Assert.Throws<KeyNotFoundException>(action);
    }
    
   
}