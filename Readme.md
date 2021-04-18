### Scroll to Releases below for download

# TemtemTracker
Temtem Tracker is a tracker for encountered Temtem based on Optical Character Recognition. 

The tracker:  
**DOES NOT** read Temtem memory  
**DOES NOT** intercept any Client-Server communication  
**DOES NOT** send any requests of its own to any server  
**DOES NOT** automate any part of gameplay  
**DOES NOT** do anything a player couldn't do themselves using pen and paper  
**WILL NOT** get you banned

![Good to go](Images/good2go.PNG)

## Table of contents

[Requirements](#requirements)  
[Releases](#releases)  
[Update Notes](#update-notes)  
[Help](#help)

## Requirements

#### Window visibility

For the application to work you must not obstruct any of the interface elements used for detection. These are the Temtem names, minimap and buttons in the bottom row of the game interface that appears during battles.

#### Supported aspect ratios:

- 16:9
- 16:10
- 4:3
- 43:18 (One of 3 aspect ratios marketed as 21:9)
- 64:27 (One of 3 aspect ratios marketed as 21:9)
- 16:3 (still vulnerable to a detection error in omninesia)

#### Minimum supported resolution:

The tracker requires a minimum resolution of 720p or equivalent level of detail at your aspect ratio of choice to be able to detect Temtem reliably.

#### Required software packages:
TemtemTracker requires .NET 4.5.2  and Visual C++ Redistributable 2017 in order to work. 

Windows 10 users most likely already have .NET, as it is part of the Windows 10 Creators Update.

.NET 4.5.2 For Win 8.1 and lower can be found here: [.NET 4.5.2](https://www.microsoft.com/en-us/download/details.aspx?id=42642);

Visual C++ Redistributable 2017 can be downloaded here: 

- [vc_redist.x86.exe (32-bit)](https://aka.ms/vs/16/release/vc_redist.x86.exe)
- [vc_redist.x64.exe (64-bit)](https://aka.ms/vs/16/release/vc_redist.x64.exe) 

OR found here: [Latest supported Visual C++ Downloads](https://support.microsoft.com/en-us/help/2977003/the-latest-supported-visual-c-downloads)

## Releases

#### Current release:

- [TemtemTracker V4.4](https://github.com/mculig/TemtemTracker/releases/download/V4.4/TemtemTracker_v4.4_x64.zip)
- [TemtemTracker V4.4 (32-bit)](https://github.com/mculig/TemtemTracker/releases/download/V4.4/TemtemTracker_v4.4_x86.zip)

#### Old releases:

[Releases](https://github.com/mculig/TemtemTracker/releases)

## Update notes

### V4.4

#### New features

- Added Cipanku Temtem
- This includes an update to the OCR whitelist to include characters 0 and 1 for 0b1 detection. This may potentially reduce accuracy at low resolutions.
- Added 3 pixels of top and bottom padding to table rows. This should hopefully prevent buttons from being cut off at the top
- Added Wiplump Lovers theme

#### Bugfixes/optimization

- Updated Tesseract version to 4.1.1

#### Known issues

- TemtemTracker does not track the changes in odds when chaining encounters using a radar
- Font size scaling from primary monitor causes font to be tiny on secondary monitor with higher resolution/different scaling. This is an issue with the underlying framework and can not yet be addressed at this time. 
- False detections/Missed detections are still possible on water encounters with clouds in the background
- Issue in optical character recognition library causes crash on systems with processors that do not support vector operations. This will be fixed when the fixes are accepted and merged into the library and make it downstream.

#### Update history

[UpdateHistory](UpdateHistory.md)

## Help

Details about the interface, settings and how to make your own styles can be found in the following documents:

[TemtemTracker features](TemtemTrackerFeatures.md)  
[How to: Settings](HowToSettings.md)  
[How to: Styles](HowToStyles.md)
