#!/bin/bash
rm -f src/packages.lock.json
dotnet publish -r linux-x64 -c Release /p:RestoreLockedMode=true
cd src/bin/Release/net7.0/linux-x64/publish 
cp AvaloniaCoreRTDemo AvaloniaCoreRTDemo.bin 
