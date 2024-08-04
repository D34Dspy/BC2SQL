using bc2sql.explore.Controllers;
using bc2sql.explore.Views;
using bc2sql.shared.OData;
using bc2sql.shared.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bc2sql.explore
{
    internal class InspectView
    {
        private Model _model;

        public InspectEntity Entity;
        public InspectDataSource DataSource;
        public InspectProperty Property;

        public BindingSource Properties;
        public BindingSource DataSets;
        public DataGridTableStyle DataSetsStyle;

        private ODataQuery Query;
        public IEnumerable<string> DataSetColumns
        {
            get
            {
                return Query.Columns.Select(col => col.Identifier);
            }
        }
        public IEnumerable<string> DataSetColumnTypes
        {
            get
            {
                return Query.Columns.Select(col => col.Type.Name);
            }
        }

        public InspectView(Model model)
        {
            _model = model;

            Entity = new InspectEntity(model);
            DataSource = new InspectDataSource(model);
            Property = new InspectProperty(model);

            RefreshFields();
            RefreshDataSets();
        }

        public void RefreshFields()
        {
            Properties = new BindingSource();
            Properties.DataSource = _model.InspectDataType.Properties;
            Properties.AllowNew = false;
        }

        public void RefreshDataSets()
        {

            Query = ODataQueryRequest
                .Create(_model.InspectDataSource.Endpoint, _model.InspectEntityName, 
                    new FormField[]
                    {
                        FormField.Create("$top","10")
                    }, false, 5000
                )
                .GetResponse();

            DataSets = new BindingSource();
            DataSets.DataSource = Query.Rows.Select(row => row.Select(cell => cell.ToString()).ToArray()).ToList();

            // TODO web request
        }

        public void OpenURL(string url)
        {
            
            System.Diagnostics.Process.Start(url);
        }

        public void OpenDataSets(ref DataGridView output)
        {
            // output.ColumnCount = Query.Columns.Count();
            foreach(var dataset in Query.Rows)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(output);
                for(int i = 0; i < dataset.Length; i++)
                    row.Cells[i].Value = dataset[i].ToString();
                output.Rows.Add(row);
            }
        }

    }
}
