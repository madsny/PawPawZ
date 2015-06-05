using PawPaw.Core;

namespace PawPaw.Readers
{
    public abstract class ReaderBase
    {
        public abstract SocialContentBase GetById(int id);
    }
}
