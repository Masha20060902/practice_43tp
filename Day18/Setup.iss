[Setup]
AppName=Task
AppVersion=1.0
DefaultDirName={pf}\Task
DefaultGroupName=Task
OutputDir=.\InstallerOutput
OutputBaseFilename=TaskSetup

[Files]
Source: "Output\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs

[Icons]
Name: "{group}\Task"; Filename: "{app}\Task.exe"

[Run]
Filename: "{app}\Task.exe"; Description: "Запустить приложение"; Flags: nowait postinstall skipifsilent
