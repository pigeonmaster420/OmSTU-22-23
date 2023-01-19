using Hwdtech;
using Hwdtech.Ioc;
using System.Numerics;
using Moq;

namespace SpaceBattle.lib.Test;
    public class StartMoveCommandTest {
        public StartMoveCommandTest() {
            new InitScopeBasedIoCImplementationCommand().Execute();

            Hwdtech.IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", Hwdtech.IoC.Resolve<object>("Scopes.New", Hwdtech.IoC.Resolve<object>("Scopes.Root"))).Execute();

            var MCommand = new Mock<ICommand>();
            MCommand.Setup(m => m.execute());
            var RStrategy = new Mock<IStrategy>();
            RStrategy.Setup(m => m.executeStrategy(It.IsAny<object[]>())).Returns(MCommand.Object);

            Hwdtech.IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Object.SetProperty", (object[] args) => RStrategy.Object.executeStrategy(args)).Execute();
            Hwdtech.IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Command.Move", (object[] args) => RStrategy.Object.executeStrategy(args)).Execute();
            Hwdtech.IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Queue.Push", (object[] args) => RStrategy.Object.executeStrategy(args)).Execute();
        }

        [Fact]
        public void StartMoveCommandPosition() {
            var move_startable = new Mock<IMoveCommandStartable>();

            move_startable.SetupGet(m => m.velocity).Returns(new Vector2(1, 1)).Verifiable();
            move_startable.SetupGet(m => m.uObject).Returns(new Mock<IUObject>().Object).Verifiable();
            move_startable.SetupGet(m => m.queue).Returns(new Mock<Queue<ICommand>>().Object).Verifiable();
            ICommand startMoveCommand = new StartMoveCommand(move_startable.Object);
            startMoveCommand.execute();
            move_startable.Verify();
        }

        [Fact]
        public void StartMoveCommandUnreadableQueue() {
            var move_startable = new Mock<IMoveCommandStartable>();

            move_startable.SetupGet(m => m.velocity).Returns(new Vector2(1, 1)).Verifiable();
            move_startable.SetupGet(m => m.uObject).Returns(new Mock<IUObject>().Object).Verifiable();
            move_startable.SetupGet(m => m.queue).Throws(new Exception()).Verifiable();
            ICommand startMoveCommand = new StartMoveCommand(move_startable.Object);
            Assert.Throws<Exception>(() => startMoveCommand.execute());
        }
        
        [Fact]
        public void StartMoveCommandUnreadableObject() {
            var move_startable = new Mock<IMoveCommandStartable>();

            move_startable.SetupGet(m => m.velocity).Returns(new Vector2(1, 1)).Verifiable();
            move_startable.SetupGet(m => m.uObject).Throws(new Exception()).Verifiable();
            move_startable.SetupGet(m => m.queue).Returns(new Mock<Queue<ICommand>>().Object).Verifiable();
            ICommand startMoveCommand = new StartMoveCommand(move_startable.Object);
            Assert.Throws<Exception>(() => startMoveCommand.execute());
        }

        [Fact]
        public void StartMoveCommandUnreadableVelocity() {
            var move_startable = new Mock<IMoveCommandStartable>();

            move_startable.SetupGet(m => m.velocity).Throws(new Exception()).Verifiable();
            move_startable.SetupGet(m => m.uObject).Returns(new Mock<IUObject>().Object).Verifiable();
            move_startable.SetupGet(m => m.queue).Returns(new Mock<Queue<ICommand>>().Object).Verifiable();
            ICommand startMoveCommand = new StartMoveCommand(move_startable.Object);
            Assert.Throws<Exception>(() => startMoveCommand.execute());
        }
    }