using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace bc2sql.explore.Views
{
    internal class CurrentDataBase
    {
        public delegate void DatabaseChangeHandler(object sender, CurrentDatabaseChangeEventArgs args);
        public event DatabaseChangeHandler OnChangeDatabase;

        private void InvokeOnChangeDatabase(CurrentDatabaseChangeEventArgs e)
        {
            if (OnChangeDatabase != null) OnChangeDatabase(this, e);
        }


        Model _model;

        [DescriptionAttribute("Filename of current database"),
            CategoryAttribute("Workspace")]
        public string Filename
        {
            get
            {
                return _model.SelectedDatabase.GetOrigin();
            }
        }


        [Browsable(false)]
        public string Source
        {
            get
            {
                return _model.SelectedDatabase.GetSource();
            }
        }

        [DescriptionAttribute("Name"),
            CategoryAttribute("Database")]
        public string Name
        {
            get
            {
                return _model.SelectedDatabase.Name;
            }
            set
            {
                InvokeOnChangeDatabase(new CurrentDatabaseChangeEventArgs
                {
                    Name = value,
                    Description = Description,
                    ConnectString = ConnectString
                });
            }
        }

        [DescriptionAttribute("Description"),
            CategoryAttribute("Database")]
        public string Description
        {
            get
            {
                return _model.SelectedDatabase.GetOrigin();
            }
            set
            {
                InvokeOnChangeDatabase(new CurrentDatabaseChangeEventArgs
                {
                    Name = Name,
                    Description = value,
                    ConnectString = ConnectString
                });
            }
        }

        [DescriptionAttribute("Connect-String"),
            CategoryAttribute("Database")]
        public string ConnectString
        {
            get
            {
                return _model.SelectedDatabase.ConnectString;
            }
            set
            {
                InvokeOnChangeDatabase(new CurrentDatabaseChangeEventArgs
                {
                    Name = Name,
                    Description = Description,
                    ConnectString = value
                });
            }
        }

        public CurrentDataBase(Model model)
        {
            _model = model;
        }
    }
}
