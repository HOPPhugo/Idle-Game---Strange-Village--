using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Idle_Game___Strange_Village__
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            background1.GetType().InvokeMember("DoubleBuffered", // permet de rendre plus fluide le jeu.
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance |
            System.Reflection.BindingFlags.SetProperty,
            null, background1, new object[] { true });
        }
        int money;
        int House1LVL = 1;
        bool birdie = false;
        bool House1GUI = false;
        bool message1 = true;
        bool message2 = true;
        bool bouger = false;

        private void FirstHouse_Tick(object sender, EventArgs e)
        {
            if (House1LVL ==1){
            label2.Text = "+ 10$";
            money = money + 10;
                FirstHouseLabel2();
            }
            if (House1LVL == 2)
            {
                label2.Text = "+ 20$";
                money = money + 20;
                FirstHouseLabel2();
            }
            if (House1LVL == 3)
            {
                label2.Text = "+ 30$";
                money = money + 30;
                FirstHouseLabel2();
            }
        }

        private void Dollars_Tick(object sender, EventArgs e)
        {
            label1.Text = "Money : " + money + "$";
        }
        private async void FirstHouseLabel2 ()
        {
            await Task.Delay(500);
            label2.Text = "";
        }
        private void verification()
        {
            
        }

        private void Vérif_Tick(object sender, EventArgs e)
        {
            verification();
            if (House1LVL == 1)
            {
                if (money >= 100)
                {
                    if (message1 == true)
                    {
                        message1 = false;
                        button1.ForeColor = Color.Green;
                        button1.Enabled = true;
                        MessageBox.Show("Maintenant que vous avez suffisament d'argent, essayez de cliquer sur la Maison pour l'améliorer.");
                        return;
                    }

                }
                else
                {
                    button1.ForeColor = Color.Black;
                    button1.Enabled = false;
                }
            }
            if (House1LVL == 2)
            {
                if (money >= 200)
                {
                    if (message2 == true)
                    {
                        message2 = false;
                        button1.ForeColor = Color.Green;
                        button1.Enabled = true;
                        return;
                    }

                }
                else
                {
                    button1.ForeColor = Color.Black;
                    button1.Enabled = false;
                }
            }
        }

        private void background1_Click(object sender, EventArgs e)
        {
            House1GUI = false;
            House1HUD();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            House1GUI = true;
            House1HUD();
        }
        private void House1HUD()
        {
            if (House1GUI == true)
            {

            button1.Visible = true;
            }
            else
            {
                button1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (House1LVL == 1 && money >= 100){
                button1.ForeColor = Color.Black;
                button1.Enabled = false;
                label3.Text = "Niveau : 2";
                money = money - 100;
                MessageBox.Show("Bravo ! maintenant assayer d'avoir 200$ !");
                House1LVL = 2;
                return;
            }
            if (House1LVL == 2 && money >= 200)
            {
                button1.ForeColor = Color.Black;
                button1.Enabled = false;
                label3.Text = "Niveau : 3";
                money = money - 200;
                MessageBox.Show("Bravo ! Une flèche est apparue au milieu en haut de votre écran. Testez de cliquer dessus !");
                label4.Visible = true;
                House1LVL = 3;
                return;
            }
        }

        private async void label4_Click(object sender, EventArgs e)
        {
           
                int location = background1.Location.Y;
                int changer = background1.Location.Y;
                while (location <= 0)
                {
                    if (location + 10 <= 0)
                    {

                        location = background1.Location.Y;
                        int location2 = label1.Location.Y;
                        await Task.Delay(10);
                        changer = changer + 10;
                        location2 = location2 - 10;
                        background1.Location = new Point(0, changer) ;
                        label1.Location = new Point(0, location2);
                        if (location == 0)
                        {
                            return;
                        }
                    }
                }

            
            
           
        }
        protected override CreateParams CreateParams // améliore la fluidité du jeu
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // Pour un rendu fluide
                return cp;

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (birdie ==  false)
            {

                DialogResult rn = MessageBox.Show("Voulez vous débloquer --Birdie-- ? Cost : 300$", "Unlock", MessageBoxButtons.YesNo);
                if (rn == DialogResult.Yes)
                {
                    if (money >= 300){
                        birdie = true;
                        money = money - 300;
                        pictureBox2.Image = Properties.Resources._3ooRmV;
                        MessageBox.Show("Vous avez débloqué --Birdie--  (vous devez cliquer dessus pour généré de l'argent)"); return;
                    }
                    else
                    {
                        MessageBox.Show("Vous n'avez pas asser d'argens...");
                    }
                }
                if (rn == DialogResult.No)
                {

                }
            }
            else
            {
                money = money + 5;
                label6.Text = "+ 5$";
                Birdie_Texte();
            }
        }
        private async void Birdie_Texte()
        {
            await Task.Delay(500);
            label6.Text = "";
        }

        private async void label5_Click(object sender, EventArgs e)
        {

            int location = background1.Location.Y;
            int changer = background1.Location.Y;
            while (location >= -450)
            {
                if (location - 10 >= -450)
                {

                    location = background1.Location.Y;
                    int location2 = label1.Location.Y;
                    await Task.Delay(10);
                    changer = changer - 10;
                    location2 = location2 + 10;
                    background1.Location = new Point(0, changer);
                    label1.Location = new Point(0, location2);
                    if (location == -450)
                    {
                        return;
                    }
                }
            }
        }
    }
}
