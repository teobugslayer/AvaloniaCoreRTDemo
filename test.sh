#!/bin/bash
rm -f src/packages.lock.json
dotnet publish -r linux-x64 -c release /p:RestoreLockedMode=true
