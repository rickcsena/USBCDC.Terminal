using DialogBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using USBClassLibrary;

// Tipo de log
public enum LOG_TIPO : int
{
    INTERFACE = 0,
    RECEBIMETO,
    ENVIO,
};

namespace USB_CDC_TERMINAL
{
    public partial class Main : Form
    {
        string strLogPath;
        string DataHora = "MM/dd/yyyy hh:mm:ss fff";
        byte byUltimo = 0;
        int countChars = 0;
        string strInicial = "";
        string strFinal = "";
        bool bIsInicializacao = true;
        Color BackColorBackup;
        
        // Para tratar os dados seriais recebidos
        StringBuilder serialDataRx = new StringBuilder();
        Mutex serialDataMutex = new Mutex();
        System.Windows.Forms.Timer tmrUpdateData;

        public Main()
        {
            InitializeComponent();

            BackColorBackup = btnPausar.BackColor;

            // Estados iniciais padrão
            this.Text = Application.ProductName.ToString() + " " + Application.ProductVersion.ToString();
            this.MinimumSize = this.Size;
            lblCOM.Text = "";
            txtDados.Text = "";

            // Checa diretorio de log
            if (!Directory.Exists(@"log"))
            {
                Directory.CreateDirectory(@"log");
            }
            
            // Carrega estados salvos
            chkData.Checked = USBCDC.Terminal.Settings1.Default.bImprimeData;
            chkHora.Checked = USBCDC.Terminal.Settings1.Default.bImprimeHora;
            chkMilisegundos.Checked = USBCDC.Terminal.Settings1.Default.bImprimeMilisegundos;
            chkQuebrarLinha.Checked = USBCDC.Terminal.Settings1.Default.bQuebrarLinha;
            rbtRecAscii.Checked = USBCDC.Terminal.Settings1.Default.bRbtRecAscii;
            rbtRecHexadecimal.Checked = USBCDC.Terminal.Settings1.Default.bRbtRecHexadecimal;
            cbxBaudrate.Text = USBCDC.Terminal.Settings1.Default.BaudRate;
            if (!cbxBaudrate.Items.Contains(cbxBaudrate.Text))
            {
                cbxBaudrate.Items.Add(cbxBaudrate.Text);
                var index = cbxBaudrate.Items.IndexOf(cbxBaudrate.Text);
                cbxBaudrate.SelectedIndex = index;
            }
            rbtEnvAscii.Checked = USBCDC.Terminal.Settings1.Default.brbtEnvAscii;
            rbtEnvHexadecimal.Checked = USBCDC.Terminal.Settings1.Default.brbtEnvHexadecimal;
            txtEnviar.Text = USBCDC.Terminal.Settings1.Default.strDadosEnviar;
            chkEnvLogar.Checked = USBCDC.Terminal.Settings1.Default.bchkEnvLogar;
            chkRecLogar.Checked = USBCDC.Terminal.Settings1.Default.bchkRecLogar;
            txtDados.Font = lstComandos.Font = USBCDC.Terminal.Settings1.Default.fontTextos;
            txtDados.ForeColor = txtEnviar.ForeColor = lstComandos.ForeColor = USBCDC.Terminal.Settings1.Default.colorTextos;
            chkEnvioAuto.Checked = USBCDC.Terminal.Settings1.Default.bEnvioAuto;
            cbxEnvioAutoTempo.Text = USBCDC.Terminal.Settings1.Default.EnvioAutoTempo;

            CheckImprimir();
            SalvarLog();
            chkSalvarLog.Checked = USBCDC.Terminal.Settings1.Default.SalvarLog;
            if (!File.Exists(strLogPath))
            {
                LogarData(LOG_TIPO.INTERFACE, new StringBuilder("\nInterface: Inicializado - " + Application.ProductName.ToString() + " " + Application.ProductVersion.ToString() + "\n"));
            }

            // Inicializa lista de dispositivos USB CDC
            try
            {
                cbxDevice.DataSource = USBCDC.Terminal.Settings1.Default.usbCDCdevice;
                cbxDevice.Text = USBCDC.Terminal.Settings1.Default.usbCDCdeviceLast;
                DeviceChanged();
            }
            catch
            {
                USBCDC.Terminal.Settings1.Default.Reset();
                USBCDC.Terminal.Settings1.Default.Save();
                return;
            }

            // Abre lista de comandos
            if (File.Exists(USBCDC.Terminal.Settings1.Default.ArquivoListaComando))
            {
                using (StreamReader texto = new StreamReader(USBCDC.Terminal.Settings1.Default.ArquivoListaComando))
                {
                    string strDados;
                    while ((strDados = texto.ReadLine()) != null)
                    {
                        lstComandos.Items.Add(strDados);
                    }
                    if (USBCDC.Terminal.Settings1.Default.ArquivoListaComando.Length > 37)
                        lblListaComandos.Text = USBCDC.Terminal.Settings1.Default.ArquivoListaComando.Substring(0, 3) + "..... " + USBCDC.Terminal.Settings1.Default.ArquivoListaComando.Substring(USBCDC.Terminal.Settings1.Default.ArquivoListaComando.Length - 37);
                    else
                        lblListaComandos.Text = USBCDC.Terminal.Settings1.Default.ArquivoListaComando;
                    LogarData(LOG_TIPO.INTERFACE, new StringBuilder("Interface# Arquivo de Comandos Carregado " + USBCDC.Terminal.Settings1.Default.ArquivoListaComando + "\n"));
                }
            }

            // Carrega outros estados salvos
            txtCaractere.Text = USBCDC.Terminal.Settings1.Default.strFinalizador;
            rbtn.Checked = USBCDC.Terminal.Settings1.Default.bRbtn;
            rbtr.Checked = USBCDC.Terminal.Settings1.Default.bRbtr;
            rbt0.Checked = USBCDC.Terminal.Settings1.Default.bRbt0;
            rbt16Char.Checked = USBCDC.Terminal.Settings1.Default.bRbt16Char;
            rbt32Char.Checked = USBCDC.Terminal.Settings1.Default.bRbt32Char;
            rbtDecimal.Checked = USBCDC.Terminal.Settings1.Default.bRbtDecimal;
            if (rbtDecimal.Checked == false)
                txtCaractere.Enabled = false;
            bIsInicializacao = false;

            // Lista seriais
            ListarSeriais(false);

            // Conexão USB
            MyUSBDeviceConnected = false;
            USBPort = new USBClass();
            USBDeviceProperties = new USBClass.DeviceProperties();
            USBPort.USBDeviceAttached += new USBClass.USBDeviceEventHandler(USBPort_USBDeviceAttached);
            USBPort.USBDeviceRemoved += new USBClass.USBDeviceEventHandler(USBPort_USBDeviceRemoved);
            USBPort.RegisterForDeviceChange(true, this.Handle);
            USBTryMyDeviceConnection();

            CheckStringFinal(null, EventArgs.Empty);
            CheckStringInicial(null, EventArgs.Empty);
            chkEnvioAuto_CheckedChanged(null, EventArgs.Empty);
            cbxEnvioAutoTempo_SelectedIndexChanged(null, EventArgs.Empty);

            // Timer para atualização de dados no textbox
            tmrUpdateData = new System.Windows.Forms.Timer();
            tmrUpdateData.Interval = 200;
            tmrUpdateData.Tick += updateDataHandle;
            tmrUpdateData.Start();

            // Diz a lenda que aumenta performace / diminui a latência dos itens visuais
            //https://stackoverflow.com/questions/9004386/prevent-a-text-box-from-lagging-due-to-fast-updates
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);

        }

