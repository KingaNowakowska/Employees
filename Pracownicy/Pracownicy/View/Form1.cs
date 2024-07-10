using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Pracownicy.View
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dateTime.MaxDate = DateTime.Now;
        }

        public event Action AddRow;
        public event Action SaveData;
        public event Action LoadData;
        public event Action<string> LoadDataClicked;



        public System.Windows.Forms.TextBox UserName
        {
            get
            {
                return tbName;
            }
            set
            {
                tbName = value;
            }
        }

        public System.Windows.Forms.TextBox UserSurname
        {
            get
            {
                return tbSurname;
            }
            set
            {
                tbSurname = value;
            }
        }

        public DateTimePicker SelectedDate
        {
            get
            {
                return dateTime;
            }
            set
            {
                dateTime = value;
            }
        }

        public NumericUpDown Salary
        {
            get
            {
                return nbSalary;
            }
            set
            {
                nbSalary = value;
            }
        }
        public System.Windows.Forms.ComboBox Position
        {
            get
            {
                return ddlPosition;
            }
            set
            {
                ddlPosition = value;
            }
        }

        public ListBox DataAAA
        {
            get
            {
                return tbData;
            }
            set
            {
                tbData = value;
            }
        }

        public string Contract
        {
            get
            {
                if (radioButton2.Checked)
                {
                    return "umowa na czas nieokreślony";
                }
                if (radioButton3.Checked)
                {
                    return "umowa na czas określony";
                }
                if (radioButton4.Checked)
                {
                    return "umowa zlecenie";
                }
                return "";
            }
            set
            {
                Contract = value;
            }
        }

        public System.Windows.Forms.RadioButton R1
        {
            get
            {
                return radioButton2;
            }
            set
            {
                radioButton2 = value;
            }
        }
        public System.Windows.Forms.RadioButton R2
        {
            get
            {
                return radioButton3;
            }
            set
            {
                radioButton3 = value;
            }
        }

        public System.Windows.Forms.RadioButton R3
        {
            get
            {
                return radioButton4;
            }
            set
            {
                radioButton4 = value;
            }
        }
      

        public System.Windows.Forms.Button buttonAdd
        {
            get
            {
                return btnAdd;
            }
            set
            {
                btnAdd = value;
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddRow?.Invoke();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData?.Invoke();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData?.Invoke();
        }

        

        private void dataClicked(object sender, EventArgs e)
        {
            ListBox sender2 = sender as ListBox;
            if (sender2.SelectedItem != null)
            {
                LoadDataClicked?.Invoke(sender2.SelectedItem.ToString());
            }
        }
    }
}
