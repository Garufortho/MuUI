using System;
using UnityEngine;

namespace MuUI
{
	public class ScrollPanel : Composite<ScrollPanel>
	{
		public BindableProperty<ScrollPanel, Vector2> ScrollPositionProperty { get; private set; }
		public bool AlwaysShowHorizontal { get; set; }
		public bool AlwaysShowVertical { get; set; }
		
		public Rect ContentRect { get; set; }
		
		public ScrollPanel()
		{
			ScrollPositionProperty = new BindableProperty<ScrollPanel, Vector2>(this);
		}
		
		public ScrollPanel(Rect position) : this()
		{
			Position = position;
		}
		
		public ScrollPanel(Rect position, Rect contentRect) : this(position)
		{
			ContentRect = contentRect;
		}
		
		public ScrollPanel SetAlwaysShowBars(bool horizontal, bool vertical)
		{
			AlwaysShowHorizontal = horizontal;
			AlwaysShowVertical = vertical;
			return this;
		}
		
		public ScrollPanel SetAlwaysShowHorizontal(bool show)
		{
			AlwaysShowHorizontal = show;
			return this;
		}
		
		public ScrollPanel SetAlwaysShowVertical(bool show)
		{
			AlwaysShowVertical = show;
			return this;
		}
		
		public ScrollPanel SetContentRect(Rect contentRect)
		{
			ContentRect = contentRect;
			return this;
		}
		
		protected override void OnLayoutBegin()
		{
			if (Position != DefaultRect && Parent == null)
			{
				GUILayout.BeginArea(Position);
			}
			ScrollPositionProperty.Value = GUILayout.BeginScrollView(ScrollPositionProperty.Value, AlwaysShowHorizontal, AlwaysShowVertical, Skin.horizontalScrollbar, Skin.verticalScrollbar, Style, LayoutOptions);
		}
		
		protected override void OnLayoutEnd()
		{
			GUILayout.EndScrollView();
			if (Position != DefaultRect && Parent == null)
			{
				GUILayout.EndArea();
			}
		}
		
		protected override void OnGuiBegin()
		{
			ScrollPositionProperty.Value = GUI.BeginScrollView(Position, ScrollPositionProperty.Value, ContentRect, AlwaysShowHorizontal, AlwaysShowVertical);
		}
		
		protected override void OnGuiEnd()
		{
			GUI.EndScrollView();
		}
	}
}

