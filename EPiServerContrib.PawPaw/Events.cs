using EPiServer;

namespace EPiServerContrib.PawPaw
{
    public class Events
    {
        public static void PublishedContent(object sender, ContentEventArgs e)
        {
            var content = e.Content as ISocialContent;
            if (content == null)
                return;

            content.CreatePost();
        }
    }
}
