package menuBar;

import javax.swing.ButtonGroup;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JRadioButtonMenuItem;

import config.UserSettings;
import temtemTableUI.TemtemTableUI;

public class MenuBar extends JMenuBar{
	
	/**
	 * 
	 */
	private static final long serialVersionUID = -825909454996733736L;
		
	@SuppressWarnings("unused")
	private TemtemTableUI tableUI;

	public MenuBar(TemtemTableUI tableUI, UserSettings settings) {
		
		this.tableUI=tableUI;
		
		//Create the "File" menu button
		JMenu fileMenu = new JMenu("File");
		//Add "Export" to the "File" menu button
		JMenuItem exportCSV = new JMenuItem("Export");
		exportCSV.addActionListener(new CSVExport(tableUI.getTable()));
		fileMenu.add(exportCSV);
		
		//Create the "Settings" menu button
		JMenu settingsMenu = new JMenu("Settings");
		//Add "Luma Time Probability"
		JMenu lumaTimeProbability = new JMenu("Time to Luma   ");
		//Add 99.99% and 50%
		ButtonGroup lumaTimeProbabilityGroup = new ButtonGroup();
		JRadioButtonMenuItem lumaTimeProbability50 = new JRadioButtonMenuItem("for 50%");
		lumaTimeProbabilityGroup.add(lumaTimeProbability50);
		JRadioButtonMenuItem lumaTimeProbability99 = new JRadioButtonMenuItem("for 99.99%");
		lumaTimeProbabilityGroup.add(lumaTimeProbability99);
		
		if(settings.timeToLumaProbability==0.5) {
			lumaTimeProbability50.setSelected(true);
		}
		else
		{
			settings.timeToLumaProbability=0.9999;
			lumaTimeProbability99.setSelected(true);
		}
		
		lumaTimeProbability50.addActionListener(new LumaTimeProbability50Listener(tableUI, settings));
		lumaTimeProbability99.addActionListener(new LumaTimeProbability99Listener(tableUI, settings));
		
		lumaTimeProbability.add(lumaTimeProbability99);
		lumaTimeProbability.add(lumaTimeProbability50);
		settingsMenu.add(lumaTimeProbability);
		
		
		this.add(fileMenu);
		this.add(settingsMenu);
		
		this.revalidate();
		this.repaint();
		
	}
	
}

