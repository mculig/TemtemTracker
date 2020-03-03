package temtemTableData;

public class TableDataRowFactory {
	
	public static TableDataRow createNameOnlyRow(String name){
		TableDataRow row = new TableDataRow();
		row.name = name;
		row.encountered = 0;
		return row;
	}

}
