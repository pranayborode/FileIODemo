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



namespace FileIODemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreateDirectory_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"D:\Eclipse\ThinkQuotient\DotNet Training\WindowsFormAppBasic\FileIOFileEx\StudentData";
                //if folder is present then return true
                if (Directory.Exists(path)) 
                {
                    MessageBox.Show("Directory Exists");
                }
                else
                {
                    Directory.CreateDirectory(path);
                    MessageBox.Show("Directory Created");
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"D:\Eclipse\ThinkQuotient\DotNet Training\WindowsFormAppBasic\FileIOFileEx\EmployeeData\employee.txt";

                if (File.Exists(path))
                {
                    MessageBox.Show("File Exits");
                }
                else
                {
                    File.Create(path);
                    MessageBox.Show("File Created...");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"D:\Eclipse\ThinkQuotient\DotNet Training\WindowsFormAppBasic\FileIOFileEx\EmployeeData\emp.dat",
                    FileMode.Create,FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(Convert.ToInt32(txtId.Text));
                bw.Write(txtName.Text);
                bw.Write(Convert.ToDouble(txtSalary.Text));
                bw.Close();
                fs.Close();
                MessageBox.Show("Data added...");


            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"D:\Eclipse\ThinkQuotient\DotNet Training\WindowsFormAppBasic\FileIOFileEx\EmployeeData\emp.dat",
                   FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                txtId.Text = br.ReadInt32().ToString();
                txtName.Text = br.ReadString();
                txtSalary.Text = br.ReadDouble().ToString();
                br.Close();
                fs.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStreamWrite_Click(object sender, EventArgs e)
        {
            try
            {

                FileStream fs = new FileStream(@"D:\Eclipse\ThinkQuotient\DotNet Training\WindowsFormAppBasic\FileIOFileEx\EmployeeData\sample.txt",
                   FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(richTextBox1.Text);
                sw.Close();
                fs.Close();
                MessageBox.Show("Done...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStreamRead_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"D:\Eclipse\ThinkQuotient\DotNet Training\WindowsFormAppBasic\FileIOFileEx\EmployeeData\sample.txt",
                  FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
