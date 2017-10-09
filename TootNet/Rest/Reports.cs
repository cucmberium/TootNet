using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class Reports : ApiBase
    {
        internal Reports(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Returns a list of reports made by the authenticated user.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the report object.</para>
        /// </returns>
        public Task<Linked<Report>> GetAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<Linked<Report>>(MethodType.Get, "reports", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Returns a list of reports made by the authenticated user.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the report object.</para>
        /// </returns>
        public Task<Linked<Report>> GetAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Linked<Report>>(MethodType.Get, "reports", parameters);
        }

        /// <summary>
        /// <para>Returns a list of reports made by the authenticated user.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> account_id (required)</para>
        /// <para>- <c>IEnumerable&lt;long&gt;</c> status_ids (required)</para>
        /// <para>- <c>string</c> comment (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the report object.</para>
        /// </returns>
        public Task<Report> PostAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<Report>(MethodType.Post, "reports", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Returns a list of reports made by the authenticated user.</para>
        /// <para>Available parameters:</para>
        /// <para>- <c>long</c> account_id (required)</para>
        /// <para>- <c>IEnumerable&lt;long&gt;</c> status_ids (required)</para>
        /// <para>- <c>string</c> comment (required)</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the report object.</para>
        /// </returns>
        public Task<Report> PostAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Report>(MethodType.Post, "reports", parameters);
        }
    }
}
