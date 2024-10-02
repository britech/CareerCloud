using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CareerCloud.WebAPI.Filters;

public class ExampleValidationFaultSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        schema.Example = new OpenApiObject
        {
            ["title"] = new OpenApiString("Invalid inputs detected."),
            ["detail"] = new OpenApiString("Refer to the API reference to resolve the violated input rules."),
            ["status"] = new OpenApiInteger(StatusCodes.Status400BadRequest),
            ["type"] = new OpenApiString("https://atc.dev/careercloud/api-reference"),
            ["ViolatedRules"] = new OpenApiObject
            {
                ["900"] = new OpenApiString("System - Country Code is required.")
            }
        };
    }
}
