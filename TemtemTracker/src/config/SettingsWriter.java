package config;

import java.io.FileWriter;
import java.io.IOException;

import com.google.gson.Gson;
import com.google.gson.stream.JsonWriter;

public class SettingsWriter {
	
	private String userSettingsPath = "./config/userSettings.json";
	private UserSettings userSettings;
	
	public SettingsWriter(UserSettings userSettings) {
		this.userSettings = userSettings;
	}
	
	public void writeSettings() {
		Gson gson = new Gson();
		FileWriter fileWriter;
		try {
			fileWriter = new FileWriter(userSettingsPath);
			JsonWriter jsonWriter = new JsonWriter(fileWriter);
			gson.toJson(userSettings, UserSettings.class, jsonWriter);
			jsonWriter.close();
		} catch (IOException e) {
			System.out.println("Failed to write user settings to file!");
			e.printStackTrace();
		}
		
	}

}
