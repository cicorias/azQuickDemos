

#$creds = Get-Credential

Invoke-RestMethod https://scicoriahdp2cluster.azurehdinsight.net/hbaserest -Credential $creds

$row = Invoke-RestMethod https://scicoriahdp2cluster.azurehdinsight.net/hbaserest/tweets_by_words/row1 -Credential $creds
$row.CellSet.Row.Cell
