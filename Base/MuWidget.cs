using System;
using UnityEngine;

namespace MuUI
{
	public abstract class Widget
	{
		public static Rect DefaultRect { get { return new Rect(0,0,0,0); } }
		
		static Widget()
		{
			DefaultLayoutType = LayoutType.GUILayout;
		}
		
		public Widget ()
		{
		}
	
		public void Draw ()
		{
			if (!Visible) return;
			if (Skin == null) Skin = GUI.skin;
			
			if (GetLayoutType() == LayoutType.GUI)
			{
				OnGui();
			}
			else
			{
				OnLayout();
			}
		}
		
		protected abstract void OnLayout();
		protected abstract void OnGui();

		public abstract bool Visible { get; set; }

		public virtual Widget Parent { get; set; }
		
		public virtual GUISkin Skin { get; set; }
		
		public virtual Rect Position { get; set; }
		
		public virtual LayoutType LayoutType { get; set; }
		
		protected virtual LayoutType GetLayoutType()
		{
			if (LayoutType == LayoutType.Unset)
			{
				return DefaultLayoutType;
			}
			return LayoutType;
		}
		
		public virtual void SetSkinRecursive(GUISkin skin) {}
		
		public static LayoutType DefaultLayoutType { get; set; }
	}
}

