using System;
using System.Collections.Generic;
using System.Text;
using TootNet.Objects;

namespace TootNet.Exception
{
    public class MastodonException : System.Exception
    {
        public MastodonException(Error error)
            : base(error.Description)
        {
            Error = error;
        }

        public Error Error { get; set; }
    }
}
