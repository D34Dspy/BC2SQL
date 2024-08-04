using bc2sql.explore.Controllers;
using bc2sql.shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bc2sql.explore
{
    public partial class Inspect : Form
    {
        InspectView _view;
        InspectController _controller;

        public Inspect()
        {
            InitializeComponent();
        }

        internal void SetVC(InspectView view, InspectController ctrl)
        {
            _view = view;
            _controller = ctrl;
        }

        private void InitDataSets()
        {
            Util.Bind(fields, "Name", "Name", "Name of the data source");

            foreach (var col in _view.DataSetColumns)
                Util.BindIdx(dataSets, col, "n/a");

            _view.OpenDataSets(ref dataSets);
        }

        private int WarnDataSetChangesLoss(int dataset, int xDataset)
        {
            if (MessageBox.Show("You're about to select another data set!\nPotential changes might not persist.\nAre you sure you want to continue?", "Data Loss", MessageBoxButtons.YesNo) == DialogResult.Yes)
                return dataset;
            return xDataset;
        }

        private void BindDataSets()
        {
            fields.DataSource = _view.Properties;
            // dataSets.DataSource = _view.DataSets;
            fieldProperties.SelectedObject = _view.Property;
        }


        private void Inspect_Load(object sender, EventArgs e)
        {
            var ds = _view.DataSource;
            var ent = _view.Entity;

            dataSourceName.Text = string.Format("Name: {0}", ds.Name);
            dataSourceDescription.Text = string.Format("Description: {0}", ds.Description);
            dataSourceGuid.Text = string.Format("GUID: {0}", ds.Guid);

            dataSourceLink.Text = "OData Service";
            Util.BindHelp(help, dataSourceLink, ds.Endpoint);

            dataSourceMetadata.Text = "OData Metadata";
            Util.BindHelp(help, dataSourceMetadata, ds.Metadata);

            dataSourceEntity.Text = "OData Entity";
            Util.BindHelp(help, dataSourceMetadata, _view.Entity.ODataUrl);

            InitDataSets();
            BindDataSets();
        }

        private void dataPage_Click(object sender, EventArgs e)
        {

        }

        private void dataSourceLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _view.OpenURL(_view.DataSource.Endpoint);
        }

        private void dataSourceMetadata_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _view.OpenURL(_view.DataSource.Metadata);
        }

        private void dataSourceEntity_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _view.OpenURL(_view.Entity.ODataUrl); 
        }

        private void fields_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            _controller.MakePropertyCurrent(e.RowIndex);
            BindDataSets();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dataSourceLink_DragLeave(object sender, EventArgs e)
        {

        }

        private void dataSourceLink_MouseEnter(object sender, EventArgs e)
        {
            help.Show(_view.DataSource.Endpoint, dataSourceLink);
        }

        private void dataSourceMetadata_MouseEnter(object sender, EventArgs e)
        {
            help.Show(_view.DataSource.Metadata, dataSourceMetadata);
        }

        private void dataSourceEntity_MouseEnter(object sender, EventArgs e)
        {
            help.Show(_view.Entity.ODataUrl, dataSourceEntity);
        }

        private void close_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void closeNewScraper_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }
    }
}
