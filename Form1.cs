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

namespace Week3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // OPEN A TEXT FILE
        string currentPath = "";

        private void openTextFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFile = new OpenFileDialog();
            oFile.Title = "Choose the file to be opened.";
            oFile.InitialDirectory = @"U:\data";
            oFile.Filter = "Text files(*.txt)|*.txt|All files (*.*)|*.*";
            if (oFile.ShowDialog() == DialogResult.OK)
            {
                //StreamReader infile;
                //infile = File.OpenText(oFile.FileName);
                // one line statement is also fine
                //StreamReader infile = new StreamReader(currentPath);
                //rtbEditor.Text = infile.ReadToEnd();
                //Alternative code using LoadFile() method of rtb
                rtbEditor.LoadFile(oFile.FileName, RichTextBoxStreamType.PlainText);
                currentPath = oFile.FileName;
                this.Text = currentPath;
            }
        }


        //OPEN RTF DOCUMENT
                private void openRTFDocumentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFile = new OpenFileDialog();
            oFile.Title = "Choose a RTF file to be opened.";
            oFile.InitialDirectory = @"U:\data";
            oFile.Filter = "RTF files(*.rtf)|*.rtf|all files (*.*)|*.*";
            if (oFile.ShowDialog() == DialogResult.OK && oFile.FileName.Length > 0)
            {
                try
                {
                    rtbEditor.LoadFile(oFile.FileName);
                    currentPath = oFile.FileName;
                    this.Text = currentPath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        // SAVE AS IN TEXT FORMAT
        private void saveAsTextFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sFile = new SaveFileDialog();
            sFile.Title = "Navigate to the right folder and type the name of the file to be saved.";
            sFile.InitialDirectory = @"U:\data";
            sFile.Filter = "Text files(*.txt)|*.txt|All files (*.*)|*.*";
            DialogResult dResult = sFile.ShowDialog();
            try
            {
                if (dResult == DialogResult.OK)
                {
                    rtbEditor.SaveFile(sFile.FileName, RichTextBoxStreamType.PlainText);
                    currentPath = sFile.FileName;
                    //Alternative code using StreamWriter
                    //StreamWriter outFile = new StreamWriter(sFile.FileName);
                    //outFile.Write(rtbEditor.Text);
                    //outFile.Close();
                    //currentPath = sFile.FileName;
                    this.Text = currentPath;
                    MessageBox.Show(sFile.FileName + " is saved.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // SAVE IN RTF FORMAT
        private void saveAsRTFDocumentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sFile = new SaveFileDialog();
            sFile.Title = "Click the save button to save your file in RTF format.";
            sFile.InitialDirectory = @"U:\data";
            sFile.DefaultExt = "rtf";
            sFile.Filter = "RTF files(*.rtf)|*.rtf|All files (*.*)|*.*";
            DialogResult dResult = sFile.ShowDialog();
            try
            {
                if (dResult == DialogResult.OK && sFile.FileName.Length > 0)
                {
                    rtbEditor.SaveFile(sFile.FileName);
                    currentPath = sFile.FileName;
                    this.Text = currentPath;
                    MessageBox.Show(sFile.FileName + " is saved.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //OPEN A NEW FORM TO WORN ON
        private void openFileInANewWindowToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Open a modeless form
            Form1 anotherWindow = new Form1();
            anotherWindow.Show();
        }


        //EXIT
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //CLOSE
        private void closeFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Do you want to save the content?",
               "File saving confirmation", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                if (currentPath != "")
                {
                    rtbEditor.SaveFile(currentPath);
                }
                else
                {
                    SaveFileDialog sFile = new SaveFileDialog();
                    sFile.Title = "Click the Save Button to save your file in rtf format";
                    sFile.InitialDirectory = @"U:\Data";
                    sFile.DefaultExt = "rtf";
                    sFile.Filter = "RTF files(*.rtf)|*.rtf|All files(*.*)|*.*";
                    DialogResult dResult = sFile.ShowDialog();
                    try
                    {
                        if (dResult == DialogResult.OK && sFile.FileName.Length > 0)
                        {
                            rtbEditor.SaveFile(sFile.FileName);
                            MessageBox.Show(sFile.FileName + " is saved.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            rtbEditor.Clear();
            this.Text = "Super Editor";
        }

      

        //BTN Normal
        private void btnNormal_Click(object sender, EventArgs e)
        {
            Font new1, old1;
            old1 = rtbEditor.SelectionFont;
            new1 = new Font(old1, FontStyle.Regular);
            rtbEditor.SelectionFont = new1;
            rtbEditor.Focus();
        }

        //BTN BOLD
        private void btnbold_Click(object sender, EventArgs e)
        {
            Font new1, old1;
            old1 = rtbEditor.SelectionFont;
            if (old1.Bold)
                new1 = new Font(old1, old1.Style & ~FontStyle.Bold);
            else
                new1 = new Font(old1, old1.Style | FontStyle.Bold);

            rtbEditor.SelectionFont = new1;
            rtbEditor.Focus();
        }

        // BTN ITALIC
        private void btnItalic_Click(object sender, EventArgs e)
        {
            Font new1, old1;
            old1 = rtbEditor.SelectionFont;
            if (old1.Italic)
                new1 = new Font(old1, old1.Style & ~FontStyle.Italic);
            else
                new1 = new Font(old1, old1.Style | FontStyle.Italic);

            rtbEditor.SelectionFont = new1;
            rtbEditor.Focus();
        }

        //BTN UNDERLINE
        private void btnUnderline_Click(object sender, EventArgs e)
        {
            Font new1, old1;
            old1 = rtbEditor.SelectionFont;
            if (old1.Underline)
                new1 = new Font(old1, old1.Style & ~FontStyle.Underline);
            else
                new1 = new Font(old1, old1.Style | FontStyle.Underline);
            rtbEditor.SelectionFont = new1;
            rtbEditor.Focus();
        }
        //BTN StrikeOut
        private void btnStrike_Click(object sender, EventArgs e)
        {
            Font new1, old1;
            old1 = rtbEditor.SelectionFont;
            if (old1.Strikeout)
                new1 = new Font(old1, old1.Style & ~FontStyle.Strikeout);
            else
                new1 = new Font(old1, old1.Style | FontStyle.Strikeout);
            rtbEditor.SelectionFont = new1;
            rtbEditor.Focus();
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = int.Parse(cboSize.SelectedItem.ToString());
            if(rtbEditor.SelectionLength > 0)
            {
                Font currentFont = rtbEditor.SelectionFont;
                rtbEditor.SelectionFont = new Font(currentFont.FontFamily, x, currentFont.Style);
                rtbEditor.Focus();

                // How to take out the border
                // How to add the timer
            }
        }

        /*************MODAL FORMS*****************/

        //Open a modaless form
        private void showANewModelessFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            Form1 anotherWindow = new Form1();
            anotherWindow.Show();
        }

        //About menu item code: open a modal form
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Welcome wform = new Welcome();
            wform.ShowDialog();
        }




    }
}
