package lumaChance;

import config.UserSettings;

public class LumaChanceCalculator {
	
	private UserSettings userSettings;
	private double lumaChance;
	
	public LumaChanceCalculator(UserSettings userSettings, double lumaChance) {
		this.userSettings = userSettings;
		this.lumaChance=lumaChance;
	}
	
	public double calculateChance(int encounters) {
		return (1-Math.pow((1-lumaChance), encounters))*100;
	}

	//Calculates the time required to get a luma with 0.9999 probability in miliseconds
	public long getTimeToLuma(int encounters, long timeMilis) {
		//This can happen when updating stuff
		if(encounters==0) {
			return 0;
		}
		else if(timeMilis==0) {
			return 0;
		}
		//If no 0s sent, calculate this stuff
		double encountersRequired = Math.log(1 - userSettings.timeToLumaProbability)/Math.log(1-lumaChance);
		double milisPerEncounter = timeMilis/(double)encounters;
		long timeRequired = (long) (((long)encountersRequired-encounters)*milisPerEncounter);
		return timeRequired;
	}
	
}
