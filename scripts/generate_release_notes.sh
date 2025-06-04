#!/bin/bash

# --- Configuración ---
RELEASE_NOTES_FILE="env-release-note.md"
MAIN_BRANCH="main"
RELEASE_BRANCH="release"
DEV_BRANCH="dev"

# --- Funciones ---

get_commit_count() {
  local branch=$1
  git rev-list --count "$branch"
}

get_last_commits() {
  local branch=$1
  local count=$2
  git log --pretty=format:"- %h %s (%an, %ad)" --date=short -n "$count" "$branch"
}

# --- Lógica Principal ---

echo "Generando notas de lanzamiento..."

# Asegúrate de estar en la rama de trabajo y de que el historial sea completo
git fetch origin "$MAIN_BRANCH" "$RELEASE_BRANCH" "$DEV_BRANCH"

# Contar commits en cada rama
COMMITS_MAIN=$(get_commit_count "origin/$MAIN_BRANCH")
COMMITS_RELEASE=$(get_commit_count "origin/$RELEASE_BRANCH")
COMMITS_DEV=$(get_commit_count "origin/$DEV_BRANCH")

# Determinar la versión
CURRENT_VERSION="${COMMITS_MAIN}.${COMMITS_RELEASE}.${COMMITS_DEV}"

echo "Versión calculada: $CURRENT_VERSION"

# Obtener los últimos commits para cada sección
echo "Obteniendo últimos commits..."

# Los últimos X commits de 'dev' pueden ser los más relevantes para la sección de 'dev'
# Ajusta el número según cuántos commits recientes quieres mostrar.
# Aquí, por ejemplo, obtenemos los últimos 5 commits de 'dev'
DEV_CHANGES=$(git log --pretty=format:"- %h %s (%an, %ad)" --date=short -n 5 "origin/$DEV_BRANCH")

# Para 'release' y 'main', quizás queramos el último commit o un resumen
RELEASE_LAST_COMMIT=$(git log --pretty=format:"- %h %s (%an, %ad)" --date=short -n 1 "origin/$RELEASE_BRANCH" || echo "No hay commits en release aún.")
MAIN_LAST_COMMIT=$(git log --pretty=format:"- %h %s (%an, %ad)" --date=short -n 1 "origin/$MAIN_BRANCH" || echo "No hay commits en main aún.")

# Crear el contenido de las notas de lanzamiento
echo "# Notas de Lanzamiento" > "$RELEASE_NOTES_FILE"
echo "" >> "$RELEASE_NOTES_FILE"
echo "## Versión: $CURRENT_VERSION" >> "$RELEASE_NOTES_FILE"
echo "" >> "$RELEASE_NOTES_FILE"
echo "Esta versión se basa en los siguientes estados de las ramas principales:" >> "$RELEASE_NOTES_FILE"
echo "" >> "$RELEASE_NOTES_FILE"
echo "### Rama Main (Producción)" >> "$RELEASE_NOTES_FILE"
echo "" >> "$RELEASE_NOTES_FILE"
echo "Último commit en Main:" >> "$RELEASE_NOTES_FILE"
echo "$MAIN_LAST_COMMIT" >> "$RELEASE_NOTES_FILE"
echo "" >> "$RELEASE_NOTES_FILE"
echo "Número total de commits en Main: $COMMITS_MAIN" >> "$RELEASE_NOTES_FILE"
echo "" >> "$RELEASE_NOTES_FILE"
echo "### Rama Release (QA)" >> "$RELEASE_NOTES_FILE"
echo "" >> "$RELEASE_NOTES_FILE"
echo "Último commit en Release:" >> "$RELEASE_NOTES_FILE"
echo "$RELEASE_LAST_COMMIT" >> "$RELEASE_NOTES_FILE"
echo "" >> "$RELEASE_NOTES_FILE"
echo "Número total de commits en Release: $COMMITS_RELEASE" >> "$RELEASE_NOTES_FILE"
echo "" >> "$RELEASE_NOTES_FILE"
echo "### Rama Dev (Desarrollo)" >> "$RELEASE_NOTES_FILE"
echo "" >> "$RELEASE_NOTES_FILE"
echo "Últimos cambios en Dev:" >> "$RELEASE_NOTES_FILE"
echo "$DEV_CHANGES" >> "$RELEASE_NOTES_FILE"
echo "" >> "$RELEASE_NOTES_FILE"
echo "Número total de commits en Dev: $COMMITS_DEV" >> "$RELEASE_NOTES_FILE"
echo "" >> "$RELEASE_NOTES_FILE"

echo "Notas de lanzamiento actualizadas en $RELEASE_NOTES_FILE"