#!/bin/zsh

#################################################################################
# Script for merge project to one exe file
#
# Author: https://github.com/asvol
#
#################################################################################

PLATFORM=v4,"C:\Windows\Microsoft.NET\Framework64\v4.0.30319"
CURR_DIR=$(cd -P -- "$(dirname -- "$0")" && pwd -P)
TOOL_PATH=$CURR_DIR/ILRepack.exe

if [ "$#" -ne 2 ]; then
    echo "Usage: $SCRIPTNAME <SRC> <OUT>"
    exit 3
fi

SRC=$1
OUT=$2

if [ ! -f $SRC ]; then
    echo "Error: File '$SRC' not found!"
    exit 2
fi

if [ ! -f $TOOL_PATH ]; then
    echo "Error: Merge tool '$TOOL_PATH' not found!"
    exit 2
fi

SRC_FOLDER=$(dirname "${SRC}")

$TOOL_PATH /log /wildcards /ndebug /copyattrs /targetplatform:$PLATFORM /out:$OUT $SRC $SRC_FOLDER/*.dll
