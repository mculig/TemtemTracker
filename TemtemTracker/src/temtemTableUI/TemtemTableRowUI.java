package temtemTableUI;

import java.awt.Dimension;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;

import org.apache.commons.lang3.time.DurationFormatUtils;

import temtemTableData.TableDataRow;

public class TemtemTableRowUI extends JPanel{
	
	/**
	 * 
	 */
	private static final long serialVersionUID = -4267571453773283907L;
	
	private static final Integer maxHeight = 25;

	private TableDataRow row;
	private JLabel temtemName;
	private JLabel encounters;
	private JLabel chanceLuma;
	private JLabel encounteredPercent;
	private JLabel timeToLuma;
	private JButton deleteButton;
	
	public TemtemTableRowUI(TableDataRow row, TemtemTableUI tableUI) {
		
		this.row = row;
		
		this.setMaximumSize(new Dimension(Integer.MAX_VALUE, maxHeight));
		
		temtemName = new JLabel(row.name, JLabel.CENTER);
		encounters = new JLabel(row.encountered.toString(), JLabel.CENTER);
		chanceLuma = new JLabel(doublePercentageString(row.lumaChance), JLabel.CENTER);
		encounteredPercent = new JLabel(doublePercentageString(row.encounteredPercent), JLabel.CENTER);
		timeToLuma = new JLabel(DurationFormatUtils.formatDuration(row.timeToLuma, "HH:mm:ss"), JLabel.CENTER);
		deleteButton = new JButton("-");

		deleteButton.addActionListener(new ActionListener() {
		
			@Override
			public void actionPerformed(ActionEvent e) {
				tableUI.removeRow(row);
			}
			
		});
		
		this.setLayout(new GridLayout(1,6));
		
		this.add(temtemName);
		this.add(encounters);
		this.add(chanceLuma);
		this.add(encounteredPercent);
		this.add(timeToLuma);
		this.add(deleteButton);
		
	}

	
	private String doublePercentageString(double percentage) {
		return String.format("%.2f%%", percentage);
	}
	
	public void update() {
		temtemName.setText(row.name);
		encounters.setText(row.encountered.toString());
		chanceLuma.setText(doublePercentageString(row.lumaChance));
		encounteredPercent.setText(doublePercentageString(row.encounteredPercent));
		timeToLuma.setText(DurationFormatUtils.formatDuration(row.timeToLuma, "HH:mm:ss"));
		this.revalidate();
		this.repaint();
	}
}
