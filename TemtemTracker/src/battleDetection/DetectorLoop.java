package battleDetection;

import java.awt.AWTException;
import java.awt.Dimension;
import java.awt.Rectangle;
import java.awt.Robot;
import java.awt.image.BufferedImage;
import java.util.ArrayList;
import java.util.TimerTask;
import java.util.concurrent.atomic.AtomicBoolean;

import OCR.OCR;
import config.Config;
import temtemTable.TemtemTable;

public class DetectorLoop extends TimerTask{
	
	//Spots for detecting in-combat status
	//Detects the orange and blue switch Temtem and Wait buttons
	
	//The colors could just as well be int since the bit values are important and not the actual values of the integers
	//But Java bitches when parsing something that would overflow into negative integers from a hex string
	//So everything is unnecessarily long. This has no impact on the performance. It's just annoying.
	
	//Detection spot 1
	private double spot1WidthPercentage;
	private double spot1HeightPercentage;
	private long spot1RGB;
	
	//Detection spot 2
	private double spot2WidthPercentage;
	private double spot2HeightPercentage;
	private long spot2RGB;
	
	//Detection spot 3
	private double spot3WidthPercentage;
	private double spot3HeightPercentage;
	private long spot3RGB;
	
	//Detection spot 4
	private double spot4WidthPercentage;
	private double spot4HeightPercentage;
	private long spot4RGB;
	
	//Spots for detecting out-of combat status
	//Detects 2 spots along the blue border of the minimap
	
	//Detection spot 5
	private double spot5WidthPercentage;
	private double spot5HeightPercentage;
	private long spot5RGB;
	
	//Detection spot 6
	private double spot6WidthPercentage;
	private double spot6HeightPercentage;
	private long spot6RGB;
	
	
	//Maximum distance between the color I'm expecting and color from the screen
	private int maxAllowedColorDistance ;
	
	public Rectangle detector1, detector2, detector3, detector4, detector5, detector6;
	
	Config config;
	
	private AtomicBoolean detectedBattle;
	
	private Robot robot;
	
	private TemtemTable table;
	
	OCR ocr;
	
	public DetectorLoop(Config config, Dimension size, OCR ocr, TemtemTable table) {
		
		this.config = config;
		
		this.spot1WidthPercentage = config.spot1WidthPercentage;
		this.spot1HeightPercentage = config.spot1HeightPercentage;
		this.spot1RGB = Long.decode(config.spot1RGB);
		
		this.spot2WidthPercentage = config.spot2WidthPercentage;
		this.spot2HeightPercentage = config.spot2HeightPercentage;
		this.spot2RGB = Long.decode(config.spot2RGB);
		
		this.spot3WidthPercentage = config.spot3WidthPercentage;
		this.spot3HeightPercentage = config.spot3HeightPercentage;
		this.spot3RGB = Long.decode(config.spot3RGB);
		
		this.spot4WidthPercentage = config.spot4WidthPercentage;
		this.spot4HeightPercentage = config.spot4HeightPercentage;
		this.spot4RGB = Long.decode(config.spot4RGB);
		
		this.spot5WidthPercentage = config.spot5WidthPercentage;
		this.spot5HeightPercentage = config.spot5HeightPercentage;
		this.spot5RGB = Long.decode(config.spot5RGB);
		
		this.spot6WidthPercentage = config.spot6WidthPercentage;
		this.spot6HeightPercentage = config.spot6HeightPercentage;
		this.spot6RGB = Long.decode(config.spot6RGB);
		
		this.maxAllowedColorDistance = config.maxAllowedColorDistance;
		
		//In-battle detection
		detector1 = new Rectangle((int)Math.ceil(spot1WidthPercentage*size.width),(int)Math.ceil(spot1HeightPercentage*size.height),1,1);
		detector2 = new Rectangle((int)Math.ceil(spot2WidthPercentage*size.width),(int)Math.ceil(spot2HeightPercentage*size.height),1,1);
		detector3 = new Rectangle((int)Math.ceil(spot3WidthPercentage*size.width),(int)Math.ceil(spot3HeightPercentage*size.height),1,1);
		detector4 = new Rectangle((int)Math.ceil(spot4WidthPercentage*size.width),(int)Math.ceil(spot4HeightPercentage*size.height),1,1);
		
		//Out-of-battle detection
		detector5 = new Rectangle((int)Math.ceil(spot5WidthPercentage*size.width),(int)Math.ceil(spot5HeightPercentage*size.height),1,1);
		detector6 = new Rectangle((int)Math.ceil(spot6WidthPercentage*size.width),(int)Math.ceil(spot6HeightPercentage*size.height),1,1);
		
		detectedBattle = new AtomicBoolean(false);
		
		this.ocr = ocr;
		
		this.table = table;
	}


	@Override
	public void run() {
		try {
			robot = new Robot();
			
			//In-battle detection
			BufferedImage pixel1 = robot.createScreenCapture(detector1);
			BufferedImage pixel2 = robot.createScreenCapture(detector2);
			BufferedImage pixel3 = robot.createScreenCapture(detector3);
			BufferedImage pixel4 = robot.createScreenCapture(detector4);
			
			//Out-of-battle detection
			BufferedImage pixel5 = robot.createScreenCapture(detector5);
			BufferedImage pixel6 = robot.createScreenCapture(detector6);
			
			if(detectedBattle.get() == false &&
			   colorDistance(pixel1.getRGB(0, 0), spot1RGB)<maxAllowedColorDistance &&
			   colorDistance(pixel2.getRGB(0, 0), spot2RGB)<maxAllowedColorDistance &&
			   colorDistance(pixel3.getRGB(0, 0), spot3RGB)<maxAllowedColorDistance &&
			   colorDistance(pixel4.getRGB(0, 0), spot4RGB)<maxAllowedColorDistance) {
					
					detectedBattle.set(true);
					//System.out.println("Detected battle!");
					ArrayList<String> results = ocr.doOCR();
					if(results.size()>0) {
						results.forEach(result->{
							table.addTemtem(result);
						});
					}
					
			}
			else if(detectedBattle.get() == true &&
					colorDistance(pixel5.getRGB(0, 0), spot5RGB)<maxAllowedColorDistance &&
					colorDistance(pixel6.getRGB(0, 0), spot6RGB)<maxAllowedColorDistance)
			{
				detectedBattle.set(false);
				//System.out.println("Detected out-of-battle!");
			}
			
		} catch (AWTException e) {
			e.printStackTrace();
		}
	}
	
	private int colorDistance(int rgb1, long rgb2) {
		int a1 = (0xFF & (rgb1>>24));
		int r1 = (0xFF & (rgb1>>16));
		int g1 = (0xFF & (rgb1>>8));
		int b1 = (0xFF & rgb1);
		
		int a2 = (int)(0xFF & (rgb2>>24));
		int r2 = (int)(0xFF & (rgb2>>16));
		int g2 = (int)(0xFF & (rgb2>>8));
		int b2 = (int)(0xFF & rgb2);
		
		int distance = Math.max((int) Math.pow((r1-r2), 2), (int) Math.pow((r1-r2 - a1+a2),2)) +
			   Math.max((int) Math.pow((g1-g2), 2), (int) Math.pow((g1-g2 - a1+a2),2)) +
			   Math.max((int) Math.pow((b1-b2), 2), (int) Math.pow((b1-b2 - a1+a2),2));
		
		//System.out.println("Color distance: " + distance);
		return distance;
	}

}
