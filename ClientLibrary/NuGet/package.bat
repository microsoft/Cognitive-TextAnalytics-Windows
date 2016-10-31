set packageSourceDir=PackageSource
if not exist %packageSourceDir% (mkdir %packageSourceDir%)
"C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe" "..\Microsoft.ProjectOxford.Text\Microsoft.ProjectOxford.Text.csproj" /p:Configuration=Release
nuget pack "..\Microsoft.ProjectOxford.Text\Microsoft.ProjectOxford.Text.csproj" -OutputDirectory %packageSourceDir%
explorer %packageSourceDir%
timeout /t -1