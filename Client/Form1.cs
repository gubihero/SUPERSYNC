using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperSimpleSync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void cSync_Click(object sender, EventArgs e)
        {
            if (cDir.Text != String.Empty)
            {
                Program p = new Program();
                //p.setAccId(cAcc.Text);
                p.setLocalStorage(cDir.Text);
                //tries to sync with server
                try
                {
                    p.SyncWithServer();
                }
                catch (Exception ex)
                {
                    //unable to sync with server
                    Console.WriteLine("There was an error syncing: " + ex.Message);
                    Environment.Exit(1);
                }
                Environment.Exit(0);
            }
        }
    }
}
