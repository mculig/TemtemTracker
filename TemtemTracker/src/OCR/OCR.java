package OCR;

import java.awt.AWTException;
import java.awt.Dimension;
import java.awt.Point;
import java.awt.Rectangle;
import java.awt.Robot;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;
import java.util.ArrayList;

import javax.imageio.ImageIO;

import config.Config;
import config.ConfigLoader;
import config.ScreenConfig;
import config.Species;
import net.sourceforge.tess4j.Tesseract;
import net.sourceforge.tess4j.TesseractException;
import windowFinder.WindowFinder;

public class OCR{

	private Tesseract tesseract;
	private String language = "eng";
	
	private ArrayList<Rectangle> OCRViewports;
	Species speciesList;
	
	//Frame locations for OCR
	private double frame1PercentageLeft;
	private double frame1PercentageTop;
	private double frame2PercentageLeft;
	private double frame2PercentageTop;
	private double frameWidthPercentage;
	private double frameHeightPercentage;
	
	//Frame size
	private Dimension frameSize;
	
	//Used to check if the window size changed
	Dimension gameWindowSize = new Dimension(0,0);
	
	public OCR(Config config, Species speciesList){
				
		
		this.speciesList = speciesList;
		tesseract = new Tesseract();
		tesseract.setDatapath("./");
		tesseract.setLanguage(language);
	}
	
	//Does the actual OCR operation and puts the generated text in the label
	public ArrayList<String> doOCR(Config config) {
		
		Rectangle gameWindow = WindowFinder.findTemtemWindow(config);
		
		Dimension gameWindowSize = new Dimension(gameWindow.width, gameWindow.height);
		
		if(this.gameWindowSize != gameWindowSize) {
			
			//Only recalculate the aspect ratio and stuff if the window size changes
			
			this.gameWindowSize = gameWindowSize;
			
			ScreenConfig screenConfig = ConfigLoader.getConfigForAspectRatio(config.aspectRatios, gameWindowSize);
			
			this.frame1PercentageLeft = screenConfig.frame1PercentageLeft;
			this.frame1PercentageTop = screenConfig.frame1PercentageTop;
			
			this.frame2PercentageLeft = screenConfig.frame2PercentageLeft;
			this.frame2PercentageTop = screenConfig.frame2PercentageTop;
			
			this.frameWidthPercentage = screenConfig.frameWidthPercentage;
			this.frameHeightPercentage = screenConfig.frameHeightPercentage;
			
			this.frameSize = new Dimension((int) Math.ceil(gameWindowSize.getWidth() * frameWidthPercentage), (int) Math.ceil(gameWindowSize.getHeight() * frameHeightPercentage));
		}
		
		//The frame locations still need to be recalculated since the gameWindow x and y location might change
		
		Point frame1Location = new Point(gameWindow.x + (int) Math.ceil(gameWindowSize.getWidth() * frame1PercentageLeft), gameWindow.y + (int) Math.ceil(gameWindowSize.getHeight() * frame1PercentageTop));
		Point frame2Location = new Point(gameWindow.x + (int) Math.ceil(gameWindowSize.getWidth() * frame2PercentageLeft), gameWindow.y + (int) Math.ceil(gameWindowSize.getHeight() * frame2PercentageTop));
		
		this.OCRViewports = new ArrayList<Rectangle>();
		
		OCRViewports.add(new Rectangle(frame1Location, frameSize));
		OCRViewports.add(new Rectangle(frame2Location, frameSize));
		
		ArrayList<String> results = new ArrayList<String>();
		try {
			Robot robot = new Robot();
			ArrayList<BufferedImage> textCaps = new ArrayList<BufferedImage>();
			for(Rectangle viewport: OCRViewports) {
				textCaps.add(robot.createScreenCapture(viewport));
			}
			for(BufferedImage textCap : textCaps) {
				String text;
				try {
					File outputFile = new File("screenCap" + textCaps.indexOf(textCap) + ".jpg");
					ImageIO.write(textCap, "jpg", outputFile);
					
					processImage(textCap);
					
					outputFile = new File("screenCap_postProc" + textCaps.indexOf(textCap) + ".jpg");
					ImageIO.write(textCap, "jpg", outputFile);
					
					text = tesseract.doOCR(textCap);
					text = text.replaceAll("[^a-zA-Z]", ""); //Remove all characters not a-z or A-Z
					if(text.length()<=3) {
						//Don't do string comparison if the output is empty
						continue;
					}
					System.out.println("OCR reading: " + text);
					text = StringSimilarityComparer.compare(text, speciesList.species);
					results.add(text);
				} catch (TesseractException e) {
					e.printStackTrace();
				} catch (IOException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
			}
		} catch (AWTException e) {
			e.printStackTrace();
		}
		return results;
	}
	
	private void processImage(BufferedImage inputImage){
		int imageHeight = inputImage.getHeight();
		int imageWidth = inputImage.getWidth();
		
		for(int i=0;i<imageWidth;i++) {
			for(int j=0;j<imageHeight;j++) {
				int pixel = inputImage.getRGB(i, j);
				
				if(pixel!=0xFFFFFFFF) {
					inputImage.setRGB(i, j, 0xFFFFFFFF);
				}
				else {
					inputImage.setRGB(i, j, 0xff000000);
				}
			}
		}
	}
	
}
