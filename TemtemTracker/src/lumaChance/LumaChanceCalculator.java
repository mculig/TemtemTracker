package lumaChance;

public class LumaChanceCalculator {
	
	private double lumaChance;
	
	public LumaChanceCalculator(double lumaChance) {
		this.lumaChance=lumaChance;
	}
	
	public double calculateChance(int encounters) {
		return (1-Math.pow((1-lumaChance), encounters))*100;
	}

}
