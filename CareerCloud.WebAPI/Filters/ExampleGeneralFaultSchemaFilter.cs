using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CareerCloud.WebAPI.Filters;

public class ExampleGeneralFaultSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        schema.Example = new OpenApiObject
        {
            ["title"] = new OpenApiString("API Fault"),
            ["detail"] = new OpenApiString("Contact support for assistance"),
            ["status"] = new OpenApiInteger(StatusCodes.Status500InternalServerError),
            ["type"] = new OpenApiString("https://atc.dev/careercloud/contact-us"),
            ["ErrorMessage"] = new OpenApiString("This is an error message.")
        };
    }
}
