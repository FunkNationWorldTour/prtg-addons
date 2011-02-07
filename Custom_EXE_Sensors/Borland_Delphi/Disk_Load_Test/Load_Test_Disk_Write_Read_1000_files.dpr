program Disk_Load_Test_Write_Read_1000_files;

{$APPTYPE CONSOLE}

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
var utc:tsystemtime; a,myfilename:string;
guid:tguid;myfile:text;
begin

  GetsystemTime(utc);
  start:=SystemTimeToDateTime(utc);

  try

  for i := 1 to 1000 do
    begin

      CreateGUID(guid);

      forcedirectories(extractfilepath(paramstr(0))+'\Disk Load Testfiles\');

      myfilename:=extractfilepath(paramstr(0))+'\Disk Load Testfiles\'+guidtostring(guid);

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
