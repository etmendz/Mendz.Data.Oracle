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
        protected override IDbConnection BuildContext()
        {
            return new OracleConnection(DataSettingOptions.ConnectionStrings[OracleDataSettingOption.Name]);
        }

        /// <summary>
        /// Creates a context asynchronously.
        /// </summary>
        /// <remarks>This method must be called explicity before accessing the Context property.
        /// By default, Context calls the synchronous CreateContext() method.
        /// </remarks>
        public async void CreateContextAsync()
        {
            if (_context == null)
            {
                _context = BuildContext();
                await ((OracleConnection)_context).OpenAsync();
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
            if (_context == null)
            {
                _context = BuildContext();
                await ((OracleConnection)_context).OpenAsync(cancellationToken);
            }
        }
    }
}
