program Load_Test_Disk_Write_Read_1000_files_with_folderselect_in_param1;

{$APPTYPE CONSOLE}

 {$R version.res}

uses
  SysUtils,windows,dateutils;

function SystemTimeToDateTime(const SystemTime: TSystemTime): TDateTime;
begin
  with SystemTime do
  begin
    Result := EncodeDate(wYear, wMonth, wDay);
    if Result >= 0 then
      Result := Result + EncodeTime(wHour, wMinute, wSecond, wMilliSeconds)
    else
      Result := Result - EncodeTime(wHour, wMinute, wSecond, wMilliSeconds);
  end;
end;


var j,i:integer;start,stop:tdatetime;
var utc:tsystemtime; folder,a,myfilename:string;
guid:tguid;myfile:text;
begin

  GetsystemTime(utc);
  start:=SystemTimeToDateTime(utc);

  if directoryexists(paramstr(1)) then folder:=paramstr(1) else folder:=extractfilepath(paramstr(0));

  try

  for i := 1 to 1000 do
    begin

      CreateGUID(guid);

      forcedirectories(folder+'\Disk Load Testfiles\');

      myfilename:=folder+'\Disk Load Testfiles\'+guidtostring(guid);

      assignfile(myfile,myfilename);
      rewrite(myfile);

      for j := 0 to 2000 do
        writeln(myfile,j);

      closefile(myfile);

      reset(myfile);
      for j := 0 to 1999 do
        readln(myfile,a);

      closefile(myfile);

      sysutils.deletefile(myfilename);

    end;
  except
    on e:exception do
    begin
      GetsystemTime(utc);
      stop:=SystemTimeToDateTime(utc);
      writeln(IntToStr(milliSecondsBetween(start,stop))+':Test failed '+e.Message);
      ExitCode:=0;
      halt;
    end;
  end;

  GetsystemTime(utc);
  stop:=SystemTimeToDateTime(utc);

  writeln(IntToStr(milliSecondsBetween(start,stop))+':ok');
  ExitCode:=0;
end.
