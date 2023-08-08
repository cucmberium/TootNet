using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class Markers : ApiBase
    {
        internal Markers(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Get saved timeline positions.</para>
        /// <para>allowed values of timeline: "home", "notifications"</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>IEnumerable&lt;string&gt;</c> timeline (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the dictionary of marker object.</para>
        /// </returns>
        public Task<IDictionary<string, Marker>> GetAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<IDictionary<string, Marker>>(MethodType.Get, "markers", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Get saved timeline positions.</para>
        /// <para>allowed values of timeline: "home", "notifications"</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>IEnumerable&lt;string&gt;</c> timeline (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the dictionary of marker object.</para>
        /// </returns>
        public Task<IDictionary<string, Marker>> GetAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<IDictionary<string, Marker>>(MethodType.Get, "markers", parameters);
        }

        /// <summary>
        /// <para>Save your position in a timeline.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> home[last_read_id] (optional)</para>
        /// <para>- <c>long</c> notifications[last_read_id] (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the dictionary of marker object.</para>
        /// </returns>
        public Task<IDictionary<string, Marker>> PostAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<IDictionary<string, Marker>>(MethodType.Post, "markers", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Save your position in a timeline.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> home[last_read_id] (optional)</para>
        /// <para>- <c>long</c> notifications[last_read_id] (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the dictionary of marker object.</para>
        /// </returns>
        public Task<IDictionary<string, Marker>> PostAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<IDictionary<string, Marker>>(MethodType.Post, "markers", parameters);
        }
    }
}
