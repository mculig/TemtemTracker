package OCR;

import java.awt.Dimension;
import java.awt.Point;
import java.awt.Rectangle;
import java.awt.image.BufferedImage;

import java.util.ArrayList;
import java.util.HashMap;




import config.Config;
import config.ConfigLoader;
import config.ScreenConfig;
import config.Species;
import net.sourceforge.tess4j.Tesseract;
import net.sourceforge.tess4j.TesseractException;

public class OCR {

	private Tesseract tesseract;
	private String language = "eng";

	private ArrayList<Rectangle> OCRViewports;
	Species speciesList;

	// Frame locations for OCR
	private double frame1PercentageLeft;
	private double frame1PercentageTop;
	private double frame2PercentageLeft;
	private double frame2PercentageTop;
	private double frameWidthPercentage;
	private double frameHeightPercentage;

	// Frame size
	private Dimension frameSize;

	// Used to check if the window size changed
	Dimension gameWindowSize = new Dimension(0, 0);

	// Maximum distance an R, G or B subpixel max be from FF, used to determine what
	// is white for pre-OCR image cleanup
	int maxOCRSubpixelFFDistance;

	public OCR(Config config, Species speciesList) {

		this.speciesList = speciesList;
		tesseract = new Tesseract();
		tesseract.setDatapath("./tessdata/");
		tesseract.setLanguage(language);
		tesseract.setTessVariable("user_defined_dpi", "72");

		this.maxOCRSubpixelFFDistance = config.maxOCRSubpixelFFDistance;
	}

	// Does the actual OCR operation and puts the generated text in the label
	public ArrayList<String> doOCR(Config config, BufferedImage screenShot, Rectangle gameWindow) {

		Dimension gameWindowSize = new Dimension(gameWindow.width, gameWindow.height);

		if (this.gameWindowSize != gameWindowSize) {

			// Only recalculate the aspect ratio and stuff if the window size changes

			this.gameWindowSize = gameWindowSize;

			ScreenConfig screenConfig = ConfigLoader.getConfigForAspectRatio(config.aspectRatios, gameWindowSize);

			this.frame1PercentageLeft = screenConfig.frame1PercentageLeft;
			this.frame1PercentageTop = screenConfig.frame1PercentageTop;

			this.frame2PercentageLeft = screenConfig.frame2PercentageLeft;
			this.frame2PercentageTop = screenConfig.frame2PercentageTop;

			this.frameWidthPercentage = screenConfig.frameWidthPercentage;
			this.frameHeightPercentage = screenConfig.frameHeightPercentage;

			this.frameSize = new Dimension((int) Math.ceil(gameWindowSize.getWidth() * frameWidthPercentage),
					(int) Math.ceil(gameWindowSize.getHeight() * frameHeightPercentage));
		}

		// The frame locations still need to be recalculated since the gameWindow x and
		// y location might change

		Point frame1Location = new Point(
				gameWindow.x + (int) Math.ceil(gameWindowSize.getWidth() * frame1PercentageLeft),
				gameWindow.y + (int) Math.ceil(gameWindowSize.getHeight() * frame1PercentageTop));
		Point frame2Location = new Point(
				gameWindow.x + (int) Math.ceil(gameWindowSize.getWidth() * frame2PercentageLeft),
				gameWindow.y + (int) Math.ceil(gameWindowSize.getHeight() * frame2PercentageTop));

		this.OCRViewports = new ArrayList<Rectangle>();

		OCRViewports.add(new Rectangle(frame1Location, frameSize));
		OCRViewports.add(new Rectangle(frame2Location, frameSize));

		ArrayList<String> results = new ArrayList<String>();
		ArrayList<BufferedImage> textCaps = new ArrayList<BufferedImage>();

		for (Rectangle viewport : OCRViewports) {
			textCaps.add(screenShot.getSubimage(viewport.x, viewport.y, viewport.width, viewport.height));
		}
		for (BufferedImage textCap : textCaps) {
			String text;
			try {

				// processImage(textCap);
				processImage(textCap);

				text = tesseract.doOCR(textCap);

				text = text.replaceAll("[^a-zA-Z]", ""); // Remove all characters not a-z or A-Z
				if (text.length() <= 3) {
					// Don't do string comparison if the output is empty
					continue;
				}
				text = StringSimilarityComparer.compare(text, speciesList.species);
				results.add(text);
			} catch (TesseractException e) {
				e.printStackTrace();
			} 
		}
		return results;
	}

