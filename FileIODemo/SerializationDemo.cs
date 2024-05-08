using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text.Json;
using System.IO;

namespace FileIODemo
{
    public partial class SerializationDemo : Form
    {
        public SerializationDemo()
        {
            InitializeComponent();
        }

        public  void ClearFields()
        {
            txtId.Clear();
            txtName.Clear();
            txtSalary.Clear();
        }

        private void btnBinaryWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Employee emp = new Employee();
                emp.Id = Convert.ToInt32(txtId.Text);
                emp.Name = txtName.Text;
                emp.Salary = Convert.ToDouble(txtSalary.Text);

                FileStream fs = new FileStream(@"D:\Eclipse\ThinkQuotient\DotNet Training\WindowsFormAppBasic\FileIOFileEx\EmployeeData\empBinary.dat",
                    FileMode.Create, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, emp);
                fs.Close();
                ClearFields();
                MessageBox.Show("Done...");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBinaryRead_Click(object sender, EventArgs e)
        {
            try
            {
                Employee emp = new Employee();
                FileStream fs = new FileStream(@"D:\Eclipse\ThinkQuotient\DotNet Training\WindowsFormAppBasic\FileIOFileEx\EmployeeData\empBinary.dat",
                  FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                emp = (Employee)bf.Deserialize(fs);
                fs.Close();
                txtId.Text = emp.Id.ToString();
                txtName.Text = emp.Name;
                txtSalary.Text = emp.Salary.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }

        private void btnXmlWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Employee emp = new Employee();
                emp.Id = Convert.ToInt32(txtId.Text);
                emp.Name = txtName.Text;
                emp.Salary = Convert.ToDouble(txtSalary.Text);

                FileStream fs = new FileStream(@"D:\Eclipse\ThinkQuotient\DotNet Training\WindowsFormAppBasic\FileIOFileEx\EmployeeData\empXml.xml",
                    FileMode.Create, FileAccess.Write);
               XmlSerializer xs = new XmlSerializer(typeof(Employee));
                xs.Serialize(fs, emp);
                fs.Close();
                ClearFields();
                MessageBox.Show("Done...");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXmlRead_Click(object sender, EventArgs e)
        {
            try
            {
                Employee emp = new Employee();
                FileStream fs = new FileStream(@"D:\Eclipse\ThinkQuotient\DotNet Training\WindowsFormAppBasic\FileIOFileEx\EmployeeData\empXml.xml",
                  FileMode.Open, FileAccess.Read);
                XmlSerializer xs = new XmlSerializer(typeof(Employee));
                emp = (Employee)xs.Deserialize(fs);
                fs.Close();
                txtId.Text = emp.Id.ToString();
                txtName.Text = emp.Name;
                txtSalary.Text = emp.Salary.ToString();
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
                Employee emp = new Employee();
                emp.Id = Convert.ToInt32(txtId.Text);
                emp.Name = txtName.Text;
                emp.Salary = Convert.ToDouble(txtSalary.Text);

                FileStream fs = new FileStream(@"D:\Eclipse\ThinkQuotient\DotNet Training\WindowsFormAppBasic\FileIOFileEx\EmployeeData\empSoap.soap",
                    FileMode.Create, FileAccess.Write);
                SoapFormatter sf = new SoapFormatter();
                sf.Serialize(fs, emp);
                fs.Close();
                ClearFields();
                MessageBox.Show("Done...");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSoapRead_Click(object sender, EventArgs e)
        {
           

            try
            {
                Employee emp = new Employee();
                FileStream fs = new FileStream(@"D:\Eclipse\ThinkQuotient\DotNet Training\WindowsFormAppBasic\FileIOFileEx\EmployeeData\empSoap.soap",
                  FileMode.Open, FileAccess.Read);
                SoapFormatter sf = new SoapFormatter();
                emp = (Employee)sf.Deserialize(fs);
                fs.Close();
                txtId.Text = emp.Id.ToString();
                txtName.Text = emp.Name;
                txtSalary.Text = emp.Salary.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnJsonWrite_Click(object sender, EventArgs e)
        {

            try
            {
                Employee emp = new Employee();
                emp.Id = Convert.ToInt32(txtId.Text);
                emp.Name = txtName.Text;
                emp.Salary = Convert.ToDouble(txtSalary.Text);

                FileStream fs = new FileStream(@"D:\Eclipse\ThinkQuotient\DotNet Training\WindowsFormAppBasic\FileIOFileEx\EmployeeData\empJson.json",
                    FileMode.Create, FileAccess.Write);
                JsonSerializer.Serialize<Employee>(fs, emp);
           
                fs.Close();
                ClearFields();
                MessageBox.Show("Done...");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnJsonRead_Click(object sender, EventArgs e)
        {
            try
            {
                Employee emp = new Employee();
                FileStream fs = new FileStream(@"D:\Eclipse\ThinkQuotient\DotNet Training\WindowsFormAppBasic\FileIOFileEx\EmployeeData\empJson.json",
                  FileMode.Open, FileAccess.Read);
                emp=JsonSerializer.Deserialize<Employee>(fs);
                fs.Close();
                txtId.Text = emp.Id.ToString();
                txtName.Text = emp.Name;
                txtSalary.Text = emp.Salary.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
