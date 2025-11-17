using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace GRMDataManager.App_Start
{
    public class AuthTokenOperation : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            swaggerDoc.paths.Add("/token", new PathItem 
            { 
                post = new Operation
                {
                    tags = new List<string> { "auth" },
                    consumes = new List<string> { "application/x-www-form-urlencoded" },
                    parameters = new List<Parameter>
                    {
                        new Parameter
                        {
                            name = "grant_type",
                            type = "string",
                            required = true,
                            @in = "formData",
                            @default = "password"
                        },
                        new Parameter
                        {
                            name = "username",
                            type = "string",
                            required = false,
                            @in = "formData",
                        },
                        new Parameter
                        {
                            name = "password",
                            type = "string",
                            required = false,
                            @in = "formData",
                        }
                    },
                }
            });
        }
    }
}