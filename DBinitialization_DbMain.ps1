
Write-Host "########################### Clean and create DbMain ... ###########################"
Remove-Item -Path 'C:\Git\MSD\Robot\80_Model\PSGM.Model.DbMain\Migrations' -Recurse -ErrorAction SilentlyContinue -Confirm:$false
Remove-Item -Path 'C:\Git\MSD\Robot\80_Model\PSGM.Model.DbMain\DbMain.db' -ErrorAction SilentlyContinue -Confirm:$false
#Remove-Item -Path 'C:\Git\MSD\Robot\80_Model\PSGM.Model.DbMain\DbMain.db' -ErrorAction SilentlyContinue -Confirm:$false
#Remove-Item -Path 'C:\Git\MSD\Robot\80_Model\PSGM.Model.DbMain\DbMain.db' -ErrorAction SilentlyContinue -Confirm:$false
cd C:\Git\MSD\Robot\80_Model\PSGM.Model.DbMain
dotnet ef migrations add InitialeCreate
dotnet ef database update

cd C:\Git\MSD\Robot\