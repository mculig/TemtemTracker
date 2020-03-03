package window;

import java.awt.Font;
import java.awt.GridLayout;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;

import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JScrollPane;
import javax.swing.JTable;
import javax.swing.WindowConstants;
import javax.swing.table.DefaultTableCellRenderer;

import config.SettingsWriter;
import config.UserSettings;
import huntingTimeTable.HuntingTable;
import temtemTable.TemtemTable;

public class CounterWindow extends JFrame{

	/**
	 * 
	 */
	private static final long serialVersionUID = -7640040263138297377L;
	
	private JTable table;
	private JTable hTable;
	
	public CounterWindow(UserSettings settings, TemtemTable temtemTable, HuntingTable huntingTable) {

		GridLayout gridLayout = new GridLayout(2,1);
		
		this.setLayout(gridLayout);
		this.setLocation(0, 0);
		this.setSize(settings.mainWindowWidth,settings.mainWindowHeight);
		this.setVisible(true);
		this.setAlwaysOnTop(true);
		this.setTitle("Temtem tracker v1");
		
		this.setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
		
		Font tableFont = new Font("Serif", Font.BOLD, 18);

		
		//Generate a table that shows our temtemTable
		table = new JTable(temtemTable);
		
		//Center all table cells
		DefaultTableCellRenderer centerRenderer = new DefaultTableCellRenderer();
		centerRenderer.setHorizontalAlignment(JLabel.CENTER);
		table.setDefaultRenderer(Integer.class, centerRenderer);
		table.setDefaultRenderer(String.class, centerRenderer);
		
		table.setFont(tableFont);
		table.getTableHeader().setFont(tableFont);
		table.setRowHeight(30);
		
		//Generate a table that shows our stats
		hTable = new JTable(huntingTable);
		
		//Center all table cells
		DefaultTableCellRenderer hTableCenterRenderer = new DefaultTableCellRenderer();
		hTableCenterRenderer.setHorizontalAlignment(JLabel.CENTER);
		hTable.setDefaultRenderer(Integer.class, centerRenderer);
		hTable.setDefaultRenderer(String.class, centerRenderer);
		
		hTable.setFont(tableFont);
		hTable.getTableHeader().setFont(tableFont);
		hTable.setRowHeight(30);
		
		JScrollPane tablePane = new JScrollPane(table);
		JScrollPane hTablePane = new JScrollPane(hTable);
		
		this.add(tablePane);
		this.add(hTablePane);
		this.revalidate();
		this.repaint();
		
		this.addWindowListener(new WindowAdapter() 
		{  
			 @Override
	         public void windowClosing(WindowEvent e)
	          {
				 	settings.mainWindowHeight = e.getWindow().getHeight();
				 	settings.mainWindowWidth = e.getWindow().getWidth();
	                SettingsWriter settingsWriter = new SettingsWriter(settings);
	                settingsWriter.writeSettings();
	          }
		});
		
	}

}
