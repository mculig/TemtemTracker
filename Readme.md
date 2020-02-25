# Temtem Tracker

Temtem Tracker is a tracker for encountered Temtem based on Optical Character Recognition. 

The tracker: 
* **DOES NOT** read Temtem memory. 
* **DOES NOT** intercept any Client-Server communication. 
* **DOES NOT** send any requests of its own to any server.
* **DOES NOT** automate any part of gameplay
* **DOES NOT** do anything a player couldn't do themselves using pen and paper

## Controls

* Exit: X on application window
* Reset timer: F8 

## Releases

[TemtemTracker V1](https://github.com/mculig/TemtemTracker/releases/download/v1.0/TemtemTracker_v1.rar)

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

The application tracks Temtem encountered, the number of encounters, the chance of having encountered a Luma of that species and the % that species represents in the total number of Temtem encountered, as well as totals for these values.

The Luma chance is based on the lumaChance value in TemtemTracker/config/config.json

The Window dimensions are saved upon exiting the application and can be found in TemtemTracker/config/userSettings.json

Finally, in order to clean up any artifacts in the OCR output, a string comparison operation is executed using the Temtem names found in TemtemTracker/config/temtemSpecies.json. This will need to be updated with new species when their names are released in order to keep the application reliable.


