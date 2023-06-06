namespace SpaceBattleTests.lib.Test.Strategies;

using Moq;

public class UuidGeneratorStrategyTests
{
    [Fact(Timeout = 1000)]
    void UuidGeneratorStrategy_GeneratesUuid()
    {
        // Init dependencies
        Container.Resolve<ICommand>(
            "Scopes.Current.Set",
            Container.Resolve<object>(
                "Scopes.New", Container.Resolve<object>("Scopes.Root")
            )
        ).Run();

        var ugs = new UuidGeneratorStrategy();

        Assert.NotEqual<string>((string)ugs.Run(), (string)ugs.Run());
    }
}