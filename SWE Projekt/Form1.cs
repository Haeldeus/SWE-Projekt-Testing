using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace SWE_Projekt {

    public partial class Form1 : Form
    {
        private Dictionary<int, TextBox> SalePriceTextBoxes = new Dictionary<int, TextBox>();
        private Dictionary<int, TextBox> PurchasePriceTextBoxes = new Dictionary<int, TextBox>();
        private Dictionary<int, TextBox> VolumeTextBoxes = new Dictionary<int, TextBox>();
        private Dictionary<int, Label> ProfitLabels = new Dictionary<int, Label>();
        private Dictionary<int, Label> TotalLabels = new Dictionary<int, Label>();
        private Dictionary<int, Label> ModelLabels = new Dictionary<int, Label>();


        private int LIMIT = 10;
        public Form1()
        {
            InitializeComponent();
            fillDictionaries();
            btCalc_Click(this, new EventArgs());
        }

        private void fillDictionaries()
        {
            TotalLabels.Clear();
            ProfitLabels.Clear();
            ModelLabels.Clear();
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

                matches = this.Controls.Find("lbModel" + i, true);
                if (matches.Length > 0)
                {
                    ModelLabels.Add(i, (Label)matches[0]);
                }
                else
                {
                    Debug.WriteLine("Kein Feld mit lbModel" + i + " gefunden");
                }
            }
        }

        private void btRename_Click(object sender, EventArgs e)
        {
            // sender als Button casten
            Button? btn = sender as Button;
            if (btn != null)
            {
                string buttonNumber = btn.Name.Replace("btRenameRow", "");

                // Create new Form
                Form inputForm = new Form();
                inputForm.Text = "Eingabe";

                // Create new TextBox
                TextBox tbInput = new TextBox();
                tbInput.Location = new Point(10, 10);
                tbInput.Width = 200;

                // Create an OK-Button
                Button btOK = new Button();
                btOK.Text = "OK";
                btOK.Location = new Point(10, 40);
                btOK.DialogResult = DialogResult.OK;

                // Add Ok-Button to new Form
                inputForm.Controls.Add(tbInput);
                inputForm.Controls.Add(btOK);

                // Set OK-Button as AcceptButton, to enable Pressing Enter to continue.
                inputForm.AcceptButton = btOK;

                // Set Form Size
                inputForm.ClientSize = new Size(230, 80);
                inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                inputForm.StartPosition = FormStartPosition.CenterParent;
                inputForm.MaximizeBox = false;
                inputForm.MinimizeBox = false;

                // Show Dialog and awaiting Input
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    string userInput = tbInput.Text;
                    Control[] matches = this.Controls.Find("lbModel" + buttonNumber, true);
                    matches[0].Text = userInput;
                }
            }
        }

        private bool TryParseFlexibleDecimal(string input, out decimal result)
        {
            result = 0;

            if (string.IsNullOrWhiteSpace(input))
                return false;

            // Komma zu Punkt normalisieren
            input = input.Replace(",", ".");

            return decimal.TryParse(
                input,
                NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
                CultureInfo.InvariantCulture,
                out result);
        }


        private void btExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "CSV Datei (*.csv)|*.csv";
            dialog.Title = "CSV exportieren";
            dialog.FileName = "export.csv";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(dialog.FileName, false, Encoding.UTF8))
                {
                    // Header
                    writer.WriteLine("Model;Purchase;Sale;Volume;Profit");

                    for (int i = 1; i <= LIMIT; i++)
                    {
                        String model = ModelLabels[i].Text;
                        String purchase = PurchasePriceTextBoxes[i].Text + "€";
                        String sale = SalePriceTextBoxes[i].Text + "€";
                        String volume = VolumeTextBoxes[i].Text;
                        String profit = ProfitLabels[i].Text;

                        writer.WriteLine($"{model};{purchase};{sale};{volume};{profit}");
                    }
                    writer.WriteLine($"Total;{TotalLabels[1].Text};{TotalLabels[2].Text};{TotalLabels[3].Text};{TotalLabels[4].Text}");
                }

                using (StreamWriter writer = new StreamWriter(dialog.FileName.Replace(".csv", "_Comma.csv"), false, Encoding.UTF8))
                {
                    // Header
                    writer.WriteLine("Model,Purchase,Sale,Volume,Profit");

                    for (int i = 1; i <= LIMIT; i++)
                    {
                        String model = ModelLabels[i].Text;
                        String purchase = PurchasePriceTextBoxes[i].Text.Replace(",",".") + "€";
                        String sale = SalePriceTextBoxes[i].Text.Replace(",", ".") + "€";
                        String volume = VolumeTextBoxes[i].Text;
                        String profit = ProfitLabels[i].Text.Replace(",", ".");

                        writer.WriteLine($"{model},{purchase},{sale},{volume},{profit}");
                    }
                    writer.WriteLine($"Total,{TotalLabels[1].Text},{TotalLabels[2].Text},{TotalLabels[3].Text},{TotalLabels[4].Text}");
                }

                MessageBox.Show("Export erfolgreich!");
            }
        }

        private void btCalc_Click(object sender, EventArgs e)
        {
            fillDictionaries();
            double resPurch = 0;
            double resSale = 0;
            int resVolume = 0;
            for (int i = 1; i <= LIMIT; i++)
            {
                
                String sale = Regex.Replace(SalePriceTextBoxes[i].Text, @"[^0-9\.,]", "");

                if (!TryParseFlexibleDecimal(SalePriceTextBoxes[i].Text, out decimal valueSale))
                {
                    valueSale = 0;
                }
                SalePriceTextBoxes[i].Text = "" + valueSale;

                String purchase = Regex.Replace(PurchasePriceTextBoxes[i].Text, @"[^0-9\.,]", "");
                if (!TryParseFlexibleDecimal(PurchasePriceTextBoxes[i].Text, out decimal valuePurch))
                {
                    valuePurch = 0;
                }
                PurchasePriceTextBoxes[i].Text = "" + valuePurch;

                VolumeTextBoxes[i].Text = Regex.Replace(VolumeTextBoxes[i].Text, @"[^0-9]", "");

                int.TryParse(VolumeTextBoxes[i].Text, out int volume);
                resVolume += volume; 
                resSale += double.Parse(valueSale.ToString("0.00")) * volume;
                resPurch += double.Parse(valuePurch.ToString("0.00")) * volume;

                decimal totalProfit = (valueSale - valuePurch) * volume;

                ProfitLabels[i].Text = (totalProfit.ToString("0.00") + " €").Replace(".", ",");
                if (totalProfit < 0)
                {
                    ProfitLabels[i].ForeColor = Color.Red;
                } else
                {
                    ProfitLabels[i].ForeColor = Color.Black;
                }
            }


            TotalLabels[1].Text = resPurch + "€".Replace(".", ",");
            TotalLabels[2].Text = resSale + "€".Replace(".", ",");
            TotalLabels[3].Text = "" + resVolume;
            TotalLabels[4].Text = (resSale - resPurch) + "€".Replace(".", ",");

            if (resSale - resPurch < 0)
            {
                TotalLabels[4].ForeColor = Color.Red;
            } else
            {
                TotalLabels[4].ForeColor = Color.Black;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            int newWidth = this.ClientSize.Width;
            int newHeight = this.ClientSize.Height;

            colPoints.Clear();
            rowPoints.Clear();
            colTbPoints.Clear();
            rowTbPoints.Clear();

            colWidth = (newWidth - 10) / 6;
            colPoints.Add(1, 5);
            colPoints.Add(2, colPoints[1] + colWidth);
            colPoints.Add(3, colPoints[2] + colWidth);
            colPoints.Add(4, colPoints[3] + colWidth);
            colPoints.Add(5, colPoints[4] + colWidth);
            colPoints.Add(6, colPoints[5] + colWidth);

            rowHeight = (newHeight - 20) / 13;
            rowPoints.Add(1, 10);
            rowPoints.Add(2, rowPoints[1] + rowHeight);
            rowPoints.Add(3, rowPoints[2] + rowHeight);
            rowPoints.Add(4, rowPoints[3] + rowHeight);
            rowPoints.Add(5, rowPoints[4] + rowHeight);
            rowPoints.Add(6, rowPoints[5] + rowHeight);
            rowPoints.Add(7, rowPoints[6] + rowHeight);
            rowPoints.Add(8, rowPoints[7] + rowHeight);
            rowPoints.Add(9, rowPoints[8] + rowHeight);
            rowPoints.Add(10, rowPoints[9] + rowHeight);
            rowPoints.Add(11, rowPoints[10] + rowHeight);
            rowPoints.Add(12, rowPoints[11] + rowHeight);
            rowPoints.Add(13, rowPoints[12] + rowHeight);

            int tbColPadding = (colWidth - TEXTBOX_WIDTH) / 2;
            int tbRowPadding = (rowHeight - TEXTBOX_HEIGHT) / 2;

            colTbPoints.Add(1, colPoints[1] + tbColPadding);
            colTbPoints.Add(2, colPoints[2] + tbColPadding);
            colTbPoints.Add(3, colPoints[3] + tbColPadding);
            colTbPoints.Add(4, colPoints[4] + tbColPadding);
            colTbPoints.Add(5, colPoints[5] + tbColPadding);
            colTbPoints.Add(6, colPoints[6] + tbColPadding);

            rowTbPoints.Add(1, rowPoints[1] + tbRowPadding);
            rowTbPoints.Add(2, rowPoints[2] + tbRowPadding);
            rowTbPoints.Add(3, rowPoints[3] + tbRowPadding);
            rowTbPoints.Add(4, rowPoints[4] + tbRowPadding);
            rowTbPoints.Add(5, rowPoints[5] + tbRowPadding);
            rowTbPoints.Add(6, rowPoints[6] + tbRowPadding);
            rowTbPoints.Add(7, rowPoints[7] + tbRowPadding);
            rowTbPoints.Add(8, rowPoints[8] + tbRowPadding);
            rowTbPoints.Add(9, rowPoints[9] + tbRowPadding);
            rowTbPoints.Add(10, rowPoints[10] + tbRowPadding);
            rowTbPoints.Add(11, rowPoints[11] + tbRowPadding);
            rowTbPoints.Add(12, rowPoints[12] + tbRowPadding);
            rowTbPoints.Add(13, rowPoints[13] + tbRowPadding);

            redrawForm();
        }
    }
}
