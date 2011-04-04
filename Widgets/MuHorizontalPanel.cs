using System;
using UnityEngine;

namespace MuUI
{
	public class HorizontalPanel : Composite<HorizontalPanel>
	{
		protected override void OnLayoutBegin()
		{
			GUILayout.BeginHorizontal(LayoutOptions);
		}
		
		protected override void OnLayoutEnd()
		{
			GUILayout.EndHorizontal();
		}
	}
}

