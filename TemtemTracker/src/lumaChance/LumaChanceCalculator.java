package lumaChance;

import config.UserSettings;

public class LumaChanceCalculator {
	
	private UserSettings userSettings;
	private double lumaChance;
	
	public LumaChanceCalculator(UserSettings userSettings, double lumaChance) {
		this.userSettings = userSettings;
		this.lumaChance=lumaChance;
	}
	
	public double calculateChance(int encounters, String temtemName) {
		double lumaChance = saiparkMultiplyer(temtemName);
		return (1-Math.pow((1-lumaChance), encounters));
	}

	//Calculates the time required to get a luma with 0.9999 probability in miliseconds
	public long getTimeToLuma(int encounters, long timeMilis, String temtemName) {
		//This can happen when updating stuff
		if(encounters==0) {
			return 0;
		}
		else if(timeMilis==0) {
			return 0;
		}
		
		double lumaChance = saiparkMultiplyer(temtemName);
		
		//If no 0s sent, calculate this stuff
		double encountersRequired = Math.log(1 - userSettings.timeToLumaProbability)/Math.log(1-lumaChance);
		double milisPerEncounter = timeMilis/(double)encounters;
		long timeRequired = (long) (((long)encountersRequired-encounters)*milisPerEncounter);
		return timeRequired;
	}
	
	private double saiparkMultiplyer(String temtemName) {
		double lumaChance = this.lumaChance;
		if(userSettings.saiparkMode) {
			if(temtemName.equals(userSettings.saiparkTemtem1)) {
				lumaChance *= userSettings.saiparkTemtem1ChanceMultiplyer;
			}
			else if(temtemName.equals(userSettings.saiparkTemtem2)) {
				lumaChance *= userSettings.saiparkTemtem2ChanceMultiplyer;
			}
		}
		return lumaChance;
	}
	
}
