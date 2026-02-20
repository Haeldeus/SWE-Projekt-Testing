using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing.Text;
using System.Security.Policy;

namespace SWE_Projekt
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Dictionary<int, int> rowPoints = new Dictionary<int, int>();
        private Dictionary<int, int> rowTbPoints = new Dictionary<int, int>();
        private Dictionary<int, int> colPoints = new Dictionary<int, int>();
        private Dictionary<int, int> colTbPoints = new Dictionary<int, int>();

        private int colWidth = 142;
        private int rowHeight = 45;

        private readonly int TEXTBOX_WIDTH = 75;
        private readonly int TEXTBOX_HEIGHT = 23;

        private readonly int MIN_CLIENT_WIDTH = 925;
        private readonly int MIN_CLIENT_HEIGHT = 600;


        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lbModelDesc = new Label();
            tbPurchPrice1 = new TextBox();
            tbPurchPrice2 = new TextBox();
            tbPurchPrice3 = new TextBox();
            tbPurchPrice4 = new TextBox();
            tbPurchPrice5 = new TextBox();
            lbModel1 = new Label();
            lbPPDesc = new Label();
            lbSPDesc = new Label();
            tbSalePrice1 = new TextBox();
            lbProfitDesc = new Label();
            lbProfit1 = new Label();
            lbModel2 = new Label();
            lbVolumeDesc = new Label();
            tbVolume1 = new TextBox();
            lbModel3 = new Label();
            lbModel4 = new Label();
            lbModel5 = new Label();
            lbModel6 = new Label();
            tbPurchPrice6 = new TextBox();
            tbPurchPrice7 = new TextBox();
            tbPurchPrice8 = new TextBox();
            tbPurchPrice9 = new TextBox();
            tbPurchPrice10 = new TextBox();
            lbModel7 = new Label();
            lbModel8 = new Label();
            lbModel9 = new Label();
            lbModel10 = new Label();
            lbTotalDesc = new Label();
            lbTotalPurchPrice = new Label();
            lbTotalSalePrice = new Label();
            lbTotalVolume = new Label();
            lbTotalProfit = new Label();
            tbSalePrice2 = new TextBox();
            tbSalePrice3 = new TextBox();
            tbSalePrice4 = new TextBox();
            tbSalePrice5 = new TextBox();
            tbSalePrice6 = new TextBox();
            tbSalePrice7 = new TextBox();
            tbSalePrice8 = new TextBox();
            tbSalePrice9 = new TextBox();
            tbSalePrice10 = new TextBox();
            tbVolume2 = new TextBox();
            tbVolume3 = new TextBox();
            tbVolume4 = new TextBox();
            tbVolume5 = new TextBox();
            tbVolume6 = new TextBox();
            tbVolume7 = new TextBox();
            tbVolume8 = new TextBox();
            tbVolume9 = new TextBox();
            tbVolume10 = new TextBox();
            lbProfit2 = new Label();
            lbProfit3 = new Label();
            lbProfit4 = new Label();
            lbProfit5 = new Label();
            lbProfit6 = new Label();
            lbProfit7 = new Label();
            lbProfit8 = new Label();
            lbProfit9 = new Label();
            lbProfit10 = new Label();
            btExport = new Button();
            btCalc = new Button();
            btRenameRow1 = new Button();
            btRenameRow2 = new Button();
            btRenameRow3 = new Button();
            btRenameRow4 = new Button();
            btRenameRow5 = new Button();
            btRenameRow6 = new Button();
            btRenameRow7 = new Button();
            btRenameRow8 = new Button();
            btRenameRow9 = new Button();
            btRenameRow10 = new Button();
            SuspendLayout();


            // 
            // lbModelDesc
            //
            lbModelDesc.Font = new Font("Segoe UI", 13F);
            lbModelDesc.Name = "lbModelDesc";
            lbModelDesc.Text = "Modelle";
            lbModelDesc.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbModel1
            // 
            lbModel1.Name = "lbModel1";
            lbModel1.Font = new Font("Segoe UI", 10);
            lbModel1.Text = "CityCruiser 3000";
            lbModel1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbModel2
            // 
            lbModel2.Name = "lbModel2";
            lbModel2.Font = new Font("Segoe UI", 10);
            lbModel2.Text = "MountainPeak X5";
            lbModel2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbModel3
            // 
            lbModel3.Name = "lbModel3";
            lbModel3.Font = new Font("Segoe UI", 10);
            lbModel3.Text = "RoadRunner Pro";
            lbModel3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbModel4
            // 
            lbModel4.Name = "lbModel4";
            lbModel4.Font = new Font("Segoe UI", 10);
            lbModel4.Text = "EcoRide E-City";
            lbModel4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbModel5
            // 
            lbModel5.Name = "lbModel5";
            lbModel5.Font = new Font("Segoe UI", 10);
            lbModel5.Text = "TrailBlazer Junior";
            lbModel5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbModel6
            // 
            lbModel6.Name = "lbModel6";
            lbModel6.Font = new Font("Segoe UI", 10);
            lbModel6.Text = "UrbanFold Flex";
            lbModel6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbModel7
            // 
            lbModel7.Name = "lbModel7";
            lbModel7.Font = new Font("Segoe UI", 10);
            lbModel7.Text = "GravelExplorer 700";
            lbModel7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbModel8
            // 
            lbModel8.Name = "lbModel8";
            lbModel8.Font = new Font("Segoe UI", 10);
            lbModel8.Text = "CargoMax Transport";
            lbModel8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbModel9
            // 
            lbModel9.Name = "lbModel9";
            lbModel9.Font = new Font("Segoe UI", 10);
            lbModel9.Text = "TourMaster LX";
            lbModel9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbModel10
            // 
            lbModel10.Name = "lbModel10";
            lbModel10.Font = new Font("Segoe UI", 10);
            lbModel10.Text = "SpeedFix One";
            lbModel10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbPPDesc
            // 
            lbPPDesc.Font = new Font("Segoe UI", 13F);
            lbPPDesc.Name = "lbPPDesc";
            lbPPDesc.Text = "Einkaufspreis in €";
            lbPPDesc.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbPurchPrice1
            // 
            tbPurchPrice1.Name = "tbPurchPrice1";
            tbPurchPrice1.TabIndex = 1;
            tbPurchPrice1.Text = "300";
            // 
            // tbPurchPrice2
            // 
            tbPurchPrice2.Name = "tbPurchPrice2";
            tbPurchPrice2.TabIndex = 2;
            tbPurchPrice2.Text = "450";
            // 
            // tbPurchPrice3
            // 
            tbPurchPrice3.Name = "tbPurchPrice3";
            tbPurchPrice3.TabIndex = 3;
            tbPurchPrice3.Text = "550";
            // 
            // tbPurchPrice4
            // 
            tbPurchPrice4.Name = "tbPurchPrice4";
            tbPurchPrice4.TabIndex = 4;
            tbPurchPrice4.Text = "800";
            // 
            // tbPurchPrice5
            // 
            tbPurchPrice5.Name = "tbPurchPrice5";
            tbPurchPrice5.TabIndex = 5;
            tbPurchPrice5.Text = "200";
            // 
            // tbPurchPrice6
            // 
            tbPurchPrice6.Name = "tbPurchPrice6";
            tbPurchPrice6.TabIndex = 6;
            tbPurchPrice6.Text = "250";
            // 
            // tbPurchPrice7
            // 
            tbPurchPrice7.Name = "tbPurchPrice7";
            tbPurchPrice7.TabIndex = 7;
            tbPurchPrice7.Text = "500";
            // 
            // tbPurchPrice8
            // 
            tbPurchPrice8.Name = "tbPurchPrice8";
            tbPurchPrice8.TabIndex = 8;
            tbPurchPrice8.Text = "600";
            // 
            // tbPurchPrice9
            // 
            tbPurchPrice9.Name = "tbPurchPrice9";
            tbPurchPrice9.TabIndex = 9;
            tbPurchPrice9.Text = "400";
            // 
            // tbPurchPrice10
            // 
            tbPurchPrice10.Name = "tbPurchPrice10";
            tbPurchPrice10.TabIndex = 10;
            tbPurchPrice10.Text = "220";
            // 
            // lbSPDesc
            // 
            lbSPDesc.Font = new Font("Segoe UI", 13F);
            lbSPDesc.Name = "lbSPDesc";
            lbSPDesc.Text = "Verkaufspreis in €";
            lbSPDesc.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbSalePrice1
            // 
            tbSalePrice1.Name = "tbSalePrice1";
            tbSalePrice1.TabIndex = 11;
            tbSalePrice1.Text = "499";
            // 
            // tbSalePrice2
            // 
            tbSalePrice2.Name = "tbSalePrice2";
            tbSalePrice2.TabIndex = 12;
            tbSalePrice2.Text = "799";
            // 
            // tbSalePrice3
            // 
            tbSalePrice3.Name = "tbSalePrice3";
            tbSalePrice3.TabIndex = 13;
            tbSalePrice3.Text = "999";
            // 
            // tbSalePrice4
            // 
            tbSalePrice4.Name = "tbSalePrice4";
            tbSalePrice4.TabIndex = 14;
            tbSalePrice4.Text = "1499";
            // 
            // tbSalePrice5
            // 
            tbSalePrice5.Name = "tbSalePrice5";
            tbSalePrice5.TabIndex = 15;
            tbSalePrice5.Text = "349";
            // 
            // tbSalePrice6
            // 
            tbSalePrice6.Name = "tbSalePrice6";
            tbSalePrice6.TabIndex = 16;
            tbSalePrice6.Text = "449";
            // 
            // tbSalePrice7
            // 
            tbSalePrice7.Name = "tbSalePrice7";
            tbSalePrice7.TabIndex = 17;
            tbSalePrice7.Text = "899";
            // 
            // tbSalePrice8
            // 
            tbSalePrice8.Name = "tbSalePrice8";
            tbSalePrice8.TabIndex = 18;
            tbSalePrice8.Text = "1099";
            // 
            // tbSalePrice9
            // 
            tbSalePrice9.Name = "tbSalePrice9";
            tbSalePrice9.TabIndex = 19;
            tbSalePrice9.Text = "749";
            // 
            // tbSalePrice10
            // 
            tbSalePrice10.Name = "tbSalePrice10";
            tbSalePrice10.TabIndex = 20;
            tbSalePrice10.Text = "399";
            // 
            // lbVolumeDesc
            // 
            lbVolumeDesc.Font = new Font("Segoe UI", 13F);
            lbVolumeDesc.Name = "lbVolumeDesc";
            lbVolumeDesc.Text = "Menge";
            lbVolumeDesc.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbVolume1
            // 
            tbVolume1.Name = "tbVolume1";
            tbVolume1.TabIndex = 21;
            tbVolume1.Text = "1";
            // 
            // tbVolume2
            // 
            tbVolume2.Name = "tbVolume2";
            tbVolume2.TabIndex = 22;
            tbVolume2.Text = "1";
            // 
            // tbVolume3
            // 
            tbVolume3.Name = "tbVolume3";
            tbVolume3.TabIndex = 23;
            tbVolume3.Text = "1";
            // 
            // tbVolume4
            // 
            tbVolume4.Name = "tbVolume4";
            tbVolume4.TabIndex = 24;
            tbVolume4.Text = "1";
            // 
            // tbVolume5
            // 
            tbVolume5.Name = "tbVolume5";
            tbVolume5.TabIndex = 25;
            tbVolume5.Text = "1";
            // 
            // tbVolume6
            // 
            tbVolume6.Name = "tbVolume6";
            tbVolume6.TabIndex = 26;
            tbVolume6.Text = "1";
            // 
            // tbVolume7
            // 
            tbVolume7.Name = "tbVolume7";
            tbVolume7.TabIndex = 27;
            tbVolume7.Text = "1";
            // 
            // tbVolume8
            // 
            tbVolume8.Name = "tbVolume8";
            tbVolume8.TabIndex = 28;
            tbVolume8.Text = "1";
            // 
            // tbVolume9
            // 
            tbVolume9.Name = "tbVolume9";
            tbVolume9.TabIndex = 29;
            tbVolume9.Text = "1";
            // 
            // tbVolume10
            // 
            tbVolume10.Name = "tbVolume10";
            tbVolume10.TabIndex = 30;
            tbVolume10.Text = "1";
            // 
            // lbProfitDesc
            // 
            lbProfitDesc.Font = new Font("Segoe UI", 13F);
            lbProfitDesc.Name = "lbProfitDesc";
            lbProfitDesc.Text = "Gewinn";
            lbProfitDesc.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbProfit1
            // 
            lbProfit1.Font = new Font("Segoe UI", 11F);
            lbProfit1.Name = "lbProfit1";
            lbProfit1.Text = "0€";
            lbProfit1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbProfit2
            // 
            lbProfit2.Font = new Font("Segoe UI", 11F);
            lbProfit2.Name = "lbProfit2";
            lbProfit2.Text = "0€";
            lbProfit2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbProfit3
            // 
            lbProfit3.Font = new Font("Segoe UI", 11F);
            lbProfit3.Name = "lbProfit3";
            lbProfit3.Text = "0€";
            lbProfit3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbProfit4
            // 
            lbProfit4.Font = new Font("Segoe UI", 11F);
            lbProfit4.Name = "lbProfit4";
            lbProfit4.Text = "0€";
            lbProfit4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbProfit5
            // 
            lbProfit5.Font = new Font("Segoe UI", 11F);
            lbProfit5.Name = "lbProfit5";
            lbProfit5.Text = "0€";
            lbProfit5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbProfit6
            // 
            lbProfit6.Font = new Font("Segoe UI", 11F);
            lbProfit6.Name = "lbProfit6";
            lbProfit6.Text = "0€";
            lbProfit6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbProfit7
            // 
            lbProfit7.Font = new Font("Segoe UI", 11F);
            lbProfit7.Name = "lbProfit7";
            lbProfit7.Text = "0€";
            lbProfit7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbProfit8
            // 
            lbProfit8.Font = new Font("Segoe UI", 11F);
            lbProfit8.Name = "lbProfit8";
            lbProfit8.Text = "0€";
            lbProfit8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbProfit9
            // 
            lbProfit9.Font = new Font("Segoe UI", 11F);
            lbProfit9.Name = "lbProfit9";
            lbProfit9.Text = "0€";
            lbProfit9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbProfit10
            // 
            lbProfit10.Font = new Font("Segoe UI", 11F);
            lbProfit10.Name = "lbProfit10";
            lbProfit10.Text = "0€";
            lbProfit10.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // btRenameRow1
            // 
            btRenameRow1.Name = "btRenameRow1";
            btRenameRow1.Font = new Font("Segoe UI", 9);
            btRenameRow1.UseVisualStyleBackColor = true;
            btRenameRow1.Text = "Umbenennen";
            btRenameRow1.Click += Click_btRename;
            btRenameRow1.TabStop = false;
            // 
            // btRenameRow2
            // 
            btRenameRow2.Name = "btRenameRow2";
            btRenameRow2.Font = new Font("Segoe UI", 9);
            btRenameRow2.UseVisualStyleBackColor = true;
            btRenameRow2.Text = "Umbenennen";
            btRenameRow2.Click += Click_btRename;
            btRenameRow2.TabStop = false;
            // 
            // btRenameRow3
            // 
            btRenameRow3.Name = "btRenameRow3";
            btRenameRow3.Font = new Font("Segoe UI", 9);
            btRenameRow3.UseVisualStyleBackColor = true;
            btRenameRow3.Text = "Umbenennen";
            btRenameRow3.Click += Click_btRename;
            btRenameRow3.TabStop = false;
            // 
            // btRenameRow4
            // 
            btRenameRow4.Name = "btRenameRow4";
            btRenameRow4.Text = "Umbenennen";
            btRenameRow4.Font = new Font("Segoe UI", 9);
            btRenameRow4.UseVisualStyleBackColor = true;
            btRenameRow4.Click += Click_btRename;
            btRenameRow4.TabStop = false;
            // 
            // btRenameRow5
            // 
            btRenameRow5.Name = "btRenameRow5";
            btRenameRow5.Text = "Umbenennen";
            btRenameRow5.Font = new Font("Segoe UI", 9);
            btRenameRow5.UseVisualStyleBackColor = true;
            btRenameRow5.Click += Click_btRename;
            btRenameRow5.TabStop = false;
            // 
            // btRenameRow6
            // 
            btRenameRow6.Name = "btRenameRow6";
            btRenameRow6.Text = "Umbenennen";
            btRenameRow6.Font = new Font("Segoe UI", 9);
            btRenameRow6.UseVisualStyleBackColor = true;
            btRenameRow6.Click += Click_btRename;
            btRenameRow6.TabStop = false;
            // 
            // btRenameRow7
            // 
            btRenameRow7.Name = "btRenameRow7";
            btRenameRow7.Text = "Umbenennen";
            btRenameRow7.Font = new Font("Segoe UI", 9);
            btRenameRow7.UseVisualStyleBackColor = true;
            btRenameRow7.Click += Click_btRename;
            btRenameRow7.TabStop = false;
            // 
            // btRenameRow8
            // 
            btRenameRow8.Name = "btRenameRow8";
            btRenameRow8.Text = "Umbenennen";
            btRenameRow8.Font = new Font("Segoe UI", 9);
            btRenameRow8.UseVisualStyleBackColor = true;
            btRenameRow8.Click += Click_btRename;
            btRenameRow8.TabStop = false;
            // 
            // btRenameRow9
            // 
            btRenameRow9.Name = "btRenameRow9";
            btRenameRow9.Text = "Umbenennen";
            btRenameRow9.Font = new Font("Segoe UI", 9);
            btRenameRow9.UseVisualStyleBackColor = true;
            btRenameRow9.Click += Click_btRename;
            btRenameRow9.TabStop = false;
            // 
            // btRenameRow10
            // 
            btRenameRow10.Name = "btRenameRow10";
            btRenameRow10.Text = "Umbenennen";
            btRenameRow10.Font = new Font("Segoe UI", 9);
            btRenameRow10.UseVisualStyleBackColor = true;
            btRenameRow10.Click += Click_btRename;
            btRenameRow10.TabStop = false;
            // 
            // lbTotalDesc
            // 
            lbTotalDesc.Font = new Font("Segoe UI", 12F);
            lbTotalDesc.Name = "lbTotalDesc";
            lbTotalDesc.Text = "Gesamtposten";
            lbTotalDesc.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbTotalPurchPrice
            // 
            lbTotalPurchPrice.Font = new Font("Segoe UI", 12F);
            lbTotalPurchPrice.Name = "lbTotalPurchPrice";
            lbTotalPurchPrice.Text = "0€";
            lbTotalPurchPrice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbTotalSalePrice
            // 
            lbTotalSalePrice.Font = new Font("Segoe UI", 12F);
            lbTotalSalePrice.Name = "lbTotalSalePrice";
            lbTotalSalePrice.Text = "0€";
            lbTotalSalePrice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbTotalVolume
            // 
            lbTotalVolume.Font = new Font("Segoe UI", 12F);
            lbTotalVolume.Name = "lbTotalVolume";
            lbTotalVolume.Text = "0";
            lbTotalVolume.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbTotalProfit
            // 
            lbTotalProfit.Font = new Font("Segoe UI", 13F);
            lbTotalProfit.Name = "lbTotalProfit";
            lbTotalProfit.Text = "0€";
            lbTotalProfit.TextAlign = ContentAlignment.MiddleCenter;
            //
            // btExport
            //
            btExport.BackColor = SystemColors.ButtonFace;
            btExport.Name = "btExport";
            btExport.Text = "Export...";
            btExport.UseVisualStyleBackColor = false;
            btExport.Click += Click_btExport;
            btExport.TabStop = false;
            // 
            // btCalc
            // 
            btCalc.BackColor = SystemColors.ButtonFace;
            btCalc.Name = "btCalc";
            btCalc.Text = "Berechnen";
            btCalc.UseVisualStyleBackColor = false;
            btCalc.Click += Click_btCalc;
            btCalc.TabStop = false;
            AcceptButton = btCalc;

            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(925, 600);

            //Sets a Minimum Size, to ensure that all Components are fully displayed at all Times
            int extraWidth = this.Width - this.ClientSize.Width;
            int extraHeight = this.Height - this.ClientSize.Height;
            this.MinimumSize = new Size(MIN_CLIENT_WIDTH + extraWidth, MIN_CLIENT_HEIGHT + extraHeight);
            //Calls Resize(), to place all Components in the Form.
            Form1_Resize(this, new EventArgs());

            Controls.Add(btRenameRow10);
            Controls.Add(btRenameRow9);
            Controls.Add(btRenameRow8);
            Controls.Add(btRenameRow7);
            Controls.Add(btRenameRow6);
            Controls.Add(btRenameRow5);
            Controls.Add(btRenameRow4);
            Controls.Add(btRenameRow3);
            Controls.Add(btRenameRow2);
            Controls.Add(btRenameRow1);
            Controls.Add(btExport);
            Controls.Add(btCalc);
            Controls.Add(lbProfit10);
            Controls.Add(lbProfit9);
            Controls.Add(lbProfit8);
            Controls.Add(lbProfit7);
            Controls.Add(lbProfit6);
            Controls.Add(lbProfit5);
            Controls.Add(lbProfit4);
            Controls.Add(lbProfit3);
            Controls.Add(lbProfit2);
            Controls.Add(tbVolume10);
            Controls.Add(tbVolume9);
            Controls.Add(tbVolume8);
            Controls.Add(tbVolume7);
            Controls.Add(tbVolume6);
            Controls.Add(tbVolume5);
            Controls.Add(tbVolume4);
            Controls.Add(tbVolume3);
            Controls.Add(tbVolume2);
            Controls.Add(tbSalePrice10);
            Controls.Add(tbSalePrice9);
            Controls.Add(tbSalePrice8);
            Controls.Add(tbSalePrice7);
            Controls.Add(tbSalePrice6);
            Controls.Add(tbSalePrice5);
            Controls.Add(tbSalePrice4);
            Controls.Add(tbSalePrice3);
            Controls.Add(tbSalePrice2);
            Controls.Add(lbTotalProfit);
            Controls.Add(lbTotalVolume);
            Controls.Add(lbTotalSalePrice);
            Controls.Add(lbTotalPurchPrice);
            Controls.Add(lbTotalDesc);
            Controls.Add(lbModel10);
            Controls.Add(lbModel9);
            Controls.Add(lbModel8);
            Controls.Add(lbModel7);
            Controls.Add(tbPurchPrice10);
            Controls.Add(tbPurchPrice9);
            Controls.Add(tbPurchPrice8);
            Controls.Add(tbPurchPrice7);
            Controls.Add(tbPurchPrice6);
            Controls.Add(lbModel6);
            Controls.Add(lbModel5);
            Controls.Add(lbModel4);
            Controls.Add(lbModel3);
            Controls.Add(tbVolume1);
            Controls.Add(lbVolumeDesc);
            Controls.Add(lbModel2);
            Controls.Add(lbProfit1);
            Controls.Add(lbProfitDesc);
            Controls.Add(tbSalePrice1);
            Controls.Add(lbSPDesc);
            Controls.Add(lbPPDesc);
            Controls.Add(lbModel1);
            Controls.Add(tbPurchPrice5);
            Controls.Add(tbPurchPrice4);
            Controls.Add(tbPurchPrice3);
            Controls.Add(tbPurchPrice2);
            Controls.Add(tbPurchPrice1);
            Controls.Add(lbModelDesc);
            Name = "Form1";
            Text = "Umsatzrechner";
            Resize += Form1_Resize;
            ResumeLayout(false);
            PerformLayout();
        }

        /// <summary>
        ///  Redraws the Form, to ensure the right Design is used, whenever the Form is Resized. 
        ///  Thus, the initial Design will be used at all Sizes.To minimize Comment-Overflow,
        ///  only the first Variant of all Components will be described.All other Components 
        ///  are virtually the same, only at another Position.
        /// </summary>
        private void RedrawForm()
        {
            /**
             * Places the Model-Labels in the First Column, with it's Description Label in the First Row
             */
            lbModelDesc.Location = new Point(colPoints[1], rowPoints[1]);
            lbModelDesc.Size = new Size(colWidth, rowHeight);

            lbModel1.Location = new Point(colPoints[1], rowPoints[2]);
            lbModel1.Size = new Size(colWidth, rowHeight);

            lbModel2.Location = new Point(colPoints[1], rowPoints[3]);
            lbModel2.Size = new Size(colWidth, rowHeight);

            lbModel3.Location = new Point(colPoints[1], rowPoints[4]);
            lbModel3.Size = new Size(colWidth, rowHeight);

            lbModel4.Location = new Point(colPoints[1], rowPoints[5]);
            lbModel4.Size = new Size(colWidth, rowHeight);

            lbModel5.Location = new Point(colPoints[1], rowPoints[6]);
            lbModel5.Size = new Size(colWidth, rowHeight);

            lbModel6.Location = new Point(colPoints[1], rowPoints[7]);
            lbModel6.Size = new Size(colWidth, rowHeight);

            lbModel7.Location = new Point(colPoints[1], rowPoints[8]);
            lbModel7.Size = new Size(colWidth, rowHeight);

            lbModel8.Location = new Point(colPoints[1], rowPoints[9]);
            lbModel8.Size = new Size(colWidth, rowHeight);

            lbModel9.Location = new Point(colPoints[1], rowPoints[10]);
            lbModel9.Size = new Size(colWidth, rowHeight);

            lbModel10.Location = new Point(colPoints[1], rowPoints[11]);
            lbModel10.Size = new Size(colWidth, rowHeight);

            /**
             * Places the Total-Label at the Bottom of the Column.
             */
            lbTotalDesc.Location = new Point(colPoints[1], rowPoints[13]);
            lbTotalDesc.Size = new Size(colWidth, rowHeight);

            /**
             * Places the Model-Labels in the First Column, with it's Description Label in the First Row
             */
            lbPPDesc.Location = new Point(colPoints[2], rowPoints[1]);
            lbPPDesc.Size = new Size(colWidth, rowHeight);

            tbPurchPrice1.Location = new Point(colTbPoints[2], rowTbPoints[2]);
            tbPurchPrice1.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);

            tbPurchPrice2.Location = new Point(colTbPoints[2], rowTbPoints[3]);
            tbPurchPrice2.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);

            tbPurchPrice3.Location = new Point(colTbPoints[2], rowTbPoints[4]);
            tbPurchPrice3.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);

            tbPurchPrice4.Location = new Point(colTbPoints[2], rowTbPoints[5]);
            tbPurchPrice4.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);

            tbPurchPrice5.Location = new Point(colTbPoints[2], rowTbPoints[6]);
            tbPurchPrice5.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);

            tbPurchPrice6.Location = new Point(colTbPoints[2], rowTbPoints[7]);
            tbPurchPrice6.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);

            tbPurchPrice7.Location = new Point(colTbPoints[2], rowTbPoints[8]);
            tbPurchPrice7.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);

            tbPurchPrice8.Location = new Point(colTbPoints[2], rowTbPoints[9]);
            tbPurchPrice8.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);

            tbPurchPrice9.Location = new Point(colTbPoints[2], rowTbPoints[10]);
            tbPurchPrice9.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);

            tbPurchPrice10.Location = new Point(colTbPoints[2], rowTbPoints[11]);
            tbPurchPrice10.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);

            lbTotalPurchPrice.Location = new Point(colPoints[2], rowPoints[13]);
            lbTotalPurchPrice.Size = new Size(colWidth, rowHeight);

            lbSPDesc.Location = new Point(colPoints[3], rowPoints[1]);
            lbSPDesc.Size = new Size(colWidth, rowHeight);

            tbSalePrice1.Location = new Point(colTbPoints[3], rowTbPoints[2]);
            tbSalePrice1.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);

            tbSalePrice2.Location = new Point(colTbPoints[3], rowTbPoints[3]);
            tbSalePrice2.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);

            tbSalePrice3.Location = new Point(colTbPoints[3], rowTbPoints[4]);
            tbSalePrice3.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);

            tbSalePrice4.Location = new Point(colTbPoints[3], rowTbPoints[5]);
            tbSalePrice4.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);

            tbSalePrice5.Location = new Point(colTbPoints[3], rowTbPoints[6]);
            tbSalePrice5.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);

            tbSalePrice6.Location = new Point(colTbPoints[3], rowTbPoints[7]);
            tbSalePrice6.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);

            tbSalePrice7.Location = new Point(colTbPoints[3], rowTbPoints[8]);
            tbSalePrice7.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);

            tbSalePrice8.Location = new Point(colTbPoints[3], rowTbPoints[9]);
            tbSalePrice8.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);

            tbSalePrice9.Location = new Point(colTbPoints[3], rowTbPoints[10]);
            tbSalePrice9.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);

            tbSalePrice10.Location = new Point(colTbPoints[3], rowTbPoints[11]);
            tbSalePrice10.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);

            lbTotalSalePrice.Location = new Point(colPoints[3], rowPoints[13]);
            lbTotalSalePrice.Size = new Size(colWidth, rowHeight);

            lbVolumeDesc.Location = new Point(colPoints[4], rowPoints[1]);
            lbVolumeDesc.Size = new Size(colWidth, rowHeight);

            tbVolume1.Location = new Point(colTbPoints[4], rowTbPoints[2]);
            tbVolume1.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);

            tbVolume2.Location = new Point(colTbPoints[4], rowTbPoints[3]);
            tbVolume2.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);

            tbVolume3.Location = new Point(colTbPoints[4], rowTbPoints[4]);
            tbVolume3.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);

            tbVolume4.Location = new Point(colTbPoints[4], rowTbPoints[5]);
            tbVolume4.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);

            tbVolume5.Location = new Point(colTbPoints[4], rowTbPoints[6]);
            tbVolume5.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);

            tbVolume6.Location = new Point(colTbPoints[4], rowTbPoints[7]);
            tbVolume6.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);

            tbVolume7.Location = new Point(colTbPoints[4], rowTbPoints[8]);
            tbVolume7.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);

            tbVolume8.Location = new Point(colTbPoints[4], rowTbPoints[9]);
            tbVolume8.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);

            tbVolume9.Location = new Point(colTbPoints[4], rowTbPoints[10]);
            tbVolume9.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);

            tbVolume10.Location = new Point(colTbPoints[4], rowTbPoints[11]);
            tbVolume10.Size = new Size(TEXTBOX_WIDTH, TEXTBOX_HEIGHT);

            lbTotalVolume.Location = new Point(colPoints[4], rowPoints[13]);
            lbTotalVolume.Size = new Size(colWidth, rowHeight);

            lbProfitDesc.Location = new Point(colPoints[5], rowPoints[1]);
            lbProfitDesc.Size = new Size(colWidth, rowHeight);

            lbProfit1.Location = new Point(colPoints[5], rowPoints[2]);
            lbProfit1.Size = new Size(colWidth, rowHeight);

            lbProfit2.Location = new Point(colPoints[5], rowPoints[3]);
            lbProfit2.Size = new Size(colWidth, rowHeight);

            lbProfit3.Location = new Point(colPoints[5], rowPoints[4]);
            lbProfit3.Size = new Size(colWidth, rowHeight);

            lbProfit4.Location = new Point(colPoints[5], rowPoints[5]);
            lbProfit4.Size = new Size(colWidth, rowHeight);

            lbProfit5.Location = new Point(colPoints[5], rowPoints[6]);
            lbProfit5.Size = new Size(colWidth, rowHeight);

            lbProfit6.Location = new Point(colPoints[5], rowPoints[7]);
            lbProfit6.Size = new Size(colWidth, rowHeight);

            lbProfit7.Location = new Point(colPoints[5], rowPoints[8]);
            lbProfit7.Size = new Size(colWidth, rowHeight);

            lbProfit8.Location = new Point(colPoints[5], rowPoints[9]);
            lbProfit8.Size = new Size(colWidth, rowHeight);

            lbProfit9.Location = new Point(colPoints[5], rowPoints[10]);
            lbProfit9.Size = new Size(colWidth, rowHeight);

            lbProfit10.Location = new Point(colPoints[5], rowPoints[11]);
            lbProfit10.Size = new Size(colWidth, rowHeight);

            lbTotalProfit.Location = new Point(colPoints[5], rowPoints[13]);
            lbTotalProfit.Size = new Size(colWidth, rowHeight);

            btRenameRow1.Location = new Point(colPoints[6] - 10, rowTbPoints[2]);
            btRenameRow1.Size = new Size((int)(colWidth*0.7), TEXTBOX_HEIGHT);

            btRenameRow2.Location = new Point(colPoints[6] - 10, rowTbPoints[3]);
            btRenameRow2.Size = new Size((int)(colWidth * 0.7), TEXTBOX_HEIGHT);

            btRenameRow3.Location = new Point(colPoints[6] - 10, rowTbPoints[4]);
            btRenameRow3.Size = new Size((int)(colWidth * 0.7), TEXTBOX_HEIGHT);

            btRenameRow4.Location = new Point(colPoints[6] - 10, rowTbPoints[5]);
            btRenameRow4.Size = new Size((int)(colWidth * 0.7), TEXTBOX_HEIGHT);

            btRenameRow5.Location = new Point(colPoints[6] - 10, rowTbPoints[6]);
            btRenameRow5.Size = new Size((int)(colWidth * 0.7), TEXTBOX_HEIGHT);

            btRenameRow6.Location = new Point(colPoints[6] - 10, rowTbPoints[7]);
            btRenameRow6.Size = new Size((int)(colWidth * 0.7), TEXTBOX_HEIGHT);

            btRenameRow7.Location = new Point(colPoints[6] - 10, rowTbPoints[8]);
            btRenameRow7.Size = new Size((int)(colWidth * 0.7), TEXTBOX_HEIGHT);

            btRenameRow8.Location = new Point(colPoints[6] - 10, rowTbPoints[9]);
            btRenameRow8.Size = new Size((int)(colWidth * 0.7), TEXTBOX_HEIGHT);

            btRenameRow9.Location = new Point(colPoints[6] - 10, rowTbPoints[10]);
            btRenameRow9.Size = new Size((int)(colWidth * 0.7), TEXTBOX_HEIGHT);

            btRenameRow10.Location = new Point(colPoints[6] - 10, rowTbPoints[11]);
            btRenameRow10.Size = new Size((int)(colWidth * 0.7), TEXTBOX_HEIGHT);

            btExport.Location = new Point(colPoints[6] - 10, rowTbPoints[12]);
            btExport.Size = new Size((int)(colWidth * 0.7), TEXTBOX_HEIGHT);

            btCalc.Location = new Point(colPoints[6] - 10, rowTbPoints[13]);
            btCalc.Size = new Size((int)(colWidth * 0.7), TEXTBOX_HEIGHT);
        }

        #endregion
        private Label lbModelDesc;
        private TextBox tbPurchPrice1;
        private TextBox tbPurchPrice2;
        private TextBox tbPurchPrice3;
        private TextBox tbPurchPrice4;
        private TextBox tbPurchPrice5;
        private Label lbModel1;
        private Label lbPPDesc;
        private Label lbSPDesc;
        private TextBox tbSalePrice1;
        private Label lbProfitDesc;
        private Label lbProfit1;
        private Label lbModel2;
        private Label lbVolumeDesc;
        private TextBox tbVolume1;
        private Label lbModel3;
        private Label lbModel4;
        private Label lbModel5;
        private Label lbModel6;
        private TextBox tbPurchPrice6;
        private TextBox tbPurchPrice7;
        private TextBox tbPurchPrice8;
        private TextBox tbPurchPrice9;
        private TextBox tbPurchPrice10;
        private Label lbModel7;
        private Label lbModel8;
        private Label lbModel9;
        private Label lbModel10;
        private Label lbTotalDesc;
        private Label lbTotalPurchPrice;
        private Label lbTotalSalePrice;
        private Label lbTotalVolume;
        private Label lbTotalProfit;
        private TextBox tbSalePrice2;
        private TextBox tbSalePrice3;
        private TextBox tbSalePrice4;
        private TextBox tbSalePrice5;
        private TextBox tbSalePrice6;
        private TextBox tbSalePrice7;
        private TextBox tbSalePrice8;
        private TextBox tbSalePrice9;
        private TextBox tbSalePrice10;
        private TextBox tbVolume2;
        private TextBox tbVolume3;
        private TextBox tbVolume4;
        private TextBox tbVolume5;
        private TextBox tbVolume6;
        private TextBox tbVolume7;
        private TextBox tbVolume8;
        private TextBox tbVolume9;
        private TextBox tbVolume10;
        private Label lbProfit2;
        private Label lbProfit3;
        private Label lbProfit4;
        private Label lbProfit5;
        private Label lbProfit6;
        private Label lbProfit7;
        private Label lbProfit8;
        private Label lbProfit9;
        private Label lbProfit10;
        private Button btCalc;
        private Button btExport;
        private Button btRenameRow1;
        private Button btRenameRow2;
        private Button btRenameRow3;
        private Button btRenameRow4;
        private Button btRenameRow5;
        private Button btRenameRow6;
        private Button btRenameRow7;
        private Button btRenameRow8;
        private Button btRenameRow9;
        private Button btRenameRow10;
    }
}