        #region USB

        //--------------------------------------------------------------------------------------------------
        private bool USBTryMyDeviceConnection()
        {
            if (rdbUtilizarUSB.Checked == false) return false;

            if (USBClass.GetUSBDevice(uint.Parse(VIDTextBox.Text, System.Globalization.NumberStyles.AllowHexSpecifier), uint.Parse(PIDTextBox.Text, System.Globalization.NumberStyles.AllowHexSpecifier), ref USBDeviceProperties, true))
            {
                //My Device is attached
                LogarData(LOG_TIPO.INTERFACE, new StringBuilder("Interface# USB Tipo: " + USBDeviceProperties.DeviceType + "\n"));
                LogarData(LOG_TIPO.INTERFACE, new StringBuilder("Interface# USB Nome: " + USBDeviceProperties.FriendlyName + "\n"));
                LogarData(LOG_TIPO.INTERFACE, new StringBuilder("Interface# USB Descrição: " + USBDeviceProperties.DeviceDescription + "\n"));
                LogarData(LOG_TIPO.INTERFACE, new StringBuilder("Interface# USB Fabricante: " + USBDeviceProperties.DeviceManufacturer + "\n"));
                LogarData(LOG_TIPO.INTERFACE, new StringBuilder("Interface# USB Classe: " + USBDeviceProperties.DeviceClass + "\n"));
                LogarData(LOG_TIPO.INTERFACE, new StringBuilder("Interface# USB Barramento: " + USBDeviceProperties.DeviceLocation + "\n"));
                LogarData(LOG_TIPO.INTERFACE, new StringBuilder("Interface# USB Caminho: " + USBDeviceProperties.DevicePath + "\n"));
                LogarData(LOG_TIPO.INTERFACE, new StringBuilder("Interface# USB Nome Físico: " + USBDeviceProperties.DevicePhysicalObjectName + "\n"));
                LogarData(LOG_TIPO.INTERFACE, new StringBuilder("Interface# USB Porta Serial: " + USBDeviceProperties.COMPort + "\n"));
                VIDTextBox.Enabled = false;
                PIDTextBox.Enabled = false;
                MyUSBDeviceConnected = true;
                if (serial.IsOpen == false) 
                    ConectarSerial(rdbUtilizarUSB.Checked);
                return true;
            }
            else
            {
                DesconectarSerial();
                return false;
            }
        }

        //--------------------------------------------------------------------------------------------------
        private void USBEndMyDeviceConnection()
        {
            if ((rdbUtilizarUSB.Checked == true) && (serial.IsOpen == true)) 
                DesconectarSerial();
        }

        //--------------------------------------------------------------------------------------------------
        private void USBPort_USBDeviceAttached(object sender, USBClass.USBDeviceEventArgs e)
        {
            if (!MyUSBDeviceConnected)
            {
                if (USBTryMyDeviceConnection())
                {
                    MyUSBDeviceConnected = true;
                }
            }
        }

        //--------------------------------------------------------------------------------------------------
        private void USBPort_USBDeviceRemoved(object sender, USBClass.USBDeviceEventArgs e)
        {
            if (!USBClass.GetUSBDevice(MyDeviceVID, MyDevicePID, ref USBDeviceProperties, false))
            {
                MyUSBDeviceConnected = false;
                if (rdbUtilizarUSB.Checked == true) 
                    DesconectarSerial();
            }
        }

        //--------------------------------------------------------------------------------------------------
        protected override void WndProc(ref Message m)
        {
            bool IsHandled = false;

            USBPort.ProcessWindowsMessage(m.Msg, m.WParam, m.LParam, ref IsHandled);

            base.WndProc(ref m);
        }

