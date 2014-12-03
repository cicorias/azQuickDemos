
Add-AzureAccount

Select-AzureSubscription -SubscriptionName "Microsoft Azure Internal Consumption"

$strg = "scicoriahdp2"
$container = "hdproot"
$clusterName = "scicoriahdp2cluster"
$location = "East US"

$strgAccount = New-AzureStorageAccount -StorageAccountName $strg -Location $location

Set-AzureStorageAccount -StorageAccountName $strg -GeoReplicationEnabled $false


.\New-HDInsightCluster.ps1 -Cluster $clusterName -Location $location  `
      -DefaultStorageAccount $strg -DefaultStorageContainer $container `
      -ClusterSizeInNodes 1 -ClusterType "HBase"



#destroy  

#Remove-AzureHDInsightCluster -Name $clustername