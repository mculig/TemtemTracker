package temtemTableData;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;

import com.google.gson.Gson;
import com.google.gson.stream.JsonReader;

public class TableReader {
	
	TemtemDataTable table;
	
	private static final String tablePath = "./savedData/table.json";

	public TableReader() {
		Gson gson = new Gson();
		FileReader fileReader;
		try {
			//For existence test
			File test = new File(tablePath);
			if(test.exists() && test.isFile()) {
				fileReader = new FileReader(tablePath);
				JsonReader jsonReader = new JsonReader(fileReader);
				table=gson.fromJson(jsonReader, TemtemDataTable.class);
				jsonReader.close();
			}
			else {
				table=null;
			}
			
		} catch (FileNotFoundException e) {
			System.out.println("Failed to read Temtem table!");
			table=null;
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	public TemtemDataTable getTable() {
		return this.table;
	}
	
}
