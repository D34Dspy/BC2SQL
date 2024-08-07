using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bc2sql.explore
{
    internal partial class SetupScraperSettingsPage : UserControl, ISetupPage
    {
        SetupView _view;
        SetupController _controller;

        public SetupScraperSettingsPage(SetupView view, SetupController controller)
        {
            InitializeComponent();
            _view = view;
            _controller = controller;
        }
        public SetupScraperSettingsPage()
        {
            InitializeComponent();
        }

        private void SetupScraperSettingsPage_Load(object sender, EventArgs e)
        {

        }

        public SetupButton[] GetButtons()
        {
            return Util.GetLastSetupButtons();
        }

        public void OnButtonClicked(SetupButton button)
        {
        }

        public string GetCaption()
        {
            return "Settings";
        }

        public UserControl GetWindow()
        {
            return this;
        }

        public bool HasBeenConfigured()
        {
            return false;
        }
    }
}
