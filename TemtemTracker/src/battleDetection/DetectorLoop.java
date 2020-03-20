package battleDetection;

import java.awt.AWTException;
import java.awt.Dimension;
import java.awt.Graphics2D;
import java.awt.Image;
import java.awt.Rectangle;
import java.awt.Robot;
import java.awt.Toolkit;
import java.awt.image.BufferedImage;
import java.awt.image.MultiResolutionImage;

import java.util.ArrayList;
import java.util.List;
import java.util.TimerTask;
import java.util.concurrent.atomic.AtomicBoolean;

import javax.swing.SwingUtilities;

import OCR.OCR;
import config.Config;
import config.ConfigLoader;
import config.ScreenConfig;
import temtemTableUI.TemtemTableUI;
import windowFinder.WindowFinder;


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
	
	//Used to check if the window size changed
	Dimension gameWindowSize = new Dimension(0,0);
	
	//Maximum distance between the color I'm expecting and color from the screen
	private int maxAllowedColorDistance ;
	
	//The window finder
	private WindowFinder windowFinder;
	
	Config config;
	
	private AtomicBoolean detectedBattle;
	
	private TemtemTableUI table;
	
	OCR ocr;
	
	public DetectorLoop(Config config, Dimension size, OCR ocr, TemtemTableUI table) {
		
		this.config = config;
		
		this.spot1RGB = Long.decode(config.spot1RGB);
		this.spot2RGB = Long.decode(config.spot2RGB);
		this.spot3RGB = Long.decode(config.spot3RGB);
		this.spot4RGB = Long.decode(config.spot4RGB);
		this.spot5RGB = Long.decode(config.spot5RGB);
		this.spot6RGB = Long.decode(config.spot6RGB);
		
		this.maxAllowedColorDistance = config.maxAllowedColorDistance;
		
		windowFinder = new WindowFinder();
		
		detectedBattle = new AtomicBoolean(false);
		
		this.ocr = ocr;
		
		this.table = table;
		
	}

	@Override
	public void run() {
		try {
			
			Robot robot = new Robot();
			Rectangle gameWindow = new Rectangle();
			
			//For loading the detection spots
			ScreenConfig screenConfig;
			
			//Local game window size. Is compared to the one stored in the class instance to verify if the size changed
			Dimension gameWindowSize;
			
			//The actual screenshot
			BufferedImage screenShot;
			
			gameWindow = windowFinder.findTemtemWindow(config);
			if(gameWindow == null) {
				//Failed to find window, return
				return;
			}
			
			gameWindowSize = new Dimension(gameWindow.width, gameWindow.height);
			
			if(gameWindowSize != this.gameWindowSize) {
				this.gameWindowSize = gameWindowSize;
				//We haven't found an aspect ratio yet, or the window aspect ratio changed
				screenConfig = ConfigLoader.getConfigForAspectRatio(config.aspectRatios, gameWindowSize);
				
				this.spot1WidthPercentage = screenConfig.spot1WidthPercentage;
				this.spot1HeightPercentage = screenConfig.spot1HeightPercentage;
				
				this.spot2WidthPercentage = screenConfig.spot2WidthPercentage;
				this.spot2HeightPercentage = screenConfig.spot2HeightPercentage;
				
				this.spot3WidthPercentage = screenConfig.spot3WidthPercentage;
				this.spot3HeightPercentage = screenConfig.spot3HeightPercentage;
				
				this.spot4WidthPercentage = screenConfig.spot4WidthPercentage;
				this.spot4HeightPercentage = screenConfig.spot4HeightPercentage;
				
				this.spot5WidthPercentage = screenConfig.spot5WidthPercentage;
				this.spot5HeightPercentage = screenConfig.spot5HeightPercentage;
				
				this.spot6WidthPercentage = screenConfig.spot6WidthPercentage;
				this.spot6HeightPercentage = screenConfig.spot6HeightPercentage;
			}
			
			//Fullscreen screenshot as workaround for createMultiResolutionScreenCapture scaling the image wrong
			Dimension fullScreenSize = Toolkit.getDefaultToolkit().getScreenSize();
			Rectangle fullScreen = new Rectangle(0,0,fullScreenSize.width,fullScreenSize.height);
			
			//Take a screenshot of the actual window region
			MultiResolutionImage mrScreenCap = robot.createMultiResolutionScreenCapture(fullScreen);
			Image nativeResImage;
			List<Image> resVariants = mrScreenCap.getResolutionVariants();
			if(resVariants.size()>1) {
				nativeResImage = resVariants.get(1);
			}
			else {
				nativeResImage = resVariants.get(0);
			}
			//Convert the Image to a BufferedImage
			screenShot = new BufferedImage(nativeResImage.getWidth(null), nativeResImage.getHeight(null), BufferedImage.TYPE_INT_ARGB);
			Graphics2D bGr = screenShot.createGraphics();
			bGr.drawImage(nativeResImage, 0, 0, null);
			bGr.dispose();
			
			//In-battle detection
			int pixel1RGB = screenShot.getRGB(gameWindow.x + (int)Math.ceil(spot1WidthPercentage*gameWindow.width),
					gameWindow.y + (int)Math.ceil(spot1HeightPercentage*gameWindow.height));
			int pixel2RGB = screenShot.getRGB(gameWindow.x + (int)Math.ceil(spot2WidthPercentage*gameWindow.width), 
					gameWindow.y + (int)Math.ceil(spot2HeightPercentage*gameWindow.height));
			int pixel3RGB = screenShot.getRGB(gameWindow.x + (int)Math.ceil(spot3WidthPercentage*gameWindow.width), 
					gameWindow.y + (int)Math.ceil(spot3HeightPercentage*gameWindow.height));
			int pixel4RGB = screenShot.getRGB(gameWindow.x + (int)Math.ceil(spot4WidthPercentage*gameWindow.width), 
					gameWindow.y + (int)Math.ceil(spot4HeightPercentage*gameWindow.height));
			
			//Out-of-battle detection
			int pixel5RGB = screenShot.getRGB(gameWindow.x + (int)Math.ceil(spot5WidthPercentage*gameWindow.width), 
					gameWindow.y + (int)Math.ceil(spot5HeightPercentage*gameWindow.height));
			int pixel6RGB = screenShot.getRGB(gameWindow.x + (int)Math.ceil(spot6WidthPercentage*gameWindow.width), 
					gameWindow.y + (int)Math.ceil(spot6HeightPercentage*gameWindow.height));
			
			if(detectedBattle.get() == false &&
			   ((colorDistance(pixel1RGB, spot1RGB)<maxAllowedColorDistance &&
			   colorDistance(pixel2RGB, spot2RGB)<maxAllowedColorDistance) ||
			   (colorDistance(pixel3RGB, spot3RGB)<maxAllowedColorDistance &&
			   colorDistance(pixel4RGB, spot4RGB)<maxAllowedColorDistance))) {
					
					detectedBattle.set(true);
					ArrayList<String> results = ocr.doOCR(config, screenShot, gameWindow);
					if(results.size()>0) {
						results.forEach(result->{
							SwingUtilities.invokeLater(new Runnable() {

								@Override
								public void run() {
									table.addTemtem(result);
								}
								
							});
							
						});
					}
					
			}
			else if(detectedBattle.get() == true &&
					colorDistance(pixel5RGB, spot5RGB)<maxAllowedColorDistance &&
					colorDistance(pixel6RGB, spot6RGB)<maxAllowedColorDistance)
			{
				detectedBattle.set(false);
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
		
		return distance;
	}

}
