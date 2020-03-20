package temtemTableUI;

import java.util.TimerTask;

import javax.swing.SwingUtilities;

public class HuntingTimer extends TimerTask{
	
	private HuntingTimerUI timerUI;
	
	public HuntingTimer(HuntingTimerUI timerUI) {
		this.timerUI = timerUI;
	}
	
	@Override
	public void run() {
		SwingUtilities.invokeLater(new Runnable() {
			@Override
			public void run() {
				timerUI.updateTime();
			}
			
		});
		
	}

}
