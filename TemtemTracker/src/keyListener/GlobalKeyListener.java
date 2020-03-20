package keyListener;

import java.util.logging.Level;
import java.util.logging.Logger;

import javax.swing.SwingUtilities;

import org.jnativehook.GlobalScreen;
import org.jnativehook.keyboard.NativeKeyEvent;
import org.jnativehook.keyboard.NativeKeyListener;

import temtemTableUI.TemtemTableUI;

public class GlobalKeyListener implements NativeKeyListener {
	
	TemtemTableUI table;
	
	public GlobalKeyListener(TemtemTableUI table){
		this.table = table;
		Logger logger = Logger.getLogger(GlobalScreen.class.getPackage().getName());
		logger.setLevel(Level.WARNING);
	}

	@Override
	public void nativeKeyPressed(NativeKeyEvent e) {
		int key = e.getKeyCode();
		switch(key) {
			case NativeKeyEvent.VC_F5:
				SwingUtilities.invokeLater(new Runnable() {
					@Override
					public void run() {
						table.resetTable();
					}	
				});
				break;
			case NativeKeyEvent.VC_F8:
				SwingUtilities.invokeLater(new Runnable() {
					@Override
					public void run() {
						table.pauseTimer();
					}
				});
				break;
			default:
				//Do nothing
				break;
		}
		
	}

	@Override
	public void nativeKeyReleased(NativeKeyEvent e) {
		// Nothing to do on release
		
	}

	@Override
	public void nativeKeyTyped(NativeKeyEvent e) {
		// Nothing to do on type
		
	}
	
	

}
