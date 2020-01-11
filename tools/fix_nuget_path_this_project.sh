#!/bin/zsh

CURR_DIR=$(cd -P -- "$(dirname -- "$0")" && pwd -P)

find ./ -name "*.csproj" -exec ${CURR_DIR}/fix_nuget_path.sh {} \;

