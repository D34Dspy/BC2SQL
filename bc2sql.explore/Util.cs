using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bc2sql.explore
{
    internal class Util
    {
        public static void Bind(DataGridView dgv, string sourceField, string caption, string description)
        {
            var col = new DataGridViewColumn();
            if(sourceField != null && sourceField != string.Empty)
                col.DataPropertyName = sourceField;
            col.HeaderText = caption;
            col.ToolTipText = description;
            if (dgv.AutoGenerateColumns)
                dgv.AutoGenerateColumns = false;
            col.CellTemplate = new DataGridViewTextBoxCell();
            dgv.Columns.Add(col);
        }
        public static void BindIdx(DataGridView dgv, string caption, string description)
        {
            var col = new DataGridViewColumn();
            col.HeaderText = caption;
            col.ToolTipText = description;
            if (dgv.AutoGenerateColumns)
                dgv.AutoGenerateColumns = false;
            col.CellTemplate = new DataGridViewTextBoxCell();
            dgv.Columns.Add(col);
        }
        public static void BindHelp(ToolTip help, Control ctrl, string caption)
        {
            help.ToolTipIcon = ToolTipIcon.Info;
            help.ToolTipTitle = "Reference";
            help.SetToolTip(ctrl, caption);
        }
        static SetupButton[] _firstButtons, _defaultButtons, _lastButtons, _extendedButtons;

        public static void EnsureButtonsInitialized()
        {
            _firstButtons = new SetupButton[2]
            {
                SetupButton.Cancel,
                SetupButton.Next
            };
            _defaultButtons = new SetupButton[2]
            {
                SetupButton.Previous,
                SetupButton.Next
            };
            _lastButtons = new SetupButton[2]
            {
                SetupButton.Previous,
                SetupButton.Finish
            };
            _extendedButtons = new SetupButton[3]
            {
                SetupButton.Cancel,
                SetupButton.Previous,
                SetupButton.Finish
            };
        }
        public static SetupButton[] GetFirstSetupButtons() => _firstButtons;
        public static SetupButton[] GetDefaultSetupButtons() => _defaultButtons;
        public static SetupButton[] GetLastSetupButtons() => _lastButtons;
        public static SetupButton[] GetExtendedSetupButtons() => _extendedButtons;

        public static void SetHeading(Label lbl)
        {
            lbl.Font = new System.Drawing.Font(lbl.Font.FontFamily, 22f, System.Drawing.FontStyle.Bold);
            lbl.Margin = new Padding(0,0,0,30);
        }
        public static void SetPoint(Label lbl)
        {
            lbl.Font = new System.Drawing.Font(lbl.Font.FontFamily, 16f, System.Drawing.FontStyle.Regular);
            lbl.Margin = new Padding(0,0,0,20);
        }
    }
}
