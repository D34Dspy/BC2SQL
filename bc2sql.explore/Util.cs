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
            help.IsBalloon = true;
            help.SetToolTip(ctrl, caption);
        }
    }
}
