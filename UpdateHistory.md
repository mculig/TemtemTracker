<<<<<<< HEAD
### V2.4

#### Bugfixes/optimization

-Fixed Total no longer working after removing a row from the table and encountering the same Temtem

=======
>>>>>>> 78327aa6ce86d65975789a6a2dfa92b7651e1f1f
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









