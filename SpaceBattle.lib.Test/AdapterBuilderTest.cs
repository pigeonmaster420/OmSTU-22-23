using Server;
using Moq;
using static UnitTests.IoCTestHelper;

namespace UnitTests
{
    public class AdapterBuilderTest
    {
        private const string ExpectedIRotatableAdapterCode =
@"
namespace Server
{
    public class IRotatableAdapter: IRotatable
    {
        private IDictionary<string, object> _obj;

        public class IRotatableAdapter(IDictionary<string, object> obj)
        {
            _obj = obj;
        }
        
        public Fractional Angle
        {
            get => (Fractional)_obj[""IRotatable.Angle""];
            set => _obj[""IRotatable.Angle""] = value;
        
        }
        public Fractional AngleVelocity
        {
            get => (Fractional)_obj[""IRotatable.AngleVelocity""];
        
        }
    }
}
";
        [Fact]
        public void Successful_IRotatable_Adapter_Code_Build()
        {
            AdapterBuilder builder = new(typeof(IRotatable).Name);
            builder.AddProperty("Fractional", "Angle", true, true).AddProperty("Fractional", "AngleVelocity", true, false);

            string code = builder.Build();

            Assert.Equal(ExpectedIRotatableAdapterCode, code);
        }
    }
    public class AdapterBuilderStrategyTest
    {
        private const string ExpectedIRotatableAdapterCode =
@"
namespace Server
{
    public class IRotatableAdapter: IRotatable
    {
        private IDictionary<string, object> _obj;

        public class IRotatableAdapter(IDictionary<string, object> obj)
        {
            _obj = obj;
        }
        
        public Server.Fractional Angle
        {
            get => (Server.Fractional)_obj[""IRotatable.Angle""];
            set => _obj[""IRotatable.Angle""] = value;
        
        }
        public Server.Fractional AngleVelocity
        {
            get => (Server.Fractional)_obj[""IRotatable.AngleVelocity""];
        
        }
    }
}
";
        [Fact]
        public void Successful_IRotatable_Adapter_Build_Strategy_Execution()
        {
            CreateNewScope();
            Hwdtech.IoC.Resolve<Hwdtech.ICommand>(RegisterStrategy, "Adapter.Builder.Get", (object[] args) => new AdapterBuilder(((Type)args[0]).Name)).Execute();
            
            string code = (string)new AdapterSourceGeneratorStrategy().Execute(typeof(IRotatable));

            Assert.Equal(ExpectedIRotatableAdapterCode, code);
        }
    }
}
