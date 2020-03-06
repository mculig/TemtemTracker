package menuBar;

import javax.swing.JSpinner;
import javax.swing.event.ChangeEvent;
import javax.swing.event.ChangeListener;

import config.UserSettings;

public class TemtemMultiplyerChangeListener implements ChangeListener{

	UserSettings settings;
	int temtemNumber;
	
	public TemtemMultiplyerChangeListener(UserSettings settings, int temtemNumber) {
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
	}

}
