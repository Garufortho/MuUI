using System;
using System.Globalization;
using System.Linq;
using UnityEngine;

namespace MuUI
{
	public class NumericTextBox : TextBox
	{
		private bool _floatingPoint = false;
		public bool FloatingPoint
		{
			get
			{
				return _floatingPoint;
			}
			set
			{
				if (_floatingPoint == value) return;
				if (!value) TextProperty.SetValueWithoutBinding(ValueAsInt.ToString());
				_floatingPoint = value;
			}
		}
		public float ValueAsFloat
		{
			get
			{
				float output;
				float.TryParse(TextProperty.Value, NumberStyles.Float, CultureInfo.InvariantCulture, out output);
				return output;
			}
		}
		public int ValueAsInt
		{
			get
			{
				return (int)ValueAsFloat;
			}
		}
		
		public NumericTextBox() : base()
		{
			FloatingPoint = false;
			TextProperty.SetValueWithoutBinding("0");
		}
		
		public NumericTextBox(Rect position) : base()
		{
			FloatingPoint = false;
			Position = position;
			TextProperty.SetValueWithoutBinding("0");
		}
		
		public NumericTextBox(int initialValue) : base()
		{
			FloatingPoint = false;
			TextProperty.SetValueWithoutBinding("0");
		}
		
		public NumericTextBox(float initialValue) : base()
		{
			FloatingPoint = true;
			TextProperty.SetValueWithoutBinding(initialValue.ToString());
		}
		
		public NumericTextBox(Rect position, int initialValue) : base()
		{
			FloatingPoint = false;
			Position = position;
			TextProperty.SetValueWithoutBinding(initialValue.ToString());
		}
		
		public NumericTextBox(Rect position, float initialValue) : base()
		{
			FloatingPoint = true;
			Position = position;
			TextProperty.SetValueWithoutBinding(initialValue.ToString());
		}
		
		/*
		protected override GUIStyle GetDefaultStyle()
		{
			var ret = new GUIStyle(base.GetDefaultStyle());
			ret.alignment = TextAnchor.MiddleRight;
			return ret;
		}
		*/
		
		protected override void SetText(string text)
		{
			int maxDecimalSeperators = FloatingPoint?1:0;
			if (text.Count(c=>c=='.') > maxDecimalSeperators) return;
			if (text.Contains('-') && (text.Count(c=>c=='-') > 1 || text.IndexOf('-') > 0)) return;
			
			if (!(string.IsNullOrEmpty(text) || text == "-"))
			{
				if (FloatingPoint)
				{
					float tmp;
					if (!float.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out tmp)) return;
				}
				else
				{
					int tmp;
					if (!int.TryParse(text, out tmp)) return;
				}
			}
			base.SetText(text);
		}
	}
}

