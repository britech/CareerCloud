using CareerCloud.WebAPI.Filters;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CareerCloud.WebAPI.Examples;

[SwaggerSchemaFilter(typeof(ExampleGeneralFaultSchemaFilter))]
public class ExampleGeneralFault : ProblemDetails
{

}
