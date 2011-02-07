// Volume based bill.
//
// Monthly fee 80€
// Volume free 100GB
// after each GB 2.50€
//
// Pseudo code:

billTraffic = 0

if Sensor has Traffic then
	if Traffic > 100 then
		billTraffic = Traffic - 100
	end if
	
	InvoiceAmount = 80 + (2.50 * billTraffic)
	
	InvoiceItem.Add("Traffic Sum: ", Traffic)
	InvoiceItem.Add("Free Traffic: ", 100)
	InvoiceItem.Add("Traffic to bill: ", billTraffic)
	
	SelectCurrency("€")
	
end if