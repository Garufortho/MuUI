using System;
using UnityEngine;

namespace MuUI
{
	public class Panel : Composite<Panel>
	{	
		public Panel()
		{
		}
		
		public Panel(Rect position)
		{
			Position = position;
		}
		
		protected override void OnLayoutBegin()
		{
			if (Position == DefaultRect || Parent != null)
				GUILayout.BeginVertical(Content.Content, Style, LayoutOptions);
			else
				GUILayout.BeginArea(Position, Content.Content, Style);
		}
		
		protected override void OnLayoutEnd()
		{
			if (Position == DefaultRect || Parent != null)
				GUILayout.EndVertical();
			else
				GUILayout.EndArea();
		}
		
		protected override void OnGuiBegin()
		{
			GUI.BeginGroup(Position, Content.Content, Style);
		}
		
		protected override void OnGuiEnd()
		{
			GUI.EndGroup();
		}
	}
}

