# Temtem Tracker

Temtem Tracker is a tracker for encountered Temtem based on Optical Character Recognition. 

The tracker: 
* **DOES NOT** read Temtem memory. 
* **DOES NOT** intercept any Client-Server communication. 
* **DOES NOT** send any requests of its own to any server.
* **DOES NOT** automate any part of gameplay
* **DOES NOT** do anything a player couldn't do themselves using pen and paper
* **WILL NOT** get you banned

![Good to go](https://github.com/mculig/TemtemTracker/blob/master/Images/good2go.png)

## Requirements

TemtemTracker V2 requires **Java 13**  and **Visual C++ Redistributable 2017** in order to work. 

Java 13 can be found here : [JAVA 13](https://www.oracle.com/java/technologies/javase-jdk13-downloads.html)

Visual C++ Redistributable 2017 can be downloaded here: 

- [vc_redist.x86.exe (32-bit)](https://aka.ms/vs/16/release/vc_redist.x86.exe)
- [vc_redist.x64.exe (64-bit)](https://aka.ms/vs/16/release/vc_redist.x64.exe) 

OR found here: [Latest supported Visual C++ Downloads](https://support.microsoft.com/en-us/help/2977003/the-latest-supported-visual-c-downloads)

## Releases

#### Current release:

-[TemtemTracker V2](https://github.com/mculig/TemtemTracker/releases/download/V1.2/TemtemTracker_v1.2.rar)

#### Old releases:

-[TemtemTracker V1](https://github.com/mculig/TemtemTracker/releases/download/v1.0/TemtemTracker_v1.rar)
-[TemtemTracker V1.1](https://github.com/mculig/TemtemTracker/releases/download/v1.1/TemtemTracker_v1.1.rar)
-[TemtemTracker V1.2](https://github.com/mculig/TemtemTracker/releases/download/V1.2/TemtemTracker_v1.2.rar)

## Important notes

For the application to work you **MUST NOT** obstruct any of the interface elements used for detection (Spots 1-6 in images below) OR OCR (Frames 1 and 2 in images below)

Currently TemtemTracker is only designed to work on the **main monitor**

## Controls

* Exit: X on application window
* Reset table and timer: F5
* Pause/restart timer: F8

## Update notes

### V1.1

- Added support for different resolutions with different detection spots in the config file

### V1.2

- Modifications to pre-OCR image cleanup code to take into account alpha channel on colors
- This should fix the high false-detection rate in Omninesia

### V2.0

#### New features

- Redesigned interface with new capabilities
- Ability to remove Temtem from tracking list
- Persistence of tracking information across tracker restarts
- Ability to export tracking data in CSV format (Excel, Google Sheets, Open Office/Libre Office Calc)
- Ability to pause/resume timer (F8)
- Remapped table reset to F5 since F5 is more commonly associated with refreshing
- Time to Luma estimates (for 99.99% chance of having encountered a Luma and 50% chance)
- Saipark mode with the ability to adjust Luma rates for 2 Temtem (does not affect Total calculation)
- Support for windowed mode using JNA

#### Bugfixes/optimization

- Further modifications to pre-OCR image cleanup to compensate for white vines in Mines of Mictlan
- Removed unnecessary screenshot re-takes from OCR loop, reducing performance overhead


## How it works

The application relies on several dots to identify in-combat and out-of-combat situations, and 2 Frames to identify Temtem names using OCR. These dots and frames can be seen on the following 2 images:

![OCR Frames and Sampling dots](https://github.com/mculig/TemtemTracker/blob/master/Images/OCR%20Frames%20and%20Sampling%20Dots.png)

![Sampling dots #2](https://github.com/mculig/TemtemTracker/blob/master/Images/Sampling%20Dots.png)

The dots are marked 1-6 and are positioned at a location on the screen determined by the values:

* spotXWidthPercentage
* spotXHeightPercentage

In TemtemTracker/config/config.json

The ARGB values the application tests for can also be found in the config file:

* spotXRGB

The application has been tested to work at 3840x2160, 1920x1080 and 1600x900 resolutions without the need to modify the spot locations in the config file.

The OCR Frames location and dimensions are determined by the values:

* frameXPercentageLeft
* frameXPercentageTop
* frameWidthPercentage
* frameHeightPercentage

The application interface can be seen on the following image: 

![Application Interface](https://github.com/mculig/TemtemTracker/blob/master/Images/window.png)
![Saipark Settings](https://github.com/mculig/TemtemTracker/blob/master/Images/saiparkSettingsWindow.png)

The application tracks Temtem encountered, the number of encounters, the chance of having encountered a Luma of that species and the % that species represents in the total number of Temtem encountered, as well as totals for these values.

The Luma chance is based on the lumaChance value in TemtemTracker/config/config.json

The Window dimensions are saved upon exiting the application and can be found in TemtemTracker/config/userSettings.json

Finally, in order to clean up any artifacts in the OCR output, a string comparison operation is executed using the Temtem names found in TemtemTracker/config/temtemSpecies.json. This will need to be updated with new species when their names are released in order to keep the application reliable.


