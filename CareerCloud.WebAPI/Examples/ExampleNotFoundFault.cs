using CareerCloud.WebAPI.Filters;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CareerCloud.WebAPI.Examples;

[SwaggerSchemaFilter(typeof(ExampleNotFoundFaultSchemaFilter))]
public class ExampleNotFoundFault : ProblemDetails
{
}
