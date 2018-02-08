//Lab11
//File Copier
//CIS 365
//Dr. Lewis
//Summer 2017
//By John Knowles
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileCopier
{
    public partial class FrmFileCopier : Form
    {
        private const int MaxLevel = 2;
        public class FileComparer : IComparer<FileInfo>
        {
            public int Compare(FileInfo file1, FileInfo file2)
            {
                if (file1.Length > file2.Length)
                {
                    return -1;
                }
                if (file1.Length < file2.Length)
                {
                    return 1;
                }
                return 0;
            }
        }
        public FrmFileCopier()
        {
            InitializeComponent();
            FillDirectoryTree(tvwSource, true);
            FillDirectoryTree(tvwTargetDir, false);
        }

        private void FillDirectoryTree(TreeView tvw, bool isSource)
        {
            tvw.Nodes.Clear();
            string[] strDrives = Environment.GetLogicalDrives();
            foreach (string rootDirectoryName in strDrives)
            {
                try
                {
                    DirectoryInfo dir = new DirectoryInfo(rootDirectoryName);
                    dir.GetDirectories();
                    TreeNode ndRoot = new TreeNode(rootDirectoryName);
                    tvw.Nodes.Add(ndRoot);
                    if (isSource)
                    {
                        GetSubDirectoryNodes(ndRoot, ndRoot.Text, true, 1);
                    }
                    else
                    {
                        GetSubDirectoryNodes(ndRoot, ndRoot.Text, false, 1);
                    }
                }
                catch
                {
                }
            }
        }

        private void GetSubDirectoryNodes(TreeNode parentNode, string fullName, bool getFileNames, int level)
        {
            DirectoryInfo dir = new DirectoryInfo(fullName);
            DirectoryInfo[] dirSubs = dir.GetDirectories();

            foreach (DirectoryInfo dirSub in dirSubs)
            {
                if ((dirSub.Attributes & FileAttributes.Hidden) != 0)
                {
                    continue;
                }
                TreeNode subNode = new TreeNode(dirSub.Name);
                parentNode.Nodes.Add(subNode);
                if (level < MaxLevel)
                {
                    GetSubDirectoryNodes(subNode, dirSub.FullName, getFileNames, level + 1);
                }
            }
            if (getFileNames)
            {
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    TreeNode fileNode = new TreeNode(file.Name);
                    parentNode.Nodes.Add(fileNode);
                }
            }

        }

        private void tvwSource_AfterCheck(object sender, TreeViewEventArgs e)
        {
            SetCheck(e.Node, e.Node.Checked);
        }

        private void SetCheck(TreeNode node, bool check)
        {
            foreach (TreeNode n in node.Nodes)
            {
                n.Checked = check;
                if (n.Nodes.Count != 0)
                {
                    SetCheck(n, check);
                }
            }
        }

        private void tvwSource_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            tvwExpand(sender, e.Node);
        }

        private void tvwExpand(object sender, TreeNode currentNode)
        {
            TreeView tvw = (TreeView)sender;
            bool getFiles = (tvw == tvwSource);
            string fullName = currentNode.FullPath;
            currentNode.Nodes.Clear();
            GetSubDirectoryNodes(currentNode, fullName, getFiles, 1);
        }

        private void tvwTargetDir_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string theFullPath = e.Node.FullPath;
            if (theFullPath.EndsWith("\\"))
            {
                theFullPath = theFullPath.Substring(0, theFullPath.Length - 1);
            }
            txtTargetDir.Text = theFullPath;
        }

        protected void btnCancel_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void btnClear_Click(object sender, System.EventArgs e)
        {
            foreach (TreeNode node in tvwSource.Nodes)
            {
                SetCheck(node, false);
            }
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            // Put up an idiot box
            System.Windows.Forms.DialogResult result =
                MessageBox.Show(
                "Are you quite sure?",              // msg
                "Delete Files",                     // caption
                MessageBoxButtons.OKCancel,         // buttons
                MessageBoxIcon.Exclamation,         // icons
                MessageBoxDefaultButton.Button2);  // default button
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                List<FileInfo> fileNames = GetFileList();
                foreach (FileInfo file in fileNames)
                {
                    try
                    {
                        // update the label to show progress
                        lblStatus.Text = "Deleting " +
                            txtTargetDir.Text + "\\" +
                            file.Name + "...";
                        Application.DoEvents();
                        file.Delete();
                    }
                    catch (Exception ex)
                    {
                        // you may want to do more than
                        // just show the message
                        MessageBox.Show(ex.Message);
                    }
                }
                lblStatus.Text = "Done.";
                Application.DoEvents();
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            List<FileInfo> fileList = GetFileList();
            foreach (FileInfo file in fileList)
            {
                try
                {
                    lblStatus.Text = "Copying " + txtTargetDir.Text +
                    "\\" + file.Name + "...";
                    Application.DoEvents();
                    // copy the file to its destination location
                    file.CopyTo(txtTargetDir.Text + "\\" +
                    file.Name, chkOverwrite.Checked);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            lblStatus.Text = "Done.";
        }



        private List<FileInfo> GetFileList()
        {
            List<string> fileNames = new List<string>();
            List<FileInfo> fileList = new List<FileInfo>();
            foreach (TreeNode theNode in tvwSource.Nodes)
            {
                GetCheckedFiles(theNode, fileNames);
               
                foreach (string fileName in fileNames)
                {
                    FileInfo file = new FileInfo(fileName);
                    if (file.Exists)
                    {
                        fileList.Add(file);
                    }
                }
                IComparer<FileInfo> comparer = (IComparer<FileInfo>)new FileComparer();
                fileList.Sort(comparer);
                
            }
            return fileList;
        }

        private void GetCheckedFiles(TreeNode node, List<string> fileNames)
        {
            // first check to see if this is a leaf
            if (node.Nodes.Count == 0)
            {
                // if the node was checked
                if (node.Checked)
                {
                    // add the full path to the List
                    fileNames.Add(node.FullPath);
                }
            }
            else // if not a leaf, use our friend RECURSION
            {
                foreach (TreeNode n in node.Nodes)
                {
                    GetCheckedFiles(n, fileNames);
                }
            }
        }

    }
}