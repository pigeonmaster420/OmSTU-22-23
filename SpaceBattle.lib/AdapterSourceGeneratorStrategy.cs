using System.Reflection;

namespace Server
{
    public class AdapterSourceGeneratorStrategy: IStrategy
    {
        public object Execute(params object[] args)
        {
            Type adapterType = (Type)args[0];
            AdapterBuilder builder = Hwdtech.IoC.Resolve<AdapterBuilder>("Adapter.Builder.Get", adapterType);
            foreach (MemberInfo member in adapterType.GetMembers())
            {
                if (member.MemberType == MemberTypes.Property)
                {
                    PropertyInfo property = (PropertyInfo)member;
                    Dictionary<string, bool> hasAccessors = new(){{"get", false}, {"set", false}};
                    foreach (MethodInfo accessor in property.GetAccessors())
                    {
                        hasAccessors.Where(type => accessor.Name.StartsWith(type.Key)).Select(x => x.Key).ToList().ForEach(key => hasAccessors[key] = true);
                    }
                    builder.AddProperty(property.PropertyType.ToString(), property.Name, hasAccessors["get"], hasAccessors["set"]);
                }
            }
            string code = builder.Build();
            return code;
        }
    }
}
