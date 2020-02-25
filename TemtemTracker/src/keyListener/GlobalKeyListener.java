package keyListener;

import java.util.logging.Level;
import java.util.logging.Logger;
import org.jnativehook.GlobalScreen;
import org.jnativehook.keyboard.NativeKeyEvent;
import org.jnativehook.keyboard.NativeKeyListener;

import huntingTimeTable.HuntingTable;
import temtemTable.TemtemTable;

public class GlobalKeyListener implements NativeKeyListener {
	
	TemtemTable table;
	HuntingTable hTable;
	
	public GlobalKeyListener(TemtemTable table, HuntingTable hTable){
		this.table = table;
		this.hTable = hTable;
		Logger logger = Logger.getLogger(GlobalScreen.class.getPackage().getName());
		logger.setLevel(Level.WARNING);
	}

	@Override
	public void nativeKeyPressed(NativeKeyEvent e) {
		int key = e.getKeyCode();
		switch(key) {
			case NativeKeyEvent.VC_F8:
				table.resetTable();
				hTable.restart();
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
