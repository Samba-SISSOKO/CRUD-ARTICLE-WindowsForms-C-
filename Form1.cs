using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using model;

namespace tp_w_crud_Article
{
    public partial class Form1 : Form
    {
        DaoArticle dao;

        public Form1()
        {
            InitializeComponent();
            dao = new DaoArticle();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int reference = Convert.ToInt32(textBox4.Text);
            string marque = textBox5.Text;
            int prix = Convert.ToInt32(textBox6.Text);

            Article article = new Article(reference, marque, prix);

            dao.Insert(article).ToString();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

            MessageBox.Show("Article inséré avec succès.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Article> articles = dao.SelectAll();
            listBox1.Items.Clear();
            foreach (Article str in articles)
                listBox1.Items.Add(str);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);

            Article article = dao.SelectByReference(id);

            if (article != null)
            {
                label8.Text = article.ToString();
              
            }
            else 
            {
                MessageBox.Show("Aucun article trouvé avec cet ID.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int prixMin = int.Parse(textBox2.Text);
            double prixMax = double.Parse(textBox3.Text);

            List<Article> articles = dao.SelectByPrixBetween(prixMin, prixMax);

            listBox2.Items.Clear();
            foreach (Article article in articles)
            {
                listBox2.Items.Add(article.Reference+ " . "+ article.Marque+ " . "+ article.Prix);
            }
        }
        


    }
}




    

