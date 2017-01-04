using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mathador
{
    public partial class MathadorGame : Form
    {
        public int resultat;
        public bool plus = false;
        public bool div = false;
        public bool fois = false;
        public bool moins = false;
        public int round = 0;
        public int ScoreRound;
        int cible;
        Button button2;
        Button LastButton;
        public bool PremierNombreSelectione = false;
        public MathadorGame()
        {
            InitializeComponent();
        }
        private void MathadorGame_Load(object sender, EventArgs e)
        {

            TextCible.Text = "";
            ButtonNombre5.Text = "";
            BouttonNombre1.Text = "";
            BouttonNombre2.Text = "";
            BouttonNombre3.Text = "";
            BouttonNombre4.Text = "";
        }

        private void ButtonTestGenerer_Click(object sender, EventArgs e)
        {

            Generator();

            string text = System.IO.File.ReadAllText(@"D:\École\Ingesup\C#\Projet\Mathador\Gene.db");
            
            data json = JsonConvert.DeserializeObject<data>(text);
           //Console.WriteLine("Cible: {0}, Nombre1: {1}", datatest.Cible, datatest.Nombre1);


            cible = json.Cible;
            NombreCible.Text = cible.ToString();
            int[] tableau = new int[5];

            tableau[0] = json.Nombre1;
            tableau[1] = json.Nombre2;
            tableau[2] = json.Nombre3;
            tableau[3] = json.Nombre4;
            tableau[4] = json.Nombre5;

            BouttonNombre1.Text = tableau[0].ToString();
            BouttonNombre2.Text = tableau[1].ToString();
            BouttonNombre3.Text = tableau[2].ToString();
            BouttonNombre4.Text = tableau[3].ToString();
            ButtonNombre5.Text = tableau[4].ToString();

        }

        private void BouttonNombre1_Click(object sender, EventArgs e)
        {
            Calcule(BouttonNombre1);
        }

        private void ButtonPlus_Click(object sender, EventArgs e)
        {
            plus = true;
        }

        private void BouttonNombre2_Click(object sender, EventArgs e)
        {

            Calcule(BouttonNombre2);
        }

        public void reset()
        {
          resultat = 0;
        plus = false;
        div = false;
        fois = false;
        moins = false;
        round = 0;
        ScoreRound = 0;
        cible = 0;
        button2 = null;
        LastButton = null;
        PremierNombreSelectione = false;

        BouttonNombre1.Text = "";
        BouttonNombre2.Text = "";
        BouttonNombre3.Text = "";
        BouttonNombre4.Text = "";
        ButtonNombre5.Text = "";
        NombreCible.Text = "0";
        TextScore.Text = "Score";
        }

        public void Calcule(Button button1)
        {
            if (PremierNombreSelectione == true)
            {
                if (plus == true)
                {
                    resultat = resultat + Int32.Parse(button1.Text);
                    button1.Text = resultat.ToString();
                    button2.Text = "";
                    ScoreRound += 1;
                    LastButton = button1;
                    plus = false;
                }
                if (moins == true)
                {
                    resultat = resultat - Int32.Parse(button1.Text);
                    button1.Text = resultat.ToString();
                    button2.Text = "";
                    ScoreRound += 2;
                    LastButton = button1;
                    moins = false;
                }
                if (div == true)
                {
                    resultat = resultat / Int32.Parse(button1.Text);
                    button1.Text = resultat.ToString();
                    button2.Text = "";
                    ScoreRound += 3;
                    LastButton = button1;
                    div = false;
                }
                if (fois == true)
                {
                    resultat = resultat * Int32.Parse(button1.Text);
                    button1.Text = resultat.ToString();
                    button2.Text = "";
                    ScoreRound += 1;
                    LastButton = button1;
                    fois = false;
                }
                PremierNombreSelectione = false;
                round++;
            }
            else
            {
                resultat = Int32.Parse(button1.Text);
                button2 = button1;
                PremierNombreSelectione = true;
            }
            if (round == 4)
            {
                TextScore.Text = "Terminer";
                if (button1.Text == cible.ToString())
                {
                    TextScore.Text = "Mathador";
                }
            }
        }

        public static void Generator()
        {
            int nb1, nb2, nb3, nb4, nb5, cible;

            Random random = new Random();

            nb1 = random.Next(1*20);
            nb2 = random.Next(1*20);
            nb3 = random.Next(1*12);
            nb4 = random.Next(1*12);
            nb5 = random.Next(1*12);

            cible = nb1 + nb2 - nb3 * nb4 / nb5;


            data datatest = new data();

            datatest.Cible = cible;
            datatest.Nombre1 = nb1;
            datatest.Nombre2 = nb2;
            datatest.Nombre3 = nb3;
            datatest.Nombre4 = nb4;
            datatest.Nombre5 = nb5;


            string json = JsonConvert.SerializeObject(datatest);

            System.IO.File.WriteAllText(@"D:\École\Ingesup\C#\Projet\Mathador\Gene.db", json);

        }




        private void BouttonNombre3_Click(object sender, EventArgs e)
        {
            Calcule(BouttonNombre3);
        }

        private void BouttonNombre4_Click(object sender, EventArgs e)
        {
            Calcule(BouttonNombre4);
        }

        private void ButtonNombre5_Click(object sender, EventArgs e)
        {
            Calcule(ButtonNombre5);
        }

        private void ButtonMoins_Click(object sender, EventArgs e)
        {
            moins = true;
        }

        private void ButtonFois_Click(object sender, EventArgs e)
        {
            fois = true;
        }

        private void ButtonDiv_Click(object sender, EventArgs e)
        {
            div = true;
        }

        private void ButtonSuivant_Click(object sender, EventArgs e)
        {
            if (LastButton.Text == NombreCible.Text)
            {
                TextScore.Text = "Bien joué";
            }
            else
            {
                TextScore.Text = "perdu";
            }
        }

        private void ButtonRetour_Click(object sender, EventArgs e)
        {
            reset();
        }



       
    }
}