        //--------------------------------------------------------------------------------------------------
        private void ConectarSerial(Boolean IsUsb)
        {
            string Porta = "";

            if (serial.IsOpen == false)
            {
                if (IsUsb)
                {
                    if (MyUSBDeviceConnected)
                    {
                        Porta = "USB " + USBDeviceProperties.COMPort.ToString();
                        serial.BaudRate = Convert.ToInt32(cbxBaudrate.Text);
                        serial.PortName = USBDeviceProperties.COMPort.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Dispositivo USB Desconectado ou Inválido!", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (cbxPortaSerial.Text != "")
                {
                    Porta = cbxPortaSerial.Text;
                    serial.BaudRate = Convert.ToInt32(cbxBaudrate.Text);
                    serial.PortName = cbxPortaSerial.Text;
                    serial.RtsEnable = chkRTS.Checked;
                    serial.DtrEnable = chkDTR.Checked;
                }

                try
                {
                    serial.Open();

                    // Caso for uma configuração diferenteda salva, atualiza
                    if (!cbxBaudrate.Items.Contains(cbxBaudrate.Text))
                    {
                        cbxBaudrate.Items.Add(cbxBaudrate.Text);
                    }
                    if (USBCDC.Terminal.Settings1.Default.BaudRate != cbxBaudrate.Text)
                    {
                        USBCDC.Terminal.Settings1.Default.BaudRate = cbxBaudrate.Text;
                        SalvaConfigs();
                    }

                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro ao abrir porta serial!");
                }

                if (serial.IsOpen == true)
                {
                    ConnectionToolStripStatusLabel.Text = "Conectado na " + Porta;
                    if (!IsUsb) ConnectionToolStripStatusLabel.Text = ConnectionToolStripStatusLabel.Text + " a " + serial.BaudRate.ToString() + "bps";
                    LogarData(LOG_TIPO.INTERFACE, new StringBuilder("Interface# Conectado na " + Porta + " a " + cbxBaudrate.Text+ "bps\n"));
                    btnEnviar.Enabled = true;
                    txtEnviar.Enabled = true;
                    lstComandos.Enabled = true;
                    VIDTextBox.Enabled = false;
                    PIDTextBox.Enabled = false;
                    cbxBaudrate.Enabled = false;
                    cbxPortaSerial.Enabled = false;
                    btnConectar.Text = "Desconectar";
                    chkEnvioAuto.Enabled = true;
                    lblCOM.Text = serial.PortName + " (" + serial.BaudRate + "bps)";

                }
            }
        }

        //--------------------------------------------------------------------------------------------------
        private void DesconectarSerial()
        {
            ConnectionToolStripStatusLabel.Text = "Desconectado";

            LogarData(LOG_TIPO.INTERFACE, new StringBuilder("Interface# Desconectado!\n"));
            btnEnviar.Enabled = false;
            txtEnviar.Enabled = false;
            lstComandos.Enabled = false;
            if (cbxDevice.Text == "USERDEFINED")
            {
                VIDTextBox.Enabled = true;
                PIDTextBox.Enabled = true;
            }
            cbxBaudrate.Enabled = true;
            cbxPortaSerial.Enabled = true;
            btnConectar.Text = "Conectar";
            chkEnvioAuto.Enabled = false;
            cbxEnvioAutoTempo.Enabled = false;
            lblCOM.Text = "";

            try
            {
                if (serial.IsOpen == true)
                    serial.Close();
            }
            catch
            {
                ;
            }
            chkCTS.Checked = false;
            chkDSR.Checked = false;
            chkRTS.Checked = false;
            chkDTR.Checked = false;

        }

        #endregion

        //--------------------------------------------------------------------------------------------------
        private void VIDTextBox_Leave(object sender, EventArgs e)
        {
            uint VID = 0;

            if (!uint.TryParse(VIDTextBox.Text, System.Globalization.NumberStyles.AllowHexSpecifier, new System.Globalization.CultureInfo("en-US"), out VID))
            {
                VIDTextBox.Focus();
                ErrorProvider.SetError(VIDTextBox, "VID is expected to be an hexadecimal number, allowed characters: 0 to 9, A to F");
            }
            else
            {
                ErrorProvider.SetError(VIDTextBox, "");
            }
        }

        //--------------------------------------------------------------------------------------------------
        private void PIDTextBox_Leave(object sender, EventArgs e)
        {
            uint PID = 0;

            if (!uint.TryParse(PIDTextBox.Text, System.Globalization.NumberStyles.AllowHexSpecifier, new System.Globalization.CultureInfo("en-US"), out PID))
            {
                PIDTextBox.Focus();
                ErrorProvider.SetError(PIDTextBox, "PID is expected to be an hexadecimal number, allowed characters: 0 to 9, A to F");
            }
            else
            {
                ErrorProvider.SetError(PIDTextBox, "");
            }
        }

        //--------------------------------------------------------------------------------------------------
        private void serial_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int size = serial.BytesToRead;
            
            StringBuilder data = new StringBuilder(100);

            if (size > 0)
            {
                if (serial.IsOpen == false)
                    return;

                if (chkRecLogar.Checked)
                {
                    byte[] bData = new byte[size];
                    if (serial.Read(bData, 0, size) > 0)
                    {
                        data.Append(System.Text.Encoding.Default.GetString(bData));
                        LogarData(LOG_TIPO.RECEBIMETO, data);
                    }
                }
            }
            
        }

        //--------------------------------------------------------------------------------------------------
        private void lstComandos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEnviar.Text = lstComandos.Text;
        }

        //--------------------------------------------------------------------------------------------------
        private void SerialEnviar()
        {
            try
            {
                if (serial.IsOpen == true)
                {

                    // Ascii
                    if (rbtEnvAscii.Checked)
                        serial.Write(strInicial + txtEnviar.Text + strFinal);

                    // Hex Ascii
                    else
                    {
                        // Verifica quantidade minima
                        if ((txtEnviar.Text.Length != 2) && ((txtEnviar.Text.Length < 2) || (!((txtEnviar.Text.Length > 2) && (((txtEnviar.Text.Length - (txtEnviar.Text.Length / 3)) % 2) == 0)))))
                        {
                            MessageBox.Show("Quantidade de caracteres ou formato inválido!\nDeve ser dois caracteres separados por espaço.\nExemplo: 0A 3F 5C", "Erro ao Enviar Hex Ascii", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Prepara dados
                        int i = 0;
                        byte[] byData = new byte[250];
                        for (i = 0; i < 250; i++) byData[i++] = (byte)0;
                        i = 0;
                        string[] hexValuesSplit = txtEnviar.Text.Split(' ');
                        foreach (String hex in hexValuesSplit)
                        {
                            int value = Convert.ToInt32(hex, 16);
                            string stringValue = Char.ConvertFromUtf32(value);
                            char charValue = (char)value;
                            Console.WriteLine("hexadecimal value = {0}, int value = {1}, char value = {2} or {3}", hex, value, stringValue, charValue);
                            byData[i++] = (byte)value;
                        }
                        serial.Write(strInicial);
                        serial.Write(byData, 0, byData.Length);
                        serial.Write(strFinal);
                    }

                    if (chkEnvLogar.Checked)
                        LogarData(LOG_TIPO.ENVIO, new StringBuilder("Env# " + strInicial + txtEnviar.Text + strFinal));
                }
            }
            catch
            {
                ;
            }
        }

        //--------------------------------------------------------------------------------------------------
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            SerialEnviar();
        }

        //--------------------------------------------------------------------------------------------------
        private void lstComandos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                SerialEnviar();
        }

        //--------------------------------------------------------------------------------------------------
        private void CheckImprimir()
        {
            DataHora = null;
            if (chkData.Checked == true)
                DataHora = "MM/dd/yyyy";
            if (chkHora.Checked == true)
                DataHora += " HH:mm:ss";
            if (chkMilisegundos.Checked == true)
                DataHora += ".fff";
            if (DataHora != null)
            {
                DataHora += " # ";
                gpbLogNewLine.Enabled = true;
            } else
            {
                gpbLogNewLine.Enabled = false;
            }
            txtDados.WordWrap = chkQuebrarLinha.Checked;
            USBCDC.Terminal.Settings1.Default.Save();
        }

