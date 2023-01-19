namespace BattleSpace.Lib.Test;
using Hwdtech;
public class Tests_decision_trees {
    Mock<IStrategy> tree_CreateStrategy = new Mock<IStrategy>();
    public decision_trees_CreationTests() {
        new InitScopeBasedIoCImplementationCommand().Execute();
        IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Gane.Tree.Build", (object[] args) => tree_CreateStrategy.Object.Execute(args)).Execute();
    }
    [Fact]
    public void PosTests_decision_trees() {
        string path = @"../../../../SpaceBattle.Lib/Data/data.txt";
     
        tree_CreateStrategy.SetupGet(a => a.Execute(It.IsAny<object[]>())).Returns(new Dictionary<int, object>()).Verifiable();
        var tree = new decision_trees (path);
        tree.Execute();
        tree_CreateStrategy.Verify();
    }

    [Fact]
    public void File_Not_Found_Exception() {
        var path = @"../../../../not_existed.txt";

        tree_CreateStrategy.Setup(a => a.Execute(It.IsAny<object[]>())).Returns(new Dictionary<int, object>()).Verifiable();
        var treeStrategy = new decision_trees (path);
        Assert .Throws<File_Not_Found_Exception>(() => treeStrategy.Execute());
        tree_CreateStrategy.Verify();
    }
}