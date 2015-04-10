using EPiServer.Core;

namespace PawPaw.EPiServer.Models.Pages
{
    public interface IHasRelatedContent
    {
        ContentArea RelatedContentArea { get; }
    }
}
