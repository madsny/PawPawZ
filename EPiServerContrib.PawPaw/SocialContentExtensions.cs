using System.Collections.Generic;
using EPiServer.ServiceLocation;
using PawPaw;
using PawPaw.Core;

namespace EPiServerContrib.PawPaw
{
    public static class SocialContentExtensions
    {
        public static int AddComment(this ISocialContent content, Post post)
        {
            var postWriter = ServiceLocator.Current.GetInstance<PostWriter>();
            var groupId = 1; // todo Gruppeid?
            return postWriter.CreatePost(post, null);
        }

        public static IEnumerable<Post> GetComments(this ISocialContent content)
        {
            var postReader = ServiceLocator.Current.GetInstance<PostStreamReader>();;
            var groupId = 1; // todo GruppeId?
            return postReader.GetPostByGroup(groupId);
        } 
    }
}
