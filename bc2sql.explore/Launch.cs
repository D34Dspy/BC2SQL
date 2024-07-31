using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace bc2sql.explore
{
    public partial class Launch : Form
    {
        public delegate DialogResult OnLaunch(object sender);

        class Payload
        {
            public DialogResult Result;
            public object Sender;
            public OnLaunch Target;
        }

        private Thread _launcherThread;
        private Payload _payload;

        public Launch()
        {
            InitializeComponent();
        }

        static void LauncherThread(object param)
        {
            var payload = (Payload)param;
            payload.Result = payload.Target(payload.Sender);
        }

        public Launch(object sender, OnLaunch launcher)
        {
            InitializeComponent();
            _payload = new Payload
            {
                Sender = sender,
                Target = launcher,
                Result = DialogResult.Cancel
            };
            _launcherThread = new Thread(LauncherThread);
            _launcherThread.Start(_payload);
        }

        private void Launch_Load(object sender, EventArgs e)
        {
        }

        bool IsAlive()
        {
            return _launcherThread.ThreadState == ThreadState.Running;
        }

        private void lifetimeExam_Tick(object sender, EventArgs e)
        {
            if (IsAlive())
            {
                DialogResult = _payload.Result;
                Close();
            }
        }
    }
}
