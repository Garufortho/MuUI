using System;
using UnityEngine;

namespace MuUI
{
	public class Button : ContentWidget<Button>
	{
		public event Action<Button> Clicked = delegate{};
		
		public Button()
		{
		}
		
		public Button(Rect position)
		{
			Position = position;
		}
		
		public Button(string label)
		{
			Content.Label = label;
		}
		
		public Button(Rect position, string label)
		{
			Position = position;
			Content.Label = label;
		}
		
		protected override GUIStyle GetDefaultStyle()
		{
			return Skin.button;
		}
		
		void PerformClick(bool val)
		{
			if (val)
			{
				Clicked(this);
			}
		}
		
		public Button OnClicked(Action<Button> callback)
		{
			Clicked += callback;
			return this;
		}
		
		protected override void OnLayout()
		{
			PerformClick(GUILayout.Button(Content.Content, Style, LayoutOptions));
		}
		
		protected override void OnGui()
		{
			PerformClick(GUI.Button(Position, Content.Content, Style));
		}
	}
}

