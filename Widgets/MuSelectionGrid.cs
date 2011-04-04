using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace MuUI
{
	public class SelectionGrid : Composite<SelectionGrid>
	{
		public IList<BindableContent> Buttons { get; private set; }
		public int ButtonsPerRow { get; set; }
		protected int GetButtonsPerRowClamped()
		{
			return (int)Mathf.Min(Buttons.Count, ButtonsPerRow);
		}

        public BindableProperty<SelectionGrid, int> SelectedProperty { get; private set; }

        public int Selected
        {
            get { return SelectedProperty.Value; }
            set { SelectedProperty.Value = value; }
        }
		
		public GUIContent SelectedContent
		{
			get { return Buttons[SelectedProperty.Value].Content; }
		}
		
		public bool ShowBackground { get; set; }
		
		private GUIStyle _backgroundStyle;
		public GUIStyle BackgroundStyle
		{
			get
			{
				if (_backgroundStyle == null) return Skin.box;
				return _backgroundStyle;
			}
			set
			{
				_backgroundStyle = value;
			}
		}
		
        public SelectionGrid()
        {
			ShowBackground = false;
			ButtonsPerRow = 999;
            Buttons = new List<BindableContent>();
            SelectedProperty = new BindableProperty<SelectionGrid, int>(this);
        }
		
		public SelectionGrid(params string[] labels) : this()
		{
			foreach(var item in labels)
			{
				AddButton(item);
			}
		}
		
		public SelectionGrid(params GUIContent[] contents) : this()
		{
			foreach(var item in contents)
			{
				AddButton(item);
			}
		}
		
		public SelectionGrid(params BindableContent[] contents) : this()
		{
			foreach(var item in contents)
			{
				AddButton(item);
			}
		}

        public SelectionGrid AddButton(string label)
        {
            Buttons.Add(new BindableContent { Label = label });
            return this;
        }
		
		public SelectionGrid AddButton(GUIContent content)
		{
			Buttons.Add(new BindableContent() { Content = content });
			return this;
		}

        public SelectionGrid AddButton(BindableContent content)
        {
            Buttons.Add(content);
            return this;
        }
		
		public void ClearButtons()
		{
			Buttons.Clear();
			SelectedProperty.SetValueWithoutBinding(0);
		}
		
		protected override GUIStyle GetDefaultStyle()
		{
			return Skin.button;
		}
		
		protected void StartLayoutBackground()
		{
			if (ShowBackground)
			{
				GUILayout.BeginVertical(BackgroundStyle);
			}
		}
		
		protected void ShowLayoutSelectionGrid()
		{
			Selected = GUILayout.SelectionGrid(Selected, Buttons.Select(x => x.Content).ToArray(), GetButtonsPerRowClamped(), Style, LayoutOptions);
		}
		
		protected void EndLayoutBackground()
		{
			if (ShowBackground)
			{
				GUILayout.EndVertical();
			}
		}

        protected override void OnLayout()
        {
			StartLayoutBackground();
			ShowLayoutSelectionGrid();
			EndLayoutBackground();
		}
		
		protected override void OnGui()
		{
			var pos = Position;
			if (ShowBackground)
			{
				GUI.BeginGroup(Position, _backgroundStyle);
				pos.x = 2;
				pos.y = 2;
				pos.width -= 4;
				pos.height -= 4;
			}
			Selected = GUI.SelectionGrid(pos, Selected, Buttons.Select(x => x.Content).ToArray(), GetButtonsPerRowClamped(), Style);
			if (ShowBackground)
			{
				GUI.EndGroup();
			}
		}
	}
}

