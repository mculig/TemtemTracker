package temtemTable;

public class Percentage {
	
	double percentage;
	
	public void set(double percentage) {
		this.percentage = percentage;
	}
	
	@Override
	public String toString() {
		return String.format("%.2f%%", percentage);
	}

}
