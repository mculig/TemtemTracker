package temtemTableUI;

import java.awt.Dimension;
import java.awt.GridLayout;
import java.util.Timer;

import javax.swing.JLabel;
import javax.swing.JPanel;

import org.apache.commons.lang3.time.DurationFormatUtils;

import temtemTableData.TimerData;


public class HuntingTimerUI extends JPanel{

	/**
	 * 
	 */
	private static final long serialVersionUID = -5791308640216893658L;
	
	private static final Integer maxHeight = 50;
	
	public String time="00:00";
	public String temtemH="0.0";

	private JLabel timeTitleLabel;
	private JLabel timeLabel;
	private JLabel temtemHTitleLabel;
	private JLabel temtemHLabel;
	
	private Timer tableTimer;
	
	private TimerData timerData;
	
	public HuntingTimerUI(TimerData timerData) {
		timeTitleLabel = new JLabel("Time",JLabel.CENTER);
		timeLabel = new JLabel(time, JLabel.CENTER);
		temtemHTitleLabel = new JLabel("Temtem/h", JLabel.CENTER);
		temtemHLabel = new JLabel(temtemH, JLabel.CENTER);
		
		this.timerData = timerData;
		
		GridLayout layout = new GridLayout(2,1);
		
		this.setLayout(layout);
		
		this.setMaximumSize(new Dimension(Integer.MAX_VALUE, maxHeight));
		
		JPanel titlePanel = new JPanel();
		titlePanel.setLayout(new GridLayout(1,5));
		
		titlePanel.add(timeTitleLabel);
		titlePanel.add(temtemHTitleLabel);
		//Empty placeholder panels
		titlePanel.add(new JPanel());
		titlePanel.add(new JPanel());
		titlePanel.add(new JPanel());
		
		JPanel dataPanel = new JPanel();
		dataPanel.setLayout(new GridLayout(1,5));
		dataPanel.add(timeLabel);
		dataPanel.add(temtemHLabel);
		//Empty placeholder panels
		dataPanel.add(new JPanel());
		dataPanel.add(new JPanel());
		dataPanel.add(new JPanel());

		this.add(titlePanel);
		this.add(dataPanel);
		
		this.revalidate();
		this.repaint();
		
		createTimer();
		
		refreshDisplay();
	}
	
	private void updateTimeDisplay() {
		time = DurationFormatUtils.formatDuration(timerData.durationTime, "HH:mm:ss");
		timeLabel.setText(time);
		this.revalidate();
		this.repaint();
	}
	
	private void refreshDisplay() {	
		updateTimeDisplay();
		updateCount();
	}
	
	public void updateTime(){
		
		timerData.durationTime += 1000;
		updateTimeDisplay();
	}
	
	public void updateCount(int temtemCount) {
		timerData.temtemCount = temtemCount;
		updateCount();
	}
	
	public void updateCount() {
		if(timerData.temtemCount!=0 && timerData.durationTime!=0) {
			temtemH = String.format("%.2f", (timerData.temtemCount/((double)timerData.durationTime/ 3600000)));
			temtemHLabel.setText(temtemH);
		}
		
		this.revalidate();
		this.repaint();
	}
	
	public void reset() {
		time="00:00";
		temtemH="0.0";
		timerData.durationTime = 0;
		
		timeLabel.setText(time);
		temtemHLabel.setText(temtemH);
		
		this.revalidate();
		this.repaint();
	}
	
	private void createTimer() {
		tableTimer = new Timer();
		tableTimer.scheduleAtFixedRate(new HuntingTimer(this), 1000, 1000);
	}
	
	public void killTimer() {
		if(tableTimer!=null) {
			tableTimer.cancel();
		}
	}
	
	public void pauseTimer() {
		if(tableTimer == null) {
			createTimer();
		} else {
			tableTimer.cancel();
			tableTimer = null;
		}
		
	}
}
