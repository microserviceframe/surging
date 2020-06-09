namespace Surging.Core.CPlatform.Diagnostics
{
    public interface ILocalSegmentContextAccessor
    {
        SegmentContext Context { get; set; }
    }
}
