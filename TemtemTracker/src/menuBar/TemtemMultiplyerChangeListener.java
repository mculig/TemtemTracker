package menuBar;

import javax.swing.JSpinner;
import javax.swing.event.ChangeEvent;
import javax.swing.event.ChangeListener;

import config.UserSettings;
import temtemTableUI.TemtemTableUI;

public class TemtemMultiplyerChangeListener implements ChangeListener{

	private TemtemTableUI tableUI;
	private UserSettings settings;
	private int temtemNumber;
	
	public TemtemMultiplyerChangeListener(TemtemTableUI tableUI, UserSettings settings, int temtemNumber) {
		this.tableUI = tableUI;
		this.settings=settings;
		this.temtemNumber=temtemNumber;
	}

	@Override
	public void stateChanged(ChangeEvent e) {
		JSpinner source = ((JSpinner) e.getSource());
		double value = (double) source.getValue();
		System.out.println("Value: " + value);
		if(temtemNumber==1) {
			settings.saiparkTemtem1ChanceMultiplyer = value;
		}
		else {
			settings.saiparkTemtem2ChanceMultiplyer = value;
		}
		tableUI.recalculateLumaTimes();
		tableUI.recalculateLumaChances();
	}

}
