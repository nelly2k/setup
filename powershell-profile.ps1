

function awsauth([string]$code) {
    $authResult = aws sts get-session-token --serial-number arn:aws:iam::668744333666:mfa/nellilovchikova --token-code $code | ConvertFrom-Json
    $env:AWS_ACCESS_KEY_ID = $authResult.Credentials.AccessKeyId
    $env:TF_VAR_access_key = $authResult.Credentials.AccessKeyId
    $env:AWS_SECRET_ACCESS_KEY = $authResult.Credentials.SecretAccessKey
    $env:TF_VAR_secret_key = $authResult.Credentials.SecretAccessKey
    $env:AWS_SESSION_TOKEN = $authResult.Credentials.SessionToken
    
    Write-Output "Success"
}

set-alias terrafrom terraform

function gs { git status  }
function rl {  . $profile}

function gitdrop { git checkout -- . }

function bp { 
    cd C:\dev\projects\livehire1\Public\
    yarn run build:local:watch 
}

function lvh {cd c:\dev\projects\livehire1}

# Chocolatey profile
$ChocolateyProfile = "$env:ChocolateyInstall\helpers\chocolateyProfile.psm1"
if (Test-Path($ChocolateyProfile)) {
  Import-Module "$ChocolateyProfile"
}
