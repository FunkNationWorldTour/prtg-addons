[Setup]
AppName=Paessler Billingtool
AppVersion=1.0
AppVerName=PRTG Billingtool 1.0

AppMutex=PrtgBillingMutex

AppPublisher=Paessler AG
AppPublisherURL=http://www.paessler.com/


AppId=5b1bff6b-ffab-4740-bd05-94ea3ea1bc53

DefaultDirName={pf}\Paessler Billingtool
DefaultGroupName=Paessler Billingtool

OutputBasefilename=PaesslerBillingSetup
OutputDir=bin\Release\setup

Compression=lzma2
SolidCompression=yes

[Icons]
Name: "{group}\Paessler Billing"; Filename: "{app}\Paessler.Billingtool.exe"; WorkingDir: "{app}"
Name: "{userdesktop}\Paessler Billing"; Filename: "{app}\Paessler.Billingtool.exe"; WorkingDir: "{app}"
Name: "{group}\scripts"; Filename: "{app}\scripts";
Name: "{group}\templates"; Filename: "{app}\templates";
Name: "{group}\uninstall"; Filename: "{uninstallexe}";

[Files]
Source: "bin\Release\Paessler.Billingtool.exe"; DestDir: "{app}"
Source: "bin\Release\lua51.dll"; DestDir: "{app}"
Source: "bin\Release\LuaInterface.dll"; DestDir: "{app}"

Source: "bin\Release\ext\*"; DestDir: "{app}\ext"
Source: "bin\Release\scripts\*"; DestDir: "{app}\scripts"
Source: "bin\Release\templates\*"; DestDir: "{app}\templates"; Flags: recursesubdirs 

[UninstallDelete]
Type: files; Name: "{app}\scripts\*"
Type: filesandordirs; Name: "{app}\templates\*"


[Run]
Filename: "{app}\Paessler.Billingtool.exe"; Description: "Start Paessler PRTG Billingtool"; WorkingDir: "{app}"; Flags: postinstall nowait skipifsilent unchecked

[CustomMessages]
dotnetmissing=This application needs Microsoft .Net 4 which is not yet installed. Do you like to download it now?

[Code]
function InitializeSetup(): Boolean;
var
  ErrorCode: Integer;
  netFrameWorkInstalled : Boolean;
  isInstalled: Cardinal;
begin
  result := true;
 
  isInstalled := 0;
  netFrameworkInstalled := RegQueryDWordValue(HKLM, 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full', 'Install', isInstalled);
  if ((netFrameworkInstalled)  and (isInstalled <> 1)) then netFrameworkInstalled := false;
 
  if netFrameworkInstalled = false then
  begin
    if (MsgBox(ExpandConstant('{cm:dotnetmissing}'), mbConfirmation, MB_YESNO) = idYes) then
    begin
      ShellExec('open',
      'http://go.microsoft.com/fwlink/?LinkId=181013',
      '','',SW_SHOWNORMAL,ewNoWait,ErrorCode);
    end;
    result := false;
  end;
 
end;
