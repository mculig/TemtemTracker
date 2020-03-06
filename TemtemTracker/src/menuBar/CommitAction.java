package menuBar;

import java.awt.event.ActionEvent;

import javax.swing.AbstractAction;
import javax.swing.JTextField;

import org.apache.commons.lang3.StringUtils;

import config.UserSettings;

public class CommitAction extends AbstractAction {

	/**
	 * 
	 */
	private static final long serialVersionUID = -8303208750844033688L;

	private JTextField textField;
	private UserSettings settings;
	private int temtemNumber;

	public CommitAction(JTextField textField, UserSettings settings, int temtemNumber) {
		this.textField = textField;
		this.settings = settings;
		this.temtemNumber = temtemNumber;
	}

	@Override
	public void actionPerformed(ActionEvent e) {
		textField.setCaretPosition(textField.getSelectionEnd());
		textField.setText(StringUtils.capitalize(textField.getText()));
		if(temtemNumber == 1) {
			settings.saiparkTemtem1 = textField.getText();
		}
		else {
			settings.saiparkTemtem2 = textField.getText();
		}
		
	}

}
