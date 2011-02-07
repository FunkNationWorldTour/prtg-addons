program DemoEXE;

{$APPTYPE CONSOLE}

uses
  SysUtils;

begin
  Randomize;
  writeln(IntToStr(Random(100))+':ok');
  ExitCode:=0;
end.
