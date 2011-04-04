using System;
using UnityEngine;

namespace MuUI
{
	public class PasswordBox : TextBox
	{
		public char MaskCharacter { get; set; }
		
		public PasswordBox() : this('*')
		{
		}
		
		public PasswordBox(char maskCharacter) : this(maskCharacter, int.MaxValue)
		{
		}
		
		public PasswordBox(char maskCharacter, int maxLength)
		{
			MaskCharacter = maskCharacter;
			MaxLength = maxLength;
		}
		
		protected override void OnLayout()
		{
			int initial = GUIUtility.keyboardControl;
			BeforeText();
			SetText(GUILayout.PasswordField(TextProperty.Value, MaskCharacter, MaxLength, Style, LayoutOptions));
			AfterText(initial);
		}
		
		protected override void OnGui()
		{
			int initial = GUIUtility.keyboardControl;
			BeforeText();
			SetText(GUI.PasswordField(Position, TextProperty.Value, MaskCharacter, MaxLength, Style));
			AfterText(initial);
		}
	}
}

