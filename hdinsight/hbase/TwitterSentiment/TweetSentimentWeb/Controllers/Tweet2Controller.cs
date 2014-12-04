using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TweetSentimentWeb.Models;

namespace TweetSentimentWeb.Controllers
{
    public class Tweet2Controller : ApiController
    {
        HBaseReader hbase = new HBaseReader();

        public Task<string[]> Get()
        {
            return Task.FromResult<string[]>( new string[] {"two", "one"});
        }

        public async Task<IEnumerable<Tweet>> GetTweetsByQuery(string query)
        {
            return await hbase.QueryTweetsByKeywordAsync(query);
        }
    }
}
