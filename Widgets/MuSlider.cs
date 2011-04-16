using System;
using UnityEngine;

namespace MuUI
{
	public class Slider : ContentWidget<Slider>
	{
		public BindableProperty<Slider, float> SliderPositionProperty { get; private set; }
		public bool Horizontal { get; set; }
		
		public float LeftValue { get; set; }
		public float RightValue { get; set; }
		
		private GUIStyle _thumbStyle;
		public GUIStyle ThumbStyle
		{
			get
			{
				if (_thumbStyle == null)
				{
					if (Horizontal)
						return Skin.horizontalSliderThumb;
					return Skin.verticalSliderThumb;
				}
				return _thumbStyle;
			}
			set
			{
				_thumbStyle = value;
			}
		}
				
		public Slider()
		{
			SliderPositionProperty = new BindableProperty<Slider, float>(this);
			Horizontal = true;
			LeftValue = 0;
			RightValue = 1;
		}
		
		public Slider(Rect position) : this()
		{
			Position = position;
		}
		
		protected override GUIStyle GetDefaultStyle()
		{
			if (Horizontal)
				return Skin.horizontalSlider;
			return Skin.verticalSlider;
		}
		
		protected override void OnLayout()
		{
			if (Horizontal)
			{
				SliderPositionProperty.Value = GUILayout.HorizontalSlider(SliderPositionProperty.Value, LeftValue, RightValue, Style, ThumbStyle, LayoutOptions);
			}
			else
			{
				SliderPositionProperty.Value = GUILayout.VerticalSlider(SliderPositionProperty.Value, LeftValue, RightValue, Style, ThumbStyle, LayoutOptions);
			}
		}
		
		protected override void OnGui()
		{
			if (Horizontal)
			{
				SliderPositionProperty.Value = GUI.HorizontalSlider(Position, SliderPositionProperty.Value, LeftValue, RightValue, Style, ThumbStyle);
			}
			else
			{
				SliderPositionProperty.Value = GUI.VerticalSlider(Position, SliderPositionProperty.Value, LeftValue, RightValue, Style, ThumbStyle);
			}
		}
	}
}

