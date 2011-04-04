using System;
using UnityEngine;

namespace MuUI
{
	public class RadioGroup : SelectionGrid
	{
		public string RadioGroupName { get; set; }
		
		public string SelectedRadioName
		{
			get { return SelectedContent.text; }
		}
		
		private void Init(string name)
		{
			RadioGroupName = name;
			ButtonsPerRow = 1;
			ShowBackground = true;
		}
		
		public RadioGroup() : base()
		{
			Init(null);
		}
		
		public RadioGroup(string name) : base()
        {
			Init(name);
        }
		
		public RadioGroup(string name, params string[] labels) : base(labels)
		{
			Init(name);
		}
		
		public RadioGroup(string name, params GUIContent[] contents) : base(contents)
		{
			Init(name);
		}
		
		public RadioGroup(string name, params BindableContent[] contents) : base(contents)
		{
			Init(name);
		}
		
		protected override GUIStyle GetDefaultStyle()
		{
			return Skin.toggle;
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
		
		protected override void OnLayoutBegin()
		{
			StartLayoutBackground();
			if (RadioGroupName != null)
			{
				GUILayout.Label(RadioGroupName);
			}
			ShowLayoutSelectionGrid();
		}
		
		protected override void OnLayoutEnd()
		{
			EndLayoutBackground();
		}
	}
}

