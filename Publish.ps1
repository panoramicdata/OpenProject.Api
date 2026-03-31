param(
	[Parameter(Mandatory = $true)]
	[string]$Version
)

$ErrorActionPreference = "Stop"

$projectName = "OpenProject.Api"
$projectPath = "$projectName/$projectName.csproj"
$configuration = "Release"
$outputDir = "nupkgs"

Write-Host "Publishing $projectName v$Version..." -ForegroundColor Cyan

# Clean
if (Test-Path $outputDir) {
	Remove-Item $outputDir -Recurse -Force
}

# Restore
Write-Host "Restoring..." -ForegroundColor Yellow
dotnet restore
if ($LASTEXITCODE -ne 0) { throw "Restore failed" }

# Build
Write-Host "Building..." -ForegroundColor Yellow
dotnet build --configuration $configuration --no-restore
if ($LASTEXITCODE -ne 0) { throw "Build failed" }

# Test
Write-Host "Testing..." -ForegroundColor Yellow
dotnet test --configuration $configuration --no-build --verbosity normal
if ($LASTEXITCODE -ne 0) { throw "Tests failed" }

# Pack
Write-Host "Packing..." -ForegroundColor Yellow
dotnet pack $projectPath --configuration $configuration --no-build --output $outputDir /p:Version=$Version
if ($LASTEXITCODE -ne 0) { throw "Pack failed" }

# Push
Write-Host "Pushing to NuGet..." -ForegroundColor Yellow
$packages = Get-ChildItem "$outputDir/*.nupkg"
foreach ($package in $packages) {
	dotnet nuget push $package.FullName --source https://api.nuget.org/v3/index.json
	if ($LASTEXITCODE -ne 0) { throw "Push failed for $($package.Name)" }
}

Write-Host "Published $projectName v$Version successfully!" -ForegroundColor Green
