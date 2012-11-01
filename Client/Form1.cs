using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SuperSimpleSync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        // display the tree, get the names of the directories and files and put them in the tree
        // doesn't work yet, probably needs a little tweaking
        private void InitializeTreeView(DirectoryInfo di)
        {
            cDirMap.BeginUpdate();
            cDirMap.Nodes.Clear();
            DirectoryInfo[] dirs = di.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                TreeNode dNode = new TreeNode(dir.Name);
                cDirMap.Nodes.Add(dNode);
                FileInfo[] files = dir.GetFiles();
                DirectoryInfo[] subdirs1 = dir.GetDirectories();
                foreach (DirectoryInfo subdir in subdirs1)
                {
                    TreeNode fNode = new TreeNode(subdir.Name);
                    cDirMap.Nodes.Add(fNode);
                }
                foreach (FileInfo file in files)
                {
                    TreeNode fNode = new TreeNode(file.Name);
                    cDirMap.Nodes.Add(fNode);
                }
            }
            cDirMap.EndUpdate();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //accidently made this by double clicking on treeview, haven't deleted yet
        }

        private void cSync_Click(object sender, EventArgs e)
        {
            if (cDir.Text != String.Empty)
            {
                Program p = new Program();
                //p.setAccId(cAcc.Text);
                p.setLocalStorage(cDir.Text);
                DirectoryInfo DI = p.getLocalStorage();
                InitializeTreeView(DI);
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
