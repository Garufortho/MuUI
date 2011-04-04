using System;
using UnityEngine;

namespace MuUI
{
	public abstract class ContentWidget<TSelf> : WidgetBase<TSelf> where TSelf : WidgetBase<TSelf>
	{
		private GUIStyle _style;
		
		public BindableContent Content { get; set; }
		public GUIStyle Style
		{
			get
			{
				if (_style == null) return GetDefaultStyle();
				return _style;
			}
			set
			{
				_style = value;
			}
		}
		
		protected abstract GUIStyle GetDefaultStyle();
		
		public ContentWidget()
		{
			Content = new BindableContent();
		}
	}
}

