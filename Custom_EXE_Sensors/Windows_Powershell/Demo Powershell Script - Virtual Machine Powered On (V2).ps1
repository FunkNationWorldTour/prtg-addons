#---------------------------------------------------------------------------------------------
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



$ErrorActionPreference = "SilentlyContinue"
Add-PSSnapin VMWare.VIMAutomation.core >$Null

$ErrorActionPreference = "SilentlyContinue"
Connect-VIServer -Server $Args[0] -Protocol $Args[1] -User $Args[2] -Password $Args[3] >$Null

$VM=Get-View -ViewType VirtualMachine -Filter @{"Name" = $Args[4]}
$V =$vm.Runtime.PowerState


$ErrorActionPreference = "Continue"

if ($V -like('*PoweredOn*')){
  write-host "1:OK"
  exit(1)
}elseif($V -like('*PoweredOff*')){
  write-host "0:Powererd Off"
  exit(2)
}else{
  write-host "0:Error in Script"
  exit(3)
}
