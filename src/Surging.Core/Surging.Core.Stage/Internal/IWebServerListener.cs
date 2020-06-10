using Surging.Core.KestrelHttpServer;

namespace Surging.Core.Stage.Internal
{
    public interface IWebServerListener
    {
        void Listen(WebHostContext context);
    }
}
