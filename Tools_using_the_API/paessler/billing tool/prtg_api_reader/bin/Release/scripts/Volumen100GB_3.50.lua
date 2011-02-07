luanet.load_assembly("Paessler.Billingtool")
invoice = GetInvoice()

if SensorChannel(1) ~= nil then
	freeVolumeGB = 100
	costPerGB = 3.50
	currency = "$"
	sumGB = math.ceil((SensorChannel(1):GetRawSum()/1024/1024/1024))
	calculateGB = sumGB - freeVolumeGB
	if calculateGB <= 0 then
		calculateGB = 0
	end

	invoice:AddItem(SensorChannel(1).Name  , sumGB .. "GB");
	invoice:AddItem("Free volume"  , freeVolumeGB);
	invoice:AddItem("Each GB over " .. freeVolumeGB, costPerGB .. currency);
	invoice:AddItem(calculateGB .. "GB to pay", calculateGB*costPerGB .. currency);
	invoice:SetTotal("Total", calculateGB*costPerGB .. currency);
else 
	invoice:AddItem("Error: "  , "Channel 1 not available in this type of sensor");
end