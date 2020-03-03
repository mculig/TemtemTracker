package temtemTableUI;

import java.awt.Dimension;
import java.awt.GridLayout;

import javax.swing.JLabel;
import javax.swing.JPanel;

import temtemTableData.TotalData;

public class TemtemTableTotalUI extends JPanel {

	/**
	 * 
	 */
	private static final long serialVersionUID = -8157109289098412802L;
	
	private static final Integer maxHeight = 25;

	private TotalData total;
	private JLabel temtemName;
	private JLabel encounters;
	private JLabel chanceLuma;
	private JLabel encounteredPercent;

	public TemtemTableTotalUI(TotalData total) {
		
		this.setMaximumSize(new Dimension(Integer.MAX_VALUE, maxHeight));

		this.total = total;

		temtemName = new JLabel(total.name, JLabel.CENTER);
		encounters = new JLabel(total.encountered.toString(), JLabel.CENTER);
		chanceLuma = new JLabel(doublePercentageString(total.lumaChance), JLabel.CENTER);
		encounteredPercent = new JLabel(doublePercentageString(total.encounteredPercent), JLabel.CENTER);

		this.setLayout(new GridLayout(1, 5));

		this.add(temtemName);
		this.add(encounters);
		this.add(chanceLuma);
		this.add(encounteredPercent);
		this.add(new JLabel());
	}

	private String doublePercentageString(double percentage) {
		return String.format("%.2f%%", percentage*100);
	}
	
	public void update() {
		encounters.setText(total.encountered.toString());
		chanceLuma.setText(doublePercentageString(total.lumaChance));
		this.revalidate();
		this.repaint();
	}

}
