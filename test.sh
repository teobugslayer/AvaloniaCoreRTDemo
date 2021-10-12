#!/bin/bash
rm -f src/packages.lock.json
dotnet publish -r linux-x64 -c release /p:RestoreLockedMode=true
cd src/bin/Release/net*/linux-x64/publish
cp AvaloniaCoreRTDemo AvaloniaCoreRTDemo.bin
strip AvaloniaCoreRTDemo.bin
