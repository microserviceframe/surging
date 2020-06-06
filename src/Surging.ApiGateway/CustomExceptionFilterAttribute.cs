using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Hosting;
using Surging.Core.ApiGateWay;

namespace Surging.ApiGateway
{
	public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public CustomExceptionFilterAttribute(IWebHostEnvironment webHostEnvironment, IModelMetadataProvider modelMetadataProvider)
        {
            _webHostEnvironment = webHostEnvironment;
            _modelMetadataProvider = modelMetadataProvider;
        }

        public override void OnException(ExceptionContext context)
        {
            if (!_webHostEnvironment.IsDevelopment())
            {
                return;
            }
            var result =  ServiceResult.Create(false,errorMessage: context.Exception.Message);
            result.StatusCode = 400;
            context.Result = new JsonResult(result);
        }
    }
}

