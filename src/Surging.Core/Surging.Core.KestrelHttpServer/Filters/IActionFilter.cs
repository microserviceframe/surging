using Surging.Core.KestrelHttpServer.Filters.Implementation;
using System.Threading.Tasks;

namespace Surging.Core.KestrelHttpServer.Filters
{
    public interface IActionFilter
    {
        Task OnActionExecuting(ActionExecutingContext filterContext);

        Task OnActionExecuted(ActionExecutedContext filterContext);
    }
}
