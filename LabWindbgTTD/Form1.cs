using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabWindbgTTD
{
    public partial class Form1 : Form
    {
        private StreamWriter LogFile { get; set; }

        public Form1()
        {
            InitializeComponent();
            LogFile = new StreamWriter("LogLabTDD" + Guid.NewGuid().ToString("N") + ".txt");
            
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                await LogFile.WriteAsync(TxtLog.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            await Task.Run(BadCodeWaitAndClose);
        }

        private async Task BadCodeWaitAndClose()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            BadCodeClosesFileUnexpectedly();
        }

        private void BadCodeClosesFileUnexpectedly()
        {
            LogFile.Dispose();
        }
    }
}
