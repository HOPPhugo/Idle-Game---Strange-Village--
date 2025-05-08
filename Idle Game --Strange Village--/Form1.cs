using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        int money = 999999999;
        int House1LVL = 1;
        int multiplication = 0;
        int LVL = 1;
        int TextKeep;
        int valueXp = 100;
        bool birdie = false;
        int calculeL;
        bool House1GUI = false;
        bool message1 = true;
        bool waluigi  = false;
        int XP = 0;
        bool CrazyFrog = false;
        bool message2 = true;
        bool autoBirdie = false;
        int NBRClickB = 0;
        bool birdielbl2 = false;
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
        }

        private void background1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (House1LVL != 3){
                var result = CustomDialogForm.Show(House1LVL);
                if (result == DialogResult.OK)
                {
                    if (House1LVL == 1)
                    {
                        money = money - 100;
                        MessageBox.Show("Bravo ! Maintenant essayez d'atteindre 200$ pour encore PLUS l'améliorer");
                        label3.Text = "Niveau : 2";
                        House1LVL = 2;
                    }
                    else
                    {
                        money = money - 200;
                        MessageBox.Show("Bravo ! Maintenant essayez de cliquer sur les flêches !");
                        label4.Visible = true;
                        label3.Text = "Niveau : 3";
                        House1LVL = 3;
                    }
                    
                }
                else
                {
                    // Action si annulé
                }
            }
            else
            {
                MessageBox.Show("Vous avez déjà atteint le niveau max (3)");
            }
        }
        public partial class CustomDialogForm : Form
        {
            
            public DialogResult Result { get; private set; }
            private int _houseLevel;
            public CustomDialogForm(int HouseLVL)
            {
                _houseLevel = HouseLVL;
                this.FormBorderStyle = FormBorderStyle.None;
                this.StartPosition = FormStartPosition.CenterParent;
                this.BackgroundImage = Properties.Resources.ChatGPT_Image_8_mai_2025__11_15_54;
                this.BackgroundImageLayout = ImageLayout.Stretch;
                this.Width = 300;
                this.Height = 150;

                Label lblMessage = new Label()
                {

                    Text = "Voulez vous améliorer la maison ?",
                    AutoSize = false,
                    Width = 250,
                    Height = 20,
                    Location = new Point(20, 20),
                    BackColor = Color.Transparent,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.Black,
                };
                Label lblMessage2 = new Label()
                {
                    AutoSize = false,
                    Width = 250,
                    Height = 20,
                    Location = new Point(20, 50),
                    BackColor = Color.Transparent,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.Black,
                };
                if (HouseLVL == 1)
                {
                    lblMessage2.Text = "Prix : 100$";
                }
                else
                {
                    lblMessage2.Text = "Prix : 200$";
                }
                lblMessage.MouseMove += (s, e) =>
                {
                    lblMessage.ForeColor = Color.Blue;
                };
                lblMessage.MouseLeave += (s, e) =>
                {
                    lblMessage.ForeColor = Color.Black;
                };
                lblMessage2.MouseMove += (s, e) =>
                {
                    lblMessage2.ForeColor = Color.Blue;
                };
                lblMessage2.MouseLeave += (s, e) =>
                {
                    lblMessage2.ForeColor = Color.Black;
                };
                Button btnOK = new Button()
                {
                    Text = "Améliorer",
                    DialogResult = DialogResult.OK,
                    Width = 100,
                    Height = 30,
                    Location = new Point(50, 90),
                    BackColor = Color.FromArgb(0x4CAF50),
                    ForeColor = Color.Black,
                    FlatStyle = FlatStyle.Flat
                };
                btnOK.FlatAppearance.BorderSize = 0;
                Button btnCancel = new Button()
                {
                    Text = "Annuler",
                    DialogResult = DialogResult.Cancel,
                    Width = 100,
                    Height = 30,
                    Location = new Point(160, 90),
                    BackColor = Color.FromArgb(0xC23028),
                    ForeColor = Color.Black,
                    FlatStyle = FlatStyle.Flat
                };
                btnCancel.FlatAppearance.BorderSize = 0;
                this.Controls.Add(lblMessage);
                this.Controls.Add(btnOK);
                this.Controls.Add(lblMessage2);
                this.Controls.Add(btnCancel);

                this.AcceptButton = btnOK;
                this.CancelButton = btnCancel;
            }

            public static DialogResult Show(int HouseLVL)
            {
                using (CustomDialogForm form = new CustomDialogForm(HouseLVL))
                {
                    return form.ShowDialog();
                }
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
                        int location3 = label9.Location.Y;
                        await Task.Delay(10);
                        changer = changer + 10;
                        location2 = location2 - 10;
                        location3 = location3 - 10;
                        background1.Location = new Point(0, changer) ;
                        label1.Location = new Point(3, location2);
                        label9.Location = new Point(614, location3);
                        if (location == 0)
                        {
                            return;
                        }
                    }
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
                        MessageBox.Show("Vous avez débloqué --Birdie--  (vous devez cliquer dessus pour généré de l'argent)"); 
                        button2.Visible = true;
                        label7.Visible = true;
                        pictureBox3.Visible = true;
                        return;
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
                NBRClickB = NBRClickB + 1;
                multiplication = NBRClickB / 10;
                if ( multiplication < 1)
                {
                    money = money + 5;
                    label6.Text = "+ 5$";
                    Birdie_Texte();
                }
                else
                {
                    money  = money + (5 * multiplication);
                    label6.Text = "+ "+5 * multiplication + "$";
                    Birdie_Texte();
                }
                
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
                    int location3 = label9.Location.Y;
                    int location2 = label1.Location.Y;
                    await Task.Delay(10);
                    changer = changer - 10;
                    location2 = location2 + 10;
                    location3 = location3 + 10;
                    background1.Location = new Point(0, changer);
                    label1.Location = new Point(3, location2);
                    label9.Location = new Point(614, location3);
                    if (location == -450)
                    {
                        return;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (autoBirdie == false){
                DialogResult rn = MessageBox.Show("Veux-tu acheter l'auto Birdie ?", "Cost : 900$", MessageBoxButtons.YesNo);
                if (rn == DialogResult.Yes)
                {
                    if (money >= 900)
                    {
                        money = money - 900;
                        autoBirdie = true;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Vous n'avez pas asser d'argent...");
                    }
                }
            }
            if (autoBirdie == true && birdielbl2 == false)
            {
                DialogResult rn = MessageBox.Show("Veux-tu améliorer l'auto Birdie ?", "Cost : 1800$", MessageBoxButtons.YesNo);
                if (rn == DialogResult.Yes)
                {
                    if (money >= 1800)
                    {
                        money = money - 1800;
                        birdielbl2 = true;
                        label7.Text = "niveau : 2 (max)";
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Vous n'avez pas asser d'argent...");
                    }
                }
            }
            if (birdielbl2 == true)
            {
                MessageBox.Show("Vous ne pouvez plus l'améliorer...");
            }
        }

        private void autoBirdie_Timer_Tick(object sender, EventArgs e)
        {
            if (autoBirdie == true && birdielbl2 == false)
            {
                money = money + 5;
                label6.Text = "+ 5$";
                Birdie_Texte();
            }
            if (autoBirdie == true && birdielbl2 == true)
            {
                money = money + 10;
                label6.Text = "+ 10$";
                Birdie_Texte();
            }
        }

        private void background1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (waluigi == false){
                DialogResult rn = MessageBox.Show("Souhaitez vous débloquer --Monstro Waluigi-- ?", "Cost : 4000$", MessageBoxButtons.YesNo);
                if (rn == DialogResult.Yes)
                {
                    if (money >= 4000)
                    {
                        money = money - 4000;
                        pictureBox3.Image = Properties.Resources.WaluigiUnlocked;
                        waluigi = true;
                        MessageBox.Show("Vous avez débloqué --Monstro Waluigi-- !");
                        MessageBox.Show("Vous avez débloquer les niveau !");
                        pictureBox4.Visible = true;
                        label9.Visible = true;
                        return;

                    }
                    else
                    {
                        MessageBox.Show("Vous n'avez pas assez d'argent...");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vous l'avez déjà débloquer...");
            }
        }
        private async void WaluigilblTimer()
        {
            await Task.Delay(500);
            label8.Text = "";
        }

        private void WAluigiTimer_Tick(object sender, EventArgs e)
        {
            if (waluigi == true)
            {
                money = money + 450;
                label8.Text = "+ 450$";
                WaluigilblTimer();
            }
        }
       
        
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
            if (CrazyFrog == false)
            {
                DialogResult rn = MessageBox.Show("Souhaitez vous débloquer --CrazyFrog-- ?", "Cost : 10,000$", MessageBoxButtons.YesNo);
                if (rn == DialogResult.Yes)
                {
                    if (money >= 10000)
                    {
                        money = money - 10000;
                        pictureBox4.Image = Properties.Resources.CrazyFrogUnlocked;
                        MessageBox.Show("Vous avez débloqué --CrazyFrog-- !");
                        CrazyFrog = true;
                        XP = XP + 50;
                        return;

                    }
                    else
                    {
                        MessageBox.Show("Vous n'avez pas assez d'argent...");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vous l'avez déjà débloquer...");
            }
        }
        private async void CrazyLabel()
        {
            await Task.Delay(500);
            label9.Text = "";
        }

        private void CrazyFrogTimer_Tick(object sender, EventArgs e)
        {
            if (CrazyFrog == true)
            {
                money = money + 450;
                label9.Text = "+ 450$";
                CrazyLabel();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void XP_TIMER_Tick(object sender, EventArgs e)
        {
            if (XP == valueXp)
            {
                LVL = LVL + 1;
                valueXp = 100 * LVL + valueXp;
                MessageBox.Show("Vous avez augmenter de niveau !");
                return;
            }
            label9.Text = "Niveau : "+LVL+"\r\nExp : " + XP.ToString() + " / " + valueXp.ToString();
        }

        private void background1_SizeChanged(object sender, EventArgs e)
        {

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
        }
    }
}
