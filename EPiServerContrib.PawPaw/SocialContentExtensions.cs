using System.Collections.Generic;
using EPiServer.ServiceLocation;
using PawPaw;
using PawPaw.Core;

namespace EPiServerContrib.PawPaw
{
    public static class SocialContentExtensions
    {
        public static void AddComment(this ISocialContent content, Comment comment)
        {
            var post = GetPost(content);

            var postWriter = ServiceLocator.Current.GetInstance<PostWriter>();
            postWriter.CreateComment(post.Id, comment);
        }

        public static IEnumerable<Comment> GetComments(this ISocialContent content)
        {
            var postReader = ServiceLocator.Current.GetInstance<PostStreamReader>();
            var post = GetPost(content, postReader);

            return postReader.GetComments(post.Id);
        }

        private static Post GetPost(ISocialContent content, PostStreamReader postStreamReader = null)
        {
            var postReader = postStreamReader ?? ServiceLocator.Current.GetInstance<PostStreamReader>();
            var post = postReader.GetPostByExternalId(content.ContentGuid.ToString());
            return post;
        }

    }
}
