using System.Diagnostics;
using System.Reflection.Metadata;

namespace SWE_Projekt {

    public partial class Form1 : Form
    {
        private Dictionary<int, TextBox> SalePriceTextBoxes = new Dictionary<int, TextBox>();
        private Dictionary<int, TextBox> PurchasePriceTextBoxes = new Dictionary<int, TextBox>();
        private Dictionary<int, TextBox> VolumeTextBoxes = new Dictionary<int, TextBox>();
        private Dictionary<int, Label> ProfitLabels = new Dictionary<int, Label>();
        private Dictionary<int, Label> TotalLabels = new Dictionary<int, Label>();

        private int LIMIT = 10;
        public Form1()
        {
            InitializeComponent();

        }

        private void fillDictionaries()
        {
            for (int i = 1; i <= LIMIT; i++)
            {
                Control[] matches = this.Controls.Find("tbSalePrice" + i, true);
                if (matches.Length > 0)
                {
                    SalePriceTextBoxes.Add(i, (TextBox)matches[0]);
                }
                else
                {
                    Debug.WriteLine("Kein Feld mit tbSalePrice" + i + " gefunden");
                }

                matches = this.Controls.Find("tbPurchPrice" + i, true);
                if (matches.Length > 0)
                {
                    PurchasePriceTextBoxes.Add(i, (TextBox)matches[0]);
                }
                else
                {
                    Debug.WriteLine("Kein Feld mit tbPurchPrice" + i + " gefunden");
                }

                matches = this.Controls.Find("tbVolume" + i, true);
                if (matches.Length > 0)
                {
                    VolumeTextBoxes.Add(i, (TextBox)matches[0]);
                }
                else
                {
                    Debug.WriteLine("Kein Feld mit tbVolume" + i + " gefunden");
                }

                matches = this.Controls.Find("lbProfit" + i, true);
                if (matches.Length > 0)
                {
                    ProfitLabels.Add(i, (Label)matches[0]);
                }
                else
                {
                    Debug.WriteLine("Kein Feld mit lbProfit" + i + " gefunden");
                }
            }
        }

        private void btCalc_Click(object sender, EventArgs e)
        {
            fillDictionaries();
            for (int i = 1; i <= LIMIT; i++)
            {
                double profit = double.Parse(SalePriceTextBoxes[i].Text.Replace(",",".")) - double.Parse(PurchasePriceTextBoxes[i].Text.Replace(",","."));
                ProfitLabels[i].Text = profit * int.Parse(VolumeTextBoxes[i].Text) + "€";
            }

            Debug.WriteLine("Dies war ein Test");
        }

    }
}
