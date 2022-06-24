using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListasForms
{
    public partial class Form1 : Form
    {

        public List<Form1> LIEmployee = new List<Form1>();



        public int Id { get; set; }
        public string EName { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public double Afp { get; set; }
        public double Sfs { get; set; }
        public double TotalDiscount { get; set; }
        public double NetIcome { get; set; }




        public Form1()
        {

            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            button1.Click += Button1_Click;
            btnShow.Click += BtnShow_Click;
            btnRemove.Click += BtnRemove_Click;
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            RemoveEmployee();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            ShowEmployee();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ShowEmployeeById();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            AddEmployee();
        }

        public double AfpValue(double salary)
        {
            return salary * 0.0287;
        }

        public double SfaValue(double salary)
        {
            return salary * 0.0304;
        }

        public double TotalDiscountValue(double afp, double sfs)
        {
            return afp + sfs;
        }

        public double NetIcomeValue(double salary, double TotalDiscount)
        {
            return salary - TotalDiscount;
        }

        public void AddEmployee()
        {          
            

                Form1 Em = new Form1();

                Em.Id = Convert.ToInt32(txtId.Text);


                Em.Name = txtName.Text;


                Em.Position = txtPosition.Text;


                Em.Salary = Convert.ToInt32(txtSalary.Text);

                Em.Afp = AfpValue(Em.Salary);
                Em.Sfs = SfaValue(Em.Salary);

                Em.TotalDiscount = TotalDiscountValue(Em.Afp, Em.Sfs);

                Em.NetIcome = NetIcomeValue(Em.Salary, Em.TotalDiscount);

                LIEmployee.Add(Em);

            dataGridView1.Rows.Clear();

            foreach (var item in LIEmployee)
            {
                dataGridView1.Rows.Add(
                  item.Id,
                  item.Name,
                  item.Position,
                  item.Salary,
                  item.Afp,
                  item.Sfs,
                  item.TotalDiscount,
                  item.NetIcome);

            }














        }

        public void ShowEmployeeById()
        {
            
            int Identify = Convert.ToInt32(textBox1.Text);

            foreach (var item in LIEmployee)
            {
                if (Identify == item.Id)
                {
                    dataGridView1.Rows.Clear();

                    dataGridView1.Rows.Add(
                  item.Id,
                  item.Name,
                  item.Position,
                  item.Salary,
                  item.Afp,
                  item.Sfs,
                  item.TotalDiscount,
                  item.NetIcome);
                }
            }

        }

        public void ShowEmployee()
        {
            dataGridView1.Rows.Clear();

            foreach (var item in LIEmployee)
            {
                

                dataGridView1.Rows.Add(
              item.Id,
              item.Name,
              item.Position,
              item.Salary,
              item.Afp,
              item.Sfs,
              item.TotalDiscount,
              item.NetIcome);
            }

        }

        public void RemoveEmployee()
        {
            
            int Identify = Convert.ToInt32(textBox1.Text);

            foreach (var item in LIEmployee)
            {
                if (Identify == item.Id)
                {
                    LIEmployee.Remove(item);
                    break;
                }

                
                
            }
            ShowEmployee();

        }

      
    }
}
