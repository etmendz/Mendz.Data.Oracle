using Mendz.Data.Common;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Threading;

namespace Mendz.Data.Oracle
{
    public class OracleDbDataContext : DbDataContextBase
    {
        /// <summary>
        /// Provides the database context for an Oracle database.
        /// </summary>
        protected override IDbConnection BuildContext() => new OracleConnection(DataSettingOptions.ConnectionStrings[OracleDataSettingOption.Name]);

        /// <summary>
        /// Creates a context asynchronously.
        /// </summary>
        /// <remarks>This method must be called explicity before accessing the Context property.
        /// By default, Context calls the synchronous CreateContext() method.
        /// </remarks>
        public async void CreateContextAsync()
        {
            if (Context == null)
            {
                Context = BuildContext();
                await ((OracleConnection)Context).OpenAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Creates a context asynchronously with a cancellation token.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <remarks>This method must be called explicity before accessing the Context property.
        /// By default, Context calls the synchronous CreateContext() method.
        /// </remarks>
        public async void CreateContextAsync(CancellationToken cancellationToken)
        {
            if (Context == null)
            {
                Context = BuildContext();
                await ((OracleConnection)Context).OpenAsync(cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
