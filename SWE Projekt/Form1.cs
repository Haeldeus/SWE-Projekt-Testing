using System.Diagnostics;
using System.Reflection.Metadata;
using System.Security.Cryptography;

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
            fillDictionaries();
            setTotals();
        }

        public void setTotals()
        {
            double resPurch = 0;
            double resSale = 0;
            double resVolume = 0;

            for (int i = 1; i <= LIMIT; i++)
            {
                try
                {
                    resPurch += double.Parse(PurchasePriceTextBoxes[i].Text) * double.Parse(VolumeTextBoxes[i].Text);
                }
                catch (Exception e)
                {
                    resPurch += 0;
                }
                try
                {
                    resSale += double.Parse(SalePriceTextBoxes[i].Text) * double.Parse(VolumeTextBoxes[i].Text);
                }
                catch (Exception e)
                {
                    resSale += 0;
                }
                try
                {
                    resVolume += double.Parse(VolumeTextBoxes[i].Text);
                }
                catch (Exception e)
                {
                    resVolume += 0;
                }
                try
                {
                    ProfitLabels[i].Text = (double.Parse(SalePriceTextBoxes[i].Text) - double.Parse(PurchasePriceTextBoxes[i].Text)) * double.Parse(VolumeTextBoxes[i].Text) + "€";
                }
                catch (Exception e)
                {
                    ProfitLabels[i].Text = 0 + "€";
                }
            }

            TotalLabels[1].Text = resPurch + "€";
            TotalLabels[2].Text = resSale + "€";
            TotalLabels[3].Text = "" + resVolume;
            TotalLabels[4].Text = (resSale - resPurch) + "€";
        }

        private void fillDictionaries()
        {
            TotalLabels.Clear();
            ProfitLabels.Clear();
            SalePriceTextBoxes.Clear();
            PurchasePriceTextBoxes.Clear();
            VolumeTextBoxes.Clear();

            TotalLabels.Add(1, lbTotalPurchPrice);
            TotalLabels.Add(2, lbTotalSalePrice);
            TotalLabels.Add(3, lbTotalVolume);
            TotalLabels.Add(4, lbTotalProfit);


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
                double profit = double.Parse(SalePriceTextBoxes[i].Text.Replace(",", ".")) - double.Parse(PurchasePriceTextBoxes[i].Text.Replace(",", "."));
                ProfitLabels[i].Text = profit * int.Parse(VolumeTextBoxes[i].Text) + "€";
            }
            setTotals();
        }

    }
}
