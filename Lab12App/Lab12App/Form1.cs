using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab12App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cbItalic_CheckedChanged(object sender, EventArgs e)
        {
            System.Drawing.Font currentFont = tbxSampleText.SelectionFont;
            tbxSampleText.SelectAll();
            if (cbItalic.Checked)
            {
                tbxSampleText.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   FontStyle.Italic
                   );
            }
            else
            {
                tbxSampleText.SelectionFont = new Font(
                  currentFont.FontFamily,
                  currentFont.Size,
                  FontStyle.Regular
                 );
            }
        }
    }
}
