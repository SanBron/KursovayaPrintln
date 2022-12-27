using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace KursovayaPrintLn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateList();
        }

        //обновляем список текстов
        void updateList()
        {
            listBox1.Items.Clear(); //удаляем старые тексты

            DirectoryInfo dir = new DirectoryInfo(@"data"); //открываем директорию
            foreach (var item in dir.GetFiles())
            {
                //добавляем файлы в listbox
                listBox1.Items.Add(item.Name.Substring(0, item.Name.Length - 4));
            }
        }

        private void buttonFnd_Click(object sender, EventArgs e)
        {
            if (textBoxFnd.Text == "")
            {
                MessageBox.Show("Введите текст для поиска");
                return;
            }
            string[] separators = { ".", "!", "?", ";", ":", " ", ",", "[", "]", "{", "}", "-", "(", ")" };
            HashSet<string> searchStrings = new HashSet<string>(textBoxFnd.Text.Split(separators, StringSplitOptions.RemoveEmptyEntries));
            WorkMethod workMethod = new Method();

            Model model1 = null;
            Model model2 = null;
            Model model3 = null;
            Model model4 = null;

            Thread thread1 = new Thread(() =>
                model1 = workMethod.Work(SearchMode.RabinaKarpa, searchStrings, listBox1));
            Thread thread2 = new Thread(() =>
                model2 = workMethod.Work(SearchMode.KMP, searchStrings, listBox1));
            Thread thread3 = new Thread(() =>
                model3 = workMethod.Work(SearchMode.BM, searchStrings, listBox1));
            Thread thread4 = new Thread(() =>
                model4 = workMethod.Work(SearchMode.AhoCorasick, searchStrings, listBox1));

            thread1.Start();
            thread1.Join();
            new FormGistogram(model1.tittles, model1.results, model1.name, model1.time).Show();
            thread2.Start();
            thread2.Join();
            new FormGistogram(model2.tittles, model2.results, model2.name, model2.time).Show();
            thread3.Start();
            thread3.Join();
            new FormGistogram(model3.tittles, model3.results, model3.name, model3.time).Show();
            thread4.Start();
            thread4.Join();
            new FormGistogram(model4.tittles, model4.results, model4.name, model4.time).Show();
        }

        private void textBoxFnd_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
