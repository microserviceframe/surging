using System.Net;

namespace Surging.Core.Stage.Internal
{
	public interface IIPChecker
    {
        bool IsBlackIp(IPAddress ip, string routePath);
    }
}
