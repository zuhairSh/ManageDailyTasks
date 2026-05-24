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
using Newtonsoft.Json;

namespace MyProject
{
    public partial class TaskManager_Form : Form
    {
        public TaskManager_Form(string userName)
        {
            InitializeComponent();
            label6.Text = userName;
        }

        int totalTasksCreated = 0;

        public class TaskItem
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public string When { get; set; }
            public bool IsImportant { get; set; }
        }

        private List<TaskItem> GetTasksFromListView()
        {
            List<TaskItem> tasks = new List<TaskItem>();
            foreach (ListViewItem item in listView1.Items)
            {
                tasks.Add(new TaskItem
                {
                    Name = item.Text,
                    Type = item.SubItems[1].Text,
                    When = item.SubItems[2].Text,
                    IsImportant = (item.ImageIndex == 0)
                });
            }
            return tasks;
        }

        void SaveTasksToJson()
        {
            var tasks = GetTasksFromListView();
            string jsonString = JsonConvert.SerializeObject(tasks, Formatting.Indented);
            File.WriteAllText("tasks.json", jsonString);
        }

        void LoadTasksFromJson()
        {
            if (File.Exists("tasks.json"))
            {
                string jsonString = File.ReadAllText("tasks.json");
                var tasks = JsonConvert.DeserializeObject<List<TaskItem>>(jsonString);

                listView1.Items.Clear();
                foreach (var task in tasks)
                {
                    ListViewItem item = new ListViewItem(task.Name);
                    item.SubItems.Add(task.Type);
                    item.SubItems.Add(task.When);
                    item.ImageIndex = task.IsImportant ? 0 : 1;
                    listView1.Items.Add(item);
                }

                totalTasksCreated = listView1.Items.Count;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblDateTime.Text = null;

            // 3. استدعاء دالة القراءة فور تشغيل الشاشة
            LoadTasksFromJson();
            ProgressBarTask();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd   hh:mm:ss tt");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddTask_Form frm = new AddTask_Form();
            frm.Owner = this;

            if (frm.ShowDialog() == DialogResult.OK || frm.DialogResult == DialogResult.OK)
            {
                // إذا تم الحفظ من الشاشة الأخرى
            }

            totalTasksCreated++;
            ProgressBarTask();

            // 4. حفظ التغييرات بعد إضافة مهمة جديدة
            SaveTasksToJson();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure to close ?", "sureing", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("are you sure to Remove ?", "sureing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    listView1.Items.Remove(listView1.SelectedItems[0]);

                    if (totalTasksCreated > 0) totalTasksCreated--;

                    ProgressBarTask();

                    // 5. حفظ التغييرات بعد حذف المهمة
                    SaveTasksToJson();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                UpdateTasck_Form frm = new UpdateTasck_Form();
                frm.Owner = this;
                frm.ShowDialog();

                // 6. حفظ التغييرات بعد تعديل المهمة وإغلاق شاشة التعديل
                SaveTasksToJson();
            }
            else
            {
                MessageBox.Show("Please select a task to update!");
            }
        }

        void ProgressBarTask()
        {
            if (totalTasksCreated == 0 || listView1.Items.Count == 0)
            {
                progressBar1.Value = (listView1.Items.Count == 0 && totalTasksCreated > 0) ? 100 : 0;
                return;
            }

            int completedTasks = totalTasksCreated - listView1.Items.Count;
            double itemPercentage = 100.0 / totalTasksCreated;
            double currentProgress = 0;

            for (int i = 0; i < completedTasks; i++)
            {
                currentProgress += itemPercentage;
            }

            progressBar1.Value = (int)Math.Min(currentProgress, 100);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Have you finished the task?", "sureing",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show("Well done, champ! The mission has been deleted !", "Well done",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    listView1.Items.Remove(listView1.SelectedItems[0]);

                    ProgressBarTask();

                    // 7. حفظ التغييرات بعد إنهاء المهمة وحذفها بالدبل كليك
                    SaveTasksToJson();
                }
            }
        }

        private void progressBar1_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
    }
}