using System;
using UnityEngine;

namespace MuUI
{
	public abstract class WidgetBase<TSelf> : Widget where TSelf : Widget
	{
		public WidgetBase ()
		{
			VisibilityProperty = new BindableProperty<WidgetBase<TSelf>, bool>(this, true);
			LayoutOptions = new GUILayoutOption[]{};
		}
		
		public BindableProperty<WidgetBase<TSelf>, bool> VisibilityProperty { get; protected set; }
		
		public GUILayoutOption[] LayoutOptions { get; set; }
		
		public TSelf SetLayoutOptions(params GUILayoutOption[] options)
		{
			LayoutOptions = options;
			return this as TSelf;
		}
		
		public TSelf SetPosition(Rect position)
		{
			Position = position;
			return this as TSelf;
		}
		
		public override bool Visible
		{
			get { return VisibilityProperty.Value; } 
			set { VisibilityProperty.Value = value; }
		}
	}
}

