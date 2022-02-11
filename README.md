# CpfNativeAOT
NativeAOT sample for CPF UI framework (http://cpf.cskin.net/)

Test drive

```
dotnet run --project CpfNativeAOT/CpfNativeAOT.csproj
```

## Linux publishing
```
dotnet publish -c Release -r linux-x64 CpfNativeAOT/CpfNativeAOT.csproj -p:PublishNativeAot=True
```
