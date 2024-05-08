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
using System.Xml.Linq;

namespace FileIODemo
{
    public partial class StudentSerialization : Form
    {
        public StudentSerialization()
        {
            InitializeComponent();
        }

        public void ClearFields()
        {
            txtRollNo.Clear();
            txtStdName.Clear();
            txtStdPer.Clear();
        }
        private void btnBinaryWrite_Click(object sender, EventArgs e)
        {

            try
            {
                Student std = new Student();
                std.RollNo = Convert.ToInt32(txtRollNo.Text);
                std.StdName = txtStdName.Text;
                std.stdPer = Convert.ToDouble(txtStdPer.Text);

                FileStream fs = new FileStream(@"D:\Eclipse\ThinkQuotient\DotNet Training\WindowsFormAppBasic\FileIOFileEx\StudentData\stdBinary.dat",
                    FileMode.Create, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, std);
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
                Student std = new Student();
                FileStream fs = new FileStream(@"D:\Eclipse\ThinkQuotient\DotNet Training\WindowsFormAppBasic\FileIOFileEx\StudentData\stdBinary.dat",
                  FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                std = (Student)bf.Deserialize(fs);
                fs.Close();
                txtRollNo.Text = std.RollNo.ToString();
                txtStdName.Text = std.StdName;
                txtStdPer.Text = std.stdPer.ToString();
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
                Student std = new Student();
                std.RollNo = Convert.ToInt32(txtRollNo.Text);
                std.StdName = txtStdName.Text;
                std.stdPer = Convert.ToDouble(txtStdPer.Text);
                FileStream fs = new FileStream(@"D:\Eclipse\ThinkQuotient\DotNet Training\WindowsFormAppBasic\FileIOFileEx\StudentData\stdXml.xml",
                    FileMode.Create, FileAccess.Write);
                XmlSerializer xs = new XmlSerializer(typeof(Student));
                xs.Serialize(fs, std);
                fs.Close();
                ClearFields();
                MessageBox.Show("Done...");
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXmlRead_Click(object sender, EventArgs e)
        {
            try
            {
                Student std = new Student();
                FileStream fs = new FileStream(@"D:\Eclipse\ThinkQuotient\DotNet Training\WindowsFormAppBasic\FileIOFileEx\StudentData\stdXml.xml",
                      FileMode.Open, FileAccess.Read);
                XmlSerializer xs = new XmlSerializer(typeof(Student));
                std = (Student)xs.Deserialize(fs);
                fs.Close();
                txtRollNo.Text = std.RollNo.ToString();
                txtStdName.Text = std.StdName;
                txtStdPer.Text = std.stdPer.ToString();
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
                Student std = new Student();
                std.RollNo = Convert.ToInt32(txtRollNo.Text);
                std.StdName = txtStdName.Text;
                std.stdPer = Convert.ToDouble(txtStdPer.Text);

                FileStream fs = new FileStream(@"D:\Eclipse\ThinkQuotient\DotNet Training\WindowsFormAppBasic\FileIOFileEx\StudentData\stdSoap.soap",
                    FileMode.Create, FileAccess.Write);
                SoapFormatter sf = new SoapFormatter();
                sf.Serialize(fs, std);
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
                Student std = new Student();
                FileStream fs = new FileStream(@"D:\Eclipse\ThinkQuotient\DotNet Training\WindowsFormAppBasic\FileIOFileEx\StudentData\stdSoap.soap",
                  FileMode.Open, FileAccess.Read);
                SoapFormatter sf = new SoapFormatter();
                std = (Student)sf.Deserialize(fs);
                fs.Close();
                txtRollNo.Text = std.RollNo.ToString();
                txtStdName.Text = std.StdName;
                txtStdPer.Text = std.stdPer.ToString();
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
                Student std = new Student();
                std.RollNo = Convert.ToInt32(txtRollNo.Text);
                std.StdName = txtStdName.Text;
                std.stdPer = Convert.ToDouble(txtStdPer.Text);


                FileStream fs = new FileStream(@"D:\Eclipse\ThinkQuotient\DotNet Training\WindowsFormAppBasic\FileIOFileEx\StudentData\stdJson.json",
                    FileMode.Create, FileAccess.Write);
                JsonSerializer.Serialize<Student>(fs, std);

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
                Student std = new Student();
                FileStream fs = new FileStream(@"D:\Eclipse\ThinkQuotient\DotNet Training\WindowsFormAppBasic\FileIOFileEx\StudentData\stdJson.json",
                  FileMode.Open, FileAccess.Read);
                std = JsonSerializer.Deserialize<Student>(fs);
                fs.Close();
                txtRollNo.Text = std.RollNo.ToString();
                txtStdName.Text = std.StdName;
                txtStdPer.Text = std.stdPer.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
