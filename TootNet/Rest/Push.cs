using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class Push : ApiBase
    {
        internal Push(Tokens e) : base(e) { }

        public Subscription Subscription => new Subscription(this.Tokens);
    }
}
