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
            /*
            data datatest = new data();

            datatest.Cible = 50;
            datatest.Nombre1 = 10;
            datatest.Nombre2 = 5;
            datatest.Nombre3 = 4;
            datatest.Nombre4 = 12;
            datatest.Nombre5 = 10;
            
           
            string json = JsonConvert.SerializeObject(datatest);
            
            System.IO.File.WriteAllText(@"C:/Users/Roro/Documents/Visual Studio 2013/Projects/Mathador/ressources/path.txt", json);
            */
            string text = System.IO.File.ReadAllText(@"C:/Users/Roro/Documents/Visual Studio 2013/Projects/Mathador/ressources/path.txt");
            
            data json = JsonConvert.DeserializeObject<data>(text);
           //Console.WriteLine("Cible: {0}, Nombre1: {1}", datatest.Cible, datatest.Nombre1);
           
          
            
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
            resultat = Int32.Parse(BouttonNombre1.Text);
            PremierNombreSelectione = true;
        }

        private void ButtonPlus_Click(object sender, EventArgs e)
        {
            plus = true;
        }

        private void BouttonNombre2_Click(object sender, EventArgs e)
        {
            if (PremierNombreSelectione == true)
            {
                if (plus == true)
                {
                    resultat = resultat + Int32.Parse(BouttonNombre2.Text);
                    BouttonNombre1.Text = resultat.ToString();
                    BouttonNombre2.Text = "";
                    plus = false;
                }
            }
            PremierNombreSelectione = false;
        }



       
    }
}
