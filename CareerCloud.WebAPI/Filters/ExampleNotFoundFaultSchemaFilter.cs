using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CareerCloud.WebAPI.Filters;

public class ExampleNotFoundFaultSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        schema.Example = new OpenApiObject
        {
            ["type"] = new OpenApiString("https://tools.ietf.org/html/rfc9110#section-15.5.5"),
            ["title"] = new OpenApiString("Not Found"),
            ["status"] = new OpenApiInteger(StatusCodes.Status404NotFound),
            ["traceId"] = new OpenApiString("00-77a728ff72dc2a92d6c395a05a9d7c50-247802088d3c6f0c-00")
        };
    }
}
