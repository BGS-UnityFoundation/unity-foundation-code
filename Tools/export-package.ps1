# Script para build de um projeto Unity para Android e PC

$UNITY = $env:UNITY_PATH
Write-Output "Exporting package..."

if(!$UNITY){
    Write-Output "UNITY_PATH variable is not setup"
    exit 1
}

Write-Output "Using Unity from: $UNITY"

$PROJECT = Get-Content ./project.json | ConvertFrom-Json
$BUILD_PATH = $PROJECT.build_path
$EXPORT_FOLDERS = $PROJECT.export_folders

$OUTPUT_NAME = $PROJECT.output
$OUTPUT_PATH = "$BUILD_PATH/$OUTPUT_NAME.unitypackage"`

Write-Output "Outputing to: $BUILD_PATH/$OUTPUT_NAME"

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
    Write-Host "Error exporting package"
    exit 1
}
