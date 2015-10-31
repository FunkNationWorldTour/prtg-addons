# Introduction #

The PRTG Billing Tool is an application that can read PRTG sensor data and generate bills in PDF format. It is an Open Source project which uses .NET and Lua scripting; monitoring data is queried via PRTG's built-in application programming interface (API).

Managed Service Providers (MSPs) can use this tool to bill their customers for certain traffic usage reported by a specific PRTG sensor. Templates and calculation are customizable to fit many use cases. We provide this tool as a basis to develop your own billing applications.

# System Requirements #

  * Microsoft Windows XP or later
  * Microsoft .NET version 4 or later
  * PRTG V8.2 or later
  * PRTG web server must be accessible from the machine running the billing tool.

# Usage #

After installation of the PRTG Billing Tool, at first start-up, the program will ask for information to connect to your PRTG server. Please provide Server IP/DNS Name, Port number, and credentials.

Once connected to the PRTG server, you can add a Group and one or more Reports in each group. Add new items by clicking on the Add buttons.


[See the Paessler website for more information](http://www.paessler.com/tools/billingtool)