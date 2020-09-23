[Back to Index](Readme.md)

### V4.1

#### New features

- Added Kisiwan Temtem species

#### Bugfixes/optimization

- Fixed deadlock that would sometimes cause the tracker to become unresponsive

#### Known issues

- Font size scaling from primary monitor causes font to be tiny on secondary monitor with higher resolution/different scaling. This is an issue with the underlying framework and can not yet be addressed at this time. 
- False detections/Missed detections are still possible on water encounters with clouds in the background
- On some systems an issue with the VC++ will cause the tracker to crash when detecting Temtem in combat. The root cause seems to lie in the VC++ instalation on on the user's PC, but the exact source is still unknown

### V4.0

#### New features

- Support for Temtem windows in Sandboxie (only default window names with [#] appended and prepended, no sandbox names)
- Statistics Window
- Added Yami (made by Yami) and GracefulKlutz styles

#### Bugfixes/optimization

- Improved error logging level of detail. Now your logs will make it easier for me to help you get the tracker running
- Decreased number of pixels necessary for objects to no longer be recognized as letters, speeding up detection
- Added additional checks to post-OCR, eliminating some sources of false and missed detections
- Fixed coding error that would make Myx undetectable due to the name being too short
- Added shutdown prevention to prevent table.json file corruption due to shutdown happening before the table can be written
- Fixed menu Unpause button not starting Timer back up after autopause
- Fixed 4:3 Aspect Ratio detection spots being wrong
- Fixed detection issues on lake in Citerior Omninesia (still missing spots in 16:3 aspect ratio)
- Fixed Individual Window timer showing 00:00:00 if timer is paused right after tracker is started

#### Known issues

- Font size scaling from primary monitor causes font to be tiny on secondary monitor with higher resolution/different scaling. This is an issue with the underlying framework and can not yet be addressed at this time. 
- False detections/Missed detections are still possible on water encounters with clouds in the background

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

### V3.0

Version 3 is a port to C# with optimizations, rewrites and cleanup

#### New features

- Opacity. Make the tracker transparent and get it out of your way.
- Window Styles. Chose the window design that you like best. Tsukki is my favourite :)
- Visual indication of paused time. See if your timer is paused.
- Hotkey remapping. No longer be at the mercy of my poor choice of hotkeys
- Autosave. PC crashed? No worries! Your tracking data is automatically saved now.
- Save/Load. Want to track multiple things? Save your current table and refresh the timer. Load it later and continue tracking!
- Don't want the tracker showing you caught a Temtem when it was paused? There's an option for that in the settings.
- Sexy icons by Alice (Parou) Peters [alicepeters.de](https://alicepeters.de), [parou.moe](https://parou.moe)
- Added about window with a little info
- Pause and Reset now also show up in menu with shortcuts shown, in case you forget.
- Added error messages for certain problems, you will hopefully never see these :)

#### Bugfixes/optimization

- Severely reduced memory and CPU impact by switching to C#
- Optimizations in detection loop to reduce CPU usage
- Fixed other windows sometimes tricking the tracker due to having Temtem in their names
- Improved detection algorithm now supports low resolutions (tested 720p)
- Better pre-OCR cleanup to minimize false detections

### V2.5

#### Bugfixes/optimization

- Fixed tracker not starting when time spent exceeds Time to Luma due to the expected time being negative

### V2.4

#### Bugfixes/optimization

-Fixed Total no longer working after removing a row from the table and encountering the same Temtem

### V2.3

#### Bugfixes/optimization

-Fixed out of bounds problem with pre-OCR image cleanup that could sometimes occur and stop the tracker from working

### V2.2

#### Bugfixes/optimization

-Fixed possible concurrency issue that may be culprit behind table sometimes no longer updating
-Fixed Temtem/h not being set back to 0 when every temtem has been manually removed from the table

### V2.1

#### Bugfixes/optimization

-Fixed Encountered % not being multiplied by 100

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

### V1.2

- Modifications to pre-OCR image cleanup code to take into account alpha channel on colors
- This should fix the high false-detection rate in Omninesia

### V1.1

- Added support for different resolutions with different detection spots in the config file