        //--------------------------------------------------------------------------------------------------
        private void updateDataHandle(object sender, System.EventArgs e)
        {
            serialDataMutex.WaitOne();

            if (serialDataRx.Length > 0)
            {
                if (chkSalvarLog.Checked)
                {
                    using (StreamWriter stwLog = File.AppendText(strLogPath))
                    {
                        stwLog.Write(serialDataRx);
                        stwLog.Close();
                    }

                }

                txtDados.AppendText(serialDataRx.ToString());
                if (btnPausar.BackColor != Color.Red)
                {
                    txtDados.SelectionStart = txtDados.Text.Length;
                    txtDados.ScrollToCaret();
                }

                serialDataRx.Clear();
            }
            serialDataMutex.ReleaseMutex();
        }

        //--------------------------------------------------------------------------------------------------
        private void LogarData(LOG_TIPO Tipo, StringBuilder data)
        {
            string strLog = "";
            int i;
            string strDataHora = "";
            byte byFinalizador = 0;

            if (data.Length <= 0)
            {
                return;
            }

            if (txtCaractere.Text != "")
            {
                byFinalizador = (byte)Convert.ToInt16(txtCaractere.Text);
            }

            if (DataHora != null)
            {
                strDataHora = DateTime.Now.ToString(DataHora);
            }
            
            if ((rbt16Char.Checked == false) && (rbt32Char.Checked == false))
            {
                countChars = 0;
                /*
                if ((byUltimo == byFinalizador) && !string.IsNullOrEmpty(strDataHora)) {
                    strLog = "\n" + strDataHora;
                }
                */
            }

            for (i = 0; i < data.Length; i++)
            {
                byte by = (byte)data[i];

                if (Tipo == LOG_TIPO.INTERFACE) {
                    strLog += data[i].ToString();
                } 
                else 
                {
                    if (rbtRecAscii.Checked == true)
                    {
                        if ((by == 0) || (by == '\r'))
                        {
                            // nada
                        }
                        if ((by == '\n') && (by == byFinalizador))
                        {
                            // não coloca line feed pois será colocado junto a finalização
                        }
                        else if ((by < 127) && ((by > 31) || (by == '\n')))
                        {
                            strLog += data[i].ToString();
                        }
                        else
                        {
                            strLog += "?";
                        }
                    }
                    else
                        strLog += by.ToString("X2") + " ";

                    if (rbt16Char.Checked == true)
                    {
                        if (++countChars >= 16)
                        {
                            countChars = 0;
                            strLog += "\n" + strDataHora;
                        }
                    }
                    else if (rbt32Char.Checked == true)
                    {
                        if (++countChars >= 32)
                        {
                            countChars = 0;
                            strLog += "\n" + strDataHora;
                        }
                    }
                    else if ((by == byFinalizador) /*&& ((i + 1) < data.Length)*/)
                    {
                        strLog += "\n" + strDataHora;
                    } 
                }
            }
            byUltimo = (byte)data[i - 1];

            if ((strLog.Length > 0) && !string.IsNullOrEmpty(strLog))
            {
                Console.WriteLine(strLog);
                serialDataMutex.WaitOne();
                serialDataRx.Append(strLog);
                serialDataMutex.ReleaseMutex();
            }
        }

