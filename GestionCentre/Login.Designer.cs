namespace GestionCentre
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.bunifuDragControl1 = new ns1.BunifuDragControl(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.Lbl_Form1_NameHeader = new System.Windows.Forms.Label();
            this.bunifuImageButton1 = new ns1.BunifuImageButton();
            this.BTN_Login_Close = new ns1.BunifuImageButton();
            this.bunifuMetroTextbox1 = new ns1.BunifuMetroTextbox();
            this.bunifuMetroTextbox2 = new ns1.BunifuMetroTextbox();
            this.label3 = new System.Windows.Forms.Label();
            this.LBL_Login_Id = new System.Windows.Forms.Label();
            this.BTN_Login_Connecter = new ns1.BunifuThinButton2();
            this.Tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.LBL_Login_MotDePasseOublie = new ns1.BunifuCustomLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BIB_Oubliemp_Retour = new ns1.BunifuImageButton();
            this.BTN_MotDePasseOublie_Ok = new ns1.BunifuThinButton2();
            this.TXB_MotDePasseOublie_Reponse = new ns1.BunifuMetroTextbox();
            this.LBL_MotDePasseOublie_Question = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.BIB_Modifiermp_Retour = new ns1.BunifuImageButton();
            this.BTN_ModifierMotPass_Connecter = new ns1.BunifuThinButton2();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TXB_Mmp_nouveumotpasse = new ns1.BunifuMetroTextbox();
            this.TXB_Mmp_Confirmémotpasse = new ns1.BunifuMetroTextbox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTN_Login_Close)).BeginInit();
            this.Tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BIB_Oubliemp_Retour)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BIB_Modifiermp_Retour)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panel1;
            this.bunifuDragControl1.Vertical = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Lbl_Form1_NameHeader);
            this.panel1.Controls.Add(this.bunifuImageButton1);
            this.panel1.Controls.Add(this.BTN_Login_Close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 55);
            this.panel1.TabIndex = 3;
            // 
            // Lbl_Form1_NameHeader
            // 
            this.Lbl_Form1_NameHeader.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Form1_NameHeader.ForeColor = System.Drawing.Color.White;
            this.Lbl_Form1_NameHeader.Location = new System.Drawing.Point(67, 5);
            this.Lbl_Form1_NameHeader.Name = "Lbl_Form1_NameHeader";
            this.Lbl_Form1_NameHeader.Size = new System.Drawing.Size(114, 44);
            this.Lbl_Form1_NameHeader.TabIndex = 3;
            this.Lbl_Form1_NameHeader.Text = "Connecter";
            this.Lbl_Form1_NameHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton1.Image")));
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(14, 9);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(36, 36);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 2;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 10;
            this.bunifuImageButton1.Click += new System.EventHandler(this.BTN_Login_Close_Click);
            // 
            // BTN_Login_Close
            // 
            this.BTN_Login_Close.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Login_Close.Image = global::GestionCentre.Properties.Resources.VisualEditor___Icon___Close___white_svg;
            this.BTN_Login_Close.ImageActive = null;
            this.BTN_Login_Close.Location = new System.Drawing.Point(626, 9);
            this.BTN_Login_Close.Name = "BTN_Login_Close";
            this.BTN_Login_Close.Size = new System.Drawing.Size(36, 36);
            this.BTN_Login_Close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BTN_Login_Close.TabIndex = 2;
            this.BTN_Login_Close.TabStop = false;
            this.BTN_Login_Close.Zoom = 10;
            this.BTN_Login_Close.Click += new System.EventHandler(this.BTN_Login_Close_Click);
            // 
            // bunifuMetroTextbox1
            // 
            this.bunifuMetroTextbox1.BorderColorFocused = System.Drawing.Color.Aqua;
            this.bunifuMetroTextbox1.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuMetroTextbox1.BorderColorMouseHover = System.Drawing.Color.Aqua;
            this.bunifuMetroTextbox1.BorderThickness = 1;
            this.bunifuMetroTextbox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuMetroTextbox1.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.bunifuMetroTextbox1.ForeColor = System.Drawing.Color.White;
            this.bunifuMetroTextbox1.isPassword = true;
            this.bunifuMetroTextbox1.Location = new System.Drawing.Point(205, 131);
            this.bunifuMetroTextbox1.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuMetroTextbox1.Name = "bunifuMetroTextbox1";
            this.bunifuMetroTextbox1.Size = new System.Drawing.Size(264, 41);
            this.bunifuMetroTextbox1.TabIndex = 4;
            this.bunifuMetroTextbox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuMetroTextbox2
            // 
            this.bunifuMetroTextbox2.BorderColorFocused = System.Drawing.Color.Aqua;
            this.bunifuMetroTextbox2.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuMetroTextbox2.BorderColorMouseHover = System.Drawing.Color.Aqua;
            this.bunifuMetroTextbox2.BorderThickness = 1;
            this.bunifuMetroTextbox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuMetroTextbox2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.bunifuMetroTextbox2.ForeColor = System.Drawing.Color.White;
            this.bunifuMetroTextbox2.isPassword = false;
            this.bunifuMetroTextbox2.Location = new System.Drawing.Point(205, 82);
            this.bunifuMetroTextbox2.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuMetroTextbox2.Name = "bunifuMetroTextbox2";
            this.bunifuMetroTextbox2.Size = new System.Drawing.Size(264, 41);
            this.bunifuMetroTextbox2.TabIndex = 4;
            this.bunifuMetroTextbox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(138, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "CIN";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_Login_Id
            // 
            this.LBL_Login_Id.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Login_Id.ForeColor = System.Drawing.Color.White;
            this.LBL_Login_Id.Location = new System.Drawing.Point(124, 94);
            this.LBL_Login_Id.Name = "LBL_Login_Id";
            this.LBL_Login_Id.Size = new System.Drawing.Size(74, 17);
            this.LBL_Login_Id.TabIndex = 5;
            this.LBL_Login_Id.Text = "ID";
            this.LBL_Login_Id.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTN_Login_Connecter
            // 
            this.BTN_Login_Connecter.ActiveBorderThickness = 1;
            this.BTN_Login_Connecter.ActiveCornerRadius = 20;
            this.BTN_Login_Connecter.ActiveFillColor = System.Drawing.Color.Aqua;
            this.BTN_Login_Connecter.ActiveForecolor = System.Drawing.Color.Black;
            this.BTN_Login_Connecter.ActiveLineColor = System.Drawing.Color.Aqua;
            this.BTN_Login_Connecter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(55)))));
            this.BTN_Login_Connecter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_Login_Connecter.BackgroundImage")));
            this.BTN_Login_Connecter.ButtonText = "Connecter";
            this.BTN_Login_Connecter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_Login_Connecter.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Login_Connecter.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BTN_Login_Connecter.IdleBorderThickness = 1;
            this.BTN_Login_Connecter.IdleCornerRadius = 20;
            this.BTN_Login_Connecter.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(123)))), ((int)(((byte)(231)))));
            this.BTN_Login_Connecter.IdleForecolor = System.Drawing.Color.White;
            this.BTN_Login_Connecter.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(123)))), ((int)(((byte)(231)))));
            this.BTN_Login_Connecter.Location = new System.Drawing.Point(247, 255);
            this.BTN_Login_Connecter.Margin = new System.Windows.Forms.Padding(5);
            this.BTN_Login_Connecter.Name = "BTN_Login_Connecter";
            this.BTN_Login_Connecter.Size = new System.Drawing.Size(181, 41);
            this.BTN_Login_Connecter.TabIndex = 3;
            this.BTN_Login_Connecter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BTN_Login_Connecter.Click += new System.EventHandler(this.BTN_Login_Connecter_Click);
            // 
            // Tab
            // 
            this.Tab.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.Tab.Controls.Add(this.tabPage1);
            this.Tab.Controls.Add(this.tabPage2);
            this.Tab.Controls.Add(this.tabPage3);
            this.Tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tab.ItemSize = new System.Drawing.Size(10, 10);
            this.Tab.Location = new System.Drawing.Point(0, 55);
            this.Tab.Multiline = true;
            this.Tab.Name = "Tab";
            this.Tab.SelectedIndex = 0;
            this.Tab.Size = new System.Drawing.Size(674, 400);
            this.Tab.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.Tab.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(55)))));
            this.tabPage1.Controls.Add(this.bunifuMetroTextbox2);
            this.tabPage1.Controls.Add(this.LBL_Login_Id);
            this.tabPage1.Controls.Add(this.BTN_Login_Connecter);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.LBL_Login_MotDePasseOublie);
            this.tabPage1.Controls.Add(this.bunifuMetroTextbox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 14);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(666, 382);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // LBL_Login_MotDePasseOublie
            // 
            this.LBL_Login_MotDePasseOublie.AutoSize = true;
            this.LBL_Login_MotDePasseOublie.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LBL_Login_MotDePasseOublie.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Login_MotDePasseOublie.ForeColor = System.Drawing.Color.White;
            this.LBL_Login_MotDePasseOublie.Location = new System.Drawing.Point(227, 187);
            this.LBL_Login_MotDePasseOublie.Name = "LBL_Login_MotDePasseOublie";
            this.LBL_Login_MotDePasseOublie.Size = new System.Drawing.Size(128, 16);
            this.LBL_Login_MotDePasseOublie.TabIndex = 2;
            this.LBL_Login_MotDePasseOublie.Text = "Mot de passe oublié ?";
            this.LBL_Login_MotDePasseOublie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LBL_Login_MotDePasseOublie.Click += new System.EventHandler(this.LBL_Login_MotDePasseOublie_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(55)))));
            this.tabPage2.Controls.Add(this.BIB_Oubliemp_Retour);
            this.tabPage2.Controls.Add(this.BTN_MotDePasseOublie_Ok);
            this.tabPage2.Controls.Add(this.TXB_MotDePasseOublie_Reponse);
            this.tabPage2.Controls.Add(this.LBL_MotDePasseOublie_Question);
            this.tabPage2.Location = new System.Drawing.Point(4, 14);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(666, 382);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // BIB_Oubliemp_Retour
            // 
            this.BIB_Oubliemp_Retour.BackColor = System.Drawing.Color.Transparent;
            this.BIB_Oubliemp_Retour.Image = ((System.Drawing.Image)(resources.GetObject("BIB_Oubliemp_Retour.Image")));
            this.BIB_Oubliemp_Retour.ImageActive = null;
            this.BIB_Oubliemp_Retour.Location = new System.Drawing.Point(21, 16);
            this.BIB_Oubliemp_Retour.Name = "BIB_Oubliemp_Retour";
            this.BIB_Oubliemp_Retour.Size = new System.Drawing.Size(36, 36);
            this.BIB_Oubliemp_Retour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BIB_Oubliemp_Retour.TabIndex = 2;
            this.BIB_Oubliemp_Retour.TabStop = false;
            this.BIB_Oubliemp_Retour.Zoom = 10;
            this.BIB_Oubliemp_Retour.Click += new System.EventHandler(this.BIB_Oubliemp_Retour_Click);
            // 
            // BTN_MotDePasseOublie_Ok
            // 
            this.BTN_MotDePasseOublie_Ok.ActiveBorderThickness = 1;
            this.BTN_MotDePasseOublie_Ok.ActiveCornerRadius = 20;
            this.BTN_MotDePasseOublie_Ok.ActiveFillColor = System.Drawing.Color.Aqua;
            this.BTN_MotDePasseOublie_Ok.ActiveForecolor = System.Drawing.Color.Black;
            this.BTN_MotDePasseOublie_Ok.ActiveLineColor = System.Drawing.Color.Aqua;
            this.BTN_MotDePasseOublie_Ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(55)))));
            this.BTN_MotDePasseOublie_Ok.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_MotDePasseOublie_Ok.BackgroundImage")));
            this.BTN_MotDePasseOublie_Ok.ButtonText = "OK";
            this.BTN_MotDePasseOublie_Ok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_MotDePasseOublie_Ok.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_MotDePasseOublie_Ok.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BTN_MotDePasseOublie_Ok.IdleBorderThickness = 1;
            this.BTN_MotDePasseOublie_Ok.IdleCornerRadius = 20;
            this.BTN_MotDePasseOublie_Ok.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(123)))), ((int)(((byte)(231)))));
            this.BTN_MotDePasseOublie_Ok.IdleForecolor = System.Drawing.Color.White;
            this.BTN_MotDePasseOublie_Ok.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(123)))), ((int)(((byte)(231)))));
            this.BTN_MotDePasseOublie_Ok.Location = new System.Drawing.Point(299, 186);
            this.BTN_MotDePasseOublie_Ok.Margin = new System.Windows.Forms.Padding(5);
            this.BTN_MotDePasseOublie_Ok.Name = "BTN_MotDePasseOublie_Ok";
            this.BTN_MotDePasseOublie_Ok.Size = new System.Drawing.Size(77, 41);
            this.BTN_MotDePasseOublie_Ok.TabIndex = 11;
            this.BTN_MotDePasseOublie_Ok.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BTN_MotDePasseOublie_Ok.Click += new System.EventHandler(this.BTN_MotDePasseOublie_Ok_Click);
            // 
            // TXB_MotDePasseOublie_Reponse
            // 
            this.TXB_MotDePasseOublie_Reponse.BorderColorFocused = System.Drawing.Color.Aqua;
            this.TXB_MotDePasseOublie_Reponse.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TXB_MotDePasseOublie_Reponse.BorderColorMouseHover = System.Drawing.Color.Aqua;
            this.TXB_MotDePasseOublie_Reponse.BorderThickness = 1;
            this.TXB_MotDePasseOublie_Reponse.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TXB_MotDePasseOublie_Reponse.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TXB_MotDePasseOublie_Reponse.ForeColor = System.Drawing.Color.White;
            this.TXB_MotDePasseOublie_Reponse.isPassword = false;
            this.TXB_MotDePasseOublie_Reponse.Location = new System.Drawing.Point(205, 120);
            this.TXB_MotDePasseOublie_Reponse.Margin = new System.Windows.Forms.Padding(4);
            this.TXB_MotDePasseOublie_Reponse.Name = "TXB_MotDePasseOublie_Reponse";
            this.TXB_MotDePasseOublie_Reponse.Size = new System.Drawing.Size(264, 41);
            this.TXB_MotDePasseOublie_Reponse.TabIndex = 10;
            this.TXB_MotDePasseOublie_Reponse.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // LBL_MotDePasseOublie_Question
            // 
            this.LBL_MotDePasseOublie_Question.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_MotDePasseOublie_Question.ForeColor = System.Drawing.Color.White;
            this.LBL_MotDePasseOublie_Question.Location = new System.Drawing.Point(170, 55);
            this.LBL_MotDePasseOublie_Question.Name = "LBL_MotDePasseOublie_Question";
            this.LBL_MotDePasseOublie_Question.Size = new System.Drawing.Size(334, 40);
            this.LBL_MotDePasseOublie_Question.TabIndex = 9;
            this.LBL_MotDePasseOublie_Question.Text = "What the fuck is your name ?";
            this.LBL_MotDePasseOublie_Question.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(55)))));
            this.tabPage3.Controls.Add(this.BIB_Modifiermp_Retour);
            this.tabPage3.Controls.Add(this.BTN_ModifierMotPass_Connecter);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.TXB_Mmp_nouveumotpasse);
            this.tabPage3.Controls.Add(this.TXB_Mmp_Confirmémotpasse);
            this.tabPage3.Location = new System.Drawing.Point(4, 14);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(666, 382);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            // 
            // BIB_Modifiermp_Retour
            // 
            this.BIB_Modifiermp_Retour.BackColor = System.Drawing.Color.Transparent;
            this.BIB_Modifiermp_Retour.Image = ((System.Drawing.Image)(resources.GetObject("BIB_Modifiermp_Retour.Image")));
            this.BIB_Modifiermp_Retour.ImageActive = null;
            this.BIB_Modifiermp_Retour.Location = new System.Drawing.Point(21, 16);
            this.BIB_Modifiermp_Retour.Name = "BIB_Modifiermp_Retour";
            this.BIB_Modifiermp_Retour.Size = new System.Drawing.Size(36, 36);
            this.BIB_Modifiermp_Retour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BIB_Modifiermp_Retour.TabIndex = 2;
            this.BIB_Modifiermp_Retour.TabStop = false;
            this.BIB_Modifiermp_Retour.Zoom = 10;
            this.BIB_Modifiermp_Retour.Click += new System.EventHandler(this.BIB_Modifiermp_Retour_Click);
            // 
            // BTN_ModifierMotPass_Connecter
            // 
            this.BTN_ModifierMotPass_Connecter.ActiveBorderThickness = 1;
            this.BTN_ModifierMotPass_Connecter.ActiveCornerRadius = 20;
            this.BTN_ModifierMotPass_Connecter.ActiveFillColor = System.Drawing.Color.Aqua;
            this.BTN_ModifierMotPass_Connecter.ActiveForecolor = System.Drawing.Color.Black;
            this.BTN_ModifierMotPass_Connecter.ActiveLineColor = System.Drawing.Color.Aqua;
            this.BTN_ModifierMotPass_Connecter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(55)))));
            this.BTN_ModifierMotPass_Connecter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_ModifierMotPass_Connecter.BackgroundImage")));
            this.BTN_ModifierMotPass_Connecter.ButtonText = "Connecter";
            this.BTN_ModifierMotPass_Connecter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_ModifierMotPass_Connecter.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_ModifierMotPass_Connecter.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BTN_ModifierMotPass_Connecter.IdleBorderThickness = 1;
            this.BTN_ModifierMotPass_Connecter.IdleCornerRadius = 20;
            this.BTN_ModifierMotPass_Connecter.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(123)))), ((int)(((byte)(231)))));
            this.BTN_ModifierMotPass_Connecter.IdleForecolor = System.Drawing.Color.White;
            this.BTN_ModifierMotPass_Connecter.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(123)))), ((int)(((byte)(231)))));
            this.BTN_ModifierMotPass_Connecter.Location = new System.Drawing.Point(324, 200);
            this.BTN_ModifierMotPass_Connecter.Margin = new System.Windows.Forms.Padding(5);
            this.BTN_ModifierMotPass_Connecter.Name = "BTN_ModifierMotPass_Connecter";
            this.BTN_ModifierMotPass_Connecter.Size = new System.Drawing.Size(181, 41);
            this.BTN_ModifierMotPass_Connecter.TabIndex = 30;
            this.BTN_ModifierMotPass_Connecter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BTN_ModifierMotPass_Connecter.Click += new System.EventHandler(this.BTN_ModifierMotPass_Connecter_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(66, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 27);
            this.label1.TabIndex = 28;
            this.label1.Text = "Nouveau mot de passe";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(66, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 27);
            this.label2.TabIndex = 29;
            this.label2.Text = "Confirmé Mot de Passe";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TXB_Mmp_nouveumotpasse
            // 
            this.TXB_Mmp_nouveumotpasse.BorderColorFocused = System.Drawing.Color.Aqua;
            this.TXB_Mmp_nouveumotpasse.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TXB_Mmp_nouveumotpasse.BorderColorMouseHover = System.Drawing.Color.Aqua;
            this.TXB_Mmp_nouveumotpasse.BorderThickness = 1;
            this.TXB_Mmp_nouveumotpasse.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TXB_Mmp_nouveumotpasse.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TXB_Mmp_nouveumotpasse.ForeColor = System.Drawing.Color.White;
            this.TXB_Mmp_nouveumotpasse.isPassword = true;
            this.TXB_Mmp_nouveumotpasse.Location = new System.Drawing.Point(278, 87);
            this.TXB_Mmp_nouveumotpasse.Margin = new System.Windows.Forms.Padding(4);
            this.TXB_Mmp_nouveumotpasse.Name = "TXB_Mmp_nouveumotpasse";
            this.TXB_Mmp_nouveumotpasse.Size = new System.Drawing.Size(272, 41);
            this.TXB_Mmp_nouveumotpasse.TabIndex = 26;
            this.TXB_Mmp_nouveumotpasse.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // TXB_Mmp_Confirmémotpasse
            // 
            this.TXB_Mmp_Confirmémotpasse.BorderColorFocused = System.Drawing.Color.Aqua;
            this.TXB_Mmp_Confirmémotpasse.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TXB_Mmp_Confirmémotpasse.BorderColorMouseHover = System.Drawing.Color.Aqua;
            this.TXB_Mmp_Confirmémotpasse.BorderThickness = 1;
            this.TXB_Mmp_Confirmémotpasse.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TXB_Mmp_Confirmémotpasse.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TXB_Mmp_Confirmémotpasse.ForeColor = System.Drawing.Color.White;
            this.TXB_Mmp_Confirmémotpasse.isPassword = true;
            this.TXB_Mmp_Confirmémotpasse.Location = new System.Drawing.Point(278, 136);
            this.TXB_Mmp_Confirmémotpasse.Margin = new System.Windows.Forms.Padding(4);
            this.TXB_Mmp_Confirmémotpasse.Name = "TXB_Mmp_Confirmémotpasse";
            this.TXB_Mmp_Confirmémotpasse.Size = new System.Drawing.Size(272, 41);
            this.TXB_Mmp_Confirmémotpasse.TabIndex = 27;
            this.TXB_Mmp_Confirmémotpasse.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(49)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(674, 455);
            this.Controls.Add(this.Tab);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTN_Login_Close)).EndInit();
            this.Tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BIB_Oubliemp_Retour)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BIB_Modifiermp_Retour)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ns1.BunifuImageButton BTN_Login_Close;
        private ns1.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Panel panel1;
        private ns1.BunifuThinButton2 BTN_Login_Connecter;
        private ns1.BunifuMetroTextbox bunifuMetroTextbox1;
        private ns1.BunifuMetroTextbox bunifuMetroTextbox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LBL_Login_Id;
        private System.Windows.Forms.TabControl Tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private ns1.BunifuThinButton2 BTN_ModifierMotPass_Connecter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ns1.BunifuMetroTextbox TXB_Mmp_nouveumotpasse;
        private ns1.BunifuMetroTextbox TXB_Mmp_Confirmémotpasse;
        private ns1.BunifuThinButton2 BTN_MotDePasseOublie_Ok;
        private ns1.BunifuMetroTextbox TXB_MotDePasseOublie_Reponse;
        private System.Windows.Forms.Label LBL_MotDePasseOublie_Question;
        private ns1.BunifuImageButton BIB_Oubliemp_Retour;
        private ns1.BunifuImageButton BIB_Modifiermp_Retour;
        private ns1.BunifuImageButton bunifuImageButton1;
        private ns1.BunifuCustomLabel LBL_Login_MotDePasseOublie;
        private System.Windows.Forms.Label Lbl_Form1_NameHeader;
    }
}