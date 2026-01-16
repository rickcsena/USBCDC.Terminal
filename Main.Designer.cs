namespace USB_CDC_TERMINAL
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.sstFooter = new System.Windows.Forms.StatusStrip();
            this.ConnectionToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.VIDLabel = new System.Windows.Forms.Label();
            this.PIDLabel = new System.Windows.Forms.Label();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.serial = new System.IO.Ports.SerialPort(this.components);
            this.cbxEnvioAutoTempo = new System.Windows.Forms.ComboBox();
            this.chkEnvioAuto = new System.Windows.Forms.CheckBox();
            this.btnCarregarListaComandos = new System.Windows.Forms.Button();
            this.gpbConnection = new System.Windows.Forms.GroupBox();
            this.btnConectar = new System.Windows.Forms.Button();
            this.rdbUtilizarUSB = new System.Windows.Forms.RadioButton();
            this.rdbUtilizarSerial = new System.Windows.Forms.RadioButton();
            this.lblPort = new System.Windows.Forms.Label();
            this.cbxPortaSerial = new System.Windows.Forms.ComboBox();
            this.lblBaudrate = new System.Windows.Forms.Label();
            this.cbxBaudrate = new System.Windows.Forms.ComboBox();
            this.gpbDataSend = new System.Windows.Forms.GroupBox();
            this.chkEnvLogar = new System.Windows.Forms.CheckBox();
            this.rbtEnvAscii = new System.Windows.Forms.RadioButton();
            this.rbtEnvHexadecimal = new System.Windows.Forms.RadioButton();
            this.gpbDataReceive = new System.Windows.Forms.GroupBox();
            this.chkRecLogar = new System.Windows.Forms.CheckBox();
            this.rbtRecAscii = new System.Windows.Forms.RadioButton();
            this.rbtRecHexadecimal = new System.Windows.Forms.RadioButton();
            this.lblListaComandos = new System.Windows.Forms.Label();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.txtDados = new System.Windows.Forms.RichTextBox();
            this.gpbLog = new System.Windows.Forms.GroupBox();
            this.chkQuebrarLinha = new System.Windows.Forms.CheckBox();
            this.chkData = new System.Windows.Forms.CheckBox();
            this.chkMilisegundos = new System.Windows.Forms.CheckBox();
            this.chkHora = new System.Windows.Forms.CheckBox();
            this.btnPausar = new System.Windows.Forms.Button();
            this.btnMarcar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.lstComandos = new System.Windows.Forms.ListBox();
            this.txtEnviar = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnRestaurarPadrao = new System.Windows.Forms.Button();
            this.gpbSendPrefix = new System.Windows.Forms.GroupBox();
            this.rbtInicioNenhum = new System.Windows.Forms.RadioButton();
            this.rbtInicioEnter = new System.Windows.Forms.RadioButton();
            this.rbtInicioStx = new System.Windows.Forms.RadioButton();
            this.rbtInicioEsc = new System.Windows.Forms.RadioButton();
            this.gpbSendSuffix = new System.Windows.Forms.GroupBox();
            this.rbtFimNenhum = new System.Windows.Forms.RadioButton();
            this.rbtFimEnter = new System.Windows.Forms.RadioButton();
            this.rbtFimEtx = new System.Windows.Forms.RadioButton();
            this.rbtFimEsc = new System.Windows.Forms.RadioButton();
            this.gpbLogNewLine = new System.Windows.Forms.GroupBox();
            this.rbt32Char = new System.Windows.Forms.RadioButton();
            this.rbt16Char = new System.Windows.Forms.RadioButton();
            this.txtCaractere = new System.Windows.Forms.TextBox();
            this.rbtDecimal = new System.Windows.Forms.RadioButton();
            this.rbt0 = new System.Windows.Forms.RadioButton();
            this.rbtr = new System.Windows.Forms.RadioButton();
            this.rbtn = new System.Windows.Forms.RadioButton();
            this.gpbConfig = new System.Windows.Forms.GroupBox();
            this.btnFonte = new System.Windows.Forms.Button();
            this.gpbUSBCDC = new System.Windows.Forms.GroupBox();
            this.lblUsbDevice = new System.Windows.Forms.Label();
            this.cbxDevice = new System.Windows.Forms.ComboBox();
            this.PIDTextBox = new System.Windows.Forms.TextBox();
            this.VIDTextBox = new System.Windows.Forms.TextBox();
            this.chkSalvarLog = new System.Windows.Forms.CheckBox();
            this.tmrEnvioAuto = new System.Windows.Forms.Timer(this.components);
            this.fbdFileOpen = new System.Windows.Forms.FolderBrowserDialog();
            this.lblCOM = new System.Windows.Forms.Label();
            this.gpbSerial = new System.Windows.Forms.GroupBox();
            this.gpbControl = new System.Windows.Forms.GroupBox();
            this.chkDTR = new System.Windows.Forms.CheckBox();
            this.chkRTS = new System.Windows.Forms.CheckBox();
            this.chkDSR = new System.Windows.Forms.CheckBox();
            this.chkCTS = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.gpbConnection.SuspendLayout();
            this.gpbDataSend.SuspendLayout();
            this.gpbDataReceive.SuspendLayout();
            this.gpbLog.SuspendLayout();
            this.gpbSendPrefix.SuspendLayout();
            this.gpbSendSuffix.SuspendLayout();
            this.gpbLogNewLine.SuspendLayout();
            this.gpbConfig.SuspendLayout();
            this.gpbUSBCDC.SuspendLayout();
            this.gpbSerial.SuspendLayout();
            this.gpbControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // sstFooter
            // 
            this.sstFooter.Location = new System.Drawing.Point(0, 462);
            this.sstFooter.Name = "sstFooter";
            this.sstFooter.Size = new System.Drawing.Size(962, 22);
            this.sstFooter.TabIndex = 0;
            this.sstFooter.Text = "sstFooter";
            // 
            // ConnectionToolStripStatusLabel
            // 
            this.ConnectionToolStripStatusLabel.Name = "ConnectionToolStripStatusLabel";
            this.ConnectionToolStripStatusLabel.Size = new System.Drawing.Size(79, 17);
            this.ConnectionToolStripStatusLabel.Text = "Disconnected";
            // 
            // VIDLabel
            // 
            this.VIDLabel.AutoSize = true;
            this.VIDLabel.Location = new System.Drawing.Point(9, 56);
            this.VIDLabel.Name = "VIDLabel";
            this.VIDLabel.Size = new System.Drawing.Size(28, 13);
            this.VIDLabel.TabIndex = 20;
            this.VIDLabel.Text = "VID:";
            // 
            // PIDLabel
            // 
            this.PIDLabel.AutoSize = true;
            this.PIDLabel.Location = new System.Drawing.Point(139, 56);
            this.PIDLabel.Name = "PIDLabel";
            this.PIDLabel.Size = new System.Drawing.Size(28, 13);
            this.PIDLabel.TabIndex = 21;
            this.PIDLabel.Text = "PID:";
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // serial
            // 
            this.serial.PinChanged += new System.IO.Ports.SerialPinChangedEventHandler(this.serial_PinChanged);
            this.serial.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serial_DataReceived);
            // 
            // cbxEnvioAutoTempo
            // 
            this.cbxEnvioAutoTempo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxEnvioAutoTempo.Enabled = false;
            this.cbxEnvioAutoTempo.FormattingEnabled = true;
            this.cbxEnvioAutoTempo.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "5",
            "10",
            "15",
            "20",
            "30",
            "60",
            "120",
            "240",
            "300",
            "600",
            "1800",
            "3600"});
            this.cbxEnvioAutoTempo.Location = new System.Drawing.Point(756, 357);
            this.cbxEnvioAutoTempo.Name = "cbxEnvioAutoTempo";
            this.cbxEnvioAutoTempo.Size = new System.Drawing.Size(53, 21);
            this.cbxEnvioAutoTempo.TabIndex = 12;
            this.cbxEnvioAutoTempo.Text = "1800";
            this.cbxEnvioAutoTempo.SelectedIndexChanged += new System.EventHandler(this.cbxEnvioAutoTempo_SelectedIndexChanged);
            this.cbxEnvioAutoTempo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxEnvioAutoTempo_KeyPress);
            // 
            // chkEnvioAuto
            // 
            this.chkEnvioAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEnvioAuto.AutoSize = true;
            this.chkEnvioAuto.Enabled = false;
            this.chkEnvioAuto.Location = new System.Drawing.Point(695, 359);
            this.chkEnvioAuto.Name = "chkEnvioAuto";
            this.chkEnvioAuto.Size = new System.Drawing.Size(65, 17);
            this.chkEnvioAuto.TabIndex = 11;
            this.chkEnvioAuto.Text = "Auto (s):";
            this.chkEnvioAuto.UseVisualStyleBackColor = true;
            this.chkEnvioAuto.CheckedChanged += new System.EventHandler(this.chkEnvioAuto_CheckedChanged);
            // 
            // btnCarregarListaComandos
            // 
            this.btnCarregarListaComandos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCarregarListaComandos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarregarListaComandos.Location = new System.Drawing.Point(825, 303);
            this.btnCarregarListaComandos.Name = "btnCarregarListaComandos";
            this.btnCarregarListaComandos.Size = new System.Drawing.Size(53, 19);
            this.btnCarregarListaComandos.TabIndex = 6;
            this.btnCarregarListaComandos.Text = "Lista";
            this.btnCarregarListaComandos.UseVisualStyleBackColor = true;
            this.btnCarregarListaComandos.Click += new System.EventHandler(this.btnCarregarListaComandos_Click);
            // 
            // gpbConnection
            // 
            this.gpbConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gpbConnection.Controls.Add(this.btnConectar);
            this.gpbConnection.Controls.Add(this.rdbUtilizarUSB);
            this.gpbConnection.Controls.Add(this.rdbUtilizarSerial);
            this.gpbConnection.Location = new System.Drawing.Point(6, 371);
            this.gpbConnection.Name = "gpbConnection";
            this.gpbConnection.Size = new System.Drawing.Size(115, 84);
            this.gpbConnection.TabIndex = 53;
            this.gpbConnection.TabStop = false;
            this.gpbConnection.Text = " Conexão ";
            // 
            // btnConectar
            // 
            this.btnConectar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConectar.Location = new System.Drawing.Point(6, 56);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(103, 25);
            this.btnConectar.TabIndex = 3;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // rdbUtilizarUSB
            // 
            this.rdbUtilizarUSB.AutoSize = true;
            this.rdbUtilizarUSB.Checked = true;
            this.rdbUtilizarUSB.Location = new System.Drawing.Point(6, 15);
            this.rdbUtilizarUSB.Name = "rdbUtilizarUSB";
            this.rdbUtilizarUSB.Size = new System.Drawing.Size(47, 17);
            this.rdbUtilizarUSB.TabIndex = 1;
            this.rdbUtilizarUSB.TabStop = true;
            this.rdbUtilizarUSB.Text = "USB";
            this.rdbUtilizarUSB.UseVisualStyleBackColor = true;
            this.rdbUtilizarUSB.CheckedChanged += new System.EventHandler(this.rdbUtilizarUSB_CheckedChanged);
            // 
            // rdbUtilizarSerial
            // 
            this.rdbUtilizarSerial.AutoSize = true;
            this.rdbUtilizarSerial.Location = new System.Drawing.Point(6, 36);
            this.rdbUtilizarSerial.Name = "rdbUtilizarSerial";
            this.rdbUtilizarSerial.Size = new System.Drawing.Size(51, 17);
            this.rdbUtilizarSerial.TabIndex = 2;
            this.rdbUtilizarSerial.Text = "Serial";
            this.rdbUtilizarSerial.UseVisualStyleBackColor = true;
            this.rdbUtilizarSerial.CheckedChanged += new System.EventHandler(this.rdbUtilizarSerial_CheckedChanged);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(17, 56);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(35, 13);
            this.lblPort.TabIndex = 3;
            this.lblPort.Text = "Porta:";
            // 
            // cbxPortaSerial
            // 
            this.cbxPortaSerial.Enabled = false;
            this.cbxPortaSerial.FormattingEnabled = true;
            this.cbxPortaSerial.Location = new System.Drawing.Point(57, 53);
            this.cbxPortaSerial.Name = "cbxPortaSerial";
            this.cbxPortaSerial.Size = new System.Drawing.Size(80, 21);
            this.cbxPortaSerial.TabIndex = 1;
            this.cbxPortaSerial.SelectedIndexChanged += new System.EventHandler(this.cbxPortaSerial_SelectedIndexChanged);
            this.cbxPortaSerial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxPortaSerial_KeyPress);
            // 
            // lblBaudrate
            // 
            this.lblBaudrate.AutoSize = true;
            this.lblBaudrate.Location = new System.Drawing.Point(10, 28);
            this.lblBaudrate.Name = "lblBaudrate";
            this.lblBaudrate.Size = new System.Drawing.Size(61, 13);
            this.lblBaudrate.TabIndex = 2;
            this.lblBaudrate.Text = "Baud Rate:";
            // 
            // cbxBaudrate
            // 
            this.cbxBaudrate.Enabled = false;
            this.cbxBaudrate.FormattingEnabled = true;
            this.cbxBaudrate.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cbxBaudrate.Location = new System.Drawing.Point(73, 25);
            this.cbxBaudrate.Name = "cbxBaudrate";
            this.cbxBaudrate.Size = new System.Drawing.Size(64, 21);
            this.cbxBaudrate.TabIndex = 0;
            this.cbxBaudrate.Text = "38400";
            this.cbxBaudrate.SelectedIndexChanged += new System.EventHandler(this.cbxBaudrate_SelectedIndexChanged);
            this.cbxBaudrate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxBaudrate_KeyPress);
            // 
            // gpbDataSend
            // 
            this.gpbDataSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gpbDataSend.Controls.Add(this.chkEnvLogar);
            this.gpbDataSend.Controls.Add(this.rbtEnvAscii);
            this.gpbDataSend.Controls.Add(this.rbtEnvHexadecimal);
            this.gpbDataSend.Location = new System.Drawing.Point(280, 284);
            this.gpbDataSend.Name = "gpbDataSend";
            this.gpbDataSend.Size = new System.Drawing.Size(95, 84);
            this.gpbDataSend.TabIndex = 52;
            this.gpbDataSend.TabStop = false;
            this.gpbDataSend.Text = " Envio ";
            // 
            // chkEnvLogar
            // 
            this.chkEnvLogar.AutoSize = true;
            this.chkEnvLogar.Checked = true;
            this.chkEnvLogar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnvLogar.Location = new System.Drawing.Point(6, 60);
            this.chkEnvLogar.Name = "chkEnvLogar";
            this.chkEnvLogar.Size = new System.Drawing.Size(78, 17);
            this.chkEnvLogar.TabIndex = 15;
            this.chkEnvLogar.Text = "Logar Env.";
            this.chkEnvLogar.UseVisualStyleBackColor = true;
            this.chkEnvLogar.CheckedChanged += new System.EventHandler(this.chkEnvLogar_CheckedChanged);
            // 
            // rbtEnvAscii
            // 
            this.rbtEnvAscii.AutoSize = true;
            this.rbtEnvAscii.Checked = true;
            this.rbtEnvAscii.Location = new System.Drawing.Point(6, 14);
            this.rbtEnvAscii.Name = "rbtEnvAscii";
            this.rbtEnvAscii.Size = new System.Drawing.Size(47, 17);
            this.rbtEnvAscii.TabIndex = 13;
            this.rbtEnvAscii.TabStop = true;
            this.rbtEnvAscii.Text = "Ascii";
            this.rbtEnvAscii.UseVisualStyleBackColor = true;
            this.rbtEnvAscii.CheckedChanged += new System.EventHandler(this.rbtEnvAscii_CheckedChanged);
            // 
            // rbtEnvHexadecimal
            // 
            this.rbtEnvHexadecimal.AutoSize = true;
            this.rbtEnvHexadecimal.Location = new System.Drawing.Point(6, 36);
            this.rbtEnvHexadecimal.Name = "rbtEnvHexadecimal";
            this.rbtEnvHexadecimal.Size = new System.Drawing.Size(86, 17);
            this.rbtEnvHexadecimal.TabIndex = 14;
            this.rbtEnvHexadecimal.Text = "Hexadecimal";
            this.rbtEnvHexadecimal.UseVisualStyleBackColor = true;
            this.rbtEnvHexadecimal.CheckedChanged += new System.EventHandler(this.rbtEnvHexadecimal_CheckedChanged);
            // 
            // gpbDataReceive
            // 
            this.gpbDataReceive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gpbDataReceive.Controls.Add(this.chkRecLogar);
            this.gpbDataReceive.Controls.Add(this.rbtRecAscii);
            this.gpbDataReceive.Controls.Add(this.rbtRecHexadecimal);
            this.gpbDataReceive.Location = new System.Drawing.Point(179, 284);
            this.gpbDataReceive.Name = "gpbDataReceive";
            this.gpbDataReceive.Size = new System.Drawing.Size(95, 84);
            this.gpbDataReceive.TabIndex = 51;
            this.gpbDataReceive.TabStop = false;
            this.gpbDataReceive.Text = " Recepção ";
            // 
            // chkRecLogar
            // 
            this.chkRecLogar.AutoSize = true;
            this.chkRecLogar.Checked = true;
            this.chkRecLogar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRecLogar.Location = new System.Drawing.Point(6, 60);
            this.chkRecLogar.Name = "chkRecLogar";
            this.chkRecLogar.Size = new System.Drawing.Size(79, 17);
            this.chkRecLogar.TabIndex = 40;
            this.chkRecLogar.Text = "Logar Rec.";
            this.chkRecLogar.UseVisualStyleBackColor = true;
            this.chkRecLogar.CheckedChanged += new System.EventHandler(this.chkRecLogar_CheckedChanged);
            // 
            // rbtRecAscii
            // 
            this.rbtRecAscii.AutoSize = true;
            this.rbtRecAscii.Location = new System.Drawing.Point(6, 14);
            this.rbtRecAscii.Name = "rbtRecAscii";
            this.rbtRecAscii.Size = new System.Drawing.Size(47, 17);
            this.rbtRecAscii.TabIndex = 38;
            this.rbtRecAscii.TabStop = true;
            this.rbtRecAscii.Text = "Ascii";
            this.rbtRecAscii.UseVisualStyleBackColor = true;
            this.rbtRecAscii.CheckedChanged += new System.EventHandler(this.rbtAscii_CheckedChanged);
            // 
            // rbtRecHexadecimal
            // 
            this.rbtRecHexadecimal.AutoSize = true;
            this.rbtRecHexadecimal.Location = new System.Drawing.Point(6, 36);
            this.rbtRecHexadecimal.Name = "rbtRecHexadecimal";
            this.rbtRecHexadecimal.Size = new System.Drawing.Size(86, 17);
            this.rbtRecHexadecimal.TabIndex = 39;
            this.rbtRecHexadecimal.TabStop = true;
            this.rbtRecHexadecimal.Text = "Hexadecimal";
            this.rbtRecHexadecimal.UseVisualStyleBackColor = true;
            this.rbtRecHexadecimal.CheckedChanged += new System.EventHandler(this.rbtHexadecimal_CheckedChanged);
            // 
            // lblListaComandos
            // 
            this.lblListaComandos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblListaComandos.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblListaComandos.Location = new System.Drawing.Point(695, 284);
            this.lblListaComandos.Name = "lblListaComandos";
            this.lblListaComandos.Size = new System.Drawing.Size(255, 13);
            this.lblListaComandos.TabIndex = 50;
            this.lblListaComandos.Text = "Nenhum";
            this.lblListaComandos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(895, 303);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(19, 19);
            this.btnDown.TabIndex = 8;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(877, 303);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(19, 19);
            this.btnUp.TabIndex = 7;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDeletar
            // 
            this.btnDeletar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeletar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletar.Image = ((System.Drawing.Image)(resources.GetObject("btnDeletar.Image")));
            this.btnDeletar.Location = new System.Drawing.Point(931, 303);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(19, 19);
            this.btnDeletar.TabIndex = 10;
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdicionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionar.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionar.Image")));
            this.btnAdicionar.Location = new System.Drawing.Point(913, 303);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(19, 19);
            this.btnAdicionar.TabIndex = 9;
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // txtDados
            // 
            this.txtDados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDados.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDados.Location = new System.Drawing.Point(6, 3);
            this.txtDados.Name = "txtDados";
            this.txtDados.Size = new System.Drawing.Size(676, 275);
            this.txtDados.TabIndex = 43;
            this.txtDados.Text = "txtDados";
            this.txtDados.WordWrap = false;
            // 
            // gpbLog
            // 
            this.gpbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gpbLog.Controls.Add(this.chkQuebrarLinha);
            this.gpbLog.Controls.Add(this.chkData);
            this.gpbLog.Controls.Add(this.chkMilisegundos);
            this.gpbLog.Controls.Add(this.chkHora);
            this.gpbLog.Controls.Add(this.btnPausar);
            this.gpbLog.Controls.Add(this.btnMarcar);
            this.gpbLog.Controls.Add(this.btnLimpar);
            this.gpbLog.Location = new System.Drawing.Point(6, 284);
            this.gpbLog.Name = "gpbLog";
            this.gpbLog.Size = new System.Drawing.Size(167, 84);
            this.gpbLog.TabIndex = 39;
            this.gpbLog.TabStop = false;
            this.gpbLog.Text = " Log ";
            // 
            // chkQuebrarLinha
            // 
            this.chkQuebrarLinha.AutoSize = true;
            this.chkQuebrarLinha.Location = new System.Drawing.Point(6, 63);
            this.chkQuebrarLinha.Name = "chkQuebrarLinha";
            this.chkQuebrarLinha.Size = new System.Drawing.Size(93, 17);
            this.chkQuebrarLinha.TabIndex = 27;
            this.chkQuebrarLinha.Text = "Quebrar Linha";
            this.chkQuebrarLinha.UseVisualStyleBackColor = true;
            this.chkQuebrarLinha.CheckedChanged += new System.EventHandler(this.chkQuebrarLinha_CheckedChanged);
            // 
            // chkData
            // 
            this.chkData.AutoSize = true;
            this.chkData.Location = new System.Drawing.Point(6, 15);
            this.chkData.Name = "chkData";
            this.chkData.Size = new System.Drawing.Size(49, 17);
            this.chkData.TabIndex = 24;
            this.chkData.Text = "Data";
            this.chkData.UseVisualStyleBackColor = true;
            this.chkData.CheckedChanged += new System.EventHandler(this.chkData_CheckedChanged);
            // 
            // chkMilisegundos
            // 
            this.chkMilisegundos.AutoSize = true;
            this.chkMilisegundos.Location = new System.Drawing.Point(6, 47);
            this.chkMilisegundos.Name = "chkMilisegundos";
            this.chkMilisegundos.Size = new System.Drawing.Size(87, 17);
            this.chkMilisegundos.TabIndex = 26;
            this.chkMilisegundos.Text = "Milisegundos";
            this.chkMilisegundos.UseVisualStyleBackColor = true;
            this.chkMilisegundos.CheckedChanged += new System.EventHandler(this.chkMilisegundos_CheckedChanged);
            // 
            // chkHora
            // 
            this.chkHora.AutoSize = true;
            this.chkHora.Location = new System.Drawing.Point(6, 31);
            this.chkHora.Name = "chkHora";
            this.chkHora.Size = new System.Drawing.Size(49, 17);
            this.chkHora.TabIndex = 25;
            this.chkHora.Text = "Hora";
            this.chkHora.UseVisualStyleBackColor = true;
            this.chkHora.CheckedChanged += new System.EventHandler(this.chkHora_CheckedChanged);
            // 
            // btnPausar
            // 
            this.btnPausar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPausar.Location = new System.Drawing.Point(101, 56);
            this.btnPausar.Name = "btnPausar";
            this.btnPausar.Size = new System.Drawing.Size(62, 25);
            this.btnPausar.TabIndex = 30;
            this.btnPausar.Text = "Pausar";
            this.btnPausar.UseVisualStyleBackColor = true;
            this.btnPausar.Click += new System.EventHandler(this.btnPausar_Click);
            // 
            // btnMarcar
            // 
            this.btnMarcar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMarcar.Location = new System.Drawing.Point(101, 32);
            this.btnMarcar.Name = "btnMarcar";
            this.btnMarcar.Size = new System.Drawing.Size(62, 25);
            this.btnMarcar.TabIndex = 29;
            this.btnMarcar.Text = "Marcar";
            this.btnMarcar.UseVisualStyleBackColor = true;
            this.btnMarcar.Click += new System.EventHandler(this.btnMarcar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLimpar.Location = new System.Drawing.Point(101, 8);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(62, 25);
            this.btnLimpar.TabIndex = 28;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // lstComandos
            // 
            this.lstComandos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstComandos.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstComandos.FormattingEnabled = true;
            this.lstComandos.ItemHeight = 15;
            this.lstComandos.Location = new System.Drawing.Point(688, 3);
            this.lstComandos.Name = "lstComandos";
            this.lstComandos.Size = new System.Drawing.Size(267, 274);
            this.lstComandos.TabIndex = 30;
            this.lstComandos.SelectedIndexChanged += new System.EventHandler(this.lstComandos_SelectedIndexChanged);
            this.lstComandos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstComandos_KeyPress);
            // 
            // txtEnviar
            // 
            this.txtEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEnviar.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnviar.Location = new System.Drawing.Point(695, 325);
            this.txtEnviar.Name = "txtEnviar";
            this.txtEnviar.Size = new System.Drawing.Size(255, 21);
            this.txtEnviar.TabIndex = 4;
            this.txtEnviar.TextChanged += new System.EventHandler(this.txtEnviar_TextChanged);
            this.txtEnviar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEnviar_KeyPress);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Location = new System.Drawing.Point(825, 347);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(125, 37);
            this.btnEnviar.TabIndex = 5;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnRestaurarPadrao
            // 
            this.btnRestaurarPadrao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRestaurarPadrao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestaurarPadrao.Location = new System.Drawing.Point(10, 51);
            this.btnRestaurarPadrao.Name = "btnRestaurarPadrao";
            this.btnRestaurarPadrao.Size = new System.Drawing.Size(131, 25);
            this.btnRestaurarPadrao.TabIndex = 43;
            this.btnRestaurarPadrao.Text = "Restaurar Padrões";
            this.btnRestaurarPadrao.UseVisualStyleBackColor = true;
            this.btnRestaurarPadrao.Click += new System.EventHandler(this.btnRestaurarPadrao_Click);
            // 
            // gpbSendPrefix
            // 
            this.gpbSendPrefix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbSendPrefix.Controls.Add(this.rbtInicioNenhum);
            this.gpbSendPrefix.Controls.Add(this.rbtInicioEnter);
            this.gpbSendPrefix.Controls.Add(this.rbtInicioStx);
            this.gpbSendPrefix.Controls.Add(this.rbtInicioEsc);
            this.gpbSendPrefix.Location = new System.Drawing.Point(688, 385);
            this.gpbSendPrefix.Name = "gpbSendPrefix";
            this.gpbSendPrefix.Size = new System.Drawing.Size(267, 34);
            this.gpbSendPrefix.TabIndex = 41;
            this.gpbSendPrefix.TabStop = false;
            this.gpbSendPrefix.Text = " Prefixo ";
            // 
            // rbtInicioNenhum
            // 
            this.rbtInicioNenhum.AutoSize = true;
            this.rbtInicioNenhum.Checked = true;
            this.rbtInicioNenhum.Location = new System.Drawing.Point(197, 12);
            this.rbtInicioNenhum.Name = "rbtInicioNenhum";
            this.rbtInicioNenhum.Size = new System.Drawing.Size(65, 17);
            this.rbtInicioNenhum.TabIndex = 19;
            this.rbtInicioNenhum.TabStop = true;
            this.rbtInicioNenhum.Text = "Nenhum";
            this.rbtInicioNenhum.UseVisualStyleBackColor = true;
            this.rbtInicioNenhum.CheckedChanged += new System.EventHandler(this.CheckStringInicial);
            // 
            // rbtInicioEnter
            // 
            this.rbtInicioEnter.AutoSize = true;
            this.rbtInicioEnter.Location = new System.Drawing.Point(137, 13);
            this.rbtInicioEnter.Name = "rbtInicioEnter";
            this.rbtInicioEnter.Size = new System.Drawing.Size(50, 17);
            this.rbtInicioEnter.TabIndex = 18;
            this.rbtInicioEnter.Text = "Enter";
            this.rbtInicioEnter.UseVisualStyleBackColor = true;
            this.rbtInicioEnter.CheckedChanged += new System.EventHandler(this.CheckStringInicial);
            // 
            // rbtInicioStx
            // 
            this.rbtInicioStx.AutoSize = true;
            this.rbtInicioStx.Location = new System.Drawing.Point(81, 13);
            this.rbtInicioStx.Name = "rbtInicioStx";
            this.rbtInicioStx.Size = new System.Drawing.Size(40, 17);
            this.rbtInicioStx.TabIndex = 17;
            this.rbtInicioStx.Text = "Stx";
            this.rbtInicioStx.UseVisualStyleBackColor = true;
            this.rbtInicioStx.CheckedChanged += new System.EventHandler(this.CheckStringInicial);
            // 
            // rbtInicioEsc
            // 
            this.rbtInicioEsc.AutoSize = true;
            this.rbtInicioEsc.Location = new System.Drawing.Point(6, 13);
            this.rbtInicioEsc.Name = "rbtInicioEsc";
            this.rbtInicioEsc.Size = new System.Drawing.Size(43, 17);
            this.rbtInicioEsc.TabIndex = 16;
            this.rbtInicioEsc.Text = "Esc";
            this.rbtInicioEsc.UseVisualStyleBackColor = true;
            this.rbtInicioEsc.CheckedChanged += new System.EventHandler(this.CheckStringInicial);
            // 
            // gpbSendSuffix
            // 
            this.gpbSendSuffix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbSendSuffix.Controls.Add(this.rbtFimNenhum);
            this.gpbSendSuffix.Controls.Add(this.rbtFimEnter);
            this.gpbSendSuffix.Controls.Add(this.rbtFimEtx);
            this.gpbSendSuffix.Controls.Add(this.rbtFimEsc);
            this.gpbSendSuffix.Location = new System.Drawing.Point(688, 421);
            this.gpbSendSuffix.Name = "gpbSendSuffix";
            this.gpbSendSuffix.Size = new System.Drawing.Size(267, 34);
            this.gpbSendSuffix.TabIndex = 42;
            this.gpbSendSuffix.TabStop = false;
            this.gpbSendSuffix.Text = " Sufixo ";
            // 
            // rbtFimNenhum
            // 
            this.rbtFimNenhum.AutoSize = true;
            this.rbtFimNenhum.Location = new System.Drawing.Point(197, 15);
            this.rbtFimNenhum.Name = "rbtFimNenhum";
            this.rbtFimNenhum.Size = new System.Drawing.Size(65, 17);
            this.rbtFimNenhum.TabIndex = 23;
            this.rbtFimNenhum.Text = "Nenhum";
            this.rbtFimNenhum.UseVisualStyleBackColor = true;
            this.rbtFimNenhum.CheckedChanged += new System.EventHandler(this.CheckStringFinal);
            // 
            // rbtFimEnter
            // 
            this.rbtFimEnter.AutoSize = true;
            this.rbtFimEnter.Checked = true;
            this.rbtFimEnter.Location = new System.Drawing.Point(137, 14);
            this.rbtFimEnter.Name = "rbtFimEnter";
            this.rbtFimEnter.Size = new System.Drawing.Size(50, 17);
            this.rbtFimEnter.TabIndex = 22;
            this.rbtFimEnter.TabStop = true;
            this.rbtFimEnter.Text = "Enter";
            this.rbtFimEnter.UseVisualStyleBackColor = true;
            this.rbtFimEnter.CheckedChanged += new System.EventHandler(this.CheckStringFinal);
            // 
            // rbtFimEtx
            // 
            this.rbtFimEtx.AutoSize = true;
            this.rbtFimEtx.Location = new System.Drawing.Point(81, 14);
            this.rbtFimEtx.Name = "rbtFimEtx";
            this.rbtFimEtx.Size = new System.Drawing.Size(40, 17);
            this.rbtFimEtx.TabIndex = 21;
            this.rbtFimEtx.Text = "Etx";
            this.rbtFimEtx.UseVisualStyleBackColor = true;
            this.rbtFimEtx.CheckedChanged += new System.EventHandler(this.CheckStringFinal);
            // 
            // rbtFimEsc
            // 
            this.rbtFimEsc.AutoSize = true;
            this.rbtFimEsc.Location = new System.Drawing.Point(7, 14);
            this.rbtFimEsc.Name = "rbtFimEsc";
            this.rbtFimEsc.Size = new System.Drawing.Size(43, 17);
            this.rbtFimEsc.TabIndex = 20;
            this.rbtFimEsc.Text = "Esc";
            this.rbtFimEsc.UseVisualStyleBackColor = true;
            this.rbtFimEsc.CheckedChanged += new System.EventHandler(this.CheckStringFinal);
            // 
            // gpbLogNewLine
            // 
            this.gpbLogNewLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gpbLogNewLine.Controls.Add(this.rbt32Char);
            this.gpbLogNewLine.Controls.Add(this.rbt16Char);
            this.gpbLogNewLine.Controls.Add(this.txtCaractere);
            this.gpbLogNewLine.Controls.Add(this.rbtDecimal);
            this.gpbLogNewLine.Controls.Add(this.rbt0);
            this.gpbLogNewLine.Controls.Add(this.rbtr);
            this.gpbLogNewLine.Controls.Add(this.rbtn);
            this.gpbLogNewLine.Location = new System.Drawing.Point(381, 284);
            this.gpbLogNewLine.Name = "gpbLogNewLine";
            this.gpbLogNewLine.Size = new System.Drawing.Size(144, 84);
            this.gpbLogNewLine.TabIndex = 40;
            this.gpbLogNewLine.TabStop = false;
            this.gpbLogNewLine.Text = " Finalizador para Log ";
            // 
            // rbt32Char
            // 
            this.rbt32Char.AutoSize = true;
            this.rbt32Char.Location = new System.Drawing.Point(46, 59);
            this.rbt32Char.Name = "rbt32Char";
            this.rbt32Char.Size = new System.Drawing.Size(91, 17);
            this.rbt32Char.TabIndex = 37;
            this.rbt32Char.Text = "32 Caracteres";
            this.rbt32Char.UseVisualStyleBackColor = true;
            this.rbt32Char.CheckedChanged += new System.EventHandler(this.rbt32Char_CheckedChanged);
            // 
            // rbt16Char
            // 
            this.rbt16Char.AutoSize = true;
            this.rbt16Char.Location = new System.Drawing.Point(45, 37);
            this.rbt16Char.Name = "rbt16Char";
            this.rbt16Char.Size = new System.Drawing.Size(91, 17);
            this.rbt16Char.TabIndex = 36;
            this.rbt16Char.Text = "16 Caracteres";
            this.rbt16Char.UseVisualStyleBackColor = true;
            this.rbt16Char.CheckedChanged += new System.EventHandler(this.rbt16Char_CheckedChanged);
            // 
            // txtCaractere
            // 
            this.txtCaractere.Location = new System.Drawing.Point(108, 14);
            this.txtCaractere.MaxLength = 3;
            this.txtCaractere.Name = "txtCaractere";
            this.txtCaractere.Size = new System.Drawing.Size(29, 20);
            this.txtCaractere.TabIndex = 35;
            this.txtCaractere.Text = "10";
            this.txtCaractere.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCaractere.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCaractere_KeyPress);
            // 
            // rbtDecimal
            // 
            this.rbtDecimal.AutoSize = true;
            this.rbtDecimal.Location = new System.Drawing.Point(45, 15);
            this.rbtDecimal.Name = "rbtDecimal";
            this.rbtDecimal.Size = new System.Drawing.Size(66, 17);
            this.rbtDecimal.TabIndex = 34;
            this.rbtDecimal.Text = "Decimal:";
            this.rbtDecimal.UseVisualStyleBackColor = true;
            this.rbtDecimal.CheckedChanged += new System.EventHandler(this.rbtDecimal_CheckedChanged);
            // 
            // rbt0
            // 
            this.rbt0.AutoSize = true;
            this.rbt0.Location = new System.Drawing.Point(6, 59);
            this.rbt0.Name = "rbt0";
            this.rbt0.Size = new System.Drawing.Size(36, 17);
            this.rbt0.TabIndex = 33;
            this.rbt0.Text = "\\0";
            this.rbt0.UseVisualStyleBackColor = true;
            this.rbt0.CheckedChanged += new System.EventHandler(this.rbt0_CheckedChanged);
            // 
            // rbtr
            // 
            this.rbtr.AutoSize = true;
            this.rbtr.Location = new System.Drawing.Point(6, 37);
            this.rbtr.Name = "rbtr";
            this.rbtr.Size = new System.Drawing.Size(33, 17);
            this.rbtr.TabIndex = 32;
            this.rbtr.Text = "\\r";
            this.rbtr.UseVisualStyleBackColor = true;
            this.rbtr.CheckedChanged += new System.EventHandler(this.rbtr_CheckedChanged);
            // 
            // rbtn
            // 
            this.rbtn.AutoSize = true;
            this.rbtn.Checked = true;
            this.rbtn.Location = new System.Drawing.Point(6, 15);
            this.rbtn.Name = "rbtn";
            this.rbtn.Size = new System.Drawing.Size(36, 17);
            this.rbtn.TabIndex = 31;
            this.rbtn.TabStop = true;
            this.rbtn.Text = "\\n";
            this.rbtn.UseVisualStyleBackColor = true;
            this.rbtn.CheckedChanged += new System.EventHandler(this.rbtn_CheckedChanged);
            // 
            // gpbConfig
            // 
            this.gpbConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gpbConfig.Controls.Add(this.btnRestaurarPadrao);
            this.gpbConfig.Controls.Add(this.btnFonte);
            this.gpbConfig.Location = new System.Drawing.Point(531, 284);
            this.gpbConfig.Name = "gpbConfig";
            this.gpbConfig.Size = new System.Drawing.Size(151, 84);
            this.gpbConfig.TabIndex = 36;
            this.gpbConfig.TabStop = false;
            this.gpbConfig.Text = " Configurações ";
            // 
            // btnFonte
            // 
            this.btnFonte.Image = ((System.Drawing.Image)(resources.GetObject("btnFonte.Image")));
            this.btnFonte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFonte.Location = new System.Drawing.Point(11, 25);
            this.btnFonte.Name = "btnFonte";
            this.btnFonte.Size = new System.Drawing.Size(130, 23);
            this.btnFonte.TabIndex = 0;
            this.btnFonte.Text = "Mudar Estilo do Texto";
            this.btnFonte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFonte.UseVisualStyleBackColor = true;
            this.btnFonte.Click += new System.EventHandler(this.btnFonte_Click);
            // 
            // gpbUSBCDC
            // 
            this.gpbUSBCDC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gpbUSBCDC.Controls.Add(this.lblUsbDevice);
            this.gpbUSBCDC.Controls.Add(this.cbxDevice);
            this.gpbUSBCDC.Controls.Add(this.PIDTextBox);
            this.gpbUSBCDC.Controls.Add(this.VIDTextBox);
            this.gpbUSBCDC.Controls.Add(this.VIDLabel);
            this.gpbUSBCDC.Controls.Add(this.PIDLabel);
            this.gpbUSBCDC.Location = new System.Drawing.Point(280, 371);
            this.gpbUSBCDC.Name = "gpbUSBCDC";
            this.gpbUSBCDC.Size = new System.Drawing.Size(245, 84);
            this.gpbUSBCDC.TabIndex = 28;
            this.gpbUSBCDC.TabStop = false;
            this.gpbUSBCDC.Text = " USB CDC ";
            // 
            // lblUsbDevice
            // 
            this.lblUsbDevice.AutoSize = true;
            this.lblUsbDevice.Location = new System.Drawing.Point(6, 28);
            this.lblUsbDevice.Name = "lblUsbDevice";
            this.lblUsbDevice.Size = new System.Drawing.Size(49, 13);
            this.lblUsbDevice.TabIndex = 31;
            this.lblUsbDevice.Text = "DEVICE:";
            // 
            // cbxDevice
            // 
            this.cbxDevice.FormattingEnabled = true;
            this.cbxDevice.Location = new System.Drawing.Point(61, 25);
            this.cbxDevice.Name = "cbxDevice";
            this.cbxDevice.Size = new System.Drawing.Size(172, 21);
            this.cbxDevice.TabIndex = 30;
            this.cbxDevice.SelectedIndexChanged += new System.EventHandler(this.cbxDevice_SelectedIndexChanged);
            this.cbxDevice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxDevice_KeyPress);
            // 
            // PIDTextBox
            // 
            this.PIDTextBox.Enabled = false;
            this.PIDTextBox.Location = new System.Drawing.Point(169, 53);
            this.PIDTextBox.Name = "PIDTextBox";
            this.PIDTextBox.Size = new System.Drawing.Size(64, 20);
            this.PIDTextBox.TabIndex = 29;
            this.PIDTextBox.TextChanged += new System.EventHandler(this.PIDTextBox_TextChanged);
            // 
            // VIDTextBox
            // 
            this.VIDTextBox.Enabled = false;
            this.VIDTextBox.Location = new System.Drawing.Point(43, 53);
            this.VIDTextBox.Name = "VIDTextBox";
            this.VIDTextBox.Size = new System.Drawing.Size(64, 20);
            this.VIDTextBox.TabIndex = 28;
            this.VIDTextBox.TextChanged += new System.EventHandler(this.VIDTextBox_TextChanged);
            // 
            // chkSalvarLog
            // 
            this.chkSalvarLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSalvarLog.AutoSize = true;
            this.chkSalvarLog.Checked = true;
            this.chkSalvarLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSalvarLog.Location = new System.Drawing.Point(127, 465);
            this.chkSalvarLog.Name = "chkSalvarLog";
            this.chkSalvarLog.Size = new System.Drawing.Size(92, 17);
            this.chkSalvarLog.TabIndex = 34;
            this.chkSalvarLog.Text = "chkSalvarLog";
            this.chkSalvarLog.UseVisualStyleBackColor = true;
            this.chkSalvarLog.CheckedChanged += new System.EventHandler(this.chkSalvarLog_CheckedChanged);
            // 
            // tmrEnvioAuto
            // 
            this.tmrEnvioAuto.Tick += new System.EventHandler(this.tmrEnvioAuto_Tick);
            // 
            // lblCOM
            // 
            this.lblCOM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCOM.AutoSize = true;
            this.lblCOM.Location = new System.Drawing.Point(3, 466);
            this.lblCOM.Name = "lblCOM";
            this.lblCOM.Size = new System.Drawing.Size(41, 13);
            this.lblCOM.TabIndex = 35;
            this.lblCOM.Text = "lblCOM";
            // 
            // gpbSerial
            // 
            this.gpbSerial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gpbSerial.Controls.Add(this.cbxBaudrate);
            this.gpbSerial.Controls.Add(this.lblPort);
            this.gpbSerial.Controls.Add(this.lblBaudrate);
            this.gpbSerial.Controls.Add(this.cbxPortaSerial);
            this.gpbSerial.Location = new System.Drawing.Point(127, 371);
            this.gpbSerial.Name = "gpbSerial";
            this.gpbSerial.Size = new System.Drawing.Size(147, 84);
            this.gpbSerial.TabIndex = 54;
            this.gpbSerial.TabStop = false;
            this.gpbSerial.Text = " Serial ";
            // 
            // gpbControl
            // 
            this.gpbControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gpbControl.Controls.Add(this.chkDTR);
            this.gpbControl.Controls.Add(this.chkRTS);
            this.gpbControl.Controls.Add(this.chkDSR);
            this.gpbControl.Controls.Add(this.chkCTS);
            this.gpbControl.Location = new System.Drawing.Point(531, 371);
            this.gpbControl.Name = "gpbControl";
            this.gpbControl.Size = new System.Drawing.Size(151, 84);
            this.gpbControl.TabIndex = 44;
            this.gpbControl.TabStop = false;
            this.gpbControl.Text = " Controle ";
            // 
            // chkDTR
            // 
            this.chkDTR.AutoSize = true;
            this.chkDTR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDTR.Location = new System.Drawing.Point(10, 52);
            this.chkDTR.Name = "chkDTR";
            this.chkDTR.Size = new System.Drawing.Size(61, 24);
            this.chkDTR.TabIndex = 38;
            this.chkDTR.Text = "DTR";
            this.chkDTR.UseVisualStyleBackColor = true;
            this.chkDTR.CheckedChanged += new System.EventHandler(this.chkDTR_CheckedChanged);
            // 
            // chkRTS
            // 
            this.chkRTS.AutoSize = true;
            this.chkRTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRTS.Location = new System.Drawing.Point(11, 22);
            this.chkRTS.Name = "chkRTS";
            this.chkRTS.Size = new System.Drawing.Size(60, 24);
            this.chkRTS.TabIndex = 37;
            this.chkRTS.Text = "RTS";
            this.chkRTS.UseVisualStyleBackColor = true;
            this.chkRTS.CheckedChanged += new System.EventHandler(this.chkRTS_CheckedChanged);
            // 
            // chkDSR
            // 
            this.chkDSR.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkDSR.AutoCheck = false;
            this.chkDSR.AutoSize = true;
            this.chkDSR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDSR.Location = new System.Drawing.Point(83, 48);
            this.chkDSR.Name = "chkDSR";
            this.chkDSR.Size = new System.Drawing.Size(58, 30);
            this.chkDSR.TabIndex = 26;
            this.chkDSR.Text = " DSR";
            this.chkDSR.UseVisualStyleBackColor = true;
            // 
            // chkCTS
            // 
            this.chkCTS.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkCTS.AutoCheck = false;
            this.chkCTS.AutoSize = true;
            this.chkCTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCTS.Location = new System.Drawing.Point(83, 18);
            this.chkCTS.Name = "chkCTS";
            this.chkCTS.Size = new System.Drawing.Size(58, 30);
            this.chkCTS.TabIndex = 25;
            this.chkCTS.Text = " CTS ";
            this.chkCTS.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 484);
            this.Controls.Add(this.gpbControl);
            this.Controls.Add(this.gpbSerial);
            this.Controls.Add(this.gpbConfig);
            this.Controls.Add(this.gpbUSBCDC);
            this.Controls.Add(this.gpbSendSuffix);
            this.Controls.Add(this.txtDados);
            this.Controls.Add(this.cbxEnvioAutoTempo);
            this.Controls.Add(this.lblCOM);
            this.Controls.Add(this.chkEnvioAuto);
            this.Controls.Add(this.gpbSendPrefix);
            this.Controls.Add(this.btnCarregarListaComandos);
            this.Controls.Add(this.chkSalvarLog);
            this.Controls.Add(this.lblListaComandos);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.sstFooter);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.gpbConnection);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.gpbLogNewLine);
            this.Controls.Add(this.gpbLog);
            this.Controls.Add(this.lstComandos);
            this.Controls.Add(this.txtEnviar);
            this.Controls.Add(this.gpbDataReceive);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.gpbDataSend);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "USBCDC.Terminal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.gpbConnection.ResumeLayout(false);
            this.gpbConnection.PerformLayout();
            this.gpbDataSend.ResumeLayout(false);
            this.gpbDataSend.PerformLayout();
            this.gpbDataReceive.ResumeLayout(false);
            this.gpbDataReceive.PerformLayout();
            this.gpbLog.ResumeLayout(false);
            this.gpbLog.PerformLayout();
            this.gpbSendPrefix.ResumeLayout(false);
            this.gpbSendPrefix.PerformLayout();
            this.gpbSendSuffix.ResumeLayout(false);
            this.gpbSendSuffix.PerformLayout();
            this.gpbLogNewLine.ResumeLayout(false);
            this.gpbLogNewLine.PerformLayout();
            this.gpbConfig.ResumeLayout(false);
            this.gpbUSBCDC.ResumeLayout(false);
            this.gpbUSBCDC.PerformLayout();
            this.gpbSerial.ResumeLayout(false);
            this.gpbSerial.PerformLayout();
            this.gpbControl.ResumeLayout(false);
            this.gpbControl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private USBClassLibrary.USBClass USBPort;
        private USBClassLibrary.USBClass.DeviceProperties USBDeviceProperties;
        bool MyUSBDeviceConnected;
        private const uint MyDeviceVID =0x14D8;     // dummy
        private const uint MyDevicePID = 0x000A;    // dummy
        private System.Windows.Forms.StatusStrip sstFooter;
        private System.Windows.Forms.ToolStripStatusLabel ConnectionToolStripStatusLabel;
        private System.Windows.Forms.Label VIDLabel;
        private System.Windows.Forms.Label PIDLabel;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.IO.Ports.SerialPort serial;
        private System.Windows.Forms.ListBox lstComandos;
        private System.Windows.Forms.GroupBox gpbUSBCDC;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtEnviar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.CheckBox chkSalvarLog;
        private System.Windows.Forms.Button btnMarcar;
        private System.Windows.Forms.TextBox PIDTextBox;
        private System.Windows.Forms.TextBox VIDTextBox;
        private System.Windows.Forms.CheckBox chkMilisegundos;
        private System.Windows.Forms.CheckBox chkHora;
        private System.Windows.Forms.CheckBox chkData;
        private System.Windows.Forms.GroupBox gpbLogNewLine;
        private System.Windows.Forms.TextBox txtCaractere;
        private System.Windows.Forms.RadioButton rbtDecimal;
        private System.Windows.Forms.RadioButton rbt0;
        private System.Windows.Forms.RadioButton rbtr;
        private System.Windows.Forms.RadioButton rbtn;
        private System.Windows.Forms.GroupBox gpbLog;
        private System.Windows.Forms.RadioButton rbt16Char;
        private System.Windows.Forms.RadioButton rbtRecHexadecimal;
        private System.Windows.Forms.RadioButton rbtRecAscii;
        private System.Windows.Forms.GroupBox gpbSendSuffix ;
        private System.Windows.Forms.RadioButton rbtFimNenhum;
        private System.Windows.Forms.RadioButton rbtFimEnter;
        private System.Windows.Forms.RadioButton rbtFimEtx;
        private System.Windows.Forms.RadioButton rbtFimEsc;
        private System.Windows.Forms.GroupBox gpbSendPrefix;
        private System.Windows.Forms.RadioButton rbtInicioNenhum;
        private System.Windows.Forms.RadioButton rbtInicioEnter;
        private System.Windows.Forms.RadioButton rbtInicioStx;
        private System.Windows.Forms.RadioButton rbtInicioEsc;
        private System.Windows.Forms.RadioButton rdbUtilizarSerial;
        private System.Windows.Forms.RadioButton rdbUtilizarUSB;
        private System.Windows.Forms.ComboBox cbxBaudrate;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblBaudrate;
        private System.Windows.Forms.ComboBox cbxPortaSerial;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.RadioButton rbt32Char;
        private System.Windows.Forms.RichTextBox txtDados;
        private System.Windows.Forms.CheckBox chkQuebrarLinha;
        private System.Windows.Forms.Button btnPausar;
        private System.Windows.Forms.Button btnCarregarListaComandos;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Label lblListaComandos;
        private System.Windows.Forms.GroupBox gpbDataReceive;
        private System.Windows.Forms.GroupBox gpbDataSend;
        private System.Windows.Forms.RadioButton rbtEnvAscii;
        private System.Windows.Forms.RadioButton rbtEnvHexadecimal;
        private System.Windows.Forms.CheckBox chkRecLogar;
        private System.Windows.Forms.CheckBox chkEnvLogar;
        private System.Windows.Forms.GroupBox gpbConnection;
        private System.Windows.Forms.GroupBox gpbConfig;
        private System.Windows.Forms.Button btnFonte;
        private System.Windows.Forms.ComboBox cbxEnvioAutoTempo;
        private System.Windows.Forms.CheckBox chkEnvioAuto;
        private System.Windows.Forms.Timer tmrEnvioAuto;
        private System.Windows.Forms.FolderBrowserDialog fbdFileOpen;
        private System.Windows.Forms.Label lblUsbDevice;
        private System.Windows.Forms.ComboBox cbxDevice;
        private System.Windows.Forms.Label lblCOM;
        private System.Windows.Forms.Button btnRestaurarPadrao;
        private System.Windows.Forms.GroupBox gpbSerial;
        private System.Windows.Forms.GroupBox gpbControl;
        private System.Windows.Forms.CheckBox chkDSR;
        private System.Windows.Forms.CheckBox chkCTS;
        private System.Windows.Forms.CheckBox chkDTR;
        private System.Windows.Forms.CheckBox chkRTS;
    }
}

