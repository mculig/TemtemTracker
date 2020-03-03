package temtemTableUI;

import java.util.TimerTask;

public class HuntingTimer extends TimerTask{
	
	private HuntingTimerUI timerUI;
	
	public HuntingTimer(HuntingTimerUI timerUI) {
		this.timerUI = timerUI;
	}
	
	@Override
	public void run() {
		timerUI.updateTime();
	}

}
