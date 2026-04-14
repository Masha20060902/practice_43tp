[Setup]
AppName=DocumentVersion
AppVersion=1.0
DefaultDirName={pf}\DocumentVersion
DefaultGroupName=DocumentVersion
OutputDir=.\InstallerOutput
OutputBaseFilename=DocumentVersionSetup

[Files]
Source: "Output\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs

[Icons]
Name: "{group}\DocumentVersion"; Filename: "{app}\DocumentVersion.exe"

[Run]
Filename: "{app}\DocumentVersion.exe"; Description: "Запустить приложение"; Flags: nowait postinstall skipifsilent
