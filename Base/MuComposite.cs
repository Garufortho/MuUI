using System;
using System.Collections.Generic;
using UnityEngine;

namespace MuUI
{
	public abstract class Composite<TSelf> : ContentWidget<TSelf>
		where TSelf : ContentWidget<TSelf>
	{
		private IList<Widget> _children = new List<Widget>();
		
		public bool ShowDefaultBackground { get; set; }
		
		protected override GUIStyle GetDefaultStyle()
		{
			if (ShowDefaultBackground && Skin != null)
			{
				return Skin.box;
			}
			return GUIStyle.none;
		}
		
		protected override void OnLayout()
		{
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
		
		protected virtual void OnGuiBegin(){}
		protected virtual void OnGuiEnd(){}
		protected virtual void OnLayoutBegin(){}
		protected virtual void OnLayoutEnd(){}

		public void Add(Widget widget)
		{
			_children.Add(widget);
			widget.Parent = this;
			if (widget.LayoutType == LayoutType.Unset)
			{
				widget.LayoutType = LayoutType;
			}
			
		}

		public void Remove (Widget widget)
		{
			if (_children.Contains(widget))
			{
				_children.Remove(widget);
				widget.Parent = null;
			}
		}
		
		public void Clear()
		{
			_children.Clear();
		}

		public IEnumerable<Widget> Children
		{
			get
			{
				return _children;
			}
		}
		
		public override void SetSkinRecursive(GUISkin skin)
		{
			Skin = skin;
			foreach(var child in Children)
			{
				child.SetSkinRecursive(skin);
			}
		}
	}
}

