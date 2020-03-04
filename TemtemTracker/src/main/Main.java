package main;

import java.awt.Dimension;
import java.awt.Toolkit;
import java.util.Timer;

import org.jnativehook.GlobalScreen;
import org.jnativehook.NativeHookException;

import OCR.OCR;
import battleDetection.DetectorLoop;
import config.ConfigLoader;
import keyListener.GlobalKeyListener;
import lumaChance.LumaChanceCalculator;
import temtemTableData.TableReader;
import temtemTableData.TemtemDataTable;
import temtemTableUI.TemtemTableUI;
import window.CounterWindow;

public class Main {

	public static void main(String args[]) {
		
		Dimension screenSize = Toolkit.getDefaultToolkit().getScreenSize();
		
		ConfigLoader loader = new ConfigLoader();
		
		LumaChanceCalculator calculator = new LumaChanceCalculator(loader.getUserSettings(), loader.getConfig().lumaChance);
		
		TableReader tableReader = new TableReader();
		TemtemDataTable dataTable = tableReader.getTable();
		
		TemtemTableUI tableUI = new TemtemTableUI(calculator, dataTable);
		
		Timer testTimer = new Timer();
		DetectorLoop detectorLoop = new DetectorLoop(loader.getConfig(), screenSize, 
				new OCR(loader.getConfig(), loader.getTemtemSpecies()), tableUI);
		testTimer.scheduleAtFixedRate(detectorLoop, 0, 10);
		
		new CounterWindow(loader.getUserSettings(), tableUI);
		
		GlobalKeyListener keyListener = new GlobalKeyListener(tableUI);
		
		
		
		// Create the global key listener for the shortcut keys
		try {
			GlobalScreen.registerNativeHook();
			GlobalScreen.addNativeKeyListener(keyListener);
		} catch (NativeHookException e) {
			e.printStackTrace();
			System.out.println("FATAL: Failed to register hooks for global keyboard shortcuts.");
			System.exit(1); // If we fail to register our hooks the app needs to close
		}

	}

}
