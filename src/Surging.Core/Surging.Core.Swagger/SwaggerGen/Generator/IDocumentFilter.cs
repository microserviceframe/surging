using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Surging.Core.Swagger;
using System.Collections.Generic;

namespace Surging.Core.SwaggerGen
{
    public interface IDocumentFilter
    {
        void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context);
    }

    public class DocumentFilterContext
    {
        public DocumentFilterContext(IEnumerable<ApiDescription> apiDescriptions, ISchemaRegistry schemaRegistry)
        {
            ApiDescriptions = apiDescriptions;
            SchemaRegistry = schemaRegistry;
        }
        //public DocumentFilterContext(
        //    ApiDescriptionGroupCollection apiDescriptionsGroups,
        //    IEnumerable<ApiDescription> apiDescriptions,
        //    ISchemaRegistry schemaRegistry)
        //{
        //    ApiDescriptionsGroups = apiDescriptionsGroups;
        //    ApiDescriptions = apiDescriptions;
        //    SchemaRegistry = schemaRegistry;
        //}

        //[Obsolete("Deprecated: Use ApiDescriptions")]
        //public ApiDescriptionGroupCollection ApiDescriptionsGroups { get; private set; }

        public IEnumerable<ApiDescription> ApiDescriptions { get; private set; }

        public ISchemaRegistry SchemaRegistry { get; private set; }
    }
}
