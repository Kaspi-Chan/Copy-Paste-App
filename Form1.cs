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

namespace Copy_paste_app
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(copyBox.Text);
            }
            catch (System.ArgumentNullException)
            {

            }
        }

        private void Copy1_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(copyBox1.Text);
            }
            catch (System.ArgumentNullException)
            {

            }
        }
        private void Copy2_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(copyBox2.Text);
            }
            catch (System.ArgumentNullException)
            {

            }
        }

        private void Copy3_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(copyBox3.Text);
            }
            catch (System.ArgumentNullException)
            {

            }
        }

        private void Copy4_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(copyBox4.Text);
            }
            catch (System.ArgumentNullException)
            {

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gay");
        }

        /**MATCH ID PROPERTIES*/
        private void buttonChangeText_Click(object sender, EventArgs e)
        {
            textBoxMatchId2.Text = textBoxMatchId.Text;
            textBoxMatchId.Text = null;
        }
        private void buttonMatchIDCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(textBoxMatchId2.Text);
            }
            catch (System.ArgumentNullException)
            {

            }
        }
        private void buttonEmpty_Click(object sender, EventArgs e)
        {
            textBoxMatchId2.Text = null;
        }

        /**INFOGRAPH PROPERTIES*/
        private void buttonReplace_Click(object sender, EventArgs e)
        {
            try
            {
                //textBoxInfo1 = the Info ID
                //textBoxInfo2 = the default Info link
                var infoLink = textBoxInfo2.Text;
                var aStringBuilder = new StringBuilder(infoLink);
                aStringBuilder.Remove(72, 7); // at place # remove *num of characters*
                aStringBuilder.Insert(72, textBoxMatchId2.Text);
                textBoxInfo2.Text = aStringBuilder.ToString();
            }
            catch
            {

            }
        }

        private void buttonInfoCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(textBoxInfo2.Text);
            }
            catch (System.ArgumentNullException)
            {

            }
        }

        /**DATE TIME PROPERTIES*/
        private void buttonReplaceDT_Click(object sender, EventArgs e)
        {
            try
            {
                //textBoxInfo1 = the Info ID
                //textBoxInfo2 = the default Info link
                string? inputDate = textBoxDT1.Text;
                inputDate = inputDate.Replace('/', '-');
                if (inputDate[1] == '-') // for dates that are before the 10th of the month e.g. 1/12/2022
                    inputDate = inputDate.Insert(0, "0");
                DateTime date = DateTime.ParseExact(inputDate, "dd-MM-yyyy HH:mm",
                    System.Globalization.CultureInfo.InvariantCulture);
                //change the hour to be -1h and 15 minutes from the input hour
                date = date.AddHours(-1);
                date = date.AddMinutes(-15);
                //format the string the way you want it to be
                string correctFormat = date.ToString("yyyy-MM-dd HH:mm:ss");
                textBoxDT2.Text = correctFormat;
                textBoxDT1.Text = null;
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Format not correct :< !");
            }
            
        }

        private void buttonDTCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(textBoxDT2.Text);
            }
            catch (System.ArgumentNullException)
            {

            }
        }

        private void buttonDTEmpty_Click(object sender, EventArgs e)
        {
            textBoxDT2.Text = null;
            if (textBoxDT1.Text != null)
                textBoxDT1.Text = null;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Spas e bok! ;)");
        }

        /**SAVING THE SETTINGS TO A TEXT FILE*/
        public List<TextBox> textBoxes = new List<TextBox>();
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\test.txt"))
            {
                foreach (TextBox text in textBoxes)
                {
                    sw.WriteLine(text.Text);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            List<TextBox> temp = new List<TextBox>();
            foreach (TextBox textBox in this.Controls.OfType<TextBox>())
            {
                temp.Add(textBox);
            }
            textBoxes = temp;
            if (File.Exists(@"C:\test.txt"))
            {
                using (StreamReader sr = new StreamReader(@"C:\test.txt"))
                {
                    for (int i = 0; i < textBoxes.Count; i++)
                    {
                        textBoxes[i].Text = sr.ReadLine();
                    }
                }
            }
        }

        /**ADD LINK*/
        private void buttonChangeTextAL_Click(object sender, EventArgs e)
        {
            try
            {
                var linkText = textBoxArticleLink1.Text;
                StringBuilder st = new StringBuilder(linkText);
                st.Remove(0, 27);
                textBoxArticleLink2.Text = st.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void buttonALCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(textBoxArticleLink2.Text);
            }
            catch (System.ArgumentNullException)
            {

            }
            MessageBox.Show("CLICK BUILD TEAM JSON !!!");
        }

        private void buttonALEmpty_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxArticleLink1.Text = default;
                textBoxArticleLink2.Text = default;
            }
            catch (System.ArgumentNullException)
            {

            }
        }

        private void buttonAlCopy1_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(textBoxArticleLink1.Text);
            }
            catch (System.ArgumentNullException)
            {

            }
        }


        // TO DO
        // 1. Make a function to be able to list the league's ids and easily check them (dropdown menu or smth)
    }
}
