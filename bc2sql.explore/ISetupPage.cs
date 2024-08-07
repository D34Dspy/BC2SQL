using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bc2sql.explore
{
    internal interface ISetupPage
    {
        SetupButton[] GetButtons();
        void OnButtonClicked(SetupButton button);
        string GetCaption();
        UserControl GetWindow();
        bool HasBeenConfigured();
    }
}
