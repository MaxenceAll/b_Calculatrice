using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using b_Calculatrice;
using System.Linq.Expressions;
using System.Windows.Forms.VisualStyles;

namespace b_Calculatrice
{
    public partial class FenetreCalculatrice : Form
    {
        private bool NouvelleOperation=true;
        private double Nombre1 = 0;
        private double Nombre2 = 0;
        private String Operation = "";
        public FenetreCalculatrice()
        {
            InitializeComponent();
        }
        public void NumberClick(object sender, EventArgs e)
        {
            Button btn_number = (Button)sender;
            if (NouvelleOperation)
            {
                resultat.Text = ("");
                calcul.Text=("");
                NouvelleOperation = false;
            }
            calcul.Text += btn_number.Text;
            resultat.Text += btn_number.Text;
        }
        public void OperationClick(object sender, EventArgs e)
        {
            Button btn_operator = (Button)sender;
            if (btn_operator.Text.Equals("!"))
            {
                Operation = btn_operator.Text;
                Nombre1 = Double.Parse(resultat.Text);
                resultat.Text = Convert.ToString(Calculator.calculerResultat(Nombre1,Operation));
                calcul.Text = ("(" + calcul.Text + "!)=" + resultat.Text);

            }
            else
            {
                if (!btn_operator.Text.Equals("="))
                {
                    if (NouvelleOperation)
                    {
                        NouvelleOperation = false;
                    }
                    Operation = btn_operator.Text;
                    Nombre1 = Double.Parse(resultat.Text);
                    calcul.Text = (calcul.Text + btn_operator.Text);
                    resultat.Text = "";

                }
                else
                {

                    Nombre2 = Double.Parse(resultat.Text);
                    resultat.Text = Convert.ToString(Calculator.calculerResultat(Nombre1, Nombre2, Operation));
                    Operation = "";
                    NouvelleOperation = true;
                    calcul.Text = ("(" + calcul.Text + ")=" + resultat.Text);

                }
            }
        }
        public void VirguleClick(object sender, EventArgs e)
        {
            calcul.Text = (calcul.Text + ".");
            resultat.Text = (resultat.Text + ".");
        }
        public void CClick(object sender, EventArgs e)
        {
            Nombre1 = 0;
            Nombre2 = 0;
            Operation = "";
            NouvelleOperation = true;
            resultat.Text = ("");
            calcul.Text = ("");
        }

        public void btnPlusMoins_Click(object sender, EventArgs e)
        {
            if (resultat.Text.Contains("-"))
            {
                double tempo = Double.Parse(resultat.Text);
                resultat.Text = Convert.ToString(Math.Abs(tempo));
            }
            else
            {
                resultat.Text=("-" + resultat.Text);
            }
        }

        private void RemoveLastClick(object sender, EventArgs e)
        {
            //MessageBox.Show( Convert.ToString(resultat.Text.Length) );
            if (resultat.Text != "")resultat.Text = resultat.Text.Substring(0, resultat.Text.Length - 1);
            if (resultat.Text != "") calcul.Text = calcul.Text.Substring(0, calcul.Text.Length - 1);
        }

        /*
         * 
         * 
         *  POUR LES RACCOURCIS CLAVIER :
         *
         *
         */
        protected override void OnKeyPress(KeyPressEventArgs ex)
        {

            string saisieToString = ex.KeyChar.ToString();
            //MessageBox.Show(ex.KeyChar.ToString());
            switch (saisieToString)
            {
                case "0": NumberClickKeyboard("0"); break;
                case "1": NumberClickKeyboard("1"); break;
                case "2": NumberClickKeyboard("2"); break;
                case "3": NumberClickKeyboard("3"); break;
                case "4": NumberClickKeyboard("4"); break;
                case "5": NumberClickKeyboard("5"); break;
                case "6": NumberClickKeyboard("6"); break;
                case "7": NumberClickKeyboard("7"); break;
                case "8": NumberClickKeyboard("8"); break;
                case "9": NumberClickKeyboard("9"); break;
                case "/": OperatorClickKeyboard("/"); break;
                case "*": OperatorClickKeyboard("*"); break;
                case "-": OperatorClickKeyboard("-"); break;
                case "+": OperatorClickKeyboard("+"); break;
                case "=": OperatorClickKeyboard("="); break;
                case ".": OperatorClickKeyboard("."); break;
                case "c": OperatorClickKeyboard("c"); break;
            }
            if (ex.KeyChar == (char)8 )
            {
                RemoveLastClickKeyboard();
            }

           
        }


        public void NumberClickKeyboard(string stringKeyPressed)
        {
            string btn_number = stringKeyPressed;
            if (NouvelleOperation)
            {
                resultat.Text = ("");
                calcul.Text = ("");
                NouvelleOperation = false;
            }
            calcul.Text += btn_number;
            resultat.Text += btn_number;
        }
        public void OperatorClickKeyboard(string stringKeyPressed)
        {
            string btn_operator= stringKeyPressed;
            if (btn_operator.Equals("!"))
            {
                Operation = btn_operator;
                Nombre1 = Double.Parse(resultat.Text);
                resultat.Text = Convert.ToString(Calculator.calculerResultat(Nombre1, Operation));
                calcul.Text = ("(" + calcul.Text + "!)=" + resultat.Text);

            }
            else
            {
                if (!btn_operator.Equals("="))
                {
                    if (NouvelleOperation)
                    {
                        NouvelleOperation = false;
                    }
                    Operation = btn_operator;
                    Nombre1 = Double.Parse(resultat.Text);
                    calcul.Text = (calcul.Text + btn_operator);
                    resultat.Text = "";

                }
                else
                {

                    Nombre2 = Double.Parse(resultat.Text);
                    resultat.Text = Convert.ToString(Calculator.calculerResultat(Nombre1, Nombre2, Operation));
                    Operation = "";
                    NouvelleOperation = true;
                    calcul.Text = ("(" + calcul.Text + ")=" + resultat.Text);

                }
            }
        }

        private void RemoveLastClickKeyboard()
        {
            if (resultat.Text != "") resultat.Text = resultat.Text.Substring(0, resultat.Text.Length - 1);
            if (resultat.Text != "") calcul.Text = calcul.Text.Substring(0, calcul.Text.Length - 1);
        }


    }
}
