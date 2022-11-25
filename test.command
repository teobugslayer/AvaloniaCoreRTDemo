#!/bin/bash 
dir=${0%/*} 
if [ -d "$dir" ]; then 
  cd "$dir" 
fi 
rm -f src/packages.lock.json 
dotnet publish -r osx-x64 -c release /p:RestoreLockedMode=true -t:BundleApp /p:TrimLink=true --self-contained 
rm -rf src/bin/x64/Release/net7.0/osx-x64/publish/Assets/
strip src/bin/x64/Release/net7.0/osx-x64/publish/AvaloniaCoreRTDemo.app/Contents/MacOS/AvaloniaCoreRTDemo 
rm -rf src/bin/x64/Release/net7.0/osx-x64/publish/AvaloniaCoreRTDemo.app/Contents/MacOS/Assets/
rm src/bin/x64/Release/net7.0/osx-x64/publish/AvaloniaCoreRTDemo.app/Contents/MacOS/AvaloniaCoreRTDemo.runtimeconfig.json 
rm src/bin/x64/Release/net7.0/osx-x64/publish/AvaloniaCoreRTDemo.app/Contents/MacOS/AvaloniaCoreRTDemo.pdb 
rm src/bin/x64/Release/net7.0/osx-x64/publish/AvaloniaCoreRTDemo.app/Contents/MacOS/AvaloniaCoreRTDemo.deps.json 