# MemoryMappedFiles
Just a project I made to learn using MemoryMappedFiles for InterProcess Communication.

![Download Binaries](https://github.com/Glatrix/MemoryMappedFiles/releases/download/v1.0.0/Release.zip)

# Tests:
- C++ to C++
  Run ServerCPP and then ClientCPP
- C++ to C#
  Run ServerCPP and then ClientC#
- C# to C#
  Run ServerC# and then ClientC#
- C# to C++
  Run ServerC# and then ClientC++

Expected Server Message (output in client console):

```Hello Maps!! (From LANG)```

'LANG' will be either C# or C++ depending
on which server you run. But both clients
should read the message the exact same.

