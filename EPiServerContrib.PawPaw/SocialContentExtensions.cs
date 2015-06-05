using System.Collections.Generic;
using System.Linq;
using EPiServer.ServiceLocation;
using PawPaw;
using PawPaw.Core;
using PawPaw.Readers;
using PawPaw.Writers;

namespace EPiServerContrib.PawPaw
{
    public static class SocialContentExtensions
    {
        internal static int CreatePost(this ISocialContent content, PostWriter postWriter = null)
        {
            var writer = postWriter ?? ServiceLocator.Current.GetInstance<PostWriter>();
            return writer.CreatePost(null, null, content.ContentGuid.ToString());
        }

        public static void AddComment(this ISocialContent content, Comment comment)
        {
            var postWriter = ServiceLocator.Current.GetInstance<PostWriter>();
            var post = GetPost(content);
            var postId = post != null ? post.Id : content.CreatePost(postWriter);

            postWriter.CreateComment(postId, comment);
        }

        public static IEnumerable<Comment> GetComments(this ISocialContent content)
        {
            var postReader = ServiceLocator.Current.GetInstance<PostStreamReader>();
            var post = GetPost(content, postReader);

            return post != null ? postReader.GetComments(post.Id) : Enumerable.Empty<Comment>();
        }

        private static Post GetPost(ISocialContent content, PostStreamReader postStreamReader = null)
        {
            var postReader = postStreamReader ?? ServiceLocator.Current.GetInstance<PostStreamReader>();
            var post = postReader.GetPostByExternalId(content.ContentGuid.ToString());
            return post;
        }
    }
}
