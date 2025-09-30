using Microsoft.JSInterop;
namespace Infrastructures.Common.DotNet
{
    public class DotNetService
    {
        public DotNetObjectReference<DotNetService> DotNetReference { get; private set; }

        public DotNetService()
        {
            DotNetReference = DotNetObjectReference.Create(this);
        }
    }
}