	private void processImage(BufferedImage inputImage) {
		int imageHeight = inputImage.getHeight();
		int imageWidth = inputImage.getWidth();
		
		int[][] pixels=new int[imageWidth][imageHeight]; 
		int[][] whiteMask=new int[imageWidth][imageHeight];

		for (int i = 0; i < imageWidth; i++) {
			for (int j = 0; j < imageHeight; j++) {
				int pixel = inputImage.getRGB(i, j);

				pixels[i][j]=pixel;
				
				if (testWhite(pixel)) {
					whiteMask[i][j]=0xFF000000;
				} else {
					whiteMask[i][j]=0xFFFFFFFF;
				}
			}	
		}
		
		//Scan along the middle of the image
		int scanningLine = imageHeight / 2;
		
		//We're going to identify letters using a DB-scan like method.
		//Initial points will be black pixels along the middle of the image
		//Pixels will join them in a cluster if they're black too.
		//Anything not part of this cluster is noise and gets removed
		
		int pixelID = 0;
		HashMap<Integer,Integer> pixelMap = new HashMap<Integer,Integer>();
		
		//Populate the pixelMap with pixelIDs and pixel locations along the scanning line
		for(int i=0; i < imageWidth; i++) {
			if(whiteMask[i][scanningLine]==0xFF000000) {
				pixelMap.put(pixelID++, i);
			}
		}
		
		//For each pixel in the IDs we'll set the whiteMask to RED and keep doing that for neighbouring pixels
		for(int PixelID : pixelMap.keySet()) {
			int pixelI = pixelMap.get(PixelID);
			
			if(whiteMask[pixelI][scanningLine]==0xFFFF0000) {
				//We've already marked this pixel as a part of a middle cluster
				continue;
			}
			//Run the recursive check on this pixel
			recursivePixelCheck(pixelI, scanningLine, whiteMask, imageHeight, imageWidth);
		}
		
		//Set red pixels to black and rest to white
		for(int i=0; i < imageWidth; i++) {
			for(int j=0; j < imageHeight; j++) {
				if(whiteMask[i][j]==0xFFFF0000) {
					whiteMask[i][j]=0xFF000000;
				}
				else {
					whiteMask[i][j]=0xFFFFFFFF;
				}
			}
		}
		
		for(int i=0; i<imageWidth;i++) {
			for(int j=0;j< imageHeight;j++) {
				inputImage.setRGB(i, j, whiteMask[i][j]);
			}
		}
		
	}
	
	private void recursivePixelCheck(int i, int j, int[][] whiteMask,int imageHeight, int imageWidth) {
		//Check if we're out of bounds
		//This should never happen as text is central to the image and should never have an uninterrupted
		//tendril of black pixels connecting it to the edges, but it's good practice to check
		if(i>imageWidth || j>imageHeight) {
			return;
		}
		if(i<0 || j<0) {
			return;
		}
		//If a pixel is already red, we've done it
		if(whiteMask[i][j]==0xFFFF0000) {
			return;
		}
		else if(whiteMask[i][j]==0xFFFFFFFF) {
			//If the pixel is white, we're not interested in its neighbours
			return;
		}
		else {
			//Mark the pixel red;
			whiteMask[i][j]=0xFFFF0000;
			for(int iOffset : new int[] {-1,1}) {
				for(int jOffset : new int[] {-1,1}) {
					//Do the recursive check on nearby pixels
					recursivePixelCheck(i+iOffset,j+jOffset,whiteMask, imageHeight, imageWidth);
				}
			}
		}
	}
	
	private boolean testWhite(int pixel) {

		// Test the pixel isn't transparent
		if ((pixel & 0xFF000000) != 0xFF000000) {
			return false;
		}

		// Test the maximum difference from 255 of a color
		if ((0xFF - (pixel >> 16 & 0xFF)) > maxOCRSubpixelFFDistance) {
			return false;
		} else if ((0xFF - (pixel >> 8 & 0xFF)) > maxOCRSubpixelFFDistance) {
			return false;
		} else if ((0xFF - (pixel & 0xFF)) > maxOCRSubpixelFFDistance) {
			return false;
		}

		return true;
	}

}
