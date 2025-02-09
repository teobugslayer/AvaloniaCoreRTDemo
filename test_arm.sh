#!/bin/bash
rm -f src/packages.lock.json
dotnet publish -r linux-arm -c Release /p:RestoreLockedMode=true /p:LinkerFlavor=lld /p:ObjCopyName=/usr/arm-linux-gnueabihf/bin/objcopy
cd src/bin/Release/net9.0/linux-arm/publish 
mv AvaloniaCoreRTDemo AvaloniaCoreRTDemo.bin 
