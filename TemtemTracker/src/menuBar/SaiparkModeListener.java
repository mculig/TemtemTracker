package menuBar;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JCheckBox;

import config.UserSettings;
import temtemTableUI.TemtemTableUI;

public class SaiparkModeListener implements ActionListener{
	
	UserSettings settings;
	TemtemTableUI tableUI;
	
	public SaiparkModeListener(TemtemTableUI tableUI, UserSettings settings) {
		this.tableUI = tableUI;
		this.settings = settings;
	}

	@Override
	public void actionPerformed(ActionEvent e) {
		JCheckBox box = (JCheckBox) e.getSource();
		settings.saiparkMode=box.isSelected();
		tableUI.recalculateLumaTimes();
		tableUI.recalculateLumaChances();
	}

	
}
