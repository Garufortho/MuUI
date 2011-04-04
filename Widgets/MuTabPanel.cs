using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MuUI
{
    public class TabPanel : WidgetBase<TabPanel>
    {
        private SelectionGrid _tabButtons = new SelectionGrid();
        private Panel _pages = new Panel();
        private Dictionary<int, Widget> _pageMap = new Dictionary<int, Widget>();
		
		public GUISkin TabSkin
		{
			get { return _tabButtons.Skin; }
			set { _tabButtons.Skin = value; }
		}
		
		public GUIStyle TabStyle
		{
			get { return _tabButtons.Style; }
			set { _tabButtons.Style = value; }
		}
		
		public int TabsPerRow
		{
			get { return _tabButtons.ButtonsPerRow; }
			set { _tabButtons.ButtonsPerRow = value; }
		}
		
		public int TabHeight { get; set; }
		
        public TabPanel()
        {
			TabHeight = 25;
			_tabButtons.SelectedProperty.PropertyChanged += (s, oldi, i) => ShowTab(i);
        }

        public TabPanel AddPage(String name, Widget page)
        {
            _tabButtons.AddButton(new BindableContent { Label = name });
            _pageMap.Add(_pageMap.Count, page);
            _pages.Add(page);
            page.Visible = false;

            // Show the first page
            if (_pages.Children.Count() == 1)
            {
                ShowTab(0);
            }
            return this;
        }
				
		public void ClearTabs()
		{
			_tabButtons.ClearButtons();
			_pageMap.Clear();
			_pages.Clear();
		}
		
		public TabPanel OnPageChanged(Action<TabPanel, int> changed)
		{
			_tabButtons.SelectedProperty.PropertyChanged += (s, oldi, i) => changed(this, i);
			return this;
		}

        public TabPanel ShowTab(int index)
        {
            foreach (var page in _pages.Children)
            {
                page.Visible = false;
            }
            _pageMap[index].Visible = true;
            _tabButtons.SelectedProperty.SetValueWithoutBinding(index);
            return this;
        }
		
		protected override void OnLayout()
		{
			_tabButtons.Draw();
			_pages.Draw();
		}
		
		protected override void OnGui()
		{
		}
    }
}