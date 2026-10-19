; Frcistan 0.1 kurulum dosyası (Inno Setup 6)
; Visual Studio'da projeye sağ tık > Yayımla > FolderProfile dediğinizde
; bu dosya otomatik derlenir ve kurulum-cikti\Frcistan-0.1-Kurulum.exe oluşur.
; (Elle derlemek için: önce yayımlayın, sonra bunu Inno Setup'ta açıp Compile.)

[Setup]
AppId={{6E2B6C1D-3F2A-4E8B-9C5A-0F1A2B3C4D51}
AppName=Frcistan
AppVersion=0.1
AppVerName=Frcistan 0.1
AppPublisher=İlyas Enes Sepetci
DefaultDirName={autopf}\Frcistan 0.1
DefaultGroupName=Frcistan
; Yönetici izni gerekmesin; kullanıcı isterse tüm kullanıcılar için kurabilsin.
PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=dialog
OutputDir=..\kurulum-cikti
OutputBaseFilename=Frcistan-0.1-Kurulum
Compression=lzma2
SolidCompression=yes
WizardStyle=modern
; logo: kurulum dosyasının simgesi ve sihirbazdaki resimler (ekran ölçeğine göre uygun boyut seçilir)
SetupIconFile=..\frcistan.ico
WizardImageFile=sihirbaz-100.bmp,sihirbaz-125.bmp,sihirbaz-150.bmp,sihirbaz-175.bmp,sihirbaz-200.bmp,sihirbaz-250.bmp
WizardSmallImageFile=sihirbaz-kucuk-100.bmp,sihirbaz-kucuk-125.bmp,sihirbaz-kucuk-150.bmp,sihirbaz-kucuk-175.bmp,sihirbaz-kucuk-200.bmp,sihirbaz-kucuk-250.bmp
; hoş geldiniz sayfası açık olsun ki büyük resim başta da görünsün
DisableWelcomePage=no
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible
UninstallDisplayIcon={app}\Frcistan.exe

[Languages]
Name: "turkish"; MessagesFile: "compiler:Languages\Turkish.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"

[Files]
Source: "..\publish\Frcistan.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\veritabani.sql"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\README.md"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\Frcistan 0.1"; Filename: "{app}\Frcistan.exe"
Name: "{group}\{cm:UninstallProgram,Frcistan 0.1}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\Frcistan 0.1"; Filename: "{app}\Frcistan.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\Frcistan.exe"; Description: "{cm:LaunchProgram,Frcistan 0.1}"; Flags: nowait postinstall skipifsilent
