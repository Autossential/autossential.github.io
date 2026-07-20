# deploy.ps1
# Script para publicar site gerado pelo Properdocs na branch gh-pages

Write-Host ">> Ativando environment"
.\.venv\Scripts\activate

# Gera o site
Write-Host ">> Gerando site com Properdocs..."
cd source
properdocs build
cd ..

# Troca para a branch gh-pages
Write-Host ">> Mudando para branch gh-pages..."
git checkout gh-pages

# Remove conteúdo antigo
Write-Host ">> Limpando branch gh-pages..."
git rm -rf .

# Copia os arquivos gerados
Write-Host ">> Copiando arquivos do site..."
Copy-Item -Path source\site\* -Destination . -Recurse -Force

# Commit e push
Write-Host ">> Fazendo commit e enviando para GitHub..."
git add .
git commit -m "Deploy docs site"
git push origin gh-pages --force

Write-Host ">> Deploy concluído com sucesso!"

Write-Host ">> Mudando de volta para master..."
git switch master
