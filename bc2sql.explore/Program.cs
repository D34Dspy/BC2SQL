using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace bc2sql.explore
{
    internal static class Program
    {
        static Model mdl;
        static Controller ctrl;
        static View view;

        static Explore CreateExplorer(string[] args)
        {
            mdl = new Model();
            ctrl = new Controller(mdl, args);
            view = new View(mdl);

            view.CurrentDataSource.OnChangeDataSource += CurrentDataSource_OnChangeDataSource;
            view.CurrentDataBase.OnChangeDatabase += CurrentDataBase_OnChangeDatabase;

            Explore explorer = new Explore();
            explorer.SetVC(view, ctrl);

            return explorer;
        }

        private static void CurrentDataBase_OnChangeDatabase(object sender, Views.CurrentDatabaseChangeEventArgs args)
        {
            mdl.SelectedDatabase.Name = args.Name;
            mdl.SelectedDatabase.Description = args.Description;
            mdl.SelectedDatabase.ConnectString = args.ConnectString;
        }

        static void CurrentDataSource_OnChangeDataSource(object sender, Views.CurrentDataSourceChangeEventArgs args)
        {
            mdl.SelectedDataSource.Name = args.Name;
            mdl.SelectedDataSource.Description = args.Description;
            mdl.SelectedDataSource.Endpoint = args.Endpoint;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(CreateExplorer(args));
        }
    }
}
