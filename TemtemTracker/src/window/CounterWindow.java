package window;

import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;

import javax.swing.BoxLayout;
import javax.swing.JFrame;
import javax.swing.WindowConstants;

import config.SettingsWriter;
import config.UserSettings;
import temtemTableUI.TemtemTableUI;

public class CounterWindow extends JFrame{

	/**
	 * 
	 */
	private static final long serialVersionUID = -7640040263138297377L;
	
	private TemtemTableUI tableUI;
	private MenuBar menuBar;

	public CounterWindow(UserSettings settings, TemtemTableUI tableUI) {
		
		this.setLayout(new BoxLayout(this.getContentPane(), BoxLayout.PAGE_AXIS));
		this.setLocation(0, 0);
		this.setSize(settings.mainWindowWidth,settings.mainWindowHeight);
		this.setVisible(true);
		this.setAlwaysOnTop(true);
		this.setTitle("Temtem tracker v1");
		
		this.setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
		
		this.tableUI = tableUI;
		
		this.menuBar = new MenuBar(tableUI);
		
		this.setJMenuBar(menuBar);
		this.add(this.tableUI);
		
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
	                tableUI.writeTable();
	          }
		});
		
	}

}
