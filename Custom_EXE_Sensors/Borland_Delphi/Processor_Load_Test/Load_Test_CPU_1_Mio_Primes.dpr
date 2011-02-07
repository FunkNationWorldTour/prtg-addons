program CPU_Load_Test_1_Mio_Primes;

{$APPTYPE CONSOLE}

uses
  SysUtils,windows,dateutils;

function IsPrim(AInteger: Integer): boolean;
var
  i: Integer;
begin
  result := true;
  if (AInteger <= 1) then  //Wenn Zahl kleiner ist als 2: keine Primzahl
    begin
      result := false;
      exit;               //Funktion beenden
    end;
  for i := 2 to Round(Sqrt(AInteger)) do //Wenn eine Zahl n von 2 bis Wurzel(n)
    begin                                // nicht teilbar ist, ist sie eine Primzahl
      if AInteger mod i = 0 then         //mod: Modulo = Rest
        begin
          result := false;
          exit;
        end;
    end;
end;

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


var a,i:integer;start,stop:tdatetime;
var utc:tsystemtime;
begin

  GetsystemTime(utc);
  start:=SystemTimeToDateTime(utc);

  for i := 1 to 1000000 do
    begin
      if IsPrim (i) then        //wenn i eine Primzahl ist,
        begin
          a:=i;           //i ausgeben
        end;
    end;

  GetsystemTime(utc);
  stop:=SystemTimeToDateTime(utc);

  writeln(IntToStr(milliSecondsBetween(start,stop))+':ok');
  ExitCode:=0;
end.
