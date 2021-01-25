using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3
{
    public partial class fmMain : Form
    {
        Assembly assembly = null;
        public fmMain()
        {
            InitializeComponent();
        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filename = openFileDialog.FileName;
                    assembly = Assembly.LoadFile(filename);
                    this.Text = "Reflector @ " + filename;
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Type[] types = assembly.GetTypes();
                lbTypes.Items.Clear();
                lbTypes.Items.AddRange(assembly.GetTypes());
            }
        }

        private void lbTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbMethods.Items.Clear();
            if (lbTypes.SelectedItem != null)
            {
                string typename = lbTypes.SelectedItem.ToString();
                Type type = assembly.GetType(typename);
                MethodInfo[] methods = type.GetMethods();
                foreach (MethodInfo method in methods)
                {
                    lbMethods.Items.Add(method.Name);
                }
            }
        }

        private void lbMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbMethodInfo.Clear();
            if (lbTypes.SelectedItem != null & lbMethods.SelectedItem != null)
            {
                try
                {
                    string typename = lbTypes.SelectedItem.ToString();
                    string methodname = lbMethods.SelectedItem.ToString();
                    Type type = assembly.GetType(typename);
                    MethodInfo method = type.GetMethod(methodname);
                    MethodBody body = method.GetMethodBody();
                    if (body != null)
                    {
                        tbMethodInfo.AppendText("HashCode: " + body.GetHashCode() + Environment.NewLine);
                        tbMethodInfo.AppendText("MaxStackSize: " + body.MaxStackSize.ToString() + Environment.NewLine);
                        tbMethodInfo.AppendText("InitLocals: " + body.InitLocals + Environment.NewLine);
                        foreach (LocalVariableInfo item in body.LocalVariables)
                        {
                            tbMethodInfo.AppendText("Local variable: " + item + Environment.NewLine);
                        }
                    }
                }
                catch
                { }
            }
        }
    }
}
