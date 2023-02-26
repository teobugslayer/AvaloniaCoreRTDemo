#!/bin/bash 
dir=${0%/*} 
if [ -d "$dir" ]; then 
  cd "$dir" 
fi 
rm -f src/packages.lock.json 
dotnet publish -r osx-x64 -c Release /p:RestoreLockedMode=true -t:BundleApp
rm -rf src/bin/Release/net7.0/osx-x64/publish/Assets/
rm -rf src/bin/Release/net7.0/osx-x64/publish/AvaloniaCoreRTDemo.app/Contents/MacOS/Assets/
rm src/bin/Release/net7.0/osx-x64/publish/AvaloniaCoreRTDemo.app/Contents/MacOS/AvaloniaCoreRTDemo.dwarf