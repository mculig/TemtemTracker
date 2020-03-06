package windowFinder;

import java.awt.Dimension;
import java.awt.GraphicsDevice;
import java.awt.GraphicsEnvironment;
import java.awt.Rectangle;

import org.apache.commons.lang3.SystemUtils;

import com.sun.jna.Native;
import com.sun.jna.platform.win32.User32;
import com.sun.jna.platform.win32.WinDef;
import com.sun.jna.platform.win32.WinDef.HDC;
import com.sun.jna.platform.win32.WinDef.HWND;
import com.sun.jna.platform.win32.WinDef.POINT;
import com.sun.jna.platform.win32.WinDef.RECT;
import com.sun.jna.platform.win32.WinUser.WINDOWINFO;
import com.sun.jna.win32.StdCallLibrary;

import config.Config;

public class WindowFinder {
	
	private static final int WS_MINIMIZE = 0x20000000;
	private static final String WINDOW_NAME = "Temtem";
	
	//Get the graphics environment. This'll help with multiple screens
	//This will also help with getting the proper resolution on DPI-scaled devices
	GraphicsEnvironment g;
	
	//Size of the main display
	Dimension screenSize;
	
	//Extension of User32 interface to include ClientToScreen since it isn't included in JNA by default
	interface User32Ext extends StdCallLibrary{
		User32Ext INSTANCE = Native.load("user32", User32Ext.class);
		
		boolean ClientToScreen(WinDef.HWND hWnd, WinDef.POINT lpPoint);
	}
	
	public WindowFinder() {
		g = GraphicsEnvironment.getLocalGraphicsEnvironment();
		GraphicsDevice mainScreen = g.getDefaultScreenDevice();
		screenSize = new Dimension(mainScreen.getDisplayMode().getWidth(), mainScreen.getDisplayMode().getHeight());
	}
	
	public Rectangle findTemtemWindow(Config config) {
		
		Dimension gameWindowSize;
		Rectangle gameWindow;
		
		if(config.useJNAWindowCapture && SystemUtils.IS_OS_WINDOWS) {
			
			//If we're on Windows and using JNA
			
			HWND temtemWindow = User32.INSTANCE.FindWindow(null, WINDOW_NAME);
			
			if(temtemWindow == null) {
				//If we can't find Temtem, we return from the loop
				return null;
			}
			
			//Get window info
			WINDOWINFO info = new WINDOWINFO();
			User32.INSTANCE.GetWindowInfo(temtemWindow, info);
			
			if((info.dwStyle & WS_MINIMIZE) == WS_MINIMIZE) {
				//Window is minimized, return null
				return null;
			}
			
			HWND focused = User32.INSTANCE.GetForegroundWindow();
			
			if(focused!= null && !focused.equals(temtemWindow)) {
				//Temtem isn't the focused window
				return null;
			}
			
			//Get the window display device context
			HDC hdcWindow = User32.INSTANCE.GetDC(temtemWindow);
			
			//Get the window location and dimensions
			RECT bounds = new RECT();
			POINT lpPoint = new POINT();
			User32.INSTANCE.GetClientRect(temtemWindow, bounds);
			User32Ext.INSTANCE.ClientToScreen(temtemWindow, lpPoint);
			
			gameWindowSize = new Dimension(bounds.right, bounds.bottom);
			
			gameWindow = new Rectangle(lpPoint.x,lpPoint.y, gameWindowSize.width, gameWindowSize.height);
			
			//Release the device context
			User32.INSTANCE.ReleaseDC(temtemWindow, hdcWindow);
		}
		else {
			//Use the full screen for the capture
			gameWindowSize = screenSize;
			gameWindow = new Rectangle(0,0,gameWindowSize.width, gameWindowSize.height);
		}
		
		//If the game is outside of the screen to the left or top
		if(gameWindow.x<0 || gameWindow.y<0) {
			return null;
		}
		
		//If the game is outside of the screen to the right or bottom
		if(gameWindow.x + gameWindow.width > screenSize.width || gameWindow.y + gameWindow.height > screenSize.height) {
			return null;
		}
		
		
		return gameWindow;
	}

}
