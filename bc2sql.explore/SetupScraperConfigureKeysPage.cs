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

        SetupScraperView _view;
        SetupScraperController _controller;

        public SetupScraperConfigureKeysPage(SetupScraperView view, SetupScraperController controller)
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

        private void InitDataSets()
        {
            Util.Bind(keys, "Name", "Name", "Name of the property");
            Util.Bind(keys, "Type", "Type", "Type of the property");
            Util.Bind(keys, "Type", "Type", "Type of the property");
            Util.Bind(keys, "MaxLength", "MaxLength", "Size of the property");
            Util.Bind(keys, "Nullable", "Nullable", "Whether or not property is nullable");

        }

        private void BindDataSets()
        {
            keys.DataSource = _view.Keys;
        }

        private void SetupScraperConfigureKeysPage_Load(object sender, EventArgs e)
        {
            InitDataSets();
            BindDataSets();
            SelectKeys();
            // UpdateKeys();
            keys.Focus();
        }

        IEnumerable<int> SelectedKeyIndices()
        {
            for(int i = 0; i < keys.SelectedRows.Count; i++)
            {
                var r = keys.SelectedRows[i];
                yield return r.Index;
            }
        }

        void UpdateKeys()
        {
            if (_view.UseSystemGUIDInsertUpdate)
            {
               
            }
            else
            {
                var selectedKeys = StringUtil.Join(", ",
                        _view.SelectKeys(SelectedKeyIndices()).Select(prop => prop.Name));
                selKeys.Text = string.Format("Selected keys: {0}", selectedKeys);
            }
        }

        private void keys_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateKeys();
        }

        private void asGUIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            


        }

        private void keys_SelectionChanged(object sender, EventArgs e)
        {
            UpdateKeys();
        }

        void SelectDefaultKeys()
        {
            keys.SelectAll();
        }

        void SelectSpecialKeys()
        {
            // TODO
            // keys.SelectAll();
        }

        void SelectKeys()
        {
            if (_view.UseSystemGUIDInsertUpdate)
                SelectSpecialKeys();
            else SelectDefaultKeys();
        }

        private void selectDefaultKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}
