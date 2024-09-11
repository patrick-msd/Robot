
Write-Host "########################### Clean and create DbStorage ... ###########################"
Remove-Item -Path 'C:\Git\MSD\Robot\80_Model\PSGM.Model.DbStorage\Migrations' -Recurse -ErrorAction SilentlyContinue -Confirm:$false
Remove-Item -Path 'C:\Git\MSD\Robot\80_Model\PSGM.Model.DbStorage\DbStorage.db' -ErrorAction SilentlyContinue -Confirm:$false
#Remove-Item -Path 'C:\Git\MSD\Robot\80_Model\PSGM.Model.DbStorage\DbStorage.db' -ErrorAction SilentlyContinue -Confirm:$false
#Remove-Item -Path 'C:\Git\MSD\Robot\80_Model\PSGM.Model.DbStorage\DbStorage.db' -ErrorAction SilentlyContinue -Confirm:$false
cd C:\Git\MSD\Robot\80_Model\PSGM.Model.DbStorage
dotnet ef migrations add InitialeCreate
dotnet ef database update

cd C:\Git\MSD\Robot\