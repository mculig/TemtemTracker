package menuBar;

import java.awt.Dimension;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.Collections;

import javax.swing.JCheckBox;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JSpinner;
import javax.swing.SpinnerModel;
import javax.swing.SpinnerNumberModel;


import config.Species;
import config.UserSettings;
import temtemTableUI.TemtemTableUI;

public class SaiparkSettingsWindow extends JFrame implements ActionListener{

	
	/**
	 * 
	 */
	private static final long serialVersionUID = -1191061631614378767L;
	
	TemtemTableUI tableUI;
	UserSettings settings;
	Species speciesList;

	public SaiparkSettingsWindow(TemtemTableUI tableUI, UserSettings settings, Species speciesList) {
		
		Collections.sort(speciesList.species);
		
		//Saipark enable box
		JCheckBox saiparkEnabled = new JCheckBox("Enable Saipark Mode", settings.saiparkMode);

		saiparkEnabled.addActionListener(new SaiparkModeListener(tableUI, settings));
		//End Saipark enable box
		
		
		//Saipark temtem names begin
		JLabel temtem1Label = new JLabel("Temtem 1:");
		JLabel temtem2Label = new JLabel("Temtem 2:");
		JComboBox<String> temtem1Name = new JComboBox<String>(speciesList.species.toArray(new String[0]));
		JComboBox<String> temtem2Name = new JComboBox<String>(speciesList.species.toArray(new String[0]));
		SpinnerModel spinnerModel1 = new SpinnerNumberModel(0.0, 0.0, 10, 0.5);
		SpinnerModel spinnerModel2 = new SpinnerNumberModel(0.0, 0.0, 10, 0.5);
		JSpinner temtem1Multiplyer = new JSpinner(spinnerModel1);
		JSpinner temtem2Multiplyer = new JSpinner(spinnerModel2);
		
		//Set the initial index
		for(String temtemName : speciesList.species) {
			if(temtemName.equals(settings.saiparkTemtem1)) {
				temtem1Name.setSelectedIndex(speciesList.species.indexOf(temtemName));
			}
			else if(temtemName.equals(settings.saiparkTemtem2)) {
				temtem2Name.setSelectedIndex(speciesList.species.indexOf(temtemName));
			}
		}
		
		temtem1Name.addItemListener(new SaiparkTemtemSelectionListener(tableUI, settings, 1));
		temtem2Name.addItemListener(new SaiparkTemtemSelectionListener(tableUI, settings, 2));
		
		temtem1Multiplyer.setValue(settings.saiparkTemtem1ChanceMultiplyer);
		temtem2Multiplyer.setValue(settings.saiparkTemtem2ChanceMultiplyer);
		
		temtem1Multiplyer.addChangeListener(new TemtemMultiplyerChangeListener(tableUI, settings, 1));
		temtem2Multiplyer.addChangeListener(new TemtemMultiplyerChangeListener(tableUI, settings, 2));
		
		JPanel temtemMenuPanel1 = new JPanel();
		temtemMenuPanel1.add(temtem1Label);
		temtemMenuPanel1.add(temtem1Name);
		temtemMenuPanel1.add(temtem1Multiplyer);
		
		JPanel temtemMenuPanel2 = new JPanel();
		temtemMenuPanel2.add(temtem2Label);
		temtemMenuPanel2.add(temtem2Name);
		temtemMenuPanel2.add(temtem2Multiplyer);
		
		//Saipark temtem names end
		
		
		this.setVisible(false);
		GridLayout layout = new GridLayout(3,1);
		this.setLayout(layout);
		this.setTitle("Saipark settings");
		this.setAlwaysOnTop(true);
		this.setMinimumSize(new Dimension(300,150));
		this.setMaximumSize(new Dimension(300,150));
		this.setResizable(false);
		
		this.add(saiparkEnabled);
		this.add(temtemMenuPanel1);
		this.add(temtemMenuPanel2);
		
		this.setDefaultCloseOperation(JFrame.HIDE_ON_CLOSE);
	}

	@Override
	public void actionPerformed(ActionEvent e) {
		this.setVisible(true);		
	}
	
	
	
}
