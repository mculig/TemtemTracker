[Back to readme](Readme.md)

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





