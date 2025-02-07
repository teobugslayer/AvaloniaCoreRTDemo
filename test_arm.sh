#!/bin/bash
rm -f src/packages.lock.json
dotnet publish -r linux-arm -c Release /p:RestoreLockedMode=true
cd src/bin/Release/net9.0/linux-arm/publish 
mv AvaloniaCoreRTDemo AvaloniaCoreRTDemo.bin 
