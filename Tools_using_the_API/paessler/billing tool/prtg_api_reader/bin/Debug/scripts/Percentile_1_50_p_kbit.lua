luanet.load_assembly("Paessler.Billingtool")
invoice = GetInvoice()

if GetPercentile() ~= nil then
	percentile = math.ceil(GetPercentile()/1000*8)
	costPerKbit = 1.50
	currency = "$"
	totalCost = percentile * costPerKbit
	
	invoice:AddItem("Percentile", percentile .. "kbit/s");
	invoice:AddItem("Charge per kbit/s", costPerKbit .. currency);
	invoice:SetTotal("Total", totalCost .. currency);
else
	invoice:AddItem("No percentile available", "");
end