# Introduction #

Among others, you can use this sensor for low cost environmental monitoring.

## What can I monitor ##
With this sensor you can check the state (open or closed) of any dry contact.
You can use this sensor to check the state of a:
  * Door switch (of your server rack)
  * Room thermostat (to monitor the temperature treshold in your server rack)
  * Potential free contact of any appliance (e.g. alarms device)
  * ...

## What else do I need ##
You need a free serial port on your PRTG server or remote probe (a usb to serial device will also do), a 9 pins sub-d connector and two resistors of 2K2.

## How do I connect the dry contacts ##
See the schematic below on how to connect the contact(s) you want to monitor.

## What are the limitations ##
  * With one serial port, you can monitor 2 contacts.
  * One ContactState sensor monitors 1 contact, so to monitor both contacts you have to run 2 sensors. As both sensors use the same serial port, you have to set the sensors mutax name to prevent the 2 sensors using the serial port at the same time.
  * You can only monitor dry contacts.
  * The biggest limitation will be your own fantasy!

![http://ptf-prtgaddons.googlecode.com/files/ContactState.jpg](http://ptf-prtgaddons.googlecode.com/files/ContactState.jpg)

The example above is of cause for illustration purposes only, as companies like APC provide a much more elegant way of environment monitoring. Your own fantasy will be the limit of what you can do with this principle. Maybe you will end up monitoring your coffee machine !!

The sensor can be downloaded from [this](http://code.google.com/p/prtg-addons/wiki\PTF_Custom_Sensors) page.