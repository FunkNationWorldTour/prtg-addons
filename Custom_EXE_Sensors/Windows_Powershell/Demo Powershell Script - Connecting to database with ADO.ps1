# **********************************************************
# PRTG Custom EXE Sensor, Powershell Demo Script for ADO Connections
# **********************************************************
# created Nov 2009 for PRTG Network Monitor V7 by Paessler Support Team, www.paessler.com
# This script is Open Source and comes without support and warranty


#************ Set Your Connection String Parameters here ****************
# Check out http://www.connectionstrings.com/ or http://www.w3schools.com/ADO/default.asp for help on ADO

# Sample for Microsoft Access Database
# $myconnectionstring = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = c:\test\sample.mdb"

# Sample for MS SQL Server
# $myconnectionstring = "Provider=SQLOLEDB.1;Password=test;Persist Security Info=True;User ID=test;Initial Catalog=yourname;Data Source=10.1.4.105\SQLEXPRESS"

# Sample for Oracle Database
# $myConnectionString = "Provider=MSDAORA.1;Password=test;User ID=test;Data Source=test;Persist Security Info=True"


#************ Set Your SQL Statement Parameters here ****************
# The script assumes that your database contains the table 'employees' with the field 'salary'.
# According to the Database you may have to adjust the SQL statement.

$mysqlstatement =  "select MAX(salary) AS MaxSalary from employees"
$mytablecomumnname = "MaxSalary"


#************ Now let's access the database ****************

$adOpenStatic = 3
$adLockOptimistic = 3

$objConnection = New-Object -comobject ADODB.Connection
$objRecordset = New-Object -comobject ADODB.Recordset

$objConnection.Open($myconnectionstring)


# *********** Check if connection is open *******************

if($objConnection.state -eq 0){
  write-host '0:Could not establish connection'
  exit 1
}

$objRecordset.Open($mysqlstatement,$objConnection,$adOpenStatic,$adLockOptimistic)

$objRecordset.MoveFirst()

# *********** Check if there are records *******************

if($objRecordset.EOF -eq $True){
  write-host '0:No Data found'
  exit 2
}

write-host $objRecordset.Fields.Item($mytablecomumnname).Value,":OK"


$objRecordset.Close()
$objConnection.Close()