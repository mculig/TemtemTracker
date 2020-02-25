package huntingTimeTable;

public class HuntingTableRow {

	public String time="00:00";
	public String temtemH="0.0";
	private int temtemCount=0;
	private long startTime=0;
	private long durationTime=0;
	
	public HuntingTableRow() {
		
	}
	
	public void updateTime(){
		durationTime = System.currentTimeMillis() - startTime;
		long minutes = ( durationTime / 1000 ) / 60;
		long seconds = ( durationTime / 1000 ) % 60;
		time = String.format("%02d:%02d", minutes, seconds);
	}
	
	public void updateCount(int temtemCount) {
		this.temtemCount = temtemCount;
		updateCount();
	}
	
	public void updateCount() {
		temtemH = String.format("%.2f", (temtemCount/((double)durationTime/ 3600000)));
	}
	
	public void reset() {
		time="00:00";
		temtemH="0.0";
		startTime = System.currentTimeMillis();
	}
	
}
