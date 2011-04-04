using System;
using UnityEngine;

namespace MuUI
{
	public class Spacer : WidgetBase<Label>
	{
		public float SpaceAmount { get; set; }
		public bool Flexible { get; set; }
		
		public Spacer()
		{
			Flexible = true;
		}
		
		public Spacer(float spaceAmount)
		{
			Flexible = false;
			SpaceAmount = spaceAmount;
		}
		
		protected override void OnLayout()
		{
			if (Flexible)
			{
				GUILayout.FlexibleSpace();
			}
			else
			{
				GUILayout.Space(SpaceAmount);
			}
		}
		
		protected override void OnGui()
		{
		}
	}
}

