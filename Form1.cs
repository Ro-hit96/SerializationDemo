using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Binary
using System.Runtime.Serialization.Formatters.Binary;
//XML
using System.Xml.Serialization;
//SOAP
using System.Runtime.Serialization.Formatters.Soap;
//JSOn  
using System.Text.Json;
//File
using System.IO;

namespace SerializationDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Employee employee = new Employee();
                employee.id = Convert.ToInt32(IDtxt.Text);
                employee.Name = NameTxt.Text;
                employee.salary = Convert.ToDouble(SalaryTxt.Text);
                //Step 2
                FileStream fs = new FileStream(@"D:\emp.xml", FileMode.Create, FileAccess.Write);
                //Step 3
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));

                xmlSerializer.Serialize(fs, employee);
                fs.Close();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXMLRead_Click(object sender, EventArgs e)
        {
            try
            {
                //Step 1:- Read Data From File
                FileStream fs = new FileStream(@"D:\emp.xml", FileMode.Open, FileAccess.Read);
                //Step 2:-Deserialized
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));

                Employee employee = new Employee();
                employee = (Employee)xmlSerializer.Deserialize(fs);
                //Step 3:- display
                IDtxt.Text = employee.id.ToString();
                NameTxt.Text = employee.Name;
                SalaryTxt.Text = employee.salary.ToString();
                fs.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnBinaryWrite_Click(object sender, EventArgs e)
        {
            try
            {
                //step 1-Store Data in the object
                Employee employee = new Employee();
                employee.id = Convert.ToInt32(IDtxt.Text);
                employee.Name=NameTxt.Text;
                employee.salary=Convert.ToDouble(SalaryTxt.Text);
                //Step 2
                FileStream fs = new FileStream(@"D:\emp.dat", FileMode.Create, FileAccess.Write);
                //Step 3
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, employee);
                fs.Close();
                MessageBox.Show("Done");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBinaryread_Click(object sender, EventArgs e)
        {
            try
            {
                //Step 1:- Read Data From File
                FileStream fs = new FileStream(@"D:\emp.dat", FileMode.Open, FileAccess.Read);
                //Step 2:-Deserialized
                BinaryFormatter bf = new BinaryFormatter();
                Employee employee=new Employee();
                employee = (Employee)bf.Deserialize(fs);
                //Step 3:- display
                IDtxt.Text=employee.id.ToString();
                NameTxt.Text = employee.Name;
                SalaryTxt.Text=employee.salary.ToString();
                fs.Close ();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSoapWrite_Click(object sender, EventArgs e)
        {
            try
            {
                //step 1-Store Data in the object
                Employee employee = new Employee();
                employee.id = Convert.ToInt32(IDtxt.Text);
                employee.Name = NameTxt.Text;
                employee.salary = Convert.ToDouble(SalaryTxt.Text);
                //Step 2
                FileStream fs = new FileStream(@"D:\emp.soap", FileMode.Create, FileAccess.Write);
                //Step 3
                SoapFormatter bf = new SoapFormatter();
                bf.Serialize(fs, employee);
                fs.Close();
                MessageBox.Show("Done");
            }
            catch(Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSoapRead_Click(object sender, EventArgs e)
        {
            try
            {
                //Step 1:- Read Data From File
                FileStream fs = new FileStream(@"D:\emp.soap", FileMode.Open, FileAccess.Read);
                //Step 2:-Deserialized
                SoapFormatter sf = new SoapFormatter();
                Employee employee = new Employee();
                employee = (Employee)sf.Deserialize(fs);
                //Step 3:- display
                IDtxt.Text = employee.id.ToString();
                NameTxt.Text = employee.Name;
                SalaryTxt.Text = employee.salary.ToString();
                fs.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
