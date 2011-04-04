using System;
using UnityEngine;

namespace MuUI
{
	public class VerticalPanel : Composite<VerticalPanel>
	{
		protected override void OnLayoutBegin()
		{
			GUILayout.BeginVertical(Content.Content, Style, LayoutOptions);
		}
		
		protected override void OnLayoutEnd()
		{
			GUILayout.EndVertical();
		}
	}
}

