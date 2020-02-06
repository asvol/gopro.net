# gopro.net

Minimal unofficial GoPro HERO 8 API library for .net

# Using 
Before you can connect to the camera, you mast enable WiFi on GoPro and connect to access point. Default ip address of camera is 10.5.5.9.
Tested on Linux (Raspberry PI, Debian, Mono) and Windows (x64, Win7, .NET 4.6).
Solution contain two projects: .net library and console application for testing library and code generation.

## Using library

```csharp

// create camera
IGoProCamera camera = new GoProHero8("10.5.5.9",8080);
// get current camera status
GoProStatus status = await camera.GetStatus(cancel);
// get media file list
MediaList list = await camera.GetMediaList(CancellationToken.None);
// get info about first file in list
MediaItem file = list.Items.First();
// download thumbnail for media file
await camera.DownloadThumbnail(file.Directory,file.Name,"dest_file_path.jpg",CancellationToken.None)
// download media file
await camera.DownloadFile(file.Directory,file.Name,"dest_file_path.MPG",CancellationToken.None)

```

## Using shell cli

By default connection config is --host=10.5.5.9 and --port=8080

```sh
# Download last created media file
asv-gorpo.exe last
# Download last created media file thumbnail
asv-gorpo.exe last --thumbnail
# Show media list
asv-gorpo.exe media
# Download media file by name
asv-gorpo.exe file --name=file.JPG --dir=folder_name
# Set camera mode: Video\Photo\MultiShot
asv-gorpo.exe mode --mode=Video
# Start video recording or take photo
asv-gorpo.exe start
# Stop video recording or take photo
asv-gorpo.exe stop
# Download JSON protocol schema and device info from GoPro
asv-gorpo.exe schema schema.json
# Download status from GoPro and save to the file
asv-gorpo.exe status out.txt

# Generate code from JSON protocol schema (need for code generation)
asv-gorpo.exe schema schema.json status.json
# Generate code from protocol schema, JSON status example, liquid syntax template
cg schema.json status.json csharp.tpl out.cs
```

# Code generation

TL;TD;

# Debug though Raspberry Pi over TCP proxy
[Debug PC]==ethernet==[RaspberryPI]==WiFi==[GoPro HERO8]
```sh
# run proxy at Raspberry PI 
sudo socat TCP-LISTEN:80,fork TCP:10.5.5.9:8080
```
Now you can debug library with PC without WiFi though Raspberry Pi

## Versioning

Project is maintained under [the Semantic Versioning guidelines](http://semver.org/).

Special thanks https://github.com/KonradIT/goprowifihack
