using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class Form1 : Form
    {
        private Tasks db;
        public Form1()
        {
            InitializeComponent();
            db = new Tasks();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = db.MyTable.ToList();
            dataGridView.Columns[0].HeaderText = "Id";
            dataGridView.Columns[1].HeaderText = "Задание №";
            dataGridView.Columns[2].HeaderText = "Текст задания";
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            using (fmInput fmAdd = new fmInput())
            {
                if (fmAdd.ShowDialog() == DialogResult.OK)
                {
                    MyTable task = new MyTable
                    {
                        TaskNo = Convert.ToInt32(fmAdd.TaskNum.Value),
                        TaskText = fmAdd.txtTask.Text.Trim()
                    };
                    db.MyTable.Add(task);
                    db.SaveChanges();
                    // Проще все было сделать через bindings, но в целях обучения все операции в ручную делаем
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = db.MyTable.ToList();
                    dataGridView.Refresh();
                }                       
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            var removeItem = db.MyTable.Find(dataGridView.CurrentRow.Cells[0].Value);
            if (removeItem != null)
            {
                db.MyTable.Remove(removeItem);
                db.SaveChanges();
                dataGridView.DataSource = null;
                dataGridView.DataSource = db.MyTable.ToList();
                dataGridView.Refresh();
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            using (fmInput fmAdd = new fmInput())
            {
                var EditItem = db.MyTable.Find(dataGridView.CurrentRow.Cells[0].Value);
                if (EditItem == null) return;
                fmAdd.TaskNum.Value = Convert.ToDecimal(EditItem.TaskNo);
                fmAdd.txtTask.Text = EditItem.TaskText.Trim();
                if (fmAdd.ShowDialog() == DialogResult.OK)
                {
                    db.MyTable.Attach(EditItem);
                    EditItem.TaskNo = Convert.ToInt32(fmAdd.TaskNum.Value);
                    EditItem.TaskText = fmAdd.txtTask.Text.Trim();
                    db.SaveChanges();
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = db.MyTable.ToList();
                    dataGridView.Refresh();
                }
            }
        }
    }
}
