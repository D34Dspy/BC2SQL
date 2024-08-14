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
            this.Visible = false;
        }

        // static void LauncherThread(object param)
        // {
        //     var payload = (Payload)param;
        //     payload.Result = payload.Target(payload.Sender);
        // }

        public Launch(object sender, OnLaunch launcher)
        {
            InitializeComponent();
            this.Visible = false;
            _payload = new Payload
            {
                Sender = sender,
                Target = launcher,
                Result = DialogResult.Abort
            };
            job.DoWork += job_DoWork;
            job.RunWorkerCompleted += Job_RunWorkerCompleted;
            // _launcherThread = new Thread(LauncherThread);
            // _launcherThread.Start(_payload);

        }

        private void Job_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DialogResult = _payload.Result;
            Close();
        }

        private void Launch_Load(object sender, EventArgs e)
        {
            job.RunWorkerAsync();
        }

        private bool _done = false;
        private void job_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_done)
                return;
            _payload.Result = _payload.Target(_payload.Sender);
            if (_payload.Result != DialogResult.Retry)
            {
                e.Result = _payload.Result;
                _done = true;
            }
            
        }
    }
}
