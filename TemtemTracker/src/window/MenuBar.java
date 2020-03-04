package window;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStreamWriter;

import javax.swing.JFileChooser;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.filechooser.FileFilter;

import org.apache.commons.lang3.time.DurationFormatUtils;

import temtemTableData.TableDataRow;
import temtemTableData.TemtemDataTable;
import temtemTableUI.TemtemTableUI;

public class MenuBar extends JMenuBar{
	
	/**
	 * 
	 */
	private static final long serialVersionUID = -825909454996733736L;
		
	@SuppressWarnings("unused")
	private TemtemTableUI tableUI;

	public MenuBar(TemtemTableUI tableUI) {
		
		this.tableUI=tableUI;
		
		//Create the "File" menu button
		JMenu fileMenu = new JMenu("File");
		//Add "Export" to the "File" menu button
		JMenuItem exportCSV = new JMenuItem("Export");
		exportCSV.addActionListener(new CSVExport(tableUI.getTable()));
		fileMenu.add(exportCSV);
		
		this.add(fileMenu);
		
		this.revalidate();
		this.repaint();
		
	}
	
}

class CSVExport implements ActionListener{
	
	TemtemDataTable table;
	
	public CSVExport(TemtemDataTable table) {
		this.table=table;
	}

	@Override
	public void actionPerformed(ActionEvent e) {
		
		JFileChooser fileChooser = new JFileChooser();
		fileChooser.setDialogTitle("Select location to save CSV file");
		fileChooser.setFileFilter(new FileFilter() {

			@Override
			public boolean accept(File f) {
				String name = f.getName().toLowerCase();
				return name.endsWith(".csv");
			}

			@Override
			public String getDescription() {
				return "CSV files (*.csv)";
			}
			
		});
		
		int userSelection = fileChooser.showSaveDialog(null);
		
		if(userSelection == JFileChooser.APPROVE_OPTION) {
			File fileToSave = new File(fileChooser.getSelectedFile()+".csv");
			try {
				FileOutputStream fos = new FileOutputStream(fileToSave);
				BufferedWriter bw = new BufferedWriter(new OutputStreamWriter(fos));
				bw.write("Temtem,Encounters,Chance Luma,Encountered %");
				bw.newLine();
				for(TableDataRow row : table.rows) {
					bw.write(row.name + "," + row.encountered + "," + row.lumaChance + "," + row.encounteredPercent);
					bw.newLine();
				}
				bw.write(table.total.name + "," + table.total.encountered + "," + table.total.lumaChance + "," + table.total.encounteredPercent);
				bw.newLine();
				bw.write("Time,Temtem/h");
				bw.newLine();
				bw.write(DurationFormatUtils.formatDuration(table.timer.durationTime, "HH:mm:ss") + "," + table.timer.temtemCount/(table.timer.durationTime/(double)3600000));
				bw.newLine();
				bw.close();
			} catch (FileNotFoundException e1) {
				e1.printStackTrace();
			} catch (IOException e1) {
				e1.printStackTrace();
			}
			
		}
	}
	
}