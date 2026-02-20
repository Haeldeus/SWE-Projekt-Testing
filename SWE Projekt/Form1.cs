using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace SWE_Projekt {

    /// <summary>
    /// The Partial Class for the Form, which provides all Methods for this Form and all EventHandler.
    /// </summary>
    public partial class Form1 : Form
    {
        /**
         * All Dictionaries, that are needed to ensure functionality. These store all Components 
         * that can be altered by either the User (TextBoxes) or the Application (Labels)
         */
        private Dictionary<int, TextBox> SalePriceTextBoxes = new Dictionary<int, TextBox>();
        private Dictionary<int, TextBox> PurchasePriceTextBoxes = new Dictionary<int, TextBox>();
        private Dictionary<int, TextBox> VolumeTextBoxes = new Dictionary<int, TextBox>();
        private Dictionary<int, Label> ProfitLabels = new Dictionary<int, Label>();
        private Dictionary<int, Label> TotalLabels = new Dictionary<int, Label>();
        private Dictionary<int, Label> ModelLabels = new Dictionary<int, Label>();
        //A Dictionary, that saves, if a row is active or not. If a row isn't active, it will not be
        //exported later when the Export Button is clicked.
        private Dictionary<int, bool> rowActive = new Dictionary<int, bool>(); 

        /**
         * The Limit of Rows in this Application.
         */
        private readonly int LIMIT = 10;

        /// <summary>
        /// Constructor for the Form. Initializes all Components and simulates a Calc-Click 
        /// to display correct Values in all Labels
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            Click_btCalc(this, new EventArgs());
        }

        /// <summary>
        ///  A Method, to fill all Dictionaries with their corresponding Controls.
        /// </summary>
        private void FillDictionaries()
        {
            /*
             * Clears all Dictionaries, so there are no duplicate entries.
             */
            TotalLabels.Clear();
            ProfitLabels.Clear();
            ModelLabels.Clear();
            SalePriceTextBoxes.Clear();
            PurchasePriceTextBoxes.Clear();
            VolumeTextBoxes.Clear();

            /*
             * Since these are pretty easy to add, the TotalLabels are added outside the Loop.
             */
            TotalLabels.Add(1, lbTotalPurchPrice);
            TotalLabels.Add(2, lbTotalSalePrice);
            TotalLabels.Add(3, lbTotalVolume);
            TotalLabels.Add(4, lbTotalProfit);


            /*
             * Gets all Textboxes and result Labels from 1 to the set LIMIT and adds them to 
             * their respective Disctionaries.
             */
            for (int i = 1; i <= LIMIT; i++)
            {
                /*
                 * Searches in the Form for the Control with the Name "tbSalePrice" + i, e.g. 
                 * "tbSalePrice4" and adds this Component to it's Dictionary. If there was an 
                 * Error while finding this TextBox, nothing happens and a Message is printed 
                 * into Debug.
                 */
                Control[] matches = this.Controls.Find("tbSalePrice" + i, true);
                if (matches.Length > 0)
                {
                    SalePriceTextBoxes.Add(i, (TextBox)matches[0]);
                }
                else
                {
                    Debug.WriteLine("Kein Feld mit tbSalePrice" + i + " gefunden");
                }

                /*
                 * Searches in the Form for the Control with the Name "tbPurchPrice" + i, e.g. 
                 * "tbPurchPrice3" and adds this Component to it's Dictionary. If there was an 
                 * Error while finding this TextBox, nothing happens and a Message is printed 
                 * into Debug.
                 */
                matches = this.Controls.Find("tbPurchPrice" + i, true);
                if (matches.Length > 0)
                {
                    PurchasePriceTextBoxes.Add(i, (TextBox)matches[0]);
                }
                else
                {
                    Debug.WriteLine("Kein Feld mit tbPurchPrice" + i + " gefunden");
                }

                /*
                 * Searches in the Form for the Control with the Name "tbVolume" + i, e.g. 
                 * "tbVolume6" and adds this Component to it's Dictionary. If there was an 
                 * Error while finding this TextBox, nothing happens and a Message is printed 
                 * into Debug.
                 */
                matches = this.Controls.Find("tbVolume" + i, true);
                if (matches.Length > 0)
                {
                    VolumeTextBoxes.Add(i, (TextBox)matches[0]);
                }
                else
                {
                    Debug.WriteLine("Kein Feld mit tbVolume" + i + " gefunden");
                }

                /*
                 * Searches in the Form for the Control with the Name "lbProfit" + i, e.g. 
                 * "lbProfit2" and adds this Component to it's Dictionary. If there was an 
                 * Error while finding this Label, nothing happens and a Message is printed 
                 * into Debug.
                 */
                matches = this.Controls.Find("lbProfit" + i, true);
                if (matches.Length > 0)
                {
                    ProfitLabels.Add(i, (Label)matches[0]);
                }
                else
                {
                    Debug.WriteLine("Kein Feld mit lbProfit" + i + " gefunden");
                }

                /*
                * Searches in the Form for the Control with the Name "lbModel" + i, e.g. 
                * "lbModel7" and adds this Component to it's Dictionary. If there was an 
                * Error while finding this Label, nothing happens and a Message is printed 
                * into Debug.
                */
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

        /// <summary>
        /// Gets called, whenever a RenameButton is clicked. This will determine which 
        /// Button was clicked, and then display a new Form to be able to get the User's 
        /// Input.
        /// </summary>
        /// <param name="sender"> The Button, this Event was sent from.</param>
        /// <param name="e"> All EventArguments belonging to the ButtonClick.</param>
        private void Click_btRename(object sender, EventArgs e)
        {
            // Cast sender as a Button
            Button? btn = sender as Button;
            if (btn != null)
            {
                //Determines the Number of the Button, that was pressed.
                string buttonNumber = btn.Name.Replace("btRenameRow", "");

                // Create new Form to display the Components needed to rename the Models.
                Form inputForm = new Form();
                inputForm.Text = "Eingabe";

                // Create new TextBox to get the Users Text Input.
                TextBox tbInput = new TextBox();
                tbInput.Location = new Point(10, 10);
                tbInput.Width = 200;

                // Create an OK-Button to confirm the new Name.
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

        /// <summary>
        /// Parses both xxx.xx and xxx,xx Inputs in the Textboxes to valid decimals. 
        /// This ensures usability no matter, which Separator the User is used to.
        /// </summary>
        /// <param name="input">
        /// The User's Input as a String, taken from the TextBox
        /// </param>
        /// <param name="result">
        /// The result of this Operation. If a valid Input was entered, 
        /// the correct decimal will be returned. Else, this result defaults to 0.
        /// </param>
        /// <returns>
        /// True, if the Parse was successfully done, False if not.
        /// </returns>
        private static bool TryParseFlexibleDecimal(String input, out decimal result)
        {
            //Sets the result to 0 as a default value.
            result = 0;

            //If no Input was entered, false is returned, and result
            //stays at the default value.
            if (String.IsNullOrWhiteSpace(input))
                return false;

            //Normalizes ',' to '.', which is used in the Parse as a Separator.
            input = input.Replace(",", ".");

            //Returns the Output of TryParse in decimal. This allows decimalPoints and LeadingSigns,
            //so e.g. "-9.81" gets correctly converted to a decimal. By using InvariantCulture, we
            //can be sure, that the Result is correct, no matter which Windows Settings are used.
            return decimal.TryParse(
                input,
                NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
                CultureInfo.InvariantCulture,
                out result);
        }

        /// <summary>
        /// Called, when the Export Button is called. 
        /// Opens a Dialog to select the target folder. All data from the form is then exported as 
        /// CSV files to the selected folder. 
        /// Since German versions of Excel use different CSV formats,
        /// two files are created:
        /// - One using ',' as the field separator and '.' as the decimal separator.
        /// - One using ';' as the field separator and ',' as the decimal separator.
        ///
        /// The former is saved as "Name_Comma.csv",
        /// the latter as "Name.csv".
        /// </summary>
        /// <param name="sender">
        /// The Button, that sent this ClickEvent. This is always the same Button and never used.
        /// </param>
        /// <param name="e">
        /// The EventArguments for this ClickEvent. Never used.
        /// </param>
        private void Click_btExport(object sender, EventArgs e)
        {
            //To ensure, that the right data is used, btCalc-Click is simulated, so a final
            //Calculation is done before exporting the data.
            Click_btCalc(this, new EventArgs());
            //Opens a new SaveFileDialog to select the target folder.
            SaveFileDialog dialog = new SaveFileDialog();
            //Sets default Values for the Dialog Window.
            dialog.Filter = "CSV Datei (*.csv)|*.csv";
            dialog.Title = "CSV exportieren";
            dialog.FileName = "export.csv";

            //Waits for the User to select a folder, than Writes the File to the folder.
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //Creates a StreamWriter to write the file to the Folder. Uses standard UTF-8
                //Encoding to ensure Correct values when Ü,Ä,Ö etc. are used.
                using (StreamWriter writer = new StreamWriter(dialog.FileName, false, Encoding.UTF8))
                {
                    //The Header for the CSV-File
                    writer.WriteLine("Model;Purchase;Sale;Volume;Profit");

                    //Iterates over all Components to get their Values and then write these
                    //Values as a single line into the File.
                    for (int i = 1; i <= LIMIT; i++)
                    {
                        if (rowActive[i])
                        {
                            //Replaces all '.' with ',', so each Cell can be displayed in the correct Column.
                            String model = ModelLabels[i].Text.Replace(".", ",");
                            String purchase = PurchasePriceTextBoxes[i].Text.Replace(".", ",") + "€";
                            String sale = SalePriceTextBoxes[i].Text.Replace(".", ",") + "€";
                            String volume = VolumeTextBoxes[i].Text.Replace(".", ",");
                            String profit = ProfitLabels[i].Text.Replace(".", ",");

                            //Writes the Line with the given Values.
                            writer.WriteLine($"{model};{purchase};{sale};{volume};{profit}");
                        }
                    }
                    //Writes the Last Line as the Total Sums, stored in the TotalLabels-Dictionary.
                    writer.WriteLine($"Total;{TotalLabels[1].Text};{TotalLabels[2].Text};{TotalLabels[3].Text};{TotalLabels[4].Text}");
                }

                //Opens a second Writer, which will use the international CSV Convention with Comma
                //as a Separator.
                using (StreamWriter writer = new StreamWriter(
                    dialog.FileName.Replace(".csv", "_Comma.csv"), false, Encoding.UTF8))
                {
                    //The Header for the CSV-File.
                    writer.WriteLine("Model,Purchase,Sale,Volume,Profit");

                    //Iterates over all Components to get their Values and then write these
                    //Values as a single line into the File.
                    for (int i = 1; i <= LIMIT; i++)
                    {
                        //Replaces all ',' with '.', so each Cell can be displayed in the correct Column.
                        String model = ModelLabels[i].Text.Replace(",", ".");
                        String purchase = PurchasePriceTextBoxes[i].Text.Replace(",", ".") + "€";
                        String sale = SalePriceTextBoxes[i].Text.Replace(",", ".") + "€";
                        String volume = VolumeTextBoxes[i].Text.Replace(",", ".");
                        String profit = ProfitLabels[i].Text.Replace(",", ".");

                        //Writes the Line with the given Values.
                        writer.WriteLine($"{model},{purchase},{sale},{volume},{profit}");
                    }
                    //Writes the Last Line as the Total Sums, stored in the TotalLabels-Dictionary.
                    writer.WriteLine($"Total,{TotalLabels[1].Text},{TotalLabels[2].Text},{TotalLabels[3].Text},{TotalLabels[4].Text}");
                }
                //Notifies the User, that the Export was successful. After this, the User is
                //returned to the normal View of Form1.
                MessageBox.Show("Export erfolgreich!");
            }
        }

        /// <summary>
        /// Sets the given row as either active or inactive. After setting the boolean value, 
        /// the Components in the Row are altered, to display the change to the User.
        /// </summary>
        /// <param name="rowIndex">
        /// The Row to be set aseither active or inactive.
        /// </param>
        /// <param name="active">
        /// The boolean Value, if the Row is active or inactive.
        /// </param>
        private void setRowActive(int rowIndex, bool active)
        {
            rowActive[rowIndex] = active;
            if (active)
            {
                SalePriceTextBoxes[rowIndex].BackColor = Color.White;
                SalePriceTextBoxes[rowIndex].BorderStyle = BorderStyle.None;
                PurchasePriceTextBoxes[rowIndex].BackColor = Color.White;
                PurchasePriceTextBoxes[rowIndex].BorderStyle = BorderStyle.None;
                ProfitLabels[rowIndex].ForeColor = Color.Black;
                ModelLabels[rowIndex].ForeColor = Color.Black;
            } else
            {
                SalePriceTextBoxes[rowIndex].BackColor = Color.DarkGray;
                SalePriceTextBoxes[rowIndex].BorderStyle = BorderStyle.Fixed3D;
                PurchasePriceTextBoxes[rowIndex].BackColor = Color.DarkGray;
                PurchasePriceTextBoxes[rowIndex].BorderStyle = BorderStyle.Fixed3D;
                ProfitLabels[rowIndex].ForeColor = Color.Gray;
                ModelLabels[rowIndex].ForeColor = Color.Gray;

            }
        }

        /// <summary>
        /// Called, whenever the Calculate-Button is clicked (or Enter is pressed, since this Button 
        /// is the ACCEPT-Button). Calculates all Results and Sets all Labels to display their 
        /// expected Values.
        /// </summary>
        /// <param name="sender">
        /// The calcButton, that was pressed.
        /// </param>
        /// <param name="e">
        /// All EventArguments for this ClickEvent.
        /// </param>
        private void Click_btCalc(object sender, EventArgs e)
        {
            //Fills the Dictionary, to ensure all Fields are used.
            FillDictionaries();

            //Default Values for all Variables.
            double resPurch = 0;
            double resSale = 0;
            int resVolume = 0;
            //Iterates over all Fields to calculate all needed Sums.
            for (int i = 1; i <= LIMIT; i++)
            {
                //Checks, if the User entered a "x" in the Box. If yes, the Row should be set
                //as inactive, and will be ignored for the Calcuation.
                if (VolumeTextBoxes[i].Text == "x" || VolumeTextBoxes[i].Text == "X")
                {
                    setRowActive(i, false);
                } else
                {
                    setRowActive(i, true);
                    //Replaces all nondigits in the SalePriceTextBox (except '.' and ',')
                    String sale = Regex.Replace(SalePriceTextBoxes[i].Text, @"[^0-9\.,]", "");
                    //Tries to Parse the Input as decimal into valueSale. If it can't be parsed,
                    //0 is used as a default.
                    if (!TryParseFlexibleDecimal(sale, out decimal valueSale))
                    {
                        valueSale = 0;
                    }
                    //Sets the TextBox's Text as the calculated Value, to be transparent to the User,
                    //which value was used for the Calculation. This allows the user to easily identify
                    //incorrect entries. Replaces "." with ",", since the User will most likely be used
                    //to the German Number Formatting.
                    SalePriceTextBoxes[i].Text = ("" + valueSale).Replace(".", ",");

                    //Same as above, just for the PurchasePriceTextBox.
                    String purchase = Regex.Replace(PurchasePriceTextBoxes[i].Text, @"[^0-9\.,]", "");
                    if (!TryParseFlexibleDecimal(purchase, out decimal valuePurch))
                    {
                        valuePurch = 0;
                    }
                    PurchasePriceTextBoxes[i].Text = ("" + valuePurch).Replace(".", ",");

                    //Replaces all nondigits in the VolumeTextBox. This is always an integer, so '.'
                    //and ',' are replaced as well.
                    VolumeTextBoxes[i].Text = Regex.Replace(VolumeTextBoxes[i].Text, @"[^0-9]", "");

                    //Parses the Volume-Text to an Integer. If this fails, 0 is used as a default.
                    if (!int.TryParse(VolumeTextBoxes[i].Text, out int volume))
                    {
                        volume = 0;
                    }

                    //Calculates all Totals up to this Point, by adding the Value of this Iteration to its
                    //current Value. After the Loop has finished, these Variables store the full Total.
                    resVolume += volume;
                    //Since we only use 2 decimal places for the Calc, all other decimal places are cut
                    //off when parsing to double.
                    resSale += double.Parse(valueSale.ToString("0.00")) * volume;
                    resPurch += double.Parse(valuePurch.ToString("0.00")) * volume;

                    //Calculates the total Profit for this Model.
                    decimal totalProfit = (valueSale - valuePurch) * volume;

                    //Sets the ProfitLabel's Text for this Row to the calculated Value.
                    ProfitLabels[i].Text = (totalProfit.ToString("0.00") + " €").Replace(".", ",");
                    //If the Profit is negative, the Profitlabel is displayed in red, so the User can
                    //easily spot bad performing Models to take subsequent Actions. If it is positive,
                    //standard Black is used.
                    if (totalProfit < 0)
                    {
                        ProfitLabels[i].ForeColor = Color.Red;
                    }
                    else
                    {
                        ProfitLabels[i].ForeColor = Color.Black;
                    }
                }
            }

            //Sets all TotalLabels to the Calculated Total Values. Replaces "." with ",", since the
            //Users will most likely be used to the german Number formatting Style.
            TotalLabels[1].Text = resPurch + "€".Replace(".", ",");
            TotalLabels[2].Text = resSale + "€".Replace(".", ",");
            TotalLabels[3].Text = "" + resVolume;
            TotalLabels[4].Text = (((resSale - resPurch)).ToString("0.00") + "€").Replace(".", ",");
            
            //If the Total Profit is negative, the Profitlabel is displayed in red, so the User can
            //easily spot bad performing Models to take subsequent Actions. If it is positive,
            //standard Black is used.
            if (resSale - resPurch < 0)
            {
                TotalLabels[4].ForeColor = Color.Red;
            } else
            {
                TotalLabels[4].ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// A Function, that gets called, whenever the Form is resized. It will calculate the provided Space 
        /// for each Row and Column in our Pseudo-Table Layout.Thus, each Cell gets assigned a new Size and
        /// all Components can be displayed in a given Way.
        /// </summary>
        /// <param name="sender"> 
        /// The Object, this Event was sent from.
        /// </param>
        /// <param name="e">
        /// All EventArguments for this ResizeEvent.
        /// </param>
        private void Form1_Resize(object sender, EventArgs e)
        {
            //Saves the Width and Height of the usable Area for easier Access.
            int newWidth = this.ClientSize.Width;
            int newHeight = this.ClientSize.Height;

            //Clears all Point-Dictionaries, so they can store new Values for each Key.
            colPoints.Clear();
            rowPoints.Clear();
            colTbPoints.Clear();
            rowTbPoints.Clear();

            //Calulates the new Width of each column and uses this Width to calculate the
            //leftmost Point of all columns.
            colWidth = (newWidth - 10) / 6;
            colPoints.Add(1, 5);
            colPoints.Add(2, colPoints[1] + colWidth);
            colPoints.Add(3, colPoints[2] + colWidth);
            colPoints.Add(4, colPoints[3] + colWidth);
            colPoints.Add(5, colPoints[4] + colWidth);
            colPoints.Add(6, colPoints[5] + colWidth);

            /**
             * Calulates the new Height of each row and uses this Height to calculate
             * the topmost Point of all rows.
             */
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

            /**
             * Calculates the needed Padding for all Textboxes, since these have a fixed Size.
             * This is used, to display these Boxes in the Center of each Cell.
             */
            int tbColPadding = (colWidth - TEXTBOX_WIDTH) / 2;
            int tbRowPadding = (rowHeight - TEXTBOX_HEIGHT) / 2;

            /**
             * Sets all TextBox Points to the newly calculated values including the Padding 
             * calculated above.
             */
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

            /** 
             * Calls the Redraw-Function in the Designer, to place all Components at their 
             * new Location in the Form
             */
            RedrawForm();
        }
    }
}