        //--------------------------------------------------------------------------------------------------
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtDados.Text = "";
            txtEnviar.Text = "";
        }

        //--------------------------------------------------------------------------------------------------
        private void btnMarcar_Click(object sender, EventArgs e)
        {
            LogarData(LOG_TIPO.INTERFACE, new StringBuilder("\n"));
            LogarData(LOG_TIPO.INTERFACE, new StringBuilder("\n******************** MARCA ********************\n"));
            LogarData(LOG_TIPO.INTERFACE, new StringBuilder(" \n"));
        }

        //--------------------------------------------------------------------------------------------------
        private void chkSalvarLog_CheckedChanged(object sender, EventArgs e)
        {

            if (bIsInicializacao == false)
            {
                USBCDC.Terminal.Settings1.Default.SalvarLog = chkSalvarLog.Checked;
                USBCDC.Terminal.Settings1.Default.Save();
                SalvarLog();

                if (chkSalvarLog.Checked == false)
                {
                    if (Directory.Exists(@"log"))
                    {
                        string[] files = System.IO.Directory.GetFiles(@"log");

                        int teste = files.Length;

                        if (MessageBox.Show("Deseja apagar " + files.Length.ToString() + " log(s) antigo(s) da pasta de log?", Application.ProductName.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            // Apaga todos
                            foreach (string s in files)
                            {
                                File.Delete(s);
                            }
                        }
                    }
                }
            }

        }

        //--------------------------------------------------------------------------------------------------
        private void SalvarLog()
        {
            if (chkSalvarLog.Checked == true)
            {
                // Prepara log
                strLogPath = @"log\log-" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".txt";
                chkSalvarLog.Text = "Salvar log em: " + Application.StartupPath + "\\" + strLogPath;
            }
        }

        //--------------------------------------------------------------------------------------------------
        private void MITextBox_TextChanged(object sender, EventArgs e)
        {
            //USBCDC.Terminal.Settings1.Default.usbMIT = Convert.ToUInt16(MITextBox.Text);
            //USBCDC.Terminal.Settings1.Default.Save();
        }

        //--------------------------------------------------------------------------------------------------
        private void VIDTextBox_TextChanged(object sender, EventArgs e)
        {
            if (bIsInicializacao)
                return;

            if (cbxDevice.Text == "USERDEFINED")
            {
                try
                {
                    USBCDC.Terminal.Settings1.Default.USERDEFINED_CDC_VID = Convert.ToUInt16(VIDTextBox.Text);
                    USBCDC.Terminal.Settings1.Default.Save();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Falha ao salvar dados: " + ex.Message.ToString());
                }
            }
        }

        //--------------------------------------------------------------------------------------------------
        private void PIDTextBox_TextChanged(object sender, EventArgs e)
        {
            if (bIsInicializacao)
                return;

            if (cbxDevice.Text == "USERDEFINED")
            {
                try
                {
                    USBCDC.Terminal.Settings1.Default.USERDEFINED_CDC_PID = Convert.ToUInt16(PIDTextBox.Text);
                    USBCDC.Terminal.Settings1.Default.Save();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Falha ao salvar dados: " + ex.Message.ToString());
                }
            }
        }

        //--------------------------------------------------------------------------------------------------
        private void chkData_CheckedChanged(object sender, EventArgs e)
        {
            USBCDC.Terminal.Settings1.Default.bImprimeData = chkData.Checked;
            CheckImprimir();
        }

        //--------------------------------------------------------------------------------------------------
        private void chkHora_CheckedChanged(object sender, EventArgs e)
        {
            USBCDC.Terminal.Settings1.Default.bImprimeHora = chkHora.Checked;
            CheckImprimir();
        }

        //--------------------------------------------------------------------------------------------------
        private void chkMilisegundos_CheckedChanged(object sender, EventArgs e)
        {
            USBCDC.Terminal.Settings1.Default.bImprimeMilisegundos = chkMilisegundos.Checked;
            CheckImprimir();
        }

        //--------------------------------------------------------------------------------------------------
        private void chkQuebrarLinha_CheckedChanged(object sender, EventArgs e)
        {
            USBCDC.Terminal.Settings1.Default.bQuebrarLinha = chkQuebrarLinha.Checked;
            CheckImprimir();
        }

        //--------------------------------------------------------------------------------------------------
        private void rbtAscii_CheckedChanged(object sender, EventArgs e)
        {
            USBCDC.Terminal.Settings1.Default.bRbtRecAscii = rbtRecAscii.Checked;
            SalvaConfigs();
        }

        //--------------------------------------------------------------------------------------------------
        private void rbtHexadecimal_CheckedChanged(object sender, EventArgs e)
        {
            USBCDC.Terminal.Settings1.Default.bRbtRecHexadecimal = rbtRecHexadecimal.Checked;
            SalvaConfigs();
        }

        //--------------------------------------------------------------------------------------------------
        private void rbtEnvAscii_CheckedChanged(object sender, EventArgs e)
        {
            USBCDC.Terminal.Settings1.Default.brbtEnvAscii = rbtEnvAscii.Checked;
            SalvaConfigs();
            txtEnviar.Text = "";
        }

        //--------------------------------------------------------------------------------------------------
        private void rbtEnvHexadecimal_CheckedChanged(object sender, EventArgs e)
        {
            USBCDC.Terminal.Settings1.Default.brbtEnvHexadecimal = rbtEnvHexadecimal.Checked;
            SalvaConfigs();
            txtEnviar.Text = "";
        }

        //--------------------------------------------------------------------------------------------------
        private void chkRecLogar_CheckedChanged(object sender, EventArgs e)
        {
            USBCDC.Terminal.Settings1.Default.bchkRecLogar = chkRecLogar.Checked;
            SalvaConfigs();
        }

        //--------------------------------------------------------------------------------------------------
        private void chkEnvLogar_CheckedChanged(object sender, EventArgs e)
        {
            USBCDC.Terminal.Settings1.Default.bchkEnvLogar = chkEnvLogar.Checked;
            SalvaConfigs();
        }

        //--------------------------------------------------------------------------------------------------
        private void txtEnviar_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Enviar
            if (e.KeyChar == '\r')
            {
                SerialEnviar();
            }

            // Verifica/valida dados em hexadecimal
            else if (rbtEnvHexadecimal.Checked)
            {
                // Caractere válido
                if (e.KeyChar == (char)8)
                {
                    if ((txtEnviar.Text.Length > 2) && (txtEnviar.Text.Substring(txtEnviar.Text.Length - 1, 1) == " "))
                    {
                        txtEnviar.Text.Remove(txtEnviar.Text.Length - 1, 1);
                        txtEnviar.Select(txtEnviar.Text.Length, 0);
                    }
                    return;
                }

                // Caractere válido
                else if ((e.KeyChar == (char)22) || (e.KeyChar == (char)127))
                {
                    return;
                }

                // Caractere válido
                else if (/*(e.KeyChar == (char)' ') ||*/
                ((e.KeyChar >= (char)'0') && (e.KeyChar <= (char)'9')) ||
                ((e.KeyChar >= (char)'A') && (e.KeyChar <= (char)'F')) ||
                ((e.KeyChar >= (char)'a') && (e.KeyChar <= (char)'f')))
                {
                    if (txtEnviar.Text.Length == 2)
                    {
                        txtEnviar.Text = txtEnviar.Text + ' ' + e.KeyChar.ToString();
                    }
                    else if ((txtEnviar.Text.Length > 2) && (((txtEnviar.Text.Length - (txtEnviar.Text.Length / 3)) % 2) == 0))
                    {
                        txtEnviar.Text = txtEnviar.Text + ' ' + e.KeyChar.ToString();
                    }
                    else
                    {
                        txtEnviar.Text = txtEnviar.Text + e.KeyChar.ToString();
                    }
                    txtEnviar.Select(txtEnviar.Text.Length, 0);
                    e.Handled = true;
                }

                e.Handled = true;
            }
        }

        //--------------------------------------------------------------------------------------------------
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serial.IsOpen == true)
                serial.Close();
        }

        //--------------------------------------------------------------------------------------------------
        private void rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn.Checked == true)
            {
                txtCaractere.Text = "10";
                txtCaractere.Enabled = false;
            }
            USBCDC.Terminal.Settings1.Default.bRbtn = rbtn.Checked;
            SalvaConfigs();
        }

        //--------------------------------------------------------------------------------------------------
        private void rbtr_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtr.Checked == true)
            {
                txtCaractere.Text = "13";
                txtCaractere.Enabled = false;
            }
            USBCDC.Terminal.Settings1.Default.bRbtr = rbtr.Checked;
            SalvaConfigs();
        }

        //--------------------------------------------------------------------------------------------------
        private void rbt0_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt0.Checked == true)
            {
                txtCaractere.Text = "0";
                txtCaractere.Enabled = false;
            }
            USBCDC.Terminal.Settings1.Default.bRbt0 = rbt0.Checked;
            SalvaConfigs();
        }

        //--------------------------------------------------------------------------------------------------
        private void rbtDecimal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtDecimal.Checked == true)
            {
                txtCaractere.Enabled = true;
            }
            USBCDC.Terminal.Settings1.Default.bRbtDecimal = rbtDecimal.Checked;
            SalvaConfigs();
        }

        //--------------------------------------------------------------------------------------------------
        private void rbt16Char_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt16Char.Checked == true)
            {
                txtCaractere.Enabled = false;
            }
            USBCDC.Terminal.Settings1.Default.bRbt16Char = rbt16Char.Checked;
            SalvaConfigs();
        }

        //--------------------------------------------------------------------------------------------------
        private void rbt32Char_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt32Char.Checked == true)
            {
                txtCaractere.Enabled = false;
            }
            USBCDC.Terminal.Settings1.Default.bRbt32Char = rbt32Char.Checked;
            SalvaConfigs();
        }

        //--------------------------------------------------------------------------------------------------
        private void SalvaConfigs()
        {
            USBCDC.Terminal.Settings1.Default.strFinalizador = txtCaractere.Text;
            USBCDC.Terminal.Settings1.Default.Save();
        }

        //--------------------------------------------------------------------------------------------------
        private void txtCaractere_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Mantém backspace
            if (e.KeyChar == 8)
                e.Handled = false;

            // Somente numeros
            else if (!char.IsDigit(e.KeyChar))
                e.Handled = true;

            // Só até 255
            else if (txtCaractere.Text.Length > 0)
                if (Convert.ToInt16(txtCaractere.Text + e.KeyChar.ToString()) > 255)
                    e.Handled = true;

            rbtDecimal.Checked = true;
            SalvaConfigs();
        }

        //--------------------------------------------------------------------------------------------------
        private void CheckStringInicial(object sender, EventArgs e)
        {
            if (rbtInicioNenhum.Checked)
                strInicial = "";
            else if (rbtInicioEsc.Checked)
                strInicial = Convert.ToChar(27).ToString();
            else if (rbtInicioStx.Checked)
                strInicial = Convert.ToChar(2).ToString();
            else if (rbtInicioEnter.Checked)
                strInicial = "\n";
        }

        //--------------------------------------------------------------------------------------------------
        private void CheckStringFinal(object sender, EventArgs e)
        {
            if (rbtFimNenhum.Checked)
                strFinal = "";
            else if (rbtFimEsc.Checked)
                strFinal = Convert.ToChar(27).ToString();
            else if (rbtFimEtx.Checked)
                strFinal = Convert.ToChar(2).ToString();
            else if (rbtFimEnter.Checked)
                strFinal = "\n";
        }

        //--------------------------------------------------------------------------------------------------
        private void rdbUtilizarUSB_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbUtilizarUSB.Checked == false)
                USBEndMyDeviceConnection();
            else
                USBTryMyDeviceConnection();
        }

        //--------------------------------------------------------------------------------------------------
        private void rdbUtilizarSerial_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbUtilizarSerial.Checked == false)
            {
                cbxBaudrate.Enabled = false;
                cbxPortaSerial.Enabled = false;
            }
            else
            {
                ListarSeriais(true);
                cbxBaudrate.Enabled = true;
                cbxPortaSerial.Enabled = true;
            }
            DesconectarSerial();
        }

        //--------------------------------------------------------------------------------------------------
        private void cbxBaudrate_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Somente números
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //--------------------------------------------------------------------------------------------------
        private void cbxBaudrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            USBCDC.Terminal.Settings1.Default.BaudRate = cbxBaudrate.Text;
            SalvaConfigs();
        }

        //--------------------------------------------------------------------------------------------------
        private void cbxPortaSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; // Não permite digitar
        }

        //--------------------------------------------------------------------------------------------------
        private void ListarSeriais(Boolean bHabilitaBox)
        {
            string[] strPortas;
            bool bPorta = false;

            // Obtém portas disponiveis
            strPortas = System.IO.Ports.SerialPort.GetPortNames();

            // Carrega na lista
            cbxPortaSerial.Items.Clear();
            foreach (string porta in strPortas)
            {
                cbxPortaSerial.Items.Add(porta);
                if (porta == USBCDC.Terminal.Settings1.Default.PortaSerial) bPorta = true;
                LogarData(LOG_TIPO.INTERFACE, new StringBuilder("Interface# Serial " + porta + " Detectada\n"));
            }

            // Aponta a última usada ou a primeira da lista
            if (cbxPortaSerial.Items.Count > 0)
            {
                if (bPorta == true) cbxPortaSerial.Text = USBCDC.Terminal.Settings1.Default.PortaSerial;
                else cbxPortaSerial.SelectedIndex = 0;
            }

            cbxPortaSerial.Enabled = bHabilitaBox;
        }

        //--------------------------------------------------------------------------------------------------
        private void cbxPortaSerial_SelectedIndexChanged(object sender, EventArgs e)
        {
            USBCDC.Terminal.Settings1.Default.PortaSerial = cbxPortaSerial.Text;
            USBCDC.Terminal.Settings1.Default.Save();
        }

        //--------------------------------------------------------------------------------------------------
        private void btnConectar_Click(object sender, EventArgs e)
        {
            if (serial.IsOpen == false)
            {
                ConectarSerial(rdbUtilizarUSB.Checked);
            }
            else
            {
                DesconectarSerial();
            }

            chkEnvioAuto_CheckedChanged(null, EventArgs.Empty);

        }

        //--------------------------------------------------------------------------------------------------
        private void btnPausar_Click(object sender, EventArgs e)
        {
            if (btnPausar.BackColor == Color.Red)
            {
                btnPausar.BackColor = BackColorBackup;
                txtDados.SelectionStart = txtDados.Text.Length;
                txtDados.ScrollToCaret();
                btnPausar.Text = "Pausar Log";
            }
            else
            {
                btnPausar.BackColor = Color.Red;
                btnPausar.Text = "Retoma Log";
            }
        }

        //--------------------------------------------------------------------------------------------------
        private void btnCarregarListaComandos_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (File.Exists(openFileDialog1.FileName))
                    {
                        // Abre lista de comandos
                        using (StreamReader texto = new StreamReader(openFileDialog1.FileName))
                        {
                            string strDados;
                            lstComandos.Items.Clear();
                            while ((strDados = texto.ReadLine()) != null)
                            {
                                lstComandos.Items.Add(strDados);
                            }
                            // Salva ultimo
                            USBCDC.Terminal.Settings1.Default.ArquivoListaComando = openFileDialog1.FileName;
                            USBCDC.Terminal.Settings1.Default.Save();
                            LogarData(LOG_TIPO.INTERFACE, new StringBuilder("Interface# Arquivo de Comandos Carregado " + USBCDC.Terminal.Settings1.Default.ArquivoListaComando + "\n"));
                            if (USBCDC.Terminal.Settings1.Default.ArquivoListaComando.Length > 37)
                                lblListaComandos.Text = USBCDC.Terminal.Settings1.Default.ArquivoListaComando.Substring(0, 3) + "..... " + USBCDC.Terminal.Settings1.Default.ArquivoListaComando.Substring(USBCDC.Terminal.Settings1.Default.ArquivoListaComando.Length - 37);
                            else
                                lblListaComandos.Text = USBCDC.Terminal.Settings1.Default.ArquivoListaComando;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        //--------------------------------------------------------------------------------------------------
        private bool SalvaListaDeComandos()
        {
            if (File.Exists(USBCDC.Terminal.Settings1.Default.ArquivoListaComando))
            {
                System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(USBCDC.Terminal.Settings1.Default.ArquivoListaComando);
                foreach (var item in lstComandos.Items)
                    SaveFile.WriteLine(item);
                SaveFile.Close();
                return true;
            }
            return false;
        }

        //--------------------------------------------------------------------------------------------------
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            lstComandos.Items.Add(txtEnviar.Text);
            if (SalvaListaDeComandos())
                MessageBox.Show("Adicionado!");
        }

        //--------------------------------------------------------------------------------------------------
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (lstComandos.SelectedIndex >= 0)
            {
                lstComandos.Items.RemoveAt(lstComandos.SelectedIndex);
                if (SalvaListaDeComandos())
                    MessageBox.Show("Deletado!");
            }
        }

        //--------------------------------------------------------------------------------------------------
        public void MoveItem(int direction)
        {
            // Checa item selecionado
            if (lstComandos.SelectedItem == null || lstComandos.SelectedIndex < 0)
                return;

            // Calcula o index
            int newIndex = lstComandos.SelectedIndex + direction;

            // Checa o index e range
            if (newIndex < 0 || newIndex >= lstComandos.Items.Count)
                return;

            object selected = lstComandos.SelectedItem;

            // Remove
            lstComandos.Items.Remove(selected);
            // Insere
            lstComandos.Items.Insert(newIndex, selected);
            // Restaura a seleção
            lstComandos.SetSelected(newIndex, true);
        }

        //--------------------------------------------------------------------------------------------------
        private void btnUp_Click(object sender, EventArgs e)
        {
            MoveItem(-1);
            SalvaListaDeComandos();
        }

        //--------------------------------------------------------------------------------------------------
        private void btnDown_Click(object sender, EventArgs e)
        {
            MoveItem(1);
            SalvaListaDeComandos();
        }

        //--------------------------------------------------------------------------------------------------
        private void btnFonte_Click(object sender, EventArgs e)
        {
            FontDialog fontdlg = new FontDialog();
            fontdlg.Font = txtDados.Font;

            if (fontdlg.ShowDialog() != DialogResult.Cancel)
            {
                txtDados.Font = lstComandos.Font = fontdlg.Font;
                txtDados.ForeColor = txtEnviar.ForeColor = lstComandos.ForeColor = fontdlg.Color;
                USBCDC.Terminal.Settings1.Default.fontTextos = fontdlg.Font;
                USBCDC.Terminal.Settings1.Default.colorTextos = fontdlg.Color;
                USBCDC.Terminal.Settings1.Default.Save();
            }
        }

        //--------------------------------------------------------------------------------------------------
        private void chkEnvioAuto_CheckedChanged(object sender, EventArgs e)
        {
            if ((serial.IsOpen == true) && (chkEnvioAuto.Checked == true))
                cbxEnvioAutoTempo.Enabled = true;
            else
                cbxEnvioAutoTempo.Enabled = false;

            // Inicia o envio de msg automatico
            if ((chkEnvioAuto.Checked == true) && (chkEnvioAuto.Enabled == true))
            {
                tmrEnvioAuto.Enabled = false;
                tmrEnvioAuto.Interval = Convert.ToInt32(cbxEnvioAutoTempo.Text) * 1000;
                tmrEnvioAuto.Enabled = true;
            }

            // Para o envio de msg automatico
            else
            {
                tmrEnvioAuto.Enabled = false;
            }

            // Salva config
            USBCDC.Terminal.Settings1.Default.bEnvioAuto = chkEnvioAuto.Checked;
            USBCDC.Terminal.Settings1.Default.Save();
        }

        //--------------------------------------------------------------------------------------------------
        private void cbxEnvioAutoTempo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Inicia o envio de msg automatico
            if (chkEnvioAuto.Enabled)
            {
                tmrEnvioAuto.Enabled = false;
                tmrEnvioAuto.Interval = Convert.ToInt32(cbxEnvioAutoTempo.Text) * 1000;
                tmrEnvioAuto.Enabled = true;

                // Salva config
                USBCDC.Terminal.Settings1.Default.EnvioAutoTempo = cbxEnvioAutoTempo.Text;
                USBCDC.Terminal.Settings1.Default.Save();
            }
        }

        //--------------------------------------------------------------------------------------------------
        private void cbxEnvioAutoTempo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Inibe a escrita nessa caixa
            e.Handled = true;
        }

        //--------------------------------------------------------------------------------------------------
        private void tmrEnvioAuto_Tick(object sender, EventArgs e)
        {
            if (txtEnviar.Text != "")
            {
                if (serial.IsOpen == true)
                {
                    if ((chkEnvioAuto.Enabled) && (chkEnvioAuto.Checked))
                        btnEnviar_Click(null, EventArgs.Empty);
                }
            }
        }

        //--------------------------------------------------------------------------------------------------
        private void txtEnviar_TextChanged(object sender, EventArgs e)
        {
            // Salva config
            USBCDC.Terminal.Settings1.Default.strDadosEnviar = txtEnviar.Text;
            USBCDC.Terminal.Settings1.Default.Save();
        }

        //--------------------------------------------------------------------------------------------------
        private void ThreadSafe(MethodInvoker method)
        {
            if (InvokeRequired)
                Invoke(method);
            else
                method();
        }

        //--------------------------------------------------------------------------------------------------
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Pressionado ctrl+Alt+Shift+b - teste
            if (keyData == (Keys)0x00070042)
            {
                string bkp = txtEnviar.Text;
                txtEnviar.Text = "ctrl+Alt+Shift+b";
                SerialEnviar();
                Thread.Sleep(100);
                SerialEnviar();
                Thread.Sleep(500);

                if (!rdbUtilizarUSB.Checked)
                {
                    // Checa se conectado
                    if (serial.IsOpen == false)
                    {
                        MessageBox.Show("Serial Não Conectada!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                txtEnviar.Text = bkp;
                
            }

            // Chamada padrão da classe base
            return base.ProcessCmdKey(ref msg, keyData);
        }

        //--------------------------------------------------------------------------------------------------
        private void DeviceChanged()
        {

            if (cbxDevice.Text == "CH340")
            {
                VIDTextBox.Text = USBCDC.Terminal.Settings1.Default.CH340_VID.ToString("X4");
                PIDTextBox.Text = USBCDC.Terminal.Settings1.Default.CH340_PID.ToString("X4");
                VIDTextBox.Enabled = false;
                PIDTextBox.Enabled = false;
            }
            else if (cbxDevice.Text == "CP210X")
            {
                VIDTextBox.Text = USBCDC.Terminal.Settings1.Default.CP210X_VID.ToString("X4");
                PIDTextBox.Text = USBCDC.Terminal.Settings1.Default.CP210X_PID.ToString("X4");
                VIDTextBox.Enabled = false;
                PIDTextBox.Enabled = false;
            }
            else if (cbxDevice.Text == "FT232/FT245")
            {
                VIDTextBox.Text = USBCDC.Terminal.Settings1.Default.FT232_FT245_VID.ToString("X4");
                PIDTextBox.Text = USBCDC.Terminal.Settings1.Default.FT232_FT245_PID.ToString("X4");
                VIDTextBox.Enabled = false;
                PIDTextBox.Enabled = false;
            }
            else if (cbxDevice.Text == "FT2232")
            {
                VIDTextBox.Text = USBCDC.Terminal.Settings1.Default.FT2232_VID.ToString("X4");
                PIDTextBox.Text = USBCDC.Terminal.Settings1.Default.FT2232_PID.ToString("X4");
                VIDTextBox.Enabled = false;
                PIDTextBox.Enabled = false;
            }
            else if (cbxDevice.Text == "FT4232")
            {
                VIDTextBox.Text = USBCDC.Terminal.Settings1.Default.FT4232_VID.ToString("X4");
                PIDTextBox.Text = USBCDC.Terminal.Settings1.Default.FT4232_PID.ToString("X4");
                VIDTextBox.Enabled = false;
                PIDTextBox.Enabled = false;
            }
            else if (cbxDevice.Text == "PL2303")
            {
                VIDTextBox.Text = USBCDC.Terminal.Settings1.Default.PL2303_VID.ToString("X4");
                PIDTextBox.Text = USBCDC.Terminal.Settings1.Default.PL2303_PID.ToString("X4");
                VIDTextBox.Enabled = false;
                PIDTextBox.Enabled = false;
            }
            else if (cbxDevice.Text == "PL2303G")
            {
                VIDTextBox.Text = USBCDC.Terminal.Settings1.Default.PL2303G_VID.ToString("X4");
                PIDTextBox.Text = USBCDC.Terminal.Settings1.Default.PL2303G_PID.ToString("X4");
                VIDTextBox.Enabled = false;
                PIDTextBox.Enabled = false;
            }
            else
            {
                if (cbxDevice.Text != "USERDEFINED") {
                    cbxDevice.Text = "USERDEFINED";
                }
                VIDTextBox.Text = USBCDC.Terminal.Settings1.Default.USERDEFINED_CDC_VID.ToString("X4");
                PIDTextBox.Text = USBCDC.Terminal.Settings1.Default.USERDEFINED_CDC_PID.ToString("X4");
                VIDTextBox.Enabled = true;
                PIDTextBox.Enabled = true;
            }
        }

        //--------------------------------------------------------------------------------------------------
        private void cbxDevice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; // Não permite digitar
        }

        //--------------------------------------------------------------------------------------------------
        private void cbxDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bIsInicializacao)
                return;
            
            if (USBCDC.Terminal.Settings1.Default.usbCDCdeviceLast != cbxDevice.Text)
            {
                DesconectarSerial();
                DeviceChanged();
                USBCDC.Terminal.Settings1.Default.usbCDCdeviceLast = cbxDevice.Text;
                USBCDC.Terminal.Settings1.Default.Save();
                rdbUtilizarUSB.Checked = true;
                USBTryMyDeviceConnection();
            }
        }

        //--------------------------------------------------------------------------------------------------
        private void btnRestaurarPadrao_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja restaurar todas as configurações aos padrões iniciais?"
                , this.Text
                , MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                USBCDC.Terminal.Settings1.Default.Reload();
                USBCDC.Terminal.Settings1.Default.Reset();
                USBCDC.Terminal.Settings1.Default.Save();
                cbxDevice.DataSource = USBCDC.Terminal.Settings1.Default.usbCDCdevice;
                cbxDevice.Text = USBCDC.Terminal.Settings1.Default.usbCDCdeviceLast;
                chkRTS.Checked = false;
                chkDTR.Checked = false;
                DeviceChanged();
            }

        }

        //--------------------------------------------------------------------------------------------------
        private void serial_PinChanged(object sender, System.IO.Ports.SerialPinChangedEventArgs e)
        {
            if (serial.IsOpen)
            {
                SerialPort sp = (SerialPort)sender;

                switch (e.EventType)
                {
                    case SerialPinChange.CtsChanged:
                        if (chkCTS.InvokeRequired)
                            chkCTS.Invoke(new Action(() => chkCTS.Checked = sp.CtsHolding));
                        else
                            chkCTS.Checked = sp.CtsHolding;
                        break;
                    case SerialPinChange.DsrChanged:
                        if (chkDSR.InvokeRequired)
                            chkDSR.Invoke(new Action(() => chkDSR.Checked = sp.DsrHolding));
                        else
                            chkDSR.Checked = sp.DsrHolding;
                        break;
                }
            }
        }

        //--------------------------------------------------------------------------------------------------
        private void chkRTS_CheckedChanged(object sender, EventArgs e)
        {
            if (serial.IsOpen)
            {
                serial.RtsEnable = chkRTS.Checked;
            }
        }

        //--------------------------------------------------------------------------------------------------
        private void chkDTR_CheckedChanged(object sender, EventArgs e)
        {
            if (serial.IsOpen)
            {
                serial.DtrEnable = chkDTR.Checked;
            }
        }
    }
        
}
