using bc2sql.explore.Controllers;
using bc2sql.shared;
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
    internal partial class SetupScraperBindDatabasePage : UserControl, ISetupPage
    {
        SetupScraperView _view;
        SetupScraperController _controller;

        public SetupScraperBindDatabasePage(SetupScraperView view, SetupScraperController controller)
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
            return "Database";
        }

        public UserControl GetWindow()
        {
            return this;
        }

        public bool HasBeenConfigured()
        {
            return false;
        }

        public void OnButtonClicked(SetupButton button)
        {
            if(button == SetupButton.Next)
            {
                _controller.SetDatabase(databases.SelectedRows[0].Index);
            }
        }
        private void InitDataSets()
        {
            Util.Bind(databases, "Name", "Name", "Name of the database");
            Util.Bind(databases, "Identifier", "ID", "(Unique) identifier of the database");
        }

        private void BindDataSets()
        {
            databases.DataSource = _view.Databases;
        }

        private void SetupScraperBindDatabasePage_Load(object sender, EventArgs e)
        {
            InitDataSets();
            BindDataSets();
        }

        private void toolStripTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {

            }
        }

        private void databases_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _controller.SetDatabase(e.RowIndex);
        }
    }
}
