package temtemTable;

public class TemtemTableRow {
	
	String name;
	Integer encountered;
	Percentage lumaChance;
	Percentage encounteredPercent;
	
	public TemtemTableRow(String name) {
		this.name=name;
		this.encountered = 0;
		this.lumaChance = new Percentage();
		this.encounteredPercent = new Percentage();
	}
	
	public void setLumaChance(double lumaChance) {
		this.lumaChance.set(lumaChance);
	}
	
	public void setEncounteredPercent(double percent) {
		this.encounteredPercent.set(percent);
	}

}
