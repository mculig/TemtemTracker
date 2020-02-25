package huntingTimeTable;

import java.util.TimerTask;

public class HuntingTimer extends TimerTask{
	
	private HuntingTable huntingTable;
	
	public HuntingTimer(HuntingTable huntingTable) {
		this.huntingTable = huntingTable;
	}
	
	@Override
	public void run() {
		huntingTable.updateTime();
	}

}
