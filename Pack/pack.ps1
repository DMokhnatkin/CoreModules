dotnet ./PackPlugin.dll pack.json

Write-Host "Press any key to continue ..."

$x = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")