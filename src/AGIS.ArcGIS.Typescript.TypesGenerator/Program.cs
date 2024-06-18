// See https://aka.ms/new-console-template for more information
using ArcGIS.Core.CIM;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NJsonSchema;


var contractResolver = new DefaultContractResolver
{
    NamingStrategy = new CamelCaseNamingStrategy()
};

var jsonSettings = new NJsonSchema.NewtonsoftJson.Generation.NewtonsoftJsonSchemaGeneratorSettings
{
    SerializerSettings = new JsonSerializerSettings
    {
        ContractResolver = contractResolver
    }
};


var schema = JsonSchema.FromType<CIMLayerDocument>(jsonSettings);
var schemaJson = schema.ToJson();

File.WriteAllText("layer-document.json", schemaJson);
