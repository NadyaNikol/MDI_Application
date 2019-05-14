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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static int Count =0;
        public Form1()
        {
            InitializeComponent();
            IsMdiContainer = true;

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Child child = new Child();
            child.MdiParent = this;

            child.Text = (++Count).ToString();
            child.Show();
        }

        private void maximizeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.WindowState = FormWindowState.Maximized;
            }
        }

        private void minimazeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.WindowState = FormWindowState.Minimized;
            }

        }

        private void maximazeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ActiveMdiChild.WindowState = FormWindowState.Maximized;
        }

        private void minimazeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ActiveMdiChild.WindowState = FormWindowState.Minimized;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ActiveMdiChild.Close();
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void horisontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                RichTextBox richTextBox = null;

                foreach (var item in this.ActiveMdiChild.Controls)
                {
                    if (item is RichTextBox)
                    {
                        richTextBox = item as RichTextBox;
                        break;
                    }
                }

                if (richTextBox !=null)
                {
                    richTextBox.Text = File.ReadAllText(dialog.FileName, Encoding.Default);
                }

                this.ActiveMdiChild.Text = Path.GetFileName(dialog.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "All files(*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                RichTextBox richTextBox = null;

                foreach (var item in this.ActiveMdiChild.Controls)
                {
                    if (item is RichTextBox)
                    {
                        richTextBox = item as RichTextBox;
                        break;
                    }
                }


                if (richTextBox != null)
                {
                    File.WriteAllText(dialog.FileName, richTextBox.Text);
                }

            }
        }
    }
}
