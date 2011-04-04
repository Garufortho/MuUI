using UnityEngine;
using System.Collections;
using MuUI;

public class TestButtonsInPanel : MonoBehaviour
{
	public bool panelVisible = true;
	VerticalPanel panel;
	Button weeee;
	
	void Start () {
		panel = new VerticalPanel();
		panel.Add(new NumericTextBox(0.0f));
		panel.VisibilityProperty.BindBoth(()=>panelVisible, b=>panelVisible = b);
		panel.Add(new Button("Hippos").SetLayoutOptions(GUILayout.Width(300), GUILayout.Height(100)));
		panel.Add(new Button("Are"));
		var moo = new Toggle("Fun!").SetLayoutOptions(GUILayout.Width(100)).IsCheckedProperty.BindSet(b=>weeee.Visible = b);
		panel.Add(moo);
		weeee = new Button("OMFGWeeeeee!");
		weeee.Clicked += button => { Debug.Log("Moo!"); moo.IsChecked = !moo.IsChecked; };
		panel.Add(weeee);
	}
	
	void OnGUI ()
	{
		panel.Draw();
	}
}
