
Write-Host "########################### Clean and create DbJob ... ###########################"
Remove-Item -Path 'C:\Git\MSD\Robot\80_Model\PSGM.Model.DbJob\Migrations' -Recurse -ErrorAction SilentlyContinue -Confirm:$false
Remove-Item -Path 'C:\Git\MSD\Robot\80_Model\PSGM.Model.DbJob\DbJob.db' -ErrorAction SilentlyContinue -Confirm:$false
#Remove-Item -Path 'C:\Git\MSD\Robot\80_Model\PSGM.Model.DbJob\DbJob.db' -ErrorAction SilentlyContinue -Confirm:$false
#Remove-Item -Path 'C:\Git\MSD\Robot\80_Model\PSGM.Model.DbJob\DbJob.db' -ErrorAction SilentlyContinue -Confirm:$false
cd C:\Git\MSD\Robot\80_Model\PSGM.Model.DbJob
dotnet ef migrations add InitialeCreate
dotnet ef database update

cd C:\Git\MSD\Robot\