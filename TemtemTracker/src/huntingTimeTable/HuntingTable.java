package huntingTimeTable;

import java.util.Timer;
import javax.swing.table.AbstractTableModel;

public class HuntingTable extends AbstractTableModel{
	
	/**
	 * 
	 */
	private static final long serialVersionUID = 2390618122694745879L;
	
	
	HuntingTableRow tableRow;
	//Change this when changing column counts and stuff
	private String columnNames[] = {"Time", "Temtem/h"};
	private int columnCount = 2;
	Timer tableTimer;
	
	public HuntingTable() {
		tableRow = new HuntingTableRow();
		tableRow.reset();
		tableTimer = new Timer();
		tableTimer.scheduleAtFixedRate(new HuntingTimer(this), 0, 1000);
		
	}
	
	public void updateTime() {
		tableRow.updateTime();
		this.fireTableDataChanged();
	}
	
	public void updateCount(int temtemCount) {
		tableRow.updateCount(temtemCount);
		this.fireTableDataChanged();
	}
	
	public void restart() {
		tableTimer.cancel();
		tableTimer = new Timer();
		tableRow.reset();
		tableTimer.scheduleAtFixedRate(new HuntingTimer(this), 0, 1000);
	}

	@Override
	public int getColumnCount() {
		return columnCount;
	}
	
	@Override
	public String getColumnName(int col) {
	      return columnNames[col];
	 }

	@Override
	public int getRowCount() {
		return 1;
	}

	@Override
	public Object getValueAt(int row, int col) {
		if(col == 0) {
			return tableRow.time;
		}
		else {
			return tableRow.temtemH;
		}
	}
	
	

}
