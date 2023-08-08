using TootNet.Objects;

namespace TootNet.Exception
{
    public class MastodonException : System.Exception
    {
        public MastodonException(Error error)
            : base(error.ErrorMessage)
        {
            Error = error;
        }

        public Error Error { get; set; }
    }
}
