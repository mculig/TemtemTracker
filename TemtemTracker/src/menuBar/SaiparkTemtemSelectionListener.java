package menuBar;

import java.awt.event.ItemEvent;
import java.awt.event.ItemListener;

import config.UserSettings;
import temtemTableUI.TemtemTableUI;

public class SaiparkTemtemSelectionListener implements ItemListener{

	private TemtemTableUI tableUI;
	private UserSettings settings;
	private int temtemNumber;
	
	public SaiparkTemtemSelectionListener(TemtemTableUI tableUI, UserSettings settings, int temtemNumber) {
		this.tableUI = tableUI;
		this.settings = settings;
		this.temtemNumber = temtemNumber;
	}

	@Override
	public void itemStateChanged(ItemEvent e) {
		if(e.getStateChange() == ItemEvent.SELECTED) {
			String item = (String) e.getItem();
			if(temtemNumber==1) {
				settings.saiparkTemtem1 = item;
			}
			else {
				settings.saiparkTemtem2 = item;
			}
			tableUI.recalculateLumaTimes();
			tableUI.recalculateLumaChances();
		}
	}

}
