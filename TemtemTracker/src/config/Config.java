package config;

public class Config {

	public double lumaChance;

	// Spots for detecting in-combat status
	// Detects the orange and blue switch Temtem and Wait buttons

	// Detection spot 1
	public double spot1WidthPercentage;
	public double spot1HeightPercentage;
	public String spot1RGB;

	// Detection spot 2
	public double spot2WidthPercentage;
	public double spot2HeightPercentage;
	public String spot2RGB;

	// Detection spot 3
	public double spot3WidthPercentage;
	public double spot3HeightPercentage;
	public String spot3RGB;

	// Detection spot 4
	public double spot4WidthPercentage;
	public double spot4HeightPercentage;
	public String spot4RGB;

	// Spots for detecting out-of combat status
	// Detects 2 spots along the blue border of the minimap

	// Detection spot 5
	public double spot5WidthPercentage;
	public double spot5HeightPercentage;
	public String spot5RGB;

	// Detection spot 6
	public double spot6WidthPercentage;
	public double spot6HeightPercentage;
	public String spot6RGB;

	// Maximum distance between the color I'm expecting and color from the screen
	public int maxAllowedColorDistance;

	// Frame locations for OCR
	public double frame1PercentageLeft;
	public double frame1PercentageTop;
	public double frame2PercentageLeft;
	public double frame2PercentageTop;
	public double frameWidthPercentage;
	public double frameHeightPercentage;

}
