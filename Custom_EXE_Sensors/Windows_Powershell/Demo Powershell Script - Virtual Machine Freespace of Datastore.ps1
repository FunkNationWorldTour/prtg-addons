#---------------------------------------------------------------------------------------------
# Get the Percent Free Diskspace of a Virtual Machine 
#
# This script requires the installation of the VMware Infrastructure (VI) Toolkit for Windows.
# 
# Args[0]:Server
# Args[1]:Protocol (HTTP/HTTPS)
# Args[2]:User
# Args[3]:Password
# Args[4]:Virtual Machine's Name
#
# e.g.: 
# 10.23.112.235 https Administrator pass01 MyVM
#---------------------------------------------------------------------------------------------


Add-PSSnapin VMWare.VIMAutomation.core >$Null

$Server=Connect-VIServer -Server $Args[0] -Protocol $Args[1] -User $Args[2] -Password $Args[3]

$VM=Get-VM $Args[4]
$datastore = Get-DataStore -VM $VM

[int]$p = $datastore.FreeSpaceMB * 100 / $datastore.CapacityMB
$x=[string]$p+":OK"
write-host $x