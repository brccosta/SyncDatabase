namespace SyncDatabase
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tpSync = new System.Windows.Forms.TabPage();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.txtInformacoes = new System.Windows.Forms.TextBox();
            this.btnSincronizar = new System.Windows.Forms.Button();
            this.cbAcao = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tpConfig = new System.Windows.Forms.TabPage();
            this.btnPrimConfig = new System.Windows.Forms.Button();
            this.btnLimparEscopo = new System.Windows.Forms.Button();
            this.btnConfigurarEscopo = new System.Windows.Forms.Button();
            this.cbServer = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbTabelasIgnoradas = new System.Windows.Forms.GroupBox();
            this.txtTabelasIgnoradas = new System.Windows.Forms.TextBox();
            this.cbEscopo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tpServer1 = new System.Windows.Forms.TabPage();
            this.btnTestarConexaoS1 = new System.Windows.Forms.Button();
            this.txtUsuarioS1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDatabaseS1 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtInstanciaS1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSenhaS1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tpServer2 = new System.Windows.Forms.TabPage();
            this.btnTestarConexaoS2 = new System.Windows.Forms.Button();
            this.txtUsuarioS2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDatabaseS2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInstanciaS2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSenhaS2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.statusMain = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.radWSync = new Telerik.WinControls.UI.RadWaitingBar();
            this.backWorkerTestaConn = new System.ComponentModel.BackgroundWorker();
            this.backWorkerLimpaEscopo = new System.ComponentModel.BackgroundWorker();
            this.backWorkerConfigEscopo = new System.ComponentModel.BackgroundWorker();
            this.backWorkerTestaConexaoSync = new System.ComponentModel.BackgroundWorker();
            this.backWorkSincronizar = new System.ComponentModel.BackgroundWorker();
            this.tabControlMain.SuspendLayout();
            this.tpSync.SuspendLayout();
            this.gbInfo.SuspendLayout();
            this.tpConfig.SuspendLayout();
            this.gbTabelasIgnoradas.SuspendLayout();
            this.tpServer1.SuspendLayout();
            this.tpServer2.SuspendLayout();
            this.statusMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radWSync)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tpSync);
            this.tabControlMain.Controls.Add(this.tpConfig);
            this.tabControlMain.Controls.Add(this.tpServer1);
            this.tabControlMain.Controls.Add(this.tpServer2);
            this.tabControlMain.Location = new System.Drawing.Point(1, 1);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(412, 193);
            this.tabControlMain.TabIndex = 99;
            // 
            // tpSync
            // 
            this.tpSync.Controls.Add(this.gbInfo);
            this.tpSync.Controls.Add(this.btnSincronizar);
            this.tpSync.Controls.Add(this.cbAcao);
            this.tpSync.Controls.Add(this.label1);
            this.tpSync.Location = new System.Drawing.Point(4, 22);
            this.tpSync.Name = "tpSync";
            this.tpSync.Padding = new System.Windows.Forms.Padding(3);
            this.tpSync.Size = new System.Drawing.Size(404, 167);
            this.tpSync.TabIndex = 0;
            this.tpSync.Text = "Sync";
            this.tpSync.UseVisualStyleBackColor = true;
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.txtInformacoes);
            this.gbInfo.Location = new System.Drawing.Point(8, 60);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(386, 101);
            this.gbInfo.TabIndex = 3;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Informações";
            // 
            // txtInformacoes
            // 
            this.txtInformacoes.Location = new System.Drawing.Point(6, 20);
            this.txtInformacoes.Multiline = true;
            this.txtInformacoes.Name = "txtInformacoes";
            this.txtInformacoes.Size = new System.Drawing.Size(374, 75);
            this.txtInformacoes.TabIndex = 0;
            // 
            // btnSincronizar
            // 
            this.btnSincronizar.Image = ((System.Drawing.Image)(resources.GetObject("btnSincronizar.Image")));
            this.btnSincronizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSincronizar.Location = new System.Drawing.Point(255, 10);
            this.btnSincronizar.Name = "btnSincronizar";
            this.btnSincronizar.Size = new System.Drawing.Size(139, 35);
            this.btnSincronizar.TabIndex = 2;
            this.btnSincronizar.Text = "Sincronizar";
            this.btnSincronizar.UseVisualStyleBackColor = true;
            this.btnSincronizar.Click += new System.EventHandler(this.btnSincronizar_Click);
            // 
            // cbAcao
            // 
            this.cbAcao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAcao.FormattingEnabled = true;
            this.cbAcao.Items.AddRange(new object[] {
            "Enviar exames",
            "Atualizar solicitações"});
            this.cbAcao.Location = new System.Drawing.Point(57, 18);
            this.cbAcao.Name = "cbAcao";
            this.cbAcao.Size = new System.Drawing.Size(158, 21);
            this.cbAcao.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ação:";
            // 
            // tpConfig
            // 
            this.tpConfig.Controls.Add(this.btnPrimConfig);
            this.tpConfig.Controls.Add(this.btnLimparEscopo);
            this.tpConfig.Controls.Add(this.btnConfigurarEscopo);
            this.tpConfig.Controls.Add(this.cbServer);
            this.tpConfig.Controls.Add(this.label3);
            this.tpConfig.Controls.Add(this.gbTabelasIgnoradas);
            this.tpConfig.Controls.Add(this.cbEscopo);
            this.tpConfig.Controls.Add(this.label2);
            this.tpConfig.Location = new System.Drawing.Point(4, 22);
            this.tpConfig.Name = "tpConfig";
            this.tpConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tpConfig.Size = new System.Drawing.Size(404, 167);
            this.tpConfig.TabIndex = 1;
            this.tpConfig.Text = "Configurações";
            this.tpConfig.UseVisualStyleBackColor = true;
            // 
            // btnPrimConfig
            // 
            this.btnPrimConfig.Location = new System.Drawing.Point(280, 139);
            this.btnPrimConfig.Name = "btnPrimConfig";
            this.btnPrimConfig.Size = new System.Drawing.Size(112, 23);
            this.btnPrimConfig.TabIndex = 9;
            this.btnPrimConfig.Text = "Up and Down";
            this.btnPrimConfig.UseVisualStyleBackColor = true;
            this.btnPrimConfig.Click += new System.EventHandler(this.btnPrimConfig_Click);
            // 
            // btnLimparEscopo
            // 
            this.btnLimparEscopo.Location = new System.Drawing.Point(162, 139);
            this.btnLimparEscopo.Name = "btnLimparEscopo";
            this.btnLimparEscopo.Size = new System.Drawing.Size(112, 23);
            this.btnLimparEscopo.TabIndex = 8;
            this.btnLimparEscopo.Text = "Limpar escopo";
            this.btnLimparEscopo.UseVisualStyleBackColor = true;
            this.btnLimparEscopo.Click += new System.EventHandler(this.btnLimparEscopo_Click);
            // 
            // btnConfigurarEscopo
            // 
            this.btnConfigurarEscopo.Location = new System.Drawing.Point(44, 139);
            this.btnConfigurarEscopo.Name = "btnConfigurarEscopo";
            this.btnConfigurarEscopo.Size = new System.Drawing.Size(112, 23);
            this.btnConfigurarEscopo.TabIndex = 7;
            this.btnConfigurarEscopo.Text = "Configurar escopo";
            this.btnConfigurarEscopo.UseVisualStyleBackColor = true;
            this.btnConfigurarEscopo.Click += new System.EventHandler(this.btnConfigurarEscopo_Click);
            // 
            // cbServer
            // 
            this.cbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbServer.FormattingEnabled = true;
            this.cbServer.Items.AddRange(new object[] {
            "Server 1",
            "Server 2"});
            this.cbServer.Location = new System.Drawing.Point(260, 13);
            this.cbServer.Name = "cbServer";
            this.cbServer.Size = new System.Drawing.Size(132, 21);
            this.cbServer.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Server:";
            // 
            // gbTabelasIgnoradas
            // 
            this.gbTabelasIgnoradas.Controls.Add(this.txtTabelasIgnoradas);
            this.gbTabelasIgnoradas.Location = new System.Drawing.Point(7, 40);
            this.gbTabelasIgnoradas.Name = "gbTabelasIgnoradas";
            this.gbTabelasIgnoradas.Size = new System.Drawing.Size(386, 93);
            this.gbTabelasIgnoradas.TabIndex = 4;
            this.gbTabelasIgnoradas.TabStop = false;
            this.gbTabelasIgnoradas.Text = "Tabelas ignoradas";
            // 
            // txtTabelasIgnoradas
            // 
            this.txtTabelasIgnoradas.Location = new System.Drawing.Point(6, 20);
            this.txtTabelasIgnoradas.Multiline = true;
            this.txtTabelasIgnoradas.Name = "txtTabelasIgnoradas";
            this.txtTabelasIgnoradas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTabelasIgnoradas.Size = new System.Drawing.Size(374, 66);
            this.txtTabelasIgnoradas.TabIndex = 0;
            // 
            // cbEscopo
            // 
            this.cbEscopo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEscopo.FormattingEnabled = true;
            this.cbEscopo.Items.AddRange(new object[] {
            "Enviar_Exames",
            "Atualizar_Solicitacoes"});
            this.cbEscopo.Location = new System.Drawing.Point(61, 13);
            this.cbEscopo.Name = "cbEscopo";
            this.cbEscopo.Size = new System.Drawing.Size(132, 21);
            this.cbEscopo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nome:";
            // 
            // tpServer1
            // 
            this.tpServer1.Controls.Add(this.btnTestarConexaoS1);
            this.tpServer1.Controls.Add(this.txtUsuarioS1);
            this.tpServer1.Controls.Add(this.label14);
            this.tpServer1.Controls.Add(this.txtDatabaseS1);
            this.tpServer1.Controls.Add(this.label13);
            this.tpServer1.Controls.Add(this.txtInstanciaS1);
            this.tpServer1.Controls.Add(this.label8);
            this.tpServer1.Controls.Add(this.txtSenhaS1);
            this.tpServer1.Controls.Add(this.label6);
            this.tpServer1.Location = new System.Drawing.Point(4, 22);
            this.tpServer1.Name = "tpServer1";
            this.tpServer1.Padding = new System.Windows.Forms.Padding(3);
            this.tpServer1.Size = new System.Drawing.Size(404, 167);
            this.tpServer1.TabIndex = 2;
            this.tpServer1.Text = "Server 1";
            this.tpServer1.UseVisualStyleBackColor = true;
            // 
            // btnTestarConexaoS1
            // 
            this.btnTestarConexaoS1.Location = new System.Drawing.Point(285, 111);
            this.btnTestarConexaoS1.Name = "btnTestarConexaoS1";
            this.btnTestarConexaoS1.Size = new System.Drawing.Size(109, 23);
            this.btnTestarConexaoS1.TabIndex = 5;
            this.btnTestarConexaoS1.TabStop = false;
            this.btnTestarConexaoS1.Text = "Testar conexão";
            this.btnTestarConexaoS1.UseVisualStyleBackColor = true;
            this.btnTestarConexaoS1.Click += new System.EventHandler(this.btnTestarConexaoS1_Click);
            // 
            // txtUsuarioS1
            // 
            this.txtUsuarioS1.Location = new System.Drawing.Point(84, 73);
            this.txtUsuarioS1.Name = "txtUsuarioS1";
            this.txtUsuarioS1.Size = new System.Drawing.Size(137, 20);
            this.txtUsuarioS1.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 76);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "Usuário:";
            // 
            // txtDatabaseS1
            // 
            this.txtDatabaseS1.Location = new System.Drawing.Point(84, 47);
            this.txtDatabaseS1.Name = "txtDatabaseS1";
            this.txtDatabaseS1.Size = new System.Drawing.Size(310, 20);
            this.txtDatabaseS1.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "Database:";
            // 
            // txtInstanciaS1
            // 
            this.txtInstanciaS1.Location = new System.Drawing.Point(84, 21);
            this.txtInstanciaS1.Name = "txtInstanciaS1";
            this.txtInstanciaS1.Size = new System.Drawing.Size(310, 20);
            this.txtInstanciaS1.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Instância:";
            // 
            // txtSenhaS1
            // 
            this.txtSenhaS1.Location = new System.Drawing.Point(281, 76);
            this.txtSenhaS1.Name = "txtSenhaS1";
            this.txtSenhaS1.Size = new System.Drawing.Size(113, 20);
            this.txtSenhaS1.TabIndex = 4;
            this.txtSenhaS1.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(227, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Senha:";
            // 
            // tpServer2
            // 
            this.tpServer2.Controls.Add(this.btnTestarConexaoS2);
            this.tpServer2.Controls.Add(this.txtUsuarioS2);
            this.tpServer2.Controls.Add(this.label4);
            this.tpServer2.Controls.Add(this.txtDatabaseS2);
            this.tpServer2.Controls.Add(this.label5);
            this.tpServer2.Controls.Add(this.txtInstanciaS2);
            this.tpServer2.Controls.Add(this.label7);
            this.tpServer2.Controls.Add(this.txtSenhaS2);
            this.tpServer2.Controls.Add(this.label9);
            this.tpServer2.Location = new System.Drawing.Point(4, 22);
            this.tpServer2.Name = "tpServer2";
            this.tpServer2.Padding = new System.Windows.Forms.Padding(3);
            this.tpServer2.Size = new System.Drawing.Size(404, 167);
            this.tpServer2.TabIndex = 3;
            this.tpServer2.Text = "Server 2";
            this.tpServer2.UseVisualStyleBackColor = true;
            // 
            // btnTestarConexaoS2
            // 
            this.btnTestarConexaoS2.Location = new System.Drawing.Point(285, 111);
            this.btnTestarConexaoS2.Name = "btnTestarConexaoS2";
            this.btnTestarConexaoS2.Size = new System.Drawing.Size(109, 23);
            this.btnTestarConexaoS2.TabIndex = 39;
            this.btnTestarConexaoS2.TabStop = false;
            this.btnTestarConexaoS2.Text = "Testar conexão";
            this.btnTestarConexaoS2.UseVisualStyleBackColor = true;
            this.btnTestarConexaoS2.Click += new System.EventHandler(this.btnTestarConexaoS2_Click);
            // 
            // txtUsuarioS2
            // 
            this.txtUsuarioS2.Location = new System.Drawing.Point(84, 73);
            this.txtUsuarioS2.Name = "txtUsuarioS2";
            this.txtUsuarioS2.Size = new System.Drawing.Size(137, 20);
            this.txtUsuarioS2.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Usuário:";
            // 
            // txtDatabaseS2
            // 
            this.txtDatabaseS2.Location = new System.Drawing.Point(84, 47);
            this.txtDatabaseS2.Name = "txtDatabaseS2";
            this.txtDatabaseS2.Size = new System.Drawing.Size(310, 20);
            this.txtDatabaseS2.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Database:";
            // 
            // txtInstanciaS2
            // 
            this.txtInstanciaS2.Location = new System.Drawing.Point(84, 21);
            this.txtInstanciaS2.Name = "txtInstanciaS2";
            this.txtInstanciaS2.Size = new System.Drawing.Size(310, 20);
            this.txtInstanciaS2.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Instância:";
            // 
            // txtSenhaS2
            // 
            this.txtSenhaS2.Location = new System.Drawing.Point(281, 76);
            this.txtSenhaS2.Name = "txtSenhaS2";
            this.txtSenhaS2.Size = new System.Drawing.Size(113, 20);
            this.txtSenhaS2.TabIndex = 4;
            this.txtSenhaS2.UseSystemPasswordChar = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(227, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Senha:";
            // 
            // statusMain
            // 
            this.statusMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusMain.Location = new System.Drawing.Point(0, 194);
            this.statusMain.Name = "statusMain";
            this.statusMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusMain.Size = new System.Drawing.Size(411, 22);
            this.statusMain.SizingGrip = false;
            this.statusMain.TabIndex = 1;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // radWSync
            // 
            this.radWSync.Location = new System.Drawing.Point(216, 197);
            this.radWSync.Name = "radWSync";
            this.radWSync.Size = new System.Drawing.Size(192, 19);
            this.radWSync.TabIndex = 2;
            this.radWSync.Visible = false;
            this.radWSync.WaitingSpeed = 10;
            // 
            // backWorkerTestaConn
            // 
            this.backWorkerTestaConn.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backWorkerTestaConn_DoWork);
            this.backWorkerTestaConn.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backWorkerTestaConn_RunWorkerCompleted);
            // 
            // backWorkerLimpaEscopo
            // 
            this.backWorkerLimpaEscopo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backWorkerLimpaEscopo_DoWork);
            this.backWorkerLimpaEscopo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backWorkerLimpaEscopo_RunWorkerCompleted);
            // 
            // backWorkerConfigEscopo
            // 
            this.backWorkerConfigEscopo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backWorkerConfigEscopo_DoWork);
            this.backWorkerConfigEscopo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backWorkerConfigEscopo_RunWorkerCompleted);
            // 
            // backWorkerTestaConexaoSync
            // 
            this.backWorkerTestaConexaoSync.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backWorkerTestaConexaoSync_DoWork);
            this.backWorkerTestaConexaoSync.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backWorkerTestaConexaoSync_RunWorkerCompleted);
            // 
            // backWorkSincronizar
            // 
            this.backWorkSincronizar.WorkerSupportsCancellation = true;
            this.backWorkSincronizar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backWorkSincronizar_DoWork);
            this.backWorkSincronizar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backWorkSincronizar_RunWorkerCompleted);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 216);
            this.Controls.Add(this.radWSync);
            this.Controls.Add(this.statusMain);
            this.Controls.Add(this.tabControlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sync Database 3.0.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.tabControlMain.ResumeLayout(false);
            this.tpSync.ResumeLayout(false);
            this.tpSync.PerformLayout();
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.tpConfig.ResumeLayout(false);
            this.tpConfig.PerformLayout();
            this.gbTabelasIgnoradas.ResumeLayout(false);
            this.gbTabelasIgnoradas.PerformLayout();
            this.tpServer1.ResumeLayout(false);
            this.tpServer1.PerformLayout();
            this.tpServer2.ResumeLayout(false);
            this.tpServer2.PerformLayout();
            this.statusMain.ResumeLayout(false);
            this.statusMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radWSync)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tpSync;
        private System.Windows.Forms.TabPage tpConfig;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.TextBox txtInformacoes;
        private System.Windows.Forms.Button btnSincronizar;
        private System.Windows.Forms.ComboBox cbAcao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tpServer1;
        private System.Windows.Forms.TabPage tpServer2;
        private System.Windows.Forms.Button btnPrimConfig;
        private System.Windows.Forms.Button btnLimparEscopo;
        private System.Windows.Forms.Button btnConfigurarEscopo;
        private System.Windows.Forms.ComboBox cbServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbTabelasIgnoradas;
        private System.Windows.Forms.TextBox txtTabelasIgnoradas;
        private System.Windows.Forms.ComboBox cbEscopo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTestarConexaoS1;
        private System.Windows.Forms.TextBox txtUsuarioS1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDatabaseS1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtInstanciaS1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSenhaS1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.StatusStrip statusMain;
        private System.Windows.Forms.Button btnTestarConexaoS2;
        private System.Windows.Forms.TextBox txtUsuarioS2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDatabaseS2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtInstanciaS2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSenhaS2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private Telerik.WinControls.UI.RadWaitingBar radWSync;
        private System.ComponentModel.BackgroundWorker backWorkerTestaConn;
        private System.ComponentModel.BackgroundWorker backWorkerLimpaEscopo;
        private System.ComponentModel.BackgroundWorker backWorkerConfigEscopo;
        private System.ComponentModel.BackgroundWorker backWorkerTestaConexaoSync;
        private System.ComponentModel.BackgroundWorker backWorkSincronizar;
    }
}

