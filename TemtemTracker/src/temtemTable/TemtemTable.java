package temtemTable;

import java.util.ArrayList;

import javax.swing.table.AbstractTableModel;

import huntingTimeTable.HuntingTable;
import lumaChance.LumaChanceCalculator;

public class TemtemTable extends AbstractTableModel{
	
	/**
	 * 
	 */
	private static final long serialVersionUID = -5349413657376266510L;
	
	private ArrayList<TemtemTableRow> table;
	private LumaChanceCalculator calculator;
	private HuntingTable hTable;
	
	//Change this when changing column counts and stuff
	private String columnNames[] = {"Temtem", "Encounters", "Chance Luma", "Encountered %"};
	private int columnCount = 4;
	
	TemtemTableRow total;
	
	public TemtemTable(LumaChanceCalculator calculator, HuntingTable hTable) {
		table = new ArrayList<TemtemTableRow>();
		this.calculator = calculator;
		this.hTable = hTable;
		//Create a total row and set the encountered Temtem to 0
		this.total = new TemtemTableRow("Total");
		resetTotal();
	}
	
	public void resetTotal() {
		total.encountered = 0;
		total.setLumaChance(calculator.calculateChance(0));
		total.setEncounteredPercent(100);
	}
	
	public double getEncounteredPercent(Integer encountered) {
		return (encountered/(double)total.encountered)*100;
	}
	
	public void addTemtem(String name) {
		if(name.length()<=3) {
			//Safety net for detector finding no matching Temtem. 
			//This will happen if there is only 1 Temtem in a battle.
			return;
		}
		boolean found=false;
		TemtemTableRow temtemRow = new TemtemTableRow(name);
		for(TemtemTableRow row : table) {
			if(row.name==name) {
				temtemRow = row;
				found=true;
			}
		}
		if(!found) {
			table.add(temtemRow);
		}
		temtemRow.encountered++;
		total.encountered++;
		hTable.updateCount(total.encountered);
		temtemRow.setLumaChance(calculator.calculateChance(temtemRow.encountered));
		temtemRow.setEncounteredPercent(getEncounteredPercent(temtemRow.encountered));
		total.setLumaChance(calculator.calculateChance(total.encountered));
		
		//Recalculate all encounter percentages
		for(TemtemTableRow row: table) {
			row.setEncounteredPercent(getEncounteredPercent(row.encountered));
		}
		this.fireTableDataChanged();
	}
	
	public ArrayList<TemtemTableRow> getTemtemList(){
		return this.table;
	}

	@Override
	public int getColumnCount() {
		return columnCount;
	}

	@Override
	public int getRowCount() {
		return table.size()+1;
	}

	@Override
	public Object getValueAt(int row, int col) {
		TemtemTableRow temtemRow;
		if(row>=table.size()) {
			temtemRow = total;
		}
		else {
			temtemRow = table.get(row);
		}
		
		if(col==0) {
			return temtemRow.name;
		}
		else if(col==1) {
			return temtemRow.encountered;
		}
		else if(col==2) {
			return temtemRow.lumaChance;
		}
		else{
			return temtemRow.encounteredPercent;
		}
	}
	
	@Override
	public String getColumnName(int col) {
	      return columnNames[col];
	 }
	
	public Class<?> getColumnClass(int col) {
	      if(col == 0) {
	         return String.class;
	      }
	      else if(col==1) {
	    	 return Integer.class;
	      }
	      else if(col==2) {
	    	 return String.class;
	      }
	      else {
	         return String.class;
	      }
	   }
	
	public void resetTable() {
		this.table.clear();
		resetTotal();
		this.fireTableDataChanged();
	}

}
