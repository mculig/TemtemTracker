package menuBar;

import javax.swing.ButtonGroup;
import javax.swing.JCheckBox;
import javax.swing.JLabel;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JPanel;
import javax.swing.JRadioButtonMenuItem;
import javax.swing.JSpinner;
import javax.swing.JTextField;
import javax.swing.KeyStroke;
import javax.swing.SpinnerModel;
import javax.swing.SpinnerNumberModel;
import javax.swing.text.BadLocationException;

import config.Species;
import config.UserSettings;
import temtemTableUI.TemtemTableUI;

public class MenuBar extends JMenuBar {

	/**
	 * 
	 */
	private static final long serialVersionUID = -825909454996733736L;


	public MenuBar(TemtemTableUI tableUI, UserSettings settings, Species species) {

		// Create the "File" menu button
		JMenu fileMenu = new JMenu("File");
		// Add "Export" to the "File" menu button
		JMenuItem exportCSV = new JMenuItem("Export");
		exportCSV.addActionListener(new CSVExport(tableUI.getTable()));
		fileMenu.add(exportCSV);

		// Create the "Settings" menu button
		JMenu settingsMenu = new JMenu("Settings");
		// Add "Luma Time Probability"
		JMenu lumaTimeProbability = new JMenu("Time to Luma   ");
		// Add 99.99% and 50%
		ButtonGroup lumaTimeProbabilityGroup = new ButtonGroup();
		JRadioButtonMenuItem lumaTimeProbability50 = new JRadioButtonMenuItem("for 50%");
		lumaTimeProbabilityGroup.add(lumaTimeProbability50);
		JRadioButtonMenuItem lumaTimeProbability99 = new JRadioButtonMenuItem("for 99.99%");
		lumaTimeProbabilityGroup.add(lumaTimeProbability99);

		if (settings.timeToLumaProbability == 0.5) {
			lumaTimeProbability50.setSelected(true);
		} else {
			settings.timeToLumaProbability = 0.9999;
			lumaTimeProbability99.setSelected(true);
		}

		lumaTimeProbability50.addActionListener(new LumaTimeProbability50Listener(tableUI, settings));
		lumaTimeProbability99.addActionListener(new LumaTimeProbability99Listener(tableUI, settings));

		lumaTimeProbability.add(lumaTimeProbability99);
		lumaTimeProbability.add(lumaTimeProbability50);
		settingsMenu.add(lumaTimeProbability);

		// Add Saipark settings
		JMenu saiparkMenu = new JMenu("Saipark");
		
		//Saipark enable box
		JCheckBox saiparkEnabled = new JCheckBox("Enable Saipark Mode", settings.saiparkMode);

		saiparkEnabled.addActionListener(new SaiparkModeListener(tableUI, settings));
		//End Saipark enable box
		
		
		//Saipark temtem names begin
		JLabel temtem1Label = new JLabel("Temtem 1:");
		JLabel temtem2Label = new JLabel("Temtem 2:");
		JTextField temtem1Name = new JTextField(12);
		JTextField temtem2Name = new JTextField(12);
		SpinnerModel spinnerModel1 = new SpinnerNumberModel(0.0, 0.0, 10, 0.5);
		SpinnerModel spinnerModel2 = new SpinnerNumberModel(0.0, 0.0, 10, 0.5);
		JSpinner temtem1Multiplyer = new JSpinner(spinnerModel1);
		JSpinner temtem2Multiplyer = new JSpinner(spinnerModel2);
		
		temtem1Name.getDocument().addDocumentListener(new TemtemNameChangeListener(species, temtem1Name));
		temtem2Name.getDocument().addDocumentListener(new TemtemNameChangeListener(species, temtem2Name));
		
		temtem1Name.getInputMap().put(KeyStroke.getKeyStroke("ENTER"), "commit");
		temtem1Name.getActionMap().put("commit", new CommitAction(temtem1Name, settings,1));
		
		temtem2Name.getInputMap().put(KeyStroke.getKeyStroke("ENTER"), "commit");
		temtem2Name.getActionMap().put("commit", new CommitAction(temtem1Name, settings,2));
		
		try {
			temtem1Name.getDocument().insertString(0, settings.saiparkTemtem1, null);
			temtem2Name.getDocument().insertString(0, settings.saiparkTemtem2, null);
		} catch (BadLocationException e) {
			e.printStackTrace();
		}
		
		temtem1Multiplyer.setValue(settings.saiparkTemtem1ChanceMultiplyer);
		temtem2Multiplyer.setValue(settings.saiparkTemtem2ChanceMultiplyer);
		
		temtem1Multiplyer.addChangeListener(new TemtemMultiplyerChangeListener(settings,1));
		temtem2Multiplyer.addChangeListener(new TemtemMultiplyerChangeListener(settings,2));
		
		JPanel temtemMenuPanel1 = new JPanel();
		temtemMenuPanel1.add(temtem1Label);
		temtemMenuPanel1.add(temtem1Name);
		temtemMenuPanel1.add(temtem1Multiplyer);
		
		JPanel temtemMenuPanel2 = new JPanel();
		temtemMenuPanel2.add(temtem2Label);
		temtemMenuPanel2.add(temtem2Name);
		temtemMenuPanel2.add(temtem2Multiplyer);
		
		//Saipark temtem names end
		
		saiparkMenu.add(saiparkEnabled);
		saiparkMenu.add(temtemMenuPanel1);
		saiparkMenu.add(temtemMenuPanel2);

		settingsMenu.add(saiparkMenu);

		this.add(fileMenu);
		this.add(settingsMenu);

		this.revalidate();
		this.repaint();

	}

}
