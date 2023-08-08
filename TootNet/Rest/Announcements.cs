using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class Announcements : ApiBase
    {
        internal Announcements(Tokens e) : base(e) { }

        /// <summary>
        /// <para>View all announcements.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>bool</c> with_dismissed (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of announcement object.</para>
        /// </returns>
        public Task<IEnumerable<Announcement>> GetAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<Announcement>>(MethodType.Get, "announcements", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>View all announcements.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>bool</c> with_dismissed (optional)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the list of announcement object.</para>
        /// </returns>
        public Task<IEnumerable<Announcement>> GetAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<Announcement>>(MethodType.Get, "announcements", parameters);
        }

        /// <summary>
        /// <para>Dismiss an announcement.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the empty object.</para>
        /// </returns>
        public Task DismissAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessParameterReservedApiAsync(MethodType.Post, "announcements/{id}/dismiss", "id", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Dismiss an announcement.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the empty object.</para>
        /// </returns>
        public Task DismissAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessParameterReservedApiAsync(MethodType.Post, "announcements/{id}/dismiss", "id", parameters);
        }

        /// <summary>
        /// <para>Add a reaction to an announcement.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>string</c> name (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the empty object.</para>
        /// </returns>
        public Task AddReactionsAsync(params Expression<Func<string, object>>[] parameters)
        {
            // TODO: refactor
            var list = Utils.ExpressionToDictionary(parameters).ToList();
            var kvp = Utils.GetReservedParameter(list, "name");
            list.Remove(kvp);
            return Tokens.AccessParameterReservedApiAsync(MethodType.Put, "announcements/{id}/reactions/" + kvp.Value, "id", list.ToDictionary(x => x.Key, x => x.Value));
        }

        //// <summary>
        /// <para>Add a reaction to an announcement.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> id (required)</para>
        /// <para>- <c>string</c> name (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the empty object.</para>
        /// </returns>
        public Task AddReactionsAsync(IDictionary<string, object> parameters)
        {
            // TODO: refactor
            var list = parameters.ToList();
            var kvp = Utils.GetReservedParameter(list, "name");
            list.Remove(kvp);
            return Tokens.AccessParameterReservedApiAsync(MethodType.Put, "announcements/{id}/reactions/" + kvp.Value, "id", list.ToDictionary(x => x.Key, x => x.Value));
        }

        /// <summary>
        /// <para>Remove a reaction from an announcement.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the empty object.</para>
        /// </returns>
        public Task DeleteReactionsAsync(params Expression<Func<string, object>>[] parameters)
        {
            // TODO: refactor
            var list = Utils.ExpressionToDictionary(parameters).ToList();
            var kvp = Utils.GetReservedParameter(list, "name");
            list.Remove(kvp);
            return Tokens.AccessParameterReservedApiAsync(MethodType.Delete, "announcements/{id}/reactions/" + kvp.Value, "id", list.ToDictionary(x => x.Key, x => x.Value));
        }

        /// <summary>
        /// <para>Remove a reaction from an announcement.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the empty object.</para>
        /// </returns>
        public Task DeleteReactionsAsync(IDictionary<string, object> parameters)
        {
            // TODO: refactor
            var list = parameters.ToList();
            var kvp = Utils.GetReservedParameter(list, "name");
            list.Remove(kvp);
            return Tokens.AccessParameterReservedApiAsync(MethodType.Delete, "announcements/{id}/reactions/" + kvp.Value, "id", list.ToDictionary(x => x.Key, x => x.Value));
        }
    }
}
