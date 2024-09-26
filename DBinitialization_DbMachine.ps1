
Write-Host "########################### Clean and create DbMachine ... ###########################"
Remove-Item -Path 'C:\Git\MSD\Robot\80_Model\PSGM.Model.DbMachine\Migrations' -Recurse -ErrorAction SilentlyContinue -Confirm:$false
Remove-Item -Path 'C:\Git\MSD\Robot\80_Model\PSGM.Model.DbMachine\DbMachine.db' -ErrorAction SilentlyContinue -Confirm:$false
#Remove-Item -Path 'C:\Git\MSD\Robot\80_Model\PSGM.Model.DbMachine\DbMachine.db' -ErrorAction SilentlyContinue -Confirm:$false
#Remove-Item -Path 'C:\Git\MSD\Robot\80_Model\PSGM.Model.DbMachine\DbMachine.db' -ErrorAction SilentlyContinue -Confirm:$false
cd C:\Git\MSD\Robot\80_Model\PSGM.Model.DbMachine
dotnet ef migrations add InitialeCreate
dotnet ef database update

cd C:\Git\MSD\Robot\