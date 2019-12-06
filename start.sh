mkdir $1
cd $1
dotnet new console
cp -r day1/.vscode/ $1/.vscode
code .