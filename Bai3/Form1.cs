using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Bai3
{
    public partial class Form1 : Form
    {
        public string path = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;
           
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                richText.ForeColor = fontDlg.Color;
                richText.Font = fontDlg.Font;
            }    

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NewVanBan();


        }
        private void NewVanBan()
        {
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                txtphongchu.Items.Add(font.Name);

            }
            for (int size = 8; size <= 72; size++)
            {
                txtcochu.Items.Add(size);
            }
            txtphongchu.SelectedIndexChanged += (sender, e) => UpdateFont();
            txtcochu.SelectedIndexChanged += (sender, e) => UpdateFont();
           
            //richText.Font =new Font("Tahoma",14,FontStyle.Bold);
            //txtcochu.SelectedItem = "14";
            //txtphongchu.SelectedItem = "Tahoma";
            path = " ";

        }
        private void UpdateFont()
        {
            
            if (txtphongchu.SelectedItem != null && txtcochu.SelectedItem != null)
            {
                string selectedFont = txtphongchu.SelectedItem.ToString();
                int selectedSize = (int)txtcochu.SelectedItem;

                
                Font font = new Font(selectedFont, selectedSize);
                richText.Font = font; 
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog= new SaveFileDialog();
            saveFileDialog.CheckFileExists = true;
            saveFileDialog.DefaultExt = "rtf";
            saveFileDialog.Filter = "RichText file|*.rtf";
            saveFileDialog.RestoreDirectory = true;
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                richText.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                MessageBox.Show("Lưu file thành công " + saveFileDialog.FileName, "Thông báo");

            }  
                

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (richText.SelectionFont.Bold)
            {
                richText.SelectionFont = new Font(richText.SelectionFont, richText.SelectionFont.Style & ~FontStyle.Bold);

            }
            else
            {
                richText.SelectionFont = new Font(richText.SelectionFont, richText.SelectionFont.Style | FontStyle.Bold);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (richText.SelectionFont.Italic)
            {
                richText.SelectionFont = new Font(richText.SelectionFont, richText.SelectionFont.Style & ~FontStyle.Italic);
            }
            else
            {
                richText.SelectionFont = new Font(richText.SelectionFont, richText.SelectionFont.Style | FontStyle.Italic);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (richText.SelectionFont.Underline)
            {
                richText.SelectionFont = new Font(richText.SelectionFont, richText.SelectionFont.Style & ~FontStyle.Underline);
            }
            else
            {
                richText.SelectionFont = new Font(richText.SelectionFont, richText.SelectionFont.Style | FontStyle.Underline);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richText.Clear();
        }
    }
}
