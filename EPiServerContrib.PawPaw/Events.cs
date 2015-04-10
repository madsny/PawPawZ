using EPiServer;
using EPiServer.ServiceLocation;
using PawPaw;

namespace EPiServerContrib.PawPaw
{
    public class Events
    {
        public static void PublishedContent(object sender, ContentEventArgs e)
        {
            var content = e.Content as ISocialContent;
            if (content == null)
                return;

            var postWriter = ServiceLocator.Current.GetInstance<PostWriter>();
            postWriter.CreatePost(null, null, content.ContentGuid.ToString());
        }
    }
}
