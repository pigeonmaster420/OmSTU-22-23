using Scriban;

namespace Server
{
    public class AdapterBuilder
    {
        private readonly string _adapterType;
        private List<Dictionary<string, object>> _membersProperties;
        private const string _mainTemplate =
@"
namespace Server
{
    public class {{ adapter_type }}Adapter: {{ adapter_type }}
    {
        private IDictionary<string, object> _obj;

        public class {{ adapter_type }}Adapter(IDictionary<string, object> obj)
        {
            _obj = obj;
        }
        {{ adapter_properties }}
    }
}
";
        private const string _propertyTemplate =
        @"
public {{ type }} {{ name }}
{
    {{ accessors }}
}";
        private const string _getAccessorTemplate = "get => ({{ get_type }})_obj[\"{{ adapter_type }}.{{ property }}\"];\n";

        private const string _setAccessorTemplate = "set => _obj[\"{{ adapter_type }}.{{ property }}\"] = value;\n";

        public AdapterBuilder(string adapterType)
        {
            _adapterType = adapterType;
            _membersProperties = new();
        }
        public AdapterBuilder AddProperty(string type, string name, bool hasGetAccessor, bool hasSetAccessor)
        {
            _membersProperties.Add(new()
            {
                {"Type", type},
                {"Name", name},
                {"HasGetAccessor", hasGetAccessor},
                {"HasSetAccessor", hasSetAccessor}
            });
            return this;
        }
        public string Build()
        {
            string propertiesCode = string.Empty;
            foreach (Dictionary<string, object> properties in _membersProperties)
            {
                string memberAccessorsCode = string.Empty;
                if ((bool)properties["HasGetAccessor"])
                {
                    Template getParsedTemplate = Template.ParseLiquid(_getAccessorTemplate);
                    string getAccessorCode = getParsedTemplate.Render(new {getType = properties["Type"], adapterType = _adapterType, property = properties["Name"]});
                    memberAccessorsCode = string.Concat(memberAccessorsCode, getAccessorCode);
                }
                if ((bool)properties["HasSetAccessor"])
                {
                    Template setParsedTemplate = Template.ParseLiquid(_setAccessorTemplate);
                    string setAccessorCode = setParsedTemplate.Render(new {adapterType = _adapterType, property = properties["Name"]});
                    memberAccessorsCode = string.Concat(memberAccessorsCode, setAccessorCode);
                }
                Template propertyParsedTemplate = Template.ParseLiquid(_propertyTemplate);
                string propertyCode = propertyParsedTemplate.Render(new {type = properties["Type"], name = properties["Name"], accessors = memberAccessorsCode});
                propertiesCode = string.Concat(propertiesCode, propertyCode);
            }
            Template mainTemplate = Template.ParseLiquid(_mainTemplate);
            string result = mainTemplate.Render(new {adapterType = _adapterType, adapterProperties = propertiesCode});
            return result;
        }
    }
}
