Set-Location -Path $PSScriptRoot
cd LolHolmes.Core
dotnet publish -o "$PSScriptRoot/site"
cd $PSScriptRoot/site
Compress-Archive -Path * -DestinationPath ../site.zip -Force
aws sso login --profile AdministratorAccess-482903906816 
cd ..
eb init -p iis lolholmes --region ap-northeast-1 --profile AdministratorAccess-482903906816
eb deploy
# 初回のみ
# eb create lolholmes-env
eb open