#!/bin/zsh

#################################################################################
# Script for fix nuget package path in .chproj files
# Need for the correct work with git submodules projects
#
# For example   <HintPath>..\..\packages\<NUGET_PACKAGE>.dll</HintPath>
#								||
#								\/
# 				<HintPath>$(SolutionDir)packages\<NUGET_PACKAGE>.dll</HintPath>
#
# Author: https://github.com/asvol
#
#################################################################################

# Input argument: path to .chproj file


if [ "$#" -ne 1 ]; then
    echo "Usage: fix_nuget_path.sh <FILE_PATH>"
    exit 3
fi

FILE_PATH=$1

if [ ! -f $FILE_PATH ]; then
    echo "Error: File '$FILE_PATH' not found!"
    exit 2
fi

echo "Fix nuget path: $FILE_PATH"

sed -r -i "s|(<HintPath>)(.*)(packages.*</HintPath>)|\1\$(SolutionDir)\3|g" $FILE_PATH


exit 0
