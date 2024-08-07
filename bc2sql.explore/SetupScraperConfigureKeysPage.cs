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
    internal partial class SetupScraperConfigureKeysPage : UserControl, ISetupPage
    {

        SetupView _view;
        SetupController _controller;

        public SetupScraperConfigureKeysPage(SetupView view, SetupController controller)
        {
            InitializeComponent();
            _view = view;
            _controller = controller;
        }

        public SetupButton[] GetButtons()
        {
            return Util.GetDefaultSetupButtons();
        }

        public string GetCaption()
        {
            return "Keys";
        }

        public UserControl GetWindow()
        {
            return this;
        }

        public bool HasBeenConfigured()
        {
            return false;
        }

        void ISetupPage.OnButtonClicked(SetupButton button)
        {

        }

        private void SetupScraperConfigureKeysPage_Load(object sender, EventArgs e)
        {

        }
    }
}
