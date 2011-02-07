program Load_Test_Memory_Allocate_And_Free_400MB;

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

var mystr1,mystr2:array[1..100000] of string;

var j,i:integer;start,stop:tdatetime;
var utc:tsystemtime;

begin

  GetsystemTime(utc);
  start:=SystemTimeToDateTime(utc);

  try

  for i := 1 to 100000 do // create 100000 strings with 1kb each => 100 MB
    begin
      mystr1[i]:='';
      for j := 0 to 100 do mystr1[i]:=mystr1[i]+'0123456789'; //this makes a 1kb string
    end;

  for i := 1 to 100000 do // free memory
    begin
      mystr2[i]:=mystr1[i]+mystr1[100000-i+1];
    end;

  for i := 1 to 100000 do // free memory
    begin
      mystr1[i]:='';
      mystr2[i]:='';
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
