all4000_to_prtg version 1.0.0.0 

This sensor gets Values from an ALLNET 4000 (ALLNET 300should be compatible) via XML HTTP Interface.

Parameters:

[0] {IP}              The IP-address of the device
[1] {0-15}            The value # (starting at zero)
[2] {CURRENT|MIN|MAX} The Value Type
                      The device provides the current, the minimum and the maximum values


Return value:

The value from the selected sensor. If the sensor is an temperature sensor you must set it as 
an float vaule in prtg (important!).

Example:

You want to read current value of the first temperature sensor on IP Adress 192.168.0.100

Command lineoptions: 192.168.0.100 0 CURRENT
