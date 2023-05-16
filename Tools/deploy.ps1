# Formats JSON in a nicer format than the built-in ConvertTo-Json does.
function Format-Json([Parameter(Mandatory, ValueFromPipeline)][String] $json) {
    $spaces = 4
    $indent = 0;
    ($json -Split '\n' |
    ForEach-Object {
        if ($_ -match '[\}\]]') {
            # This line contains  ] or }, decrement the indentation level
            $indent--
        }
        $line = (' ' * $indent * $spaces) + $_.TrimStart().Replace(':  ', ': ')
        if ($_ -match '[\{\[]') {
            # This line contains [ or {, increment the indentation level
            $indent++
        }
        $line
    }) -Join "`n"
}

$VERSION = $args[0]

# Atualizar a versão do project json
$PROJECT_FILE = "./project.json"
$PROJECT = Get-Content $PROJECT_FILE | ConvertFrom-Json
$PROJECT.version = $VERSION
ConvertTo-Json $PROJECT -Depth 100 | Format-Json | Set-Content $PROJECT_FILE

$PACKAGE_FILE = $PROJECT.package_file
$PACKAGE_JSON = Get-Content $PACKAGE_FILE | ConvertFrom-Json
$PACKAGE_JSON.version = $VERSION
ConvertTo-Json $PACKAGE_JSON -Depth 100 | Format-Json | Set-Content $PACKAGE_FILE

$deploy_icon_value = [System.Convert]::toInt32("1f680", 16)
$deploy_icon = ([System.Char]::ConvertFromUtf32($deploy_icon_value))

Write-Output "-------------------------------------------------------------------"
Write-Output ""
Write-Output "$deploy_icon Deploying version $VERSION"
Write-Output ""
Write-Output "-------------------------------------------------------------------"

# Commitar as alterações
git add $PROJECT_FILE $PACKAGE_FILE
git commit -m "$deploy_icon Deployment of version $VERSION"
git tag $VERSION
git push
git push origin $VERSION

& $PSScriptRoot/export-package.ps1