using EPiServer.Core;

namespace PawPaw.Alloy.Models.Pages
{
    public interface IHasRelatedContent
    {
        ContentArea RelatedContentArea { get; }
    }
}
