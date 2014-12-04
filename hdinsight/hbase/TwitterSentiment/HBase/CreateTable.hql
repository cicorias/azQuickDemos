CREATE EXTERNAL TABLE tweetsbywords(rowkey STRING, coor STRING, str STRING, lang STRING, sentiment INT)
STORED BY 'org.apache.hadoop.hive.hbase.HBaseStorageHandler'
WITH SERDEPROPERTIES ('hbase.columns.mapping' = ':key,d:coor,d:id_str,d:lang,d:sentiment')
TBLPROPERTIES ('hbase.table.name' = 'tweets_by_words');