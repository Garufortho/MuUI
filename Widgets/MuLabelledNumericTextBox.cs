using System;
using UnityEngine;

namespace MuUI
{
	public class LabelledNumericTextBox : NumericTextBox
	{
		public BindableProperty<LabelledNumericTextBox, string> LabelProperty { get; private set; }
		public int LabelWidth { get; set; }
		
		public LabelledNumericTextBox() : base()
		{
			Init(null);
		}
		
		public LabelledNumericTextBox(string label) : base()
		{
			Init(label);
		}
		
		public LabelledNumericTextBox(Rect position, string label) : base(position)
		{
			Init(label);
		}
		
		public LabelledNumericTextBox(string label, int initialValue) : base(initialValue)
		{
			Init(label);
		}
		
		public LabelledNumericTextBox(string label, float initialValue) : base(initialValue)
		{
			Init(label);
		}
		
		public LabelledNumericTextBox(Rect position, string label, int initialValue) : base(position, initialValue)
		{
			Init(label);
		}
		
		public LabelledNumericTextBox(Rect position, string label, float initialValue) : base(position, initialValue)
		{
			Init(label);
		}
		
		private void Init(string label)
		{
			LabelProperty = new BindableProperty<LabelledNumericTextBox, string>(this, label);
			LabelWidth = 100;
		}
		
		public LabelledNumericTextBox SetLabelWidth(int width)
		{
			LabelWidth = width;
			return this;
		}
		
		protected override void OnLayout()
		{
			GUILayout.BeginHorizontal();
			GUILayout.Label(LabelProperty.Value, GUILayout.Width(LabelWidth));
			base.OnLayout();
			GUILayout.EndHorizontal();
		}
	}
}

