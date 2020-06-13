### Scroll to Releases below for download

# TemtemTracker
Temtem Tracker is a tracker for encountered Temtem based on Optical Character Recognition. 

The tracker:\
**DOES NOT** read Temtem memory\
**DOES NOT** intercept any Client-Server communication\
**DOES NOT** send any requests of its own to any server\
**DOES NOT** automate any part of gameplay\
**DOES NOT** do anything a player couldn't do themselves using pen and paper\
**WILL NOT** get you banned

![Good to go](Images/good2go.PNG)

## Table of contents

[Requirements](#Requirements)\
[Releases](#Releases)\
[Update Notes](#Update-notes)\
[Help](#Help)

## Requirements

#### Window visibility

For the application to work you must not obstruct any of the interface elements used for detection. These are the Temtem names, minimap and buttons in the bottom row of the game interface that appears during battles.

#### Supported aspect ratios:

- 16:9
- 16:10
- 4:3
- 43:18 (One of 3 aspect ratios marketed as 21:9)
- 16:3 (still vulnerable to a detection error in omninesia)

#### Minimum supported resolution:

The tracker requires a minimum resolution of 720p or equivalent level of detail at your aspect ratio of choice to be able to detect Temtem reliably.

#### Required software packages:
TemtemTracker V3 requires .NET 4.5.2  and Visual C++ Redistributable 2017 in order to work. 

Windows 10 users most likely already have .NET, as it is part of the Windows 10 Creators Update.

.NET 4.5.2 For Win 8.1 and lower can be found here: [.NET 4.5.2](https://www.microsoft.com/en-us/download/details.aspx?id=42642);

Visual C++ Redistributable 2017 can be downloaded here: 

- [vc_redist.x86.exe (32-bit)](https://aka.ms/vs/16/release/vc_redist.x86.exe)
- [vc_redist.x64.exe (64-bit)](https://aka.ms/vs/16/release/vc_redist.x64.exe) 

OR found here: [Latest supported Visual C++ Downloads](https://support.microsoft.com/en-us/help/2977003/the-latest-supported-visual-c-downloads)

## Releases

#### Current release:

- [TemtemTracker V3.1](https://github.com/mculig/TemtemTracker/releases/download/V3.1/TemtemTracker_v3.1_x64.zip)
- [TemtemTracker V3.1 (32-bit)](https://github.com/mculig/TemtemTracker/releases/download/V3.1/TemtemTracker_v3.1_x86.zip)

#### Old releases:

[Releases](https://github.com/mculig/TemtemTracker/releases)

## Update notes

### V3.1

#### New features

- Added 16:3 and 4:3 aspect ratios to config
- Added support for multiple Temtem windows/clients running simultaneously
- Added log generation for unhandled crashes
- Added auto-pause feature to settings
- Changed style organization from single file to individual style folders/manifests. This should make it easier to share styles
- Added more robust and informative error handling for styles to support style development
- Added additional options to styles: tableRowButtonBorderColor and toolStripBackground
- Added individual tracking windows, minimalist windows that can be used to track a single Temtem while still keeping an eye on time and temtem/h. 

#### Bugfixes/optimization

- Fixed detection not working monitors other than main monitor

#### Update history

[UpdateHistory](UpdateHistory.md)

## Help

Details about the interface, settings and how to make your own styles can be found in the following documents:

[TemtemTracker features](TemtemTrackerFeatures.md)\
[How to: Settings](HowToSettings.md)\
[How to: Styles](HowToStyles.md)
