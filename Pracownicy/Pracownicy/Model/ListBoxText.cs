using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Pracownicy.Model
{
    class ListBoxText
    {
        private View.Form1 _view;
        private Model _model;


        public ListBoxText(View.Form1 view)
        {
            _view = view;
        }
        public void AddRow()
        {
            string name = _view.UserName.Text;
            string surname = _view.UserSurname.Text;
            DateTime dateTmp = _view.SelectedDate.Value;
            string birthdayDate = dateTmp.ToString().Substring(0, 10);
            decimal salary = _view.Salary.Value;
            string position = _view.Position.Text;
            string contract = _view.Contract;

            

            bool CheckName(String name2)
            {
                if (name2 == "" || !name2.All(Char.IsLetter))
                {
                    _view.errorProvider2.SetError(_view.UserName, "Nalezy podac imie");
                    return false;

                }
                else
                {
                    _view.errorProvider2.SetError(_view.UserName, "");
                    return true;
                }

            }
            bool CheckSurname(String surname2)
            {
                if (surname2 == "" || !surname2.All(Char.IsLetter))
                {
                    _view.errorProvider2.SetError(_view.UserSurname, "Nalezy podac nazwisko");
                    return false;
                }
                else
                {
                    _view.errorProvider2.SetError(_view.UserSurname, "");
                    return true;
                }

            }

            bool CheckPosition(String position2)
            {
                if (position2 == "")
                {
                    _view.errorProvider2.SetError(_view.Position, "Nalezy podac stanowisko");
                    return false;

                }
                else
                {
                    _view.errorProvider2.SetError(_view.Position, "");
                    return true;
                }

            }

            bool CheckSalary(decimal salary2)
            {
                if (salary2 < 2709)
                {
                    _view.errorProvider2.SetError(_view.Salary, "Pensja wyzsza od 2709 zl");
                    return false;

                }
                else
                {
                    _view.errorProvider2.SetError(_view.Salary, "");
                    return true;
                }

            }

            bool CheckContract(String contract2)
            {
                if (contract2 == "")
                {
                    _view.errorProvider2.SetError(_view.R1, "Nalezy wybrac umowe");
                    return false;

                }
                else
                {
                    _view.errorProvider2.SetError(_view.R1, "");
                    return true;
                }

            }

            bool CheckDate(DateTime date2)
            {
                string date = date2.ToString().Substring(6, 4);
                string rok = DateTime.Now.ToString().Substring(6, 4);
                int lata = int.Parse(rok) - int.Parse(date);
                
                if(date=="" || lata < 18 || lata > 65)
                {
                    _view.errorProvider2.SetError(_view.SelectedDate, "Wiek niepoprawny");
                    return false;

                }
                else
                {
                    _view.errorProvider2.SetError(_view.SelectedDate, "");
                    return true;
                }

            }

            if (!CheckName(name) || !CheckSurname(surname) || !CheckDate(dateTmp) || !CheckSalary(salary) || !CheckPosition(position) || !CheckContract(contract))
            {
                return;

            }
            else
            {
                string row = $"{name} {surname}, {birthdayDate}, {position}, {salary}PLN, {contract}";
                _view.DataAAA.Items.Add(row);
            }

            _view.R1.Checked = false;
            _view.R2.Checked = false;
            _view.R3.Checked = false;
            _view.Position.Text = null;
            _view.SelectedDate.Value = Convert.ToDateTime("01.01.2000");
            _view.Salary.Value = Convert.ToDecimal("0");
            _view.UserName.Text = "";
            _view.UserSurname.Text = "";
        }
        public void SaveData()
        {
            XmlDocument file = new XmlDocument();
            XmlElement root = file.CreateElement("data");
            for (int i = 0; i < _view.DataAAA.Items.Count; i++)
            {
                XmlElement child = file.CreateElement("item");
                child.InnerText = _view.DataAAA.Items[i].ToString();
                root.AppendChild(child);
            }
            file.AppendChild(root);
            string fileName = "Dane.xml";
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                file.Save(sw);
            }
        }

        public void LoadData()
        {
            _view.DataAAA.Items.Clear();
            XmlDocument file = new XmlDocument();
            file.Load("Dane.xml");
            XmlElement root = file.DocumentElement;
            foreach (XmlNode node in root.ChildNodes)
            {
                _view.DataAAA.Items.Add(node.InnerText);
            }
        }
        public void LoadDataClicked(string data)
        {
            _view.DataAAA.SelectedIndex = -1;
            string[] pomocy = data.Split(',');
            string FirstnameSurname = pomocy[0];
            string firstname = FirstnameSurname.Split()[0];
            string surname = FirstnameSurname.Substring(firstname.Length + 1);
            string birthday = pomocy[1].Substring(1);
            string position = pomocy[2].Substring(1);
            string salary = pomocy[3].Substring(1);
            string contract = pomocy[4].Substring(1);
            _view.UserName.Text = firstname;
            _view.UserSurname.Text = surname;
            //_view.SelectedDate.Value = Convert.ToDateTime(birthday);
            _view.Salary.Value = Convert.ToDecimal(salary.Substring(0, salary.Length - 3));
            _view.Position.Text = position;

            if (contract == "umowa na czas nieokreślony")
            {
                _view.R1.Checked = true;
            }
            else if (contract == "umowa na czas określony")
            {
                _view.R2.Checked = true;
            }
            else
            {
                _view.R3.Checked = true;
            }
        }
    }
        

}
