Write-Host ">> Preparando ambiente virtual"
uv sync
.\.venv\Scripts\activate
Start-Sleep -Milliseconds 500

# Gera o site
Write-Host ">> Gerando site com Properdocs..."
cd source
properdocs build
cd ..
Start-Sleep -Milliseconds 500

# Troca para a branch gh-pages
Write-Host ">> Mudando para branch gh-pages..."
git checkout gh-pages
Start-Sleep -Milliseconds 500

# Remove conteúdo antigo
Write-Host ">> Limpando branch gh-pages..."
git rm -rf .
Start-Sleep -Milliseconds 500

# Copia os arquivos gerados
Write-Host ">> Copiando arquivos do site..."
Copy-Item -Path .\source\site\* -Destination . -Recurse -Force
Start-Sleep -Milliseconds 500

# Commit e push
Write-Host ">> Fazendo commit e enviando para GitHub..."
git add .
git commit -m "Deploy docs site"
git push origin gh-pages --force
Start-Sleep -Milliseconds 500

Write-Host ">> Deploy concluído com sucesso!"
git switch master
