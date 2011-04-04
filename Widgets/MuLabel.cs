using System;
using UnityEngine;

namespace MuUI
{
	public class Label : ContentWidget<Label>
	{		
		public Label()
		{
		}
		
		public Label(Rect position)
		{
			Position = position;
		}
		
		public Label(string label)
		{
			Content.Label = label;
		}
		
		public Label(Rect position, string label)
		{
			Position = position;
			Content.Label = label;
		}
		
		protected override GUIStyle GetDefaultStyle()
		{
			return Skin.label;
		}
		
		protected override void OnLayout()
		{
			GUILayout.Label(Content.Content, Style, LayoutOptions);
		}
		
		protected override void OnGui()
		{
			GUI.Label(Position, Content.Content, Style);
		}
	}
}

