using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form1 : Form
    {
        private Model1Container db;
        public Form1()
        {
            InitializeComponent();
            db = new Model1Container();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = db.Marks.ToList();
            dataGridView.Columns[0].HeaderText = "Id";
            dataGridView.Columns[1].HeaderText = "Урок №";
            dataGridView.Columns[2].HeaderText = "Оценка";
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            using (fmInput fmAdd = new fmInput())
            {
                if (fmAdd.ShowDialog() == DialogResult.OK)
                {
                    db.Marks.Add(new MarksEntity
                         {
                            Lesson = Convert.ToInt32(fmAdd.LessonNum.Value),
                            Mark = Convert.ToDecimal(fmAdd.numMark.Value)
                         });
                    db.SaveChanges();
                    // Проще все было сделать через bindings, но в целях обучения все операции в ручную делаем
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = db.Marks.ToList();
                    dataGridView.Refresh();
                }
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            var removeItem = db.Marks.Find(dataGridView.CurrentRow.Cells[0].Value);
            if (removeItem != null)
            {
                db.Marks.Remove(removeItem);
                db.SaveChanges();
                dataGridView.DataSource = null;
                dataGridView.DataSource = db.Marks.ToList();
                dataGridView.Refresh();
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            using (fmInput fmAdd = new fmInput())
            {
                var EditItem = db.Marks.Find(dataGridView.CurrentRow.Cells[0].Value);
                if (EditItem == null) return;
                fmAdd.LessonNum.Value = Convert.ToDecimal(EditItem.Lesson);
                fmAdd.numMark.Value = Convert.ToDecimal(EditItem.Mark);
                if (fmAdd.ShowDialog() == DialogResult.OK)
                {
                    db.Marks.Attach(EditItem);
                    EditItem.Lesson = Convert.ToInt32(fmAdd.LessonNum.Value);
                    EditItem.Mark = Convert.ToDecimal(fmAdd.numMark.Value);
                    db.SaveChanges();
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = db.Marks.ToList();
                    dataGridView.Refresh();
                }
            }
        }
    }
}
