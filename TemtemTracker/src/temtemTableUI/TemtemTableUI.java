package temtemTableUI;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.concurrent.atomic.AtomicLong;

import javax.swing.BoxLayout;
import javax.swing.JPanel;

import lumaChance.LumaChanceCalculator;
import temtemTableData.TableDataRow;
import temtemTableData.TableDataRowFactory;
import temtemTableData.TableWriter;
import temtemTableData.TemtemDataTable;
import temtemTableData.TimerData;
import temtemTableData.TotalData;

public class TemtemTableUI extends JPanel {

	/**
	 * 
	 */
	private static final long serialVersionUID = -7136591758870450345L;

	private TemtemDataTable temtemTable;
	private LumaChanceCalculator calculator;
	private HashMap<TableDataRow, TemtemTableRowUI> UIRows;
	private TemtemTableTotalUI total;
	private HuntingTimerUI huntingUI;

	public TemtemTableUI(LumaChanceCalculator calculator, TemtemDataTable table) {
		this.calculator = calculator;
		this.setLayout(new BoxLayout(this, BoxLayout.PAGE_AXIS));

		initializeTable(table);
	}

	public void addTemtem(String name) {
		TableDataRow targetRow = TableDataRowFactory.createNameOnlyRow(name);
		for (TableDataRow row : temtemTable.rows) {
			if (row.name.equals(name)) {
				targetRow = row;
			}
		}
		if (!temtemTable.rows.contains(targetRow)) {
			// If the row isn't in the table, add it
			temtemTable.rows.add(targetRow);
			UIRows.put(targetRow, new TemtemTableRowUI(targetRow, this));
			this.add(UIRows.get(targetRow), 1);
		}
		// Calculate stuff
		temtemTable.total.encountered++;
		temtemTable.total.lumaChance = calculator.calculateChance(temtemTable.total.encountered, temtemTable.total.name);
		temtemTable.total.timeToLuma = calculator.getTimeToLuma(temtemTable.total.encountered, temtemTable.timer.durationTime.get(), temtemTable.total.name);
		targetRow.encountered++;
		targetRow.lumaChance = calculator.calculateChance(targetRow.encountered, targetRow.name);
		targetRow.encounteredPercent = targetRow.encountered / (double) temtemTable.total.encountered;
		targetRow.timeToLuma = calculator.getTimeToLuma(targetRow.encountered, temtemTable.timer.durationTime.get(), targetRow.name);
		UIRows.get(targetRow).update();
		total.update();
		UIRows.forEach((tableRow, UIElement) -> {
			tableRow.encounteredPercent = tableRow.encountered / (double) temtemTable.total.encountered;
			UIElement.update();
		});
		huntingUI.updateCount(temtemTable.total.encountered);
		this.revalidate();
		this.repaint();
	}

	public void removeRow(TableDataRow row) {
		TemtemTableRowUI rowUI = UIRows.get(row);
		// Remove the row from the UI
		this.remove(rowUI);
		// Reduce the total
		temtemTable.total.encountered -= row.encountered;
		// Recalculate Temtem/H
		huntingUI.updateCount(temtemTable.total.encountered);
		// Recalculate total Luma chance
		temtemTable.total.lumaChance = calculator.calculateChance(temtemTable.total.encountered, temtemTable.total.name);
		// Recalculate the encounteredPercent in the table
		temtemTable.rows.forEach(tableRow -> {
			tableRow.encounteredPercent = tableRow.encountered / (double) temtemTable.total.encountered;
			UIRows.get(tableRow).update();
		});
		// Remove the row
		temtemTable.rows.remove(row);
		// Remove the row from the hash map
		UIRows.remove(row);
		// Redraw the panel
		redrawPanel();
	}

	private void redrawPanel() {
		this.removeAll();
		this.add(TemtemTableHeaderUIFactory.createHeaderUI(), 0);
		this.add(new TemtemTableTotalUI(temtemTable.total), 1);
		this.add(huntingUI, 2);
		for (TableDataRow row : temtemTable.rows) {
			this.add(UIRows.get(row), 1);
		}
		this.revalidate();
		this.repaint();
	}

	private void initializeTable(TemtemDataTable table) {
		if (table == null) {
			// No table exists
			temtemTable = new TemtemDataTable();
			// Initialize the table
			temtemTable.rows = new ArrayList<TableDataRow>();
			temtemTable.total = new TotalData();
			temtemTable.total.encountered = 0;
			temtemTable.total.encounteredPercent = 1;
			temtemTable.total.lumaChance = 0;
			temtemTable.timer = new TimerData();
			temtemTable.timer.durationTime = new AtomicLong(0);
		} else {
			temtemTable = table;
		}

		UIRows = new HashMap<TableDataRow, TemtemTableRowUI>();

		total = new TemtemTableTotalUI(temtemTable.total);

		huntingUI = new HuntingTimerUI(temtemTable.timer);

		this.removeAll();

		this.add(TemtemTableHeaderUIFactory.createHeaderUI(), 0);
		this.add(total, 1);
		this.add(huntingUI, 2);

		//Add each table element
		//This can be here since if we create a new table this will be length 0 and do nothing
		for(TableDataRow dataRow : temtemTable.rows) {
			UIRows.put(dataRow, new TemtemTableRowUI(dataRow, this));
			this.add(UIRows.get(dataRow), 1);
		}
		
		this.revalidate();
		this.repaint();
	}

	public void resetTable() {
		// Kill the timer process
		huntingUI.killTimer();
		// Initialize the table anew
		initializeTable(null);
	}

	public void pauseTimer() {
		huntingUI.pauseTimer();
	}

	public void writeTable() {
		TableWriter tableWriter = new TableWriter(temtemTable);
		tableWriter.writeTable();
	}
	
	public TemtemDataTable getTable() {
		return this.temtemTable;
	}
	
	public void recalculateLumaTimes() {
		for(TableDataRow dataRow : temtemTable.rows) {
			dataRow.timeToLuma = calculator.getTimeToLuma(dataRow.encountered, temtemTable.timer.durationTime.get(), dataRow.name);
			UIRows.get(dataRow).update();
		}
		temtemTable.total.timeToLuma = calculator.getTimeToLuma(temtemTable.total.encountered, temtemTable.timer.durationTime.get(), temtemTable.total.name);
		total.update();
	}
	
	public void recalculateLumaChances() {
		for(TableDataRow dataRow : temtemTable.rows) {
			dataRow.lumaChance = calculator.calculateChance(dataRow.encountered, dataRow.name);
			UIRows.get(dataRow).update();
		}
	}

}
