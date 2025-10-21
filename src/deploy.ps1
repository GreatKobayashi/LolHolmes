cd LolHolmes.Core

dotnet publish -c Release -o ./publish
cd publish

# ƒfƒvƒƒC
eb deploy --profile lolholmes-prof

Write-Host "Deployment script finished."