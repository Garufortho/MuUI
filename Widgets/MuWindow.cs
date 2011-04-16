using System;
using UnityEngine;

namespace MuUI
{
	public class Window : Composite<Panel>
	{
		private static int _currentId = int.MinValue;
		protected int WindowId { get; private set; }
		
		protected static int GetNewWindowId()
		{
			return ++_currentId;
		}
		
		public bool AllowDrag { get; set; }
		public string Title { get; set; }
		
		
		private Window()
		{
			WindowId = GetNewWindowId();
			AllowDrag = true;
			Title = "";
		}
		
		public Window(Rect position) : this()
		{
			Position = position;
		}
		
		public Window(Rect position, string title) : this(position)
		{
			Title = title;
		}
		
		protected override GUIStyle GetDefaultStyle()
		{
			return Skin.window;
		}
		
		protected override void OnLayout()
		{
			Position = GUILayout.Window(WindowId, Position, OnDrawLayoutWindow, Title, Style, LayoutOptions);
		}
		
		private void OnDrawLayoutWindow(int windowId)
		{
			if (AllowDrag) GUI.DragWindow(new Rect(0, 0, Position.width - 20, 20));
			var buttonStyle = Skin.button;
			var buttonAlign = buttonStyle.alignment;
			var padding = buttonStyle.padding;
			buttonStyle.alignment = TextAnchor.UpperCenter;
			buttonStyle.padding = new RectOffset();
			if (GUI.Button(new Rect(Position.width - 20, 3, 15, 15), "x", buttonStyle))
			{
				Visible = false;
			}
			buttonStyle.alignment = buttonAlign;
			buttonStyle.padding = padding;
			
			OnLayoutBegin();
			
			foreach(var child in Children)
			{
				child.Draw();
			}
			
			OnLayoutEnd();
		}
		
		protected override void OnGui()
		{
			OnGuiBegin();
			
			foreach(var child in Children)
			{
				child.Draw();
			}
			
			OnGuiEnd();
		}
		
		private void OnDrawGuiWindow(int windowId)
		{
		}
	}
}

