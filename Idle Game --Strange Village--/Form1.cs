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
        int money = 0;
        int House1LVL = 1;
        int multiplication = 0;
        int LVL = 1;
        int TextKeep;
        int valueXp = 100;
        bool birdie = false;
        int calculeL;
        bool House1GUI = false;
        bool message1 = true;
        bool waluigi = false;
        string textUse;
        int XP = 0;
        bool CrazyFrog = false;
        bool message2 = true;
        bool autoBirdie = false;
        int NBRClickB = 0;
        bool birdielbl2 = false;
        bool bouger = false;
        public partial class CustomDialogForm3 : Form
        {
            // Cache statique pour l'image de fond
            private static Image backgroundImageCache;

            // Cache pour les tailles de texte précalculées (optimisation du rendu de texte)
            private static Dictionary<string, Size> textSizeCache = new Dictionary<string, Size>();

            // Cache pour les polices (évite de créer plusieurs fois les mêmes polices)
            private static Font labelFont;

            public DialogResult Result { get; private set; }
            private string _Text;
            private string _langue;

            static CustomDialogForm3()
            {
                // Initialisation des ressources statiques
                labelFont = new Font("Segoe UI", 10);
            }

            // Méthode statique pour précharger l'image et initialiser les ressources
            public static void PreloadResources()
            {
                if (backgroundImageCache == null)
                {
                    // Charge l'image en mémoire une seule fois
                    backgroundImageCache = Properties.Resources.ChatGPT_Image_8_mai_2025__11_15_54;
                }
            }

            // Méthode optimisée pour calculer la taille du texte (avec mise en cache)
            private static Size GetTextSize(string text, int maxWidth)
            {
                string cacheKey = text + "_" + maxWidth.ToString();

                // Utilise la taille mise en cache si disponible
                if (textSizeCache.ContainsKey(cacheKey))
                    return textSizeCache[cacheKey];

                // Calcule et met en cache la taille pour les prochaines utilisations
                Size textSize;
                using (Bitmap dummyBitmap = new Bitmap(1, 1))
                using (Graphics g = Graphics.FromImage(dummyBitmap))
                {
                    textSize = TextRenderer.MeasureText(g, text, labelFont, new Size(maxWidth, 0), TextFormatFlags.WordBreak);
                }

                // Stocke dans le cache (limite la taille du cache à 100 entrées)
                if (textSizeCache.Count > 100)
                {
                    // Simple stratégie : vide le cache s'il devient trop grand
                    textSizeCache.Clear();
                }
                textSizeCache[cacheKey] = textSize;

                return textSize;
            }

            public CustomDialogForm3(string text)
            {
                // Configuration initiale avec double buffering pour éviter les scintillements
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                              ControlStyles.AllPaintingInWmPaint |
                              ControlStyles.UserPaint,
                              true);

                this.SuspendLayout();
                this.FormBorderStyle = FormBorderStyle.None;
                this.StartPosition = FormStartPosition.CenterParent;
                this.BackgroundImageLayout = ImageLayout.Stretch;

                // Utilise l'image du cache
                if (backgroundImageCache == null)
                    backgroundImageCache = Properties.Resources.ChatGPT_Image_8_mai_2025__11_15_54;

                this.BackgroundImage = backgroundImageCache;

                _Text = text;

                // Constantes pour le layout
                const int maxWidth = 400;
                const int padding = 20;

                // Utilise la fonction optimisée pour calculer la taille du texte
                Size textSizes = GetTextSize(_Text, maxWidth);
                this.MinimumSize = new System.Drawing.Size(170, 20);
                // Calcul optimisé des dimensions
                int formWidth = textSizes.Width + 2 * padding;
                int formHeight = textSizes.Height + 30 + 3 * padding; // 30 = hauteur bouton

                // Définit la taille du formulaire immédiatement
                this.ClientSize = new Size(formWidth, formHeight);

                // Création du label avec les dimensions précalculées
                Label lblMessage = new Label
                {
                    Text = _Text,
                    AutoSize = false,
                    Size = textSizes,
                    Location = new Point(+25, padding),
                    BackColor = Color.Transparent,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = labelFont,
                    ForeColor = Color.Black,
                    UseMnemonic = false // Optimisation: désactive le traitement des mnémoniques (&)
                };
                Button btnNo = new Button
                {
                    DialogResult = DialogResult.No,
                    Width = 70,
                    Height = 30,
                    Location = new Point((formWidth + 0) / 2, lblMessage.Bottom + padding),
                    BackColor = Color.FromArgb(0x4CAF50),
                    ForeColor = Color.Black,
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderSize = 0 },
                    Text = "Non"
                };

                // Création du bouton (optimisée)
                Button btnOK = new Button
                {
                    DialogResult = DialogResult.Yes,
                    Width = 70,
                    Height = 30,
                    Location = new Point((formWidth - 150) / 2, lblMessage.Bottom + padding),
                    BackColor = Color.FromArgb(0x4CAF50),
                    ForeColor = Color.Black,
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderSize = 0 },
                    Text = "Oui"
                };
                int newSize = 12;
                // Délégués pré-alloués pour éviter les créations multiples
                lblMessage.MouseMove += (s, e) => lblMessage.ForeColor = Color.Blue;
                lblMessage.MouseLeave += (s, e) => lblMessage.ForeColor = Color.Black;
                btnNo.MouseMove += (s, e) => btnNo.Font = new Font(btnNo.Font.FontFamily, newSize);
                btnNo.MouseLeave += (s, e) => btnNo.Font = new Font(btnNo.Font.FontFamily, 8);
                btnOK.MouseMove += (s, e) => btnOK.Font = new Font(btnOK.Font.FontFamily, newSize);
                btnOK.MouseLeave += (s, e) => btnOK.Font = new Font(btnOK.Font.FontFamily, 8);

                // Utilisation de Controls.AddRange pour ajouter tous les contrôles en une seule fois
                this.Controls.AddRange(new Control[] { lblMessage, btnOK, btnNo });


                this.ResumeLayout(false);
            }

            // Optimisation: évite les redessins inutiles
            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams cp = base.CreateParams;
                    cp.ExStyle |= 0x02000000; // fluidifie
                    return cp;
                }
            }

            public static DialogResult Show(string text)
            {
                // Précharge les ressources si nécessaire
                EnsureResourcesLoaded();

                using (CustomDialogForm3 form = new CustomDialogForm3(text))
                {
                    return form.ShowDialog();
                }
            }

            // Version asynchrone préférée pour ne pas bloquer l'interface
            public static async Task<DialogResult> ShowAsync(string text)
            {
                // Précharge les ressources de manière asynchrone
                await Task.Run(() => EnsureResourcesLoaded());

                // Optimisation: précalcule la taille du texte en arrière-plan
                await Task.Run(() => GetTextSize(text, 400));

                // Utilise TaskCompletionSource pour exécuter ShowDialog de manière asynchrone
                TaskCompletionSource<DialogResult> tcs = new TaskCompletionSource<DialogResult>();

                Form mainForm = Application.OpenForms.Count > 0 ? Application.OpenForms[0] : null;

                if (mainForm != null && !mainForm.IsDisposed)
                {
                    mainForm.BeginInvoke(new Action(() =>
                    {
                        using (CustomDialogForm3 form = new CustomDialogForm3(text))
                        {
                            DialogResult result = form.ShowDialog(mainForm);
                            tcs.SetResult(result);
                        }
                    }));
                }
                else
                {
                    // Fallback si aucun formulaire principal n'est disponible
                    await Task.Run(() =>
                    {
                        using (CustomDialogForm3 form = new CustomDialogForm3(text))
                        {
                            DialogResult result = form.ShowDialog();
                            tcs.SetResult(result);
                        }
                    });
                }

                return await tcs.Task;
            }

            // S'assure que toutes les ressources sont chargées
            private static void EnsureResourcesLoaded()
            {
                if (backgroundImageCache == null)
                    PreloadResources();

                if (labelFont == null)
                    labelFont = new Font("Segoe UI", 10);
            }
        }

        private void FirstHouse_Tick(object sender, EventArgs e)
        {
            if (House1LVL == 1)
            {
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
        private async void FirstHouseLabel2()
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
            if (House1LVL != 3)
            {
                textUse = "Voulez Vous améliorer la maison ?";
                var result = CustomDialogForm3.Show(textUse);
                if (result == DialogResult.Yes)
                {
                    if (House1LVL == 1)
                    {
                        if (money >= 100)
                        {
                            money = money - 100;
                            textUse = "Bravo ! Maintenant essayez d'atteindre 200$ pour encore PLUS l'améliorer";
                            var r = CustomDialogForm.Show(textUse);
                            label3.Text = "Niveau : 2";
                            House1LVL = 2;
                            return;
                        }
                        else
                        {
                            textUse = "Vous n'avez pas assez d'argent...";
                            var ran = CustomDialogForm.Show(textUse);
                            return;
                        }
                    }
                    else
                    {
                        if (money >= 200)
                        {
                            money = money - 200;
                            textUse = "Bravo ! Maintenant essayez de cliquer sur les flêches !";
                            var r = CustomDialogForm.Show(textUse);
                            label4.Visible = true;
                            label3.Text = "Niveau : 3";
                            House1LVL = 3;
                            return;
                        }
                        else
                        {

                            textUse = "Vous n'avez pas assez d'argent...";
                            var ran = CustomDialogForm.Show(textUse);
                            return;
                        }
                    }

                }
                else
                {
                    // Action si annulé
                }
            }
            else
            {
                textUse = "Vous avez déjà atteint le niveau max (3)";
                var r = CustomDialogForm.Show(textUse);
            }
        }
        public partial class CustomDialogForm : Form
        {
            // Cache statique pour l'image de fond
            private static Image backgroundImageCache;

            // Cache pour les tailles de texte précalculées (optimisation du rendu de texte)
            private static Dictionary<string, Size> textSizeCache = new Dictionary<string, Size>();

            // Cache pour les polices (évite de créer plusieurs fois les mêmes polices)
            private static Font labelFont;

            public DialogResult Result { get; private set; }
            private string _Text;

            static CustomDialogForm()
            {
                // Initialisation des ressources statiques
                labelFont = new Font("Segoe UI", 10);
            }

            // Méthode statique pour précharger l'image et initialiser les ressources
            public static void PreloadResources()
            {
                if (backgroundImageCache == null)
                {
                    // Charge l'image en mémoire une seule fois
                    backgroundImageCache = Properties.Resources.ChatGPT_Image_8_mai_2025__11_15_54;
                }
            }

            // Méthode optimisée pour calculer la taille du texte (avec mise en cache)
            private static Size GetTextSize(string text, int maxWidth)
            {
                string cacheKey = text + "_" + maxWidth.ToString();

                // Utilise la taille mise en cache si disponible
                if (textSizeCache.ContainsKey(cacheKey))
                    return textSizeCache[cacheKey];

                // Calcule et met en cache la taille pour les prochaines utilisations
                Size textSize;
                using (Bitmap dummyBitmap = new Bitmap(1, 1))
                using (Graphics g = Graphics.FromImage(dummyBitmap))
                {
                    textSize = TextRenderer.MeasureText(g, text, labelFont, new Size(maxWidth, 0), TextFormatFlags.WordBreak);
                }

                // Stocke dans le cache (limite la taille du cache à 100 entrées)
                if (textSizeCache.Count > 100)
                {
                    // Simple stratégie : vide le cache s'il devient trop grand
                    textSizeCache.Clear();
                }
                textSizeCache[cacheKey] = textSize;

                return textSize;
            }

            public CustomDialogForm(string text)
            {
                // Configuration initiale avec double buffering pour éviter les scintillements
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                              ControlStyles.AllPaintingInWmPaint |
                              ControlStyles.UserPaint,
                              true);

                this.SuspendLayout();
                this.FormBorderStyle = FormBorderStyle.None;
                this.StartPosition = FormStartPosition.CenterParent;
                this.BackgroundImageLayout = ImageLayout.Stretch;

                // Utilise l'image du cache
                if (backgroundImageCache == null)
                    backgroundImageCache = Properties.Resources.ChatGPT_Image_8_mai_2025__11_15_54;

                this.BackgroundImage = backgroundImageCache;

                _Text = text;

                // Constantes pour le layout
                const int maxWidth = 400;
                const int padding = 20;

                // Utilise la fonction optimisée pour calculer la taille du texte
                Size textSizes = GetTextSize(_Text, maxWidth);

                // Calcul optimisé des dimensions
                int formWidth = textSizes.Width + 2 * padding;
                int formHeight = textSizes.Height + 30 + 3 * padding; // 30 = hauteur bouton

                // Définit la taille du formulaire immédiatement
                this.ClientSize = new Size(formWidth, formHeight);

                // Création du label avec les dimensions précalculées
                Label lblMessage = new Label
                {
                    Text = _Text,
                    AutoSize = false,
                    Size = textSizes,
                    Location = new Point(padding, padding),
                    BackColor = Color.Transparent,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = labelFont,
                    ForeColor = Color.Black,
                    UseMnemonic = false // Optimisation: désactive le traitement des mnémoniques (&)
                };

                // Création du bouton (optimisée)
                Button btnOK = new Button
                {
                    DialogResult = DialogResult.OK,
                    Width = 100,
                    Height = 30,
                    Location = new Point((formWidth - 100) / 2, lblMessage.Bottom + padding),
                    BackColor = Color.FromArgb(0x4CAF50),
                    ForeColor = Color.Black,
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderSize = 0 },
                    Text = "Ok"
                };
                int newSize = 12;
                // Délégués pré-alloués pour éviter les créations multiples
                lblMessage.MouseMove += (s, e) => lblMessage.ForeColor = Color.Blue;
                lblMessage.MouseLeave += (s, e) => lblMessage.ForeColor = Color.Black;
                btnOK.MouseMove += (s, e) => btnOK.Font = new Font(btnOK.Font.FontFamily, newSize);
                btnOK.MouseLeave += (s, e) => btnOK.Font = new Font(btnOK.Font.FontFamily, 8);

                // Utilisation de Controls.AddRange pour ajouter tous les contrôles en une seule fois
                this.Controls.AddRange(new Control[] { lblMessage, btnOK });
                this.AcceptButton = btnOK;

                // Pour éviter les problèmes de focus
                btnOK.TabIndex = 0;

                this.ResumeLayout(false);
            }

            // Optimisation: évite les redessins inutiles
            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams cp = base.CreateParams;
                    cp.ExStyle |= 0x02000000; // fluidifi
                    return cp;
                }
            }

            public static DialogResult Show(string text)
            {
                // Précharge les ressources si nécessaire
                EnsureResourcesLoaded();

                using (CustomDialogForm form = new CustomDialogForm(text))
                {
                    return form.ShowDialog();
                }
            }

            // Version asynchrone préférée pour ne pas bloquer l'interface
            public static async Task<DialogResult> ShowAsync(string text)
            {
                // Précharge les ressources de manière asynchrone
                await Task.Run(() => EnsureResourcesLoaded());

                // Optimisation: précalcule la taille du texte en arrière-plan
                await Task.Run(() => GetTextSize(text, 400));

                // Utilise TaskCompletionSource pour exécuter ShowDialog de manière asynchrone
                TaskCompletionSource<DialogResult> tcs = new TaskCompletionSource<DialogResult>();

                Form mainForm = Application.OpenForms.Count > 0 ? Application.OpenForms[0] : null;

                if (mainForm != null && !mainForm.IsDisposed)
                {
                    mainForm.BeginInvoke(new Action(() =>
                    {
                        using (CustomDialogForm form = new CustomDialogForm(text))
                        {
                            DialogResult result = form.ShowDialog(mainForm);
                            tcs.SetResult(result);
                        }
                    }));
                }
                else
                {
                    // Fallback si aucun formulaire principal n'est disponible
                    await Task.Run(() =>
                    {
                        using (CustomDialogForm form = new CustomDialogForm(text))
                        {
                            DialogResult result = form.ShowDialog();
                            tcs.SetResult(result);
                        }
                    });
                }

                return await tcs.Task;
            }

            // S'assure que toutes les ressources sont chargées
            private static void EnsureResourcesLoaded()
            {
                if (backgroundImageCache == null)
                    PreloadResources();

                if (labelFont == null)
                    labelFont = new Font("Segoe UI", 10);
            }
        }
        // Gère le clic sur label4 pour faire défiler l'interface vers le bas
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
                    await Task.Delay(10); // Attente pour animation fluide
                    changer = changer + 10;
                    location2 = location2 - 10;
                    location3 = location3 - 10;
                    background1.Location = new Point(0, changer);
                    label1.Location = new Point(3, location2);
                    label9.Location = new Point(614, location3);
                    if (location == 0)
                    {
                        return;
                    }
                }
            }
        }

        // Gère l'achat et le clic de Birdie
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (birdie == false)
            {
                // Affiche boîte de dialogue pour débloquer Birdie
                textUse = "Voulez vous débloquer --Birdie-- ? \nCost : 300$";
                var r = CustomDialogForm3.Show(textUse);
                if (r == DialogResult.Yes)
                {
                    if (money >= 300)
                    {
                        birdie = true;
                        money = money - 300;
                        pictureBox2.Image = Properties.Resources._3ooRmV;
                        textUse = "Vous avez débloqué --Birdie--  (vous devez cliquer dessus pour généré de l'argent)";
                        var result = CustomDialogForm.Show(textUse);
                        button2.Visible = true;
                        label7.Visible = true;
                        pictureBox3.Visible = true;
                        return;
                    }
                    else
                    {
                        // Message d'argent insuffisant
                        textUse = "Vous n'avez pas asser d'argens...";
                        var result = CustomDialogForm.Show(textUse);
                    }
                }
                if (r == DialogResult.No)
                {
                    // Rien ne se passe si refus
                }
            }
            else
            {
                // Génère de l'argent manuellement si Birdie est déjà débloqué
                NBRClickB = NBRClickB + 1;
                multiplication = NBRClickB / 10;
                if (multiplication < 1)
                {
                    money = money + 5;
                    label6.Text = "+ 5$";
                    Birdie_Texte();
                }
                else
                {
                    money = money + (5 * multiplication);
                    label6.Text = "+ " + 5 * multiplication + "$";
                    Birdie_Texte();
                }
            }
        }

        // Efface le texte d'argent généré par Birdie après un délai
        private async void Birdie_Texte()
        {
            await Task.Delay(500);
            label6.Text = "";
        }

        // Gère le clic sur label5 pour faire défiler l'interface vers le haut
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

        // Gère l'achat et l'amélioration de l'auto Birdie
        private void button2_Click(object sender, EventArgs e)
        {
            if (autoBirdie == false)
            {
                textUse = "Veux-tu acheter l'auto Birdie ?\nCost : 900$";
                var rn = CustomDialogForm3.Show(textUse);
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
                        textUse = "Vous n'avez pas asser d'argent...";
                        var a = CustomDialogForm.Show(textUse);
                    }
                }
            }
            if (autoBirdie == true && birdielbl2 == false)
            {
                textUse = "Veux-tu améliorer l'auto Birdie ?\nCost : 1800$";
                var rn = CustomDialogForm3.Show(textUse);
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
                        textUse = "Vous n'avez pas asser d'argent...";
                        var a = CustomDialogForm.Show(textUse);
                    }
                }
            }
            if (birdielbl2 == true)
            {
                textUse = "Vous ne pouvez plus l'améliorer...";
                var a = CustomDialogForm.Show(textUse);
            }
        }

        // Gère le gain automatique d'argent avec l'auto Birdie
        private void autoBirdie_Timer_Tick(object sender, EventArgs e)
        {
            if (autoBirdie == true && birdielbl2 == false)
            {
                money = money + 5;
                label6.Text = "+ 50$";
                Birdie_Texte();
            }
            if (autoBirdie == true && birdielbl2 == true)
            {
                money = money + 10;
                label6.Text = "+ 125$";
                Birdie_Texte();
            }
        }

        // Événement vide de dessin du fond
        private void background1_Paint(object sender, PaintEventArgs e)
        {
        }

        // Gère l'achat de Waluigi
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (waluigi == false)
            {
                textUse = "Souhaitez vous débloquer --Monstro Waluigi-- ?\nCost : 4000$";
                var rn = CustomDialogForm3.Show(textUse);
                if (rn == DialogResult.Yes)
                {
                    if (money >= 4000)
                    {
                        money = money - 4000;
                        pictureBox3.Image = Properties.Resources.WaluigiUnlocked;
                        waluigi = true;
                        textUse = "Vous avez débloqué --Monstro Waluigi-- !";
                        var ran = CustomDialogForm.Show(textUse);
                        textUse = "Vous avez débloquer les niveau !";
                        var wa = CustomDialogForm.Show(textUse);
                        pictureBox4.Visible = true;
                        label9.Visible = true;
                        return;
                    }
                    else
                    {
                        textUse = "Vous n'avez pas assez d'argent...";
                        var wa = CustomDialogForm.Show(textUse);
                    }
                }
            }
            else
            {
                textUse = "Vous l'avez déjà débloquer...";
                var wa = CustomDialogForm.Show(textUse);
            }
        }

        // Efface le texte d'argent généré par Waluigi après un délai
        private async void WaluigilblTimer()
        {
            await Task.Delay(500);
            label8.Text = "";
        }

        // Gère le gain automatique d'argent avec Waluigi
        private void WAluigiTimer_Tick(object sender, EventArgs e)
        {
            if (waluigi == true)
            {
                money = money + 450;
                label8.Text = "+ 450$";
                WaluigilblTimer();
            }
        }

        // Gère l'achat de CrazyFrog
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (CrazyFrog == false)
            {
                textUse = "Souhaitez vous débloquer --CrazyFrog-- ?\nCost : 10,000$";
                var rn = CustomDialogForm3.Show(textUse);
                if (rn == DialogResult.Yes)
                {
                    if (money >= 10000)
                    {
                        money = money - 10000;
                        pictureBox4.Image = Properties.Resources.CrazyFrogUnlocked;
                        textUse = "Vous avez débloqué --CrazyFrog-- !";
                        var wa = CustomDialogForm.Show(textUse);
                        CrazyFrog = true;
                        XP = XP + 50;
                        textUse = "BRAVO VOUS AVEZ FINI LE JEU ! ( j'ai pas un temps infini pour fair un idle game c'est trop loooooooooooong)";
                        var a = CustomDialogForm.Show(textUse);
                        return;
                    }
                    else
                    {
                        textUse = "Vous n'avez pas assez d'argent...";
                        var ran = CustomDialogForm.Show(textUse);
                    }
                }
            }
            else
            {
                textUse = "Vous l'avez déjà débloquer...";
                var ran = CustomDialogForm.Show(textUse);
            }
        }

        // Efface le texte d'argent généré par CrazyFrog après un délai
        private async void CrazyLabel()
        {
            await Task.Delay(500);
            label9.Text = "";
        }

        // Gère le gain automatique d'argent avec CrazyFrog
        private void CrazyFrogTimer_Tick(object sender, EventArgs e)
        {
            if (CrazyFrog == true)
            {
                money = money + 450;
                label10.Text = "+ 450$";
                CrazyLabel();
            }
        }

        // Clic sur le label9 (ne fait rien actuellement)
        private void label9_Click(object sender, EventArgs e)
        {
        }

        // Gère la montée de niveau avec l'expérience
        private void XP_TIMER_Tick(object sender, EventArgs e)
        {
            if (XP == valueXp)
            {
                LVL = LVL + 1;
                valueXp = 100 * LVL + valueXp;
                textUse = "Vous avez augmenter de niveau !";
                var ran = CustomDialogForm.Show(textUse);
                return;
            }
            label9.Text = "Niveau : " + LVL + "\r\nExp : " + XP.ToString() + " / " + valueXp.ToString();
        }

        // Événement vide si taille de background1 change
        private void background1_SizeChanged(object sender, EventArgs e)
        {
        }

        // Événement vide si taille du formulaire change
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
        }

        // Timer vide
        private void timer1_Tick(object sender, EventArgs e)
        {
        }
    }
}