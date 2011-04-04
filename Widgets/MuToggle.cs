using System;
using UnityEngine;

namespace MuUI
{
	public class Toggle : ContentWidget<Toggle>
	{
		public event Action<Toggle, bool, bool> Toggled
		{
			add
			{
				IsCheckedProperty.PropertyChanged += value;
			}
			remove
			{
				IsCheckedProperty.PropertyChanged -= value;
			}
		}
		
		public BindableProperty<Toggle, bool> IsCheckedProperty { get; private set; }
		public bool IsChecked { get { return IsCheckedProperty.Value; } set { IsCheckedProperty.Value = value; } }
		
		public Toggle()
		{
			IsCheckedProperty = new BindableProperty<Toggle, bool>(this);
		}
		
		public Toggle(Rect position) : this()
		{
			Position = position;
		}
		
		public Toggle(string label) : this()
		{
			Content.Label = label;
		}
		
		public Toggle(Rect position, string label) : this()
		{
			Position = position;
			Content.Label = label;
		}
		
		public Toggle OnToggled(Action<Toggle, bool, bool> callback)
		{
			Toggled += callback;
			return this;
		}
		
		public Toggle SetChecked(bool isChecked)
		{
			IsChecked = isChecked;
			return this;
		}
		
		protected override GUIStyle GetDefaultStyle()
		{
			return GUI.skin.toggle;
		}
		
		protected override void OnLayout()
		{
			IsChecked = GUILayout.Toggle(IsChecked, Content.Content, Style, LayoutOptions);
		}
		
		protected override void OnGui()
		{
			IsChecked = GUI.Toggle(Position, IsChecked, Content.Content, Style);
		}
	}
}
