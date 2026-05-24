using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProject
{
    public partial class AddTask_Form : Form
    {
        public AddTask_Form()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddTasck_Form_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        void SaveTask()
        {
            ListViewItem MyList = new ListViewItem(textBoxName.Text);
            MyList.SubItems.Add(comboBox1.Text);

            if (radioButton1.Checked)
                MyList.SubItems.Add(radioButton1.Text); 
            else if (radioButton2.Checked)
                MyList.SubItems.Add(radioButton2.Text);


            if (radioButton3.Checked)
                MyList.SubItems.Add(radioButton3.Text);
            else if (radioButton4.Checked)
                MyList.SubItems.Add(radioButton4.Text);

            if (radioButton4.Checked)
                MyList.ImageIndex = 0;
            else
                MyList.ImageIndex = 1;

            

            // 1. استدعاء شاشة الـ TaskManager المفتوحة حالياً عبر الـ Owner
            TaskManager_Form mainForm = (TaskManager_Form)this.Owner;

            if (mainForm != null)
            {
                // 2. إضافة العناصر إلى الـ listView1 (تأكد من كتابة حرف l سمول)
                mainForm.listView1.Items.Add(MyList);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isTextInvalid = (textBoxName.Text == string.Empty || comboBox1.Text == string.Empty);

            // 2. التحقق من المجموعة الأولى
            bool isGroup1Invalid = (!radioButton1.Checked && !radioButton2.Checked);

            // 3. التحقق من المجموعة الثانية
            bool isGroup2Invalid = (!radioButton3.Checked && !radioButton4.Checked);

            // إذا كان هناك نقص بالبيانات
            if (isTextInvalid || isGroup1Invalid || isGroup2Invalid)
            {
                MessageBox.Show("Data is incomplete !!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                // أضفنا الأقواس هنا لكي ينفذ الحفظ والإغلاق معاً فقط عند الضغط على Yes
                if (MessageBox.Show("are you sure ?", "sureing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SaveTask();    // يحفظ أولاً
                    this.Close();  // يغلق ثانياً
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBoxName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                e.Cancel = true;
                textBoxName.Focus();
                errorProvider1.SetError(textBoxName, "Please enter data");

            }

        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                e.Cancel = true;
                comboBox1.Focus();
                errorProvider1.SetError(comboBox1, "Please enter data");

            }
        }

        private void radioButton1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(radioButton1.Text))
            {
                e.Cancel = true;
                radioButton1.Focus();
                errorProvider1.SetError(radioButton1, "Please enter data");

            }
        }

        private void radioButton2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(radioButton2.Text))
            {
                e.Cancel = true;
                radioButton2.Focus();
                errorProvider1.SetError(radioButton2, "Please enter data");

            }
        }

        private void radioButton4_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(radioButton4.Text))
            {
                e.Cancel = true;
                radioButton4.Focus();
                errorProvider1.SetError(radioButton4, "Please enter data");

            }
        }

        private void radioButton3_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(radioButton3.Text))
            {
                e.Cancel = true;
                radioButton3.Focus();
                errorProvider1.SetError(radioButton3, "Please enter data");

            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
