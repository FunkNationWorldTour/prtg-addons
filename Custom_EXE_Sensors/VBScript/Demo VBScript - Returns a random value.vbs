Randomize
i = Cint((100 - 1 + 1) * Rnd + 1)

if i >= 30 Then
   WScript.echo i & ":OK"
   WScript.Quit("0")
else
   WScript.echo i & ":Value too low"
   WScript.Quit("4")
end if
