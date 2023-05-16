# Script para build de um projeto Unity para Android e PC

$PROJECT_FILE = "./project.json"
$UNITY = $env:UNITY_PATH

Write-Output ""
Write-Output "Exporting package..."

if (!$UNITY) {
    Write-Error "[ERROR] UNITY_PATH variable is not setup"
    exit 1
}

Write-Output ""
Write-Output "Using Unity from: $UNITY"

$PROJECT = Get-Content $PROJECT_FILE | ConvertFrom-Json
$VERSION = $PROJECT.version
$OUTPUT_NAME = $PROJECT.unity_package.name
$BUILD_PATH = $PROJECT.unity_package.path
$EXPORT_FOLDERS = $PROJECT.unity_package.export_folders

$OUTPUT_PATH = "$BUILD_PATH/$OUTPUT_NAME-$VERSION.unitypackage"`

Write-Output ""
Write-Output "Project "
Write-Output "Name: $OUTPUT_NAME"
Write-Output "Version: $VERSION"
Write-Output "Outputing to: $OUTPUT_PATH"
Write-Output ""

& "$UNITY" `
    -batchmode `
    -projectPath "." `
    -logFile ".\$BUILD_PATH\exporting.log" `
    -exportPackage $EXPORT_FOLDERS $OUTPUT_PATH `
    -quit `
| Out-Null

# Verificar se o build para Android foi concluído com sucesso
if ($LASTEXITCODE -eq 0) {
    Write-Host "Export successfully"
}
else {
    Write-Error "[Error] exporting package"
    exit 1
}
