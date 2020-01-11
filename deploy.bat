SET BASH_PATH=%SYSTEMDRIVE%\Users\%USERNAME%\.babun\cygwin\bin\
SET PATH=%PATH%;%BASH_PATH%

rsync -r -v ./bin/publish/* pi@10.10.5.233:~/
