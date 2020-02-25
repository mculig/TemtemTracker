package config;

import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;

import com.google.gson.Gson;
import com.google.gson.stream.JsonReader;

public class ConfigLoader {
	
	private String speciesPath = "./config/temtemSpecies.json";
	private String configPath = "./config/config.json";
	private String userSettingsPath = "./config/userSettings.json";
	private Species species;
	private Config config;
	private UserSettings userSettings;
	
	public ConfigLoader(){
			Gson gson = new Gson();
			FileReader fileReader;
			try {
				//Read species
				fileReader = new FileReader(speciesPath);
				JsonReader jsonReader = new JsonReader(fileReader);
				species=gson.fromJson(jsonReader, Species.class);
				jsonReader.close();
			} catch (FileNotFoundException e) {
				System.out.println("FATAL: Failed to load species list! Exiting!");
				System.exit(1);
			} catch (IOException e) {
				e.printStackTrace();
			}
			try {
				fileReader = new FileReader(configPath);
				JsonReader jsonReader = new JsonReader(fileReader);
				config=gson.fromJson(jsonReader, Config.class);
				jsonReader.close();
			} catch (FileNotFoundException e) {
				System.out.println("FATAL: Failed to load config! Exiting!");
				e.printStackTrace();
				System.exit(1);
			} catch (IOException e) {
				e.printStackTrace();
			}
			try {
				fileReader = new FileReader(userSettingsPath);
				JsonReader jsonReader = new JsonReader(fileReader);
				userSettings=gson.fromJson(jsonReader, UserSettings.class);
				jsonReader.close();
			} catch (FileNotFoundException e) {
				System.out.println("FATAL: Failed to load user settings! Exiting!");
				e.printStackTrace();
				System.exit(1);
			} catch (IOException e) {
				e.printStackTrace();
			}
			
	}
	
	public Species getTemtemSpecies(){
		return this.species;
	}
	
	public Config getConfig(){
		return this.config;
	}
	
	public UserSettings getUserSettings() {
		return this.userSettings;
	}

}
