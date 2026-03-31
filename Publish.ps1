param(
	[Parameter(Mandatory = $true)]
	[string]$Version
)

$ErrorActionPreference = "Stop"

# Check for clean working tree
$status = git status --porcelain
if ($status) {
	throw "Working tree is not clean. Commit or stash changes before publishing.`n$status"
}

# Tag and push
Write-Host "Tagging v$Version..." -ForegroundColor Cyan
git tag $Version
if ($LASTEXITCODE -ne 0) { throw "Failed to create tag $Version" }

Write-Host "Pushing tag $Version..." -ForegroundColor Yellow
git push origin $Version
if ($LASTEXITCODE -ne 0) { throw "Failed to push tag $Version" }

Write-Host "Tag $Version pushed. CI workflow will handle build and publish to NuGet." -ForegroundColor Green
