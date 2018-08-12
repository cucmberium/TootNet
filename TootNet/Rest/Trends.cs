using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class Trends : ApiBase
    {
        internal Trends(Tokens e) : base(e) { }

        // /// <summary>
        // /// <para>Returns trending hashtags.</para>
        // /// <para>Available parameters:</para>
        // /// <para>- No parameters available in this method.</para>
        // /// </summary>
        // /// <param name="parameters">The parameters.</param>
        // /// <returns>
        // /// <para>The task object representing the asynchronous operation.</para>
        // /// <para>The Result property on the task object returns the list of tag object.</para>
        // /// </returns>
        // public Task<IEnumerable<Tag>> GetAsync(params Expression<Func<string, object>>[] parameters)
        // {
        //     return Tokens.AccessApiAsync<IEnumerable<Tag>>(MethodType.Get, "trends", Utils.ExpressionToDictionary(parameters));
        // }
        // 
        // /// <summary>
        // /// <para>Returns trending hashtags.</para>
        // /// <para>Available parameters:</para>
        // /// <para>- No parameters available in this method.</para>
        // /// </summary>
        // /// <param name="parameters">The parameters.</param>
        // /// <returns>
        // /// <para>The task object representing the asynchronous operation.</para>
        // /// <para>The Result property on the task object returns the list of tag object.</para>
        // /// </returns>
        // public Task<IEnumerable<Tag>> GetAsync(IDictionary<string, object> parameters)
        // {
        //     return Tokens.AccessApiAsync<IEnumerable<Tag>>(MethodType.Get, "trends", parameters);
        // }
    }
}
