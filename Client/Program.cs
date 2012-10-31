using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using Common;
using System.Threading;
using System.Windows.Forms;

namespace SuperSimpleSync
{
    class Program
    {
        //reads into temp folder and reads in the TestSyncDir folder
       private DirectoryInfo LocalStorage = new System.IO.DirectoryInfo(@"C:\temp\TestSyncDir");

       public void setLocalStorage(string p)
       {

           LocalStorage = new System.IO.DirectoryInfo(p);
           return;
       }
        
        private Guid accountId = Guid.Parse("{FC948776-0FA5-4ABC-A2F3-E8AC8005DFCA}");
        //public void setAccId(string p)
        //{

        //    accountId = Guid.Parse("{" + p + "}");

        //    return;

        //}
        //SyncServer never used
        SyncServer.Sync _sync = new SyncServer.Sync();

       // Program begins
        static void Main(string[] args)
        {
            Application.Run(new Form1());
        }

        public void SyncWithServer()
        {
            //stores the local directory
            SyncDir local = Util.AuditTree(LocalStorage);
            //creates new directory on server with name of accountId, contains the Directory stored in local 
            SyncDir server = Util.FromXml<SyncDir>(_sync.GetServerSyncDir(accountId, local.Name));
            Util.RebuildParentRelationships(server);
            //updates server directory with any new/updated files/folders
            ResolveDifferencesWithLocal(server.GetNewerFiles(local), LocalStorage);
            //updates 
            ResolveDifferencesWithServer(local.GetNewerFiles(server), LocalStorage);
        }

        private void ResolveDifferencesWithServer(SyncDir diff, DirectoryInfo dir)
        {
            //Copies over Files
            if (diff.Files != null)
            {
                foreach (SyncFile f in diff.Files)
                {
                    byte[] buffer = File.ReadAllBytes(dir.FullName + Path.DirectorySeparatorChar + f.Name);
                    _sync.SendFileToServer(accountId, f.BuildPath(), buffer);
                }
            }
            //Copies over Directories and recalls ResolveDifferencesWithServer to copy over directores/files within
            
            if (diff.Directories != null)
            {
                int dim = diff.Directories.Count();
                //foreach (SyncDir d in diff.Directories)
                 foreach (SyncDir d in diff.Directories)
                {
                   DirectoryInfo sub1 = new DirectoryInfo(dir.FullName + Path.DirectorySeparatorChar + d.Name);
                    DirectoryInfo sub = new DirectoryInfo(@"C:\temp\TestServerStorage" + Path.DirectorySeparatorChar + accountId.ToString() + Path.DirectorySeparatorChar + dir.Name + Path.DirectorySeparatorChar + d.Name);
                    if (!sub.Exists) 
                     sub.Create();

                    
                       ResolveDifferencesWithServer(d, sub1);
                }
            }
        }

        
        private void ResolveDifferencesWithLocal(SyncDir diff, DirectoryInfo dir)
        {

            int dim = diff.Directories.Count();
            if (diff.Files != null)
            {
                foreach (SyncFile f in diff.Files)
                {
                    byte[] buffer = _sync.GetFileFromServer(accountId, f.BuildPath());
                    File.WriteAllBytes(dir.FullName + Path.DirectorySeparatorChar + f.Name, buffer);
                }
            }
            if (diff.Directories != null)
            {
                foreach (SyncDir d in diff.Directories)
                {
                    DirectoryInfo sub = new DirectoryInfo(dir.FullName + Path.DirectorySeparatorChar + d.Name);
                    if (!sub.Exists)
                        sub.Create();
                    ResolveDifferencesWithLocal(d, sub);
                }
            }
        }
    }
}
