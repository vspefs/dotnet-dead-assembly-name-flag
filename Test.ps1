# Compile C# files
& (Get-Command csc -CommandType Application | Select-Object -First 1).Source On.cs *> $null
& (Get-Command csc -CommandType Application | Select-Object -First 1).Source Off.cs *> $null

# Run original assemblies
Write-Host "For .NET assembly produced by Roslyn:"
& .\On.exe
& .\Off.exe

# Disassemble to IL
& (Get-Command ildasm -CommandType Application | Select-Object -First 1).Source On.exe -out:On.il *> $null
& (Get-Command ildasm -CommandType Application | Select-Object -First 1).Source Off.exe -out:Off.il *> $null

# Reassemble from IL
& (Get-Command ilasm -CommandType Application | Select-Object -First 1).Source On.il -out:On.il.exe *> $null
& (Get-Command ilasm -CommandType Application | Select-Object -First 1).Source Off.il -out:Off.il.exe *> $null

# Run reassembled assemblies
Write-Host "For .NET assembly from IL:"
& .\On.il.exe
& .\Off.il.exe