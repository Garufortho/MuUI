using System;
using MuUI;
using UnityEngine;


public class TestLayoutWidgets : MonoBehaviour
{
	ScrollPanel panel;
	public bool keyboard = false;
	
	void Start()
	{
		panel = new ScrollPanel(new Rect(50, 50, 300, 200));
		panel.ShowDefaultBackground = true;
		
		panel.Add(new RadioGroup("My radio group", "a", "b", "c", "d", "e", "f", "g", "h", "i") { ButtonsPerRow = 3 });
		panel.Add(new Box());
		panel.Add(new Spacer(20));
		
		for (int i = 0; i < 15; ++i)
		{
			
			var textBox = new TextBox(i.ToString());
			panel.Add(new Button("Test button").OnClicked(b=>textBox.KeyboardControlProperty.Value = true));
			if (i == 1) textBox.KeyboardControlProperty.BindBoth(()=>keyboard, b=>keyboard = b);
			panel.Add(textBox);
			var label = new Label("Test label " + i.ToString());
			panel.Add(new Toggle("Test toggle").OnToggled((t,oldChecked,newChecked) => label.Visible = !newChecked));
			panel.Add(label);
			panel.Add(new SelectionGrid().AddButton("1").AddButton("2").AddButton("3"));
			panel.Add(new PasswordBox().OnEnterPressed(t=>Debug.Log(t.TextProperty.Value)));
			panel.Add(new Spacer(20));
		}
	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.K))
		{
			keyboard = true;
		}
	}
	
	void OnGUI()
	{
		panel.Draw();
	}
}