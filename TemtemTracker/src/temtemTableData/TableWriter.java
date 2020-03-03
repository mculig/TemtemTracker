package temtemTableData;

import java.io.FileWriter;
import java.io.IOException;

import com.google.gson.Gson;
import com.google.gson.stream.JsonWriter;

public class TableWriter {
	
	private String tablePath = "./savedData/table.json";
	private TemtemDataTable table;
	
	public TableWriter(TemtemDataTable table) {
		this.table = table;
	}
	
	public void writeTable() {
		Gson gson = new Gson();
		FileWriter fileWriter;
		try {
			fileWriter = new FileWriter(tablePath);
			JsonWriter jsonWriter = new JsonWriter(fileWriter);
			gson.toJson(table, TemtemDataTable.class, jsonWriter);
			jsonWriter.close();
		} catch (IOException e) {
			System.out.println("Failed to write Temtem data table to file!");
			e.printStackTrace();
		}
		
	}

}
