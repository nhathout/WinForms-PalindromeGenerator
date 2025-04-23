using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Text = "Palindromes by Noah Hathout";
            this.Size = new Size(805, 437);

            button1.Text = "Generate";
            label1.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GeneratePalindromes();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            Font font = this.Font;
            g.DrawString("Enter a starting integer (0-1,000,000,000):", font, Brushes.Black, 136, 103);
            g.DrawString("Enter count (1-100):", font, Brushes.Black, 487, 102);

            Font bigfont = new Font(this.Font.FontFamily, 24, FontStyle.Bold);
            g.DrawString("Find Numeric Palindromes", bigfont, Brushes.Black, 177, 32);

            const float width = 805;
            const float height = 437;

            Rectangle rect = this.ClientRectangle;
            float scale = Math.Min(rect.Width / width, rect.Height / height);

            if (scale == 0f) return; //if window is 0 pixels in the x or y, then dont paint anything
        }

        //textbox for starting integer
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        //textbox for count
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        //listbox for displaying palindromes
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //label1 for throwing exception message
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void GeneratePalindromes()
        {
            listBox1.Items.Clear();
            label1.Text = string.Empty;

            int startInt = 0;
            int count = 0;
            bool isValid = true;

            try
            {
                startInt = int.Parse(textBox1.Text);

                if (startInt < 0 || startInt > 1000000000)
                {
                    isValid = false;
                }
            }
            catch 
            {
                isValid = false;
            }

            try
            {
                count = int.Parse(textBox2.Text);

                if(count < 1 || count > 100)
                {
                    isValid = false;
                }
            }
            catch
            {
                isValid = false;
            }

            if(!isValid)
            {
                label1.Text = "Please enter a positive integer within range.";
                return;
            }

            //generate and output palindromes to list box
            int palindromes = 0;
            while(palindromes < count)
            {
                if (IsPalindrome(startInt.ToString()))
                {
                    listBox1.Items.Add(startInt);
                    palindromes++;
                }

                startInt++;
            }
        }

        private bool IsPalindrome(string n)
        {
            return n.SequenceEqual(n.Reverse());
        }
    }
}
