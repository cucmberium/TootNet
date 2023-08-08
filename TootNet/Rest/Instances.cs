using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{
    public class Instances : ApiBase
    {
        internal Instances(Tokens e) : base(e) { }

        /// <summary>
        /// <para>Returns information about instance.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the instance object.</para>
        /// </returns>
        public Task<Instance> GetAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<Instance>(MethodType.Get, "instance", Utils.ExpressionToDictionary(parameters));
        }

        /// <summary>
        /// <para>Returns information about instance.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the instance object.</para>
        /// </returns>
        public Task<Instance> GetAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<Instance>(MethodType.Get, "instance", parameters);
        }

        /// <summary>
        /// <para>Returns list of connected domains.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the instance object.</para>
        /// </returns>
        public Task<IEnumerable<string>> PeersAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<string>>(MethodType.Get, "instance/peers", Utils.ExpressionToDictionary(parameters));
        }

        // <summary>
        /// <para>Returns list of connected domains.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the instance object.</para>
        /// </returns>
        public Task<IEnumerable<string>> PeersAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<string>>(MethodType.Get, "instance/peers", parameters);
        }

        /// <summary>
        /// <para>Returns list of weekly activity.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the instance object.</para>
        /// </returns>
        public Task<IEnumerable<IDictionary<string, string>>> ActivityAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<IDictionary<string, string>>>(MethodType.Get, "instance/activity", Utils.ExpressionToDictionary(parameters));
        }

        // <summary>
        /// <para>Returns list of connected domains.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the instance object.</para>
        /// </returns>
        public Task<IEnumerable<IDictionary<string, string>>> ActivityAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<IDictionary<string, string>>>(MethodType.Get, "instance/activity", parameters);
        }




        /// <summary>
        /// <para>Returns list of weekly activity.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the instance object.</para>
        /// </returns>
        public Task<IEnumerable<Objects.Rule>> RulesAsync(params Expression<Func<string, object>>[] parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<Objects.Rule>>(MethodType.Get, "instance/rules", Utils.ExpressionToDictionary(parameters));
        }

        // <summary>
        /// <para>Returns list of connected domains.</para>
        /// <para>Available parameters:</para>
        /// <para>- No parameters available in this method.</para>
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// <para>The task object representing the asynchronous operation.</para>
        /// <para>The Result property on the task object returns the instance object.</para>
        /// </returns>
        public Task<IEnumerable<Objects.Rule>> RulesAsync(IDictionary<string, object> parameters)
        {
            return Tokens.AccessApiAsync<IEnumerable<Objects.Rule>>(MethodType.Get, "instance/rules", parameters);
        }
    }
}
