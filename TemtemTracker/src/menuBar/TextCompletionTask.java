package menuBar;

import javax.swing.JTextField;
import javax.swing.text.BadLocationException;

public class TextCompletionTask implements Runnable{

	int length;
	String bestMatch;
	JTextField containingTextField;
	
	public TextCompletionTask(int length, String bestMatch, JTextField containingTextField) {
		this.length=length;
		this.bestMatch=bestMatch;
		this.containingTextField=containingTextField;
	}

	@Override
	public void run() {
		try {
			containingTextField.getDocument().insertString(length, bestMatch.substring(length, bestMatch.length()), null);
			containingTextField.setCaretPosition(bestMatch.length());
			containingTextField.moveCaretPosition(length);
		} catch (BadLocationException e) {
			e.printStackTrace();
		}
		
	}

}
