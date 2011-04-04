using System;
using UnityEngine;

namespace MuUI
{
	public class TextBox : ContentWidget<TextBox>
	{
		private int _hotControl = -1;
		private bool _needsKeyboardFocus;
		public BindableProperty<TextBox, string> TextProperty { get; private set; }
		public BindableProperty<TextBox, bool> KeyboardControlProperty { get; private set; }
		public event Action<TextBox> EnterPressed = delegate{};
		public bool MultiLine { get; set; }
		public int MaxLength { get; set; }
		
		public TextBox()
		{
			TextProperty = new BindableProperty<TextBox, string>(this, string.Empty);
			KeyboardControlProperty = new BindableProperty<TextBox, bool>(this);
			KeyboardControlProperty.OnPropertyChanged((t, orig, cur) => _needsKeyboardFocus = cur);
			MaxLength = int.MaxValue;
			VisibilityProperty.OnPropertyChanged((t, o, n) => { KeyboardControlProperty.Value = false; _hotControl = -1; }); //reset hot control when it goes invisible
		}
		
		public TextBox(Rect position) : this()
		{
			Position = position;
		}
		
		public TextBox(string initialText) : this()
		{
			TextProperty.SetValueWithoutBinding(initialText);
		}
		
		public TextBox(Rect position, string initialText) : this()
		{
			Position = position;
			TextProperty.SetValueWithoutBinding(initialText);
		}
		
		protected override GUIStyle GetDefaultStyle()
		{
			if (MultiLine) return Skin.textArea;
			return Skin.textField;
		}
		
		public TextBox OnEnterPressed(Action<TextBox> callback)
		{
			EnterPressed += callback;
			return this;
		}
		
		protected void BeforeText()
		{
			if (_hotControl == -1)
				GUI.SetNextControlName("TextBox " + GetHashCode().ToString());
			if (KeyboardControlProperty.Value)
			{
				if (_needsKeyboardFocus)
				{
					if (_hotControl == -1)
						GUI.FocusControl("TextBox " + GetHashCode().ToString());
					else
						GUIUtility.keyboardControl = _hotControl;
				}
				if (Event.current.type == EventType.KeyUp && (Event.current.keyCode == KeyCode.KeypadEnter || Event.current.keyCode == KeyCode.Return))
				{
					EnterPressed(this);
				}
			}
		}
		
		protected void AfterText(int initial)
		{
			if (_needsKeyboardFocus || (_hotControl == -1 && initial != GUIUtility.keyboardControl))
			{
				_hotControl = GUIUtility.keyboardControl;
			}
			
			KeyboardControlProperty.Value = _hotControl == GUIUtility.keyboardControl;
			_needsKeyboardFocus = false;
		}
		
		protected virtual void SetText(string text)
		{
			TextProperty.Value = text;
		}
		
		protected override void OnLayout()
		{
			int initial = GUIUtility.keyboardControl;
			BeforeText();

			if (MultiLine)
			{
				SetText(GUILayout.TextArea(TextProperty.Value, MaxLength, Style, LayoutOptions));
			}
			else
			{
				SetText(GUILayout.TextField(TextProperty.Value, MaxLength, Style, LayoutOptions));
			}
			
			AfterText(initial);
		}
		
		protected override void OnGui()
		{
			int initial = GUIUtility.keyboardControl;
			BeforeText();
			
			if (MultiLine)
			{
				SetText(GUI.TextArea(Position, TextProperty.Value, MaxLength, Style));
			}
			else
			{
				SetText(GUI.TextField(Position, TextProperty.Value, MaxLength, Style));
			}
			
			AfterText(initial);
		}
	}
}

