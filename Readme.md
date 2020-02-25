# Temtem Tracker

Temtem Tracker is a tracker for encountered Temtem based on Optical Character Recognition. 

The tracker: 
* **DOES NOT** read Temtem memory. 
* **DOES NOT** intercept any Client-Server communication. 
* **DOES NOT** send any requests of its own to any server.

The application relies on several dots to identify in-combat and out-of-combat situations. These dots can be seen on the following 2 images:

![OCR Frames and Sampling dots](https://github.com/mculig/TemtemTracker/blob/master/Images/OCR%20Frames%20and%20Sampling%20Dots.png)

![Sampling dots #2](https://github.com/mculig/TemtemTracker/blob/master/Images/Sampling%20Dots.png)

The dots are marked 1-6 and are positioned at a location on the screen determined by the values:

* spotXWidthPercentage
* spotXHeightPercentage

In TemtemTracker/config/config.json

The ARGB values the application tests for can also be found in the config file:

* spotXRGB

The application has been tested to work at 3840x2160, 1920x1080 and 1600x900 resolutions without the need to modify the spot locations in the config file.

The application interface can be seen on the following image: 

![Application Interface](https://github.com/mculig/TemtemTracker/blob/master/Images/window.png)
