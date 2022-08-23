# TemtemTracker

### Scroll to Releases below for download
### Update V4.5 with Arbury species can be found down below

### Farewell

Dear Reader,

Over time I have grown more and more disenchanted with Crema and their approach to handling things, starting with a point where I disclosed what I felt was a serious issue and got treated in a way I do not feel was ok. Having experienced this, I started asking myself some hard questions about how they were doing things, how they were treating players, and also about where I myself stood in that whole. 

From where I stand right now, it is obvious that the way they handled many of their players was wrong, and that the way I steadfastly supported them was also wrong. Many conversations that maybe could have been had in a less shutdown-happy environment should have been had and would have made for a better game in the long term. For my participation on the wrong side of many of these debates, I can now only apologize.

Despite no longer wanting to support Crema, I still wished to complete the final list of Temtem species in the tracker as a matter of personal principle and my own desire to "complete" a project that started out of love for a game and studio, but also afterwards grew to become something I cared about for its own sake. A project I am proud to have made and shared with so many of you.

It is my hope that TemtemTracker will be able to continue operating long into the future, and should any game changes result in the tracker breaking, that this open source repository will provide others with all the resources they need to embark upon their own forks/updates OR entirely new trackers that they themselves make in a similar fashion.

Farewell,
Silber

## TemtemTracker
Temtem Tracker is a tracker for encountered Temtem based on Optical Character Recognition. 

The tracker:  
**DOES NOT** read Temtem memory  
**DOES NOT** intercept any Client-Server communication  
**DOES NOT** send any requests of its own to any server  
**DOES NOT** automate any part of gameplay  
**DOES NOT** do anything a player couldn't do themselves using pen and paper  
**WILL NOT** get you banned

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

- [TemtemTracker V4.5](https://github.com/mculig/TemtemTracker/releases/download/V4.5/TemtemTracker_v4.5_x64.zip)
- [TemtemTracker V4.5 (32-bit)](https://github.com/mculig/TemtemTracker/releases/download/V4.5/TemtemTracker_v4.5_x86.zip)

#### Old releases:

[Releases](https://github.com/mculig/TemtemTracker/releases)

## Update notes

### V4.5

#### New features

- Added Arbury species

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
