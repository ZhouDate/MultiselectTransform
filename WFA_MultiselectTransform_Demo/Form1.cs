//Name：Form1 
//Summary：Form demo 
//Maker：zzf 
//Make time：201512071602
//Other： 
//-------------------------------------------- 
//No     Editor     UpdateTime       Note 

using System;
using System.Linq;
using System.Windows.Forms;

namespace WFA_MultiselectTransform_Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //get true or false by checked
            bool[] bolarray = new bool[this.checkedListBox.Items.Count];
            for (int i = 0; i < this.checkedListBox.Items.Count; i++)
            {
                bolarray[i] = this.checkedListBox.GetItemChecked(i);
            }

            MultiselectTransformDemo transform = new MultiselectTransformDemo(bolarray.ToList());

            object strrtn = "";

            transform.Transform(ref strrtn);

            MessageBox.Show(strrtn.ToString());
        }

        //this is Simplify Method 
        private void SimplifyDemo(bool bolIndexDesc)
        {
            //get '1' or '0' by bool
            char[] chararray = new char[this.checkedListBox.Items.Count];
            for (int i = 0; i < this.checkedListBox.Items.Count; i++)
            {
                chararray[i] = this.checkedListBox.GetItemChecked(i) ? '1' : '0';
            }

            //create new array
            char[] newchararray = new char[chararray.Length];
            chararray.CopyTo(newchararray, 0);

            //Asc or Desc
            if (bolIndexDesc)
            {
                for (int i = chararray.Length - 1; i >= 0; i--)
                {
                    newchararray[chararray.Length - i - 1] = chararray[i];
                }
            }

            //Binary to Decimal
            int intmode = Convert.ToInt32(new string(newchararray), 2);

            //switch and show
            switch (intmode)
            {
                case 0:
                    MessageBox.Show("Index is 0");
                    break;
                case 1:
                    MessageBox.Show("This is Test1! ");
                    break;
                case 2:
                    MessageBox.Show("This is Test2! ");
                    break;
                case 3:
                    MessageBox.Show("This is Test1! This is Test2! ");
                    break;
                case 4:
                    MessageBox.Show("This is Test4! ");
                    break;
                default:
                    MessageBox.Show("Nothing! ");
                    break;
            }
        }
    }
}
