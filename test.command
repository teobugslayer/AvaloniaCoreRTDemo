#!/bin/bash
dir=${0%/*}
if [ -d "$dir" ]; then
  cd "$dir"
fi
rm -f src/packages.lock.json
dotnet publish -r osx-x64 -c release /p:RestoreLockedMode=true -t:BundleApp
strip src/bin/Release/net*/osx-x64/publish/AvaloniaCoreRTDemo.app/Contents/MacOS/AvaloniaCoreRTDemo