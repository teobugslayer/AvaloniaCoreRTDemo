#!/bin/bash
dir=${0%/*}
if [ -d "$dir" ]; then
  cd "$dir"
fi
rm -f src/packages.lock.json
dotnet publish -r osx-x64 -c release /p:RestoreLockedMode=true -t:BundleApp --self-contained
rm src/bin/Release/net*/osx-x64/publish/*.icns
strip src/bin/Release/net*/osx-x64/publish/AvaloniaCoreRTDemo.app/Contents/MacOS/AvaloniaCoreRTDemo
rm src/bin/Release/net*/osx-x64/publish/AvaloniaCoreRTDemo.app/Contents/MacOS/*.runtimeconfig.json
rm src/bin/Release/net*/osx-x64/publish/AvaloniaCoreRTDemo.app/Contents/MacOS/*.pdb
rm src/bin/Release/net*/osx-x64/publish/AvaloniaCoreRTDemo.app/Contents/MacOS/*.deps.json
