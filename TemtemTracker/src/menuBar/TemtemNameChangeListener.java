package menuBar;

import javax.swing.JTextField;
import javax.swing.SwingUtilities;
import javax.swing.event.DocumentEvent;
import javax.swing.event.DocumentListener;
import javax.swing.text.BadLocationException;
import javax.swing.text.Document;

import org.apache.commons.lang3.StringUtils;

import config.Species;

public class TemtemNameChangeListener implements DocumentListener{

	Species species;
	JTextField containingTextField;
	
	public TemtemNameChangeListener(Species species, JTextField containingTextField) {
		this.species = species;
		this.containingTextField = containingTextField;
	}

	//These two only need to point towards changed
	@Override
	public void insertUpdate(DocumentEvent e) {
		changedUpdate(e);
	}

	@Override
	public void removeUpdate(DocumentEvent e) {
		//changedUpdate(e);
	}

	@Override
	public void changedUpdate(DocumentEvent e) {
		if(e.getLength()!= 1) {
			return;
		}
		Document doc = e.getDocument();
		String text;
		try {
			text=doc.getText(0, doc.getLength());
			text=StringUtils.capitalize(text);
			String bestMatch=null;
			for(String temtem : species.species) {
				if(temtem.startsWith(text)) {
					bestMatch = temtem;
					break;
				}
			}
			if(bestMatch!=null) {
				SwingUtilities.invokeLater(new TextCompletionTask(text.length(), bestMatch, containingTextField));
			}
			
		} catch (BadLocationException e1) {
			e1.printStackTrace();
		}
	}

}


