
Add-AzureAccount

Select-AzureSubscription -SubscriptionName "Microsoft Azure Internal Consumption"

Use-AzureHDInsightCluster scicoriahdp2cluster


$jarFile = "/example/jars/hadoop-mapreduce-examples.jar"
$className = "wordcount"
$statusDirectory = "/samples/wordcount/status"
$outputDirectory = "/samples/wordcount/output"
$inputDirectory = "/example/data/gutenberg"
$wordCount = New-AzureHDInsightMapReduceJobDefinition -JarFile $jarFile -ClassName $className -Arguments $inputDirectory, $outputDirectory -StatusFolder $statusDirectory


$wordCountJob = $wordCount | Start-AzureHDInsightJob -Cluster scicoriahdp2cluster | Wait-AzureHDInsightJob



#done
Get-AzureHDInsightJobOutput -Cluster scicoriahdp2cluster -JobId $wordCountJob.JobId -StandardError

Get-AzureHDInsightJobOutput -Cluster scicoriahdp2cluster -JobId $wordCountJob.JobId -StandardOutput

