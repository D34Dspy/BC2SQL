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
    internal partial class Setup : Form
    {
        public Setup(string caption, ISetupPage[] pages, int startingPage = 0)
        {
            InitializeComponent();

            _caption = caption;
            _pages = pages;
            _hasOrigin = false;

            if(_pages == null)
                throw new Exception("invalid pages");

            SetCurrentPage(startingPage);
            Execute();
        }

        public static Setup CreateScraper(SetupView view, SetupController controller)
        {
            return new Setup((view.IsEditing ? "Edit" : "New") + " Scraper", new ISetupPage[]
            {
                new SetupScraperBindDataSourcePage(view, controller),
                new SetupScraperBindDatabasePage(view, controller),
                new SetupScraperConfigureKeysPage(view, controller),
                new SetupScraperConfigureStrategy(view, controller),
                new SetupScraperSettingsPage(view, controller),
            });
        }

        private string _caption;
        private ISetupPage[] _pages;
        private int _currentPage;

        // action
        bool _hasOrigin;
        SetupButton _origin;
        int _newPage;

        private void AdjustAgenda()
        {
            setupAgenda.Controls.Clear();

            var agenda = new Label();
            agenda.Text = _caption;
            agenda.AutoSize = true;
            Util.SetHeading(agenda);
            setupAgenda.Controls.Add(agenda);

            foreach(var page in _pages)
            {
                var pageLabel = new Label();
                var caption = page.GetCaption();
                if (_pages[_currentPage] == page)
                    pageLabel.BorderStyle = BorderStyle.Fixed3D;
                if (!page.HasBeenConfigured())
                    caption += "*";
                pageLabel.Text = caption;
                pageLabel.AutoSize = true;
                Util.SetPoint(pageLabel);
                setupAgenda.Controls.Add(pageLabel);
            }

            // setupAgenda.Invalidate();
        }

        public void SetOrigin(SetupButton origin)
        {
            _hasOrigin = true;
            _origin = origin;
        }

        public void SetCurrentPage(int pageNo)
        {
            if (pageNo < 0 || pageNo >= _pages.Length)
                throw new Exception("invalid page number");
            _newPage = pageNo;
        }

        private string FormatSetupButton(SetupButton button)
        {
            switch (button)
            {
                case SetupButton.Previous:
                    return "&Previous";
                case SetupButton.Next:
                    return "&Next";
                case SetupButton.Cancel:
                    return "&Cancel";
                case SetupButton.Finish:
                    return "&Finish";
                default:
                    throw new Exception("invalid button");
            }
        }

        private void Execute()
        {
            ISetupPage page = _pages[_newPage];
            if (page == null)
                throw new Exception("invalid page");
            if(_hasOrigin)
                page.OnButtonClicked(_origin);
            var window = page.GetWindow();
            if (window == null)
                throw new Exception("invalid window");
            window.Dock = DockStyle.Fill;
            var buttons = page.GetButtons();
            if (buttons == null)
                throw new Exception("invalid buttons");
            wizardButtonLayout.Controls.Clear();
            for(int i = 0; i < buttons.Length; i++)
            {
                var button = buttons[buttons.Length - 1 - i];
                var buttonCaption = FormatSetupButton(button);

                var buttonWindow = new Button();
                buttonWindow.Size = new Size(150, 40);
                buttonWindow.Text = buttonCaption;
                buttonWindow.Tag = button;
                buttonWindow.Click += SetupButtonWindow_Click;

                wizardButtonLayout.Controls.Add(buttonWindow, i, 0);
            }
            _currentPage = _newPage;

            setupPageContainer.Controls.Clear();
            setupPageContainer.Controls.Add(window);
            // setupPageContainer.Invalidate();

            AdjustAgenda();
        }

        private void SetupButtonWindow_Click(object sender, EventArgs e)
        {
            var page = _pages[_currentPage];
            var button = (Button)sender;
            var setupButton = (SetupButton)button.Tag;

            try
            {
                page.OnButtonClicked(setupButton);

                var newPageNo = _currentPage + 
                    (setupButton == SetupButton.Next ? 1 : setupButton == SetupButton.Previous ? -1 : 0);

                if(newPageNo == _currentPage)
                {
                    DialogResult = setupButton == SetupButton.Finish ? DialogResult.OK : DialogResult.Cancel;
                    Close();
                    return;
                }

                SetOrigin(setupButton);
                SetCurrentPage(newPageNo);
                Execute();
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Wizard Exception Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Setup_Load(object sender, EventArgs e)
        {
             
        }
    }
}
