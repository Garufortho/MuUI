using System;
using UnityEngine;

namespace MuUI
{
	public class Box : ContentWidget<Box>
	{
		protected override GUIStyle GetDefaultStyle()
		{
			return Skin.box;
		}
		
		protected override void OnLayout()
		{
			GUILayout.Box(Content.Content, Style, LayoutOptions);
		}
		
		protected override void OnGui()
		{
			GUI.Box(Position, Content.Content, Style);
		}
	}
}

