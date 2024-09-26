
Write-Host "########################### Clean and create DbSoftware ... ###########################"
Remove-Item -Path 'C:\Git\MSD\Robot\80_Model\PSGM.Model.DbSoftware\Migrations' -Recurse -ErrorAction SilentlyContinue -Confirm:$false
Remove-Item -Path 'C:\Git\MSD\Robot\80_Model\PSGM.Model.DbSoftware\DbSoftware.db' -ErrorAction SilentlyContinue -Confirm:$false
#Remove-Item -Path 'C:\Git\MSD\Robot\80_Model\PSGM.Model.DbSoftware\DbSoftware.db' -ErrorAction SilentlyContinue -Confirm:$false
#Remove-Item -Path 'C:\Git\MSD\Robot\80_Model\PSGM.Model.DbSoftware\DbSoftware.db' -ErrorAction SilentlyContinue -Confirm:$false
cd C:\Git\MSD\Robot\80_Model\PSGM.Model.DbSoftware
dotnet ef migrations add InitialeCreate
dotnet ef database update

cd C:\Git\MSD\Robot\