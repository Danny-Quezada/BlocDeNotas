
using BlocDeNotas.AppCore.IServices;
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

namespace BlocDeNotas.Forms
{
    public partial class FrmBloc : Form
    {
        private string GlobalPath;
        private IDirectoryServices services;
        public FrmBloc(IDirectoryServices cServices)
        {
            InitializeComponent();
            this.services = cServices;
        }
        private void fileNew()
        {
            try
            {
                if (services.CheckRoute(TreeViewDirectory.SelectedNode.Tag.ToString()))
                {
                    MessageBox.Show("Please select a file.");
                    return;
                }
                TreeViewDirectory.BeginUpdate();
                frm frm = new frm();
                frm.ShowDialog();
                string name = frm.name + ".txt";
                if (name.Length != 4)
                {
                    DirectoryInfo info = services.CreateFile(TreeViewDirectory.SelectedNode.Tag.ToString(), @"\\" + name);
                    TreeNode node = new TreeNode("📎  " + name);
                    node.Tag = info.FullName;
                    TreeViewDirectory.SelectedNode.Nodes.Add(node);
                    TreeViewDirectory.EndUpdate();
                }
                else
                {
                    MessageBox.Show("Please select a file.");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Please select a file.");
            }
        }
        private void folderNew()
        {

            try
            {

                if (services.CheckRoute(TreeViewDirectory.SelectedNode.Tag.ToString()))
                {
                    MessageBox.Show("Please select a file.");
                    return;
                }
                TreeViewDirectory.BeginUpdate();
                frm frm = new frm();
                frm.ShowDialog();
                string name = frm.name;
                if (name != String.Empty)
                {
                    DirectoryInfo info = services.Create(TreeViewDirectory.SelectedNode.Tag.ToString() + @"\\" + name);
                    TreeViewDirectory.SelectedNode.Nodes.Add(AddDirectoryNodes(info));
                }
                else
                {
                    MessageBox.Show("Please select a file.");
                }
                TreeViewDirectory.EndUpdate();
            }
            catch (Exception)
            {
                MessageBox.Show("Please select a file.");
            }
        }
        private void OpenFile()
        {

            if (Path.HasExtension(TreeViewDirectory.SelectedNode.Tag.ToString()))
            {
                if (TreeViewDirectory.SelectedNode.Tag.ToString().Contains(".txt"))
                {
                    GlobalPath = TreeViewDirectory.SelectedNode.Tag.ToString();
                    rtbFile.Text = String.Empty;
                    rtbFile.Text = services.Read(TreeViewDirectory.SelectedNode.Tag.ToString());
                }
            }
            else if (Path.IsPathRooted(TreeViewDirectory.SelectedNode.Tag.ToString()))
            {
                MessageBox.Show("Files only, please");
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                String GlobalPath = dialog.SelectedPath;
                TreeViewDirectory.Nodes.Add(AddDirectoryNodes(services.Create(GlobalPath)));
            }
        }
        private TreeNode AddDirectoryNodes(DirectoryInfo info)
        {
            TreeNode root = new TreeNode("🖿  " + info.Name);
            String path = info.FullName;
            root.Tag = path;
            foreach (var items in info.GetFiles())
            {
                TreeNode file = new TreeNode("📎  " + items.Name);
                file.Tag = items.FullName;
                root.Nodes.Add(file);
            }
            foreach (var items in info.GetDirectories())
            {
                root.Nodes.Add(AddDirectoryNodes(items));
            }

            return root;
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FontColor.ShowDialog() == DialogResult.OK)
            {
                rtbFile.ForeColor = FontColor.Color;
            }
        }


        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FontColor.ShowDialog() == DialogResult.OK)
            {
                rtbFile.ForeColor = FontColor.Color;
            }
        }

        private void fontFamilyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FontDialog.ShowDialog() == DialogResult.OK)
            {
                rtbFile.Font = FontDialog.Font;
            }
        }
        private void folderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            folderNew();
        }

        private void pruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbFile.Text = TreeViewDirectory.SelectedNode.Tag.ToString();
        }

        private void TreeViewDirectory_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void TreeViewDirectory_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (Path.IsPathRooted(files[0]))
            {
                MessageBox.Show(files[0]);
                TreeViewDirectory.Nodes.Add(AddDirectoryNodes(services.Create(files[0])));
            }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                String path = TreeViewDirectory.SelectedNode.Tag.ToString();
                if (Path.IsPathRooted(path))
                {
                    if (Path.HasExtension(path))
                    {
                        File.Delete(path);
                        MessageBox.Show("Delete");
                        TreeViewDirectory.Nodes.Remove(TreeViewDirectory.SelectedNode);
                    }
                    else
                    {
                        services.Delete(path);
                        MessageBox.Show("Delete");
                        TreeViewDirectory.Nodes.Remove(TreeViewDirectory.SelectedNode);
                    }

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Select a file or Folder");
            }

        }

        private void fileToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            fileNew();
        }

        private void fileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fileNew();
        }

        private void folderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            folderNew();
        }


        private void TreeViewDirectory_DoubleClick(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
         
                services.OverWrite(GlobalPath, rtbFile.Text);
               
        }


    }
}
