using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PSCPMSWebApi.Helper
{
    public class SchemaFilter : ISchemaFilter
    {

        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema.Properties == null)
            {
                return;
            }

            foreach (PropertyInfo propertyInfo in context.GetType().GetProperties())
            {

                // Look for class attributes that have been decorated with "[DefaultAttribute(...)]".
                DefaultValueAttribute defaultAttribute = propertyInfo
                    .GetCustomAttribute<DefaultValueAttribute>();

                if (defaultAttribute != null)
                {
                    foreach (KeyValuePair<string, OpenApiSchema> property in schema.Properties)
                    {

                        // Only assign default value to the proper element.
                        if (ToCamelCase(propertyInfo.Name) == property.Key)
                        {
                            property.Value.Example = (IOpenApiAny)defaultAttribute.Value;
                            break;
                        }
                    }
                }
            }
        }

        private string ToCamelCase(string name)
        {
            return char.ToLowerInvariant(name[0]) + name.Substring(1);
        }
    }
}
