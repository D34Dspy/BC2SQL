using bc2sql.shared.OData;
using bc2sql.shared.Serialize;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;

namespace bc2sql.explore.Views
{
    internal class CurrentDataSource
    {
        public delegate void DataSourceChangeHandler(object sender, CurrentDataSourceChangeEventArgs args);
        public event DataSourceChangeHandler OnChangeDataSource;

        private void InvokeOnChangeDataSource(CurrentDataSourceChangeEventArgs e)
        {
            if (OnChangeDataSource != null) OnChangeDataSource(this, e);
        }

        Model _model;

        [DescriptionAttribute("Filename of current database"),
            CategoryAttribute("Workspace")]
        public string Filename
        {
            get
            {
                return _model.SelectedDataSource.GetOrigin();
            }
        }

        [Browsable(false)]
        public string Source
        {
            get
            {
                return _model.SelectedDataSource.GetSource();
            }
        }

        [DescriptionAttribute("Form Fields"),
            CategoryAttribute("Data Source")]
        public List<FormField> FormFields
        {
            get
            {
                return _model.SelectedDataSource.Fields;
            }
        }

        [DescriptionAttribute("Name"),
            CategoryAttribute("Data Source")]
        public string Name
        {
            get
            {
                return _model.SelectedDataSource.Name;
            }
            set
            {
                InvokeOnChangeDataSource(new CurrentDataSourceChangeEventArgs
                {
                    Name = value,
                    Description = Description,
                    Endpoint = Endpoint
                });
            }
        }

        [DescriptionAttribute("Description"),
            CategoryAttribute("Data Source")]
        public string Description
        {
            get
            {
                return _model.SelectedDataSource.Description;
            }
            set
            {
                InvokeOnChangeDataSource(new CurrentDataSourceChangeEventArgs
                {
                    Name = Name,
                    Description = value,
                    Endpoint = Endpoint
                });
            }
        }

        [DescriptionAttribute("Endpoint"),
            CategoryAttribute("Data Source")]
        public string Endpoint
        {
            get
            {
                return _model.SelectedDataSource.Endpoint;
            }
            set
            {
                InvokeOnChangeDataSource(new CurrentDataSourceChangeEventArgs
                {
                    Name = Name,
                    Description = Description,
                    Endpoint = value
                });
            }
        }

        [Browsable(false)]
        public Schema Metadata
        {
            get
            {
                return _model.SelectedDataSource.Metadata;
            }
        }

        public CurrentDataSource(Model model)
        {
            _model = model;
        }
    }
}
