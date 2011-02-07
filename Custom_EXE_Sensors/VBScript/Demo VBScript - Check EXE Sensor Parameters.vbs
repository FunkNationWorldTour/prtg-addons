Dim i,c, str

c = WScript.Arguments.Count


if c = 0 then

 WScript.echo c&":No Arguments"

else

  for i = 0 to c - 1
     str = str + """" + WScript.Arguments(i) +""" "
  next
  WScript.echo c & ":" & str

end if




