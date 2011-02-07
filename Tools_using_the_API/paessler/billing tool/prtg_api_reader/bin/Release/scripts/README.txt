PRTG Billing Tool Scripting Documentation
2011

To customize the billing calculations and output it is necessary to edit or write 
scripts in the Lua scripting language (see Lua documentation: 
http://www.lua.org/docs.html). 

There are already some example scripts in the “\scripts” folder as well as example 
templates in the “\templates” folder. The Billing Tool executes the script to 
assign data to the template placeholders. The templates will be rendered as HTML 
and PDF files afterwards.


Load Lua assembly
-----------------
To access the Billing Tool functions and data in Lua scripts, the Lua assembly 
needs to be loaded:

luanet.load_assembly("Paessler.Billingtool")


Available Lua functions
-----------------------

After this step the following functions are available:

SensorChannel([channel_ID]):GetRawSum()
    - Return the total bytes of the selected sensor channel for the specified
      period.
    - The [channel_ID] can to be found in the PRTG web interface under the 
      channels tab in the sensor details view.

SensorChannel([channel_ID]).Name
    - Return the name of the selected sensor channel.
	
SensorChannel([channel_ID]).Id
    - Return the ID of the selected sensor channel.

GetPercentile()
    - Return the calculated percentile value for the spcified period if 
      available.

invoice = GetInvoice()
    - Save the invoice object in the invoice variable to access invoice 
      functions later.
	
invoice:AddItem([name], [value])
    - Add an item to the <#itemtable> placeholder in the template.
    - With style sheets it is possible to customize the layout. Each item is 
      seperated into 2 columns (<td> tags).
    - The columns are accessible via the CSS class "itemkey" for [name] and 
      "itemvalue" for [value].
	  
invoice:SetTotal([totaltext], [totalvalue])
    - Add the total value to the <#itemtable> placeholder in the template.
    - The <tr> tag in the generated HTML file is accessible via the CSS ID 
      "total".
    - Via the CSS class "totalvalue" it is possible to style the <span> tag 
      where the [value] will be visible.


Itemtable HTML
--------------

The following HTML is generated for the <#itemtable> placeholder:

<tr>
    <td class="itemkey">
             [name]
    </td>
    <td class="itemvalue">
             [value]
    </td>
</tr>
<tr id="total">
    <td class="itemkey" >	
             [totaltext]
    </td>
    <td class="itemvalue">
        <span class="totalvalue">[totalvalue]</span>
    </td>
</tr>

