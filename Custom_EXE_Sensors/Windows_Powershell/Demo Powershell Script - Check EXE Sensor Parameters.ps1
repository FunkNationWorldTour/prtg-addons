foreach ($arg in $args)
{
   $s += """" + $arg + """ "
}

$x = [string]$args.Length + ":" + $s
write-Host $x