using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using Newtonsoft.Json;
using System.IO;

namespace TwitterSentiment
{
    internal class Config
    {

        string _twitterAppAccessToken = null;
        string _twitterAppAccessTokenSecret = null;
        string _twitterAppApiKey = null;
        string _twitterAppApiSecret = null;

        string _clusterName = null;
        string _hadoopUserName = null;
        string _hadoopUserPassword = null;
        string _hBaseTableName = null;

        static Config s_instance;


        public string TwitterAppAccessToken
        {
            get { return _twitterAppAccessToken; }
            set { _twitterAppAccessToken = value; }
        }

        public string TwitterAppAccessTokenSecret
        {
            get { return _twitterAppAccessTokenSecret; }
            set { _twitterAppAccessTokenSecret = value; }
        }

        public string TwitterAppApiKey
        {
            get { return _twitterAppApiKey; }
            set { _twitterAppApiKey = value; }
        }

        public string TwitterAppApiSecret
        {
            get { return _twitterAppApiSecret; }
            set { _twitterAppApiSecret = value; }
        }

        public string ClusterName
        {
            get { return _clusterName; }
            set { _clusterName = value; }
        }

        public string HadoopUserName
        {
            get { return _hadoopUserName; }
            set { _hadoopUserName = value; }
        }
        public string HadoopUserPassword
        {
            get { return _hadoopUserPassword; }
            set { _hadoopUserPassword = value; }
        }

        public string HBaseTableName
        {
            get { return _hBaseTableName; }
            set { _hBaseTableName = value; }
        }

        public static Config Instance
        {
            get
            {
                if (null == s_instance)
                {
                    Config cfg = JsonConvert.DeserializeObject<Config>(File.ReadAllText("config.private"));
                    s_instance = cfg;
                }
                return s_instance;
            }
        }

        
    }
}
