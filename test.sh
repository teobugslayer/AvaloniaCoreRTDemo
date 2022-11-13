#!/bin/bash
rm -f src/packages.lock.json
dotnet publish -r linux-x64 -c release /p:RestoreLockedMode=true /p:TrimLink=true --self-contained 
cd src/bin/x64/Release/net7.0/linux-x64/publish 
cp AvaloniaCoreRTDemo AvaloniaCoreRTDemo.bin 
strip AvaloniaCoreRTDemo.bin 
