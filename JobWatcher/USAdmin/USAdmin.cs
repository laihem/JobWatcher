using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;

namespace USAdmin
{
    public partial class USAdmin : Form
    {
        private const string CONST_WATCHER_SERVICE = "Job Watcher Service";
        public USAdmin()
        {
            InitializeComponent();
        }

        private void USAdmin_Load(object sender, EventArgs e)
        {
            lblServiceStatus.Text = "Service Status: " + getServiceStatus();
            if (lblServiceStatus.Text.Contains("Stopped"))
            {
                btnStartService.Enabled = true;
            }
            else
            {
                btnStopService.Enabled = true;
            }
        }

        public string getServiceStatus()
        {
            ServiceController sc = new ServiceController("Job Watcher Windows Service");
            string serviceStatus = string.Empty;

            try
            {
                serviceStatus = sc.Status.ToString();
            }
            catch(Exception excp)
            {
                MessageBox.Show(excp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return serviceStatus;
            
        }

        private void btnGetServiceStatus_Click(object sender, EventArgs e)
        {
            lblServiceStatus.Text = "Service Status: " + getServiceStatus();
            if (lblServiceStatus.Text.Contains("Stopped"))
            {
                btnStartService.Enabled = true;
            }
            else
            {
                btnStopService.Enabled = true;
            }
        }

        public bool startService()
        {
            ServiceController sc = new ServiceController(CONST_WATCHER_SERVICE);
            try
            {
                sc.Start();
                sc.WaitForStatus(ServiceControllerStatus.Running);
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public bool stopService()
        {
            ServiceController sc = new ServiceController(CONST_WATCHER_SERVICE);
            try
            {
                sc.Stop();
                sc.WaitForStatus(ServiceControllerStatus.Stopped);
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnStartService_Click(object sender, EventArgs e)
        {
            if (startService())
            {
                btnStartService.Enabled = false;
                btnStopService.Enabled = true;
                lblServiceStatus.Text = "Service Status: Started";
            }
        }

        private void btnStopService_Click(object sender, EventArgs e)
        {
            if (stopService())
            {
                btnStartService.Enabled = true;
                btnStopService.Enabled = false;
                lblServiceStatus.Text = "Service Status: Stopped";
            }
        }
    }
}
