package temtemTableUI;

import java.awt.Dimension;
import java.awt.GridLayout;

import javax.swing.JLabel;
import javax.swing.JPanel;

public class TemtemTableHeaderUIFactory {
	
	private static final Integer maxHeight = 25;

	public static JPanel createHeaderUI() {
		JLabel temtemLabel = new JLabel("Temtem", JLabel.CENTER);
		JLabel encountersLabel = new JLabel("Encounters", JLabel.CENTER);
		JLabel chanceLumaLabel = new JLabel("Chance Luma", JLabel.CENTER);
		JLabel encounteredPercentLabel = new JLabel("Encountered %", JLabel.CENTER);
		JLabel deleteLabel = new JLabel("Delete", JLabel.CENTER);
		
		GridLayout layout = new GridLayout(1,5);
		JPanel headerPanel = new JPanel();
		headerPanel.setLayout(layout);
		
		headerPanel.add(temtemLabel);
		headerPanel.add(encountersLabel);
		headerPanel.add(chanceLumaLabel);
		headerPanel.add(encounteredPercentLabel);
		headerPanel.add(deleteLabel);
		
		headerPanel.setMaximumSize(new Dimension(Integer.MAX_VALUE, maxHeight));
		
		return headerPanel;
	}
	
}
