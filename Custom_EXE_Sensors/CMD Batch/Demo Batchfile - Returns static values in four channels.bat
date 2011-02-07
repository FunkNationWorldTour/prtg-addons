@echo off

REM Sample Exe/Script Advanced sensor                              
REM Returns four sensor channels with static values to standard OUT
REM < and > must be escaped in command line scripts

echo ^<prtg^>

echo    ^<result^>
echo        ^<channel^>Demo Minimum Example^</channel^>
echo        ^<value^>3^</value^>
echo    ^</result^>

echo    ^<result^>
echo        ^<channel^>Demo Disk Free^</channel^>
echo        ^<unit^>Percent^</unit^>
echo        ^<mode^>Absolute^</mode^>
echo        ^<showChart^>1^</showChart^>
echo        ^<showTable^>1^</showTable^>
echo        ^<warning^>0^</warning^>
echo        ^<float^>1^</float^>
echo        ^<value^>38.4487^</value^>
echo    ^</result^>

echo    ^<result^>
echo        ^<channel^>Demo Network Speed^</channel^>
echo        ^<unit^>SpeedNet^</unit^>
echo        ^<volumeSize^>MegaBit^</volumeSize^>
echo        ^<mode^>Absolute^</mode^>
echo        ^<showChart^>1^</showChart^>
echo        ^<showTable^>1^</showTable^>
echo        ^<warning^>0^</warning^>
echo        ^<float^>0^</float^>
echo        ^<value^>124487000^</value^>
echo    ^</result^>

echo    ^<result^>
echo        ^<channel^>Demo Custom^</channel^>
echo        ^<unit^>Custom^</unit^>
echo        ^<customUnit^>Pieces^</customUnit^>
echo        ^<mode^>Absolute^</mode^>
echo        ^<showChart^>1^</showChart^>
echo        ^<showTable^>1^</showTable^>
echo        ^<warning^>0^</warning^>
echo        ^<float^>0^</float^>
echo        ^<value^>855^</value^>
echo    ^</result^>

echo    ^<text^>Demo values. OS: %OS%^</text^>
echo ^</prtg^>
