using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.Azure.Management.DataFactories.Models;
using Microsoft.DataFactories.Runtime;

//http://azure.microsoft.com/en-us/documentation/articles/data-factory-get-started/
//http://azure.microsoft.com/en-us/documentation/articles/data-factory-use-custom-activities/
//ref: http://msdn.microsoft.com/en-us/library/dn834987.aspx
//http://azure.microsoft.com/en-us/documentation/articles/hdinsight-get-started/


namespace TwitterSentimentLib
{
    class TwitterActivity : ICustomActivity
    {
        /// <summary>
        /// ICustomActivity implementation.
        /// </summary>
        /// <param name="inputTables"></param>
        /// <param name="outputTables"></param>
        /// <param name="extendedProperties"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        public IDictionary<string, string> Execute(
            IEnumerable<ResolvedTable> inputTables,
            IEnumerable<ResolvedTable> outputTables,
            IDictionary<string, string> extendedProperties,
            IActivityLogger logger)
        {
            throw new NotImplementedException();
        }
    }
}
