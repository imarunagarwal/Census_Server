using CensusDataDigitalization.DAL.Interceptor;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensusDataDigitalization.DAL
{
    /// <summary>
    /// configuration File that Initializes the DB Interceptor and Logger
    /// </summary>
    public class CensusDataDigitalizationConfiguration : DbConfiguration
    {
        public CensusDataDigitalizationConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
            DbInterception.Add(new CensusDataDigitalizationInterceptorTransientErrors());
            DbInterception.Add(new CensusDataDigitalizationInterceptorLogging());
        }
    }
}
