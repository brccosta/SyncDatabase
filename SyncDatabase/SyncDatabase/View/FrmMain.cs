using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Synchronization.Data.SqlServer;
using Microsoft.Synchronization;

namespace SyncDatabase
{
    public partial class FrmMain : Form
    {

        #region GlobalVariables

        SqlSyncProvider providerOrigem;
        SqlSyncProvider providerDestino;
        int tempoMedioMinutos = 0;
        String strConnS1 = "";
        String strConnS2 = "";
        String strScopo = "";
        String tabelasIgnoradas = "";
        Int32 numSync = 0;
        static String strResultado = "";
        static String strDirection = "";

        #endregion

        #region Properties

        #endregion

        #region EventControls

        public FrmMain()
        {
            InitializeComponent();
            cbAcao.SelectedIndex = 0;
            cbEscopo.SelectedIndex = 0;
            cbServer.SelectedIndex = 0;
            CarregarXML();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SalvarXML();
        }

        private void btnTestarConexaoS1_Click(object sender, EventArgs e)
        {
            InitExecut("Testando conexão Server 1...");
            strConnS1 = @"Data Source=" + txtInstanciaS1.Text + " ;Initial Catalog=" + txtDatabaseS1.Text + ";Persist Security Info=True;User ID= " + txtUsuarioS1.Text + ";Password= " + txtSenhaS1.Text;
            backWorkerTestaConn.RunWorkerAsync(strConnS1);
        }

        private void btnTestarConexaoS2_Click(object sender, EventArgs e)
        {
            InitExecut("Testando conexão Server 2...");
            strConnS2 = @"Data Source=" + txtInstanciaS2.Text + " ;Initial Catalog=" + txtDatabaseS2.Text + ";Persist Security Info=True;User ID= " + txtUsuarioS2.Text + ";Password= " + txtSenhaS2.Text;
            backWorkerTestaConn.RunWorkerAsync(strConnS2);
        }

        private void btnLimparEscopo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma a exclusão do escopo na base de dados?", "", MessageBoxButtons.YesNoCancel).Equals(DialogResult.Yes))
            {
                InitExecut("Excluíndo escopo " + cbServer.Text + "...");
                strScopo = cbEscopo.Text;
                if (cbServer.Text.Equals("Server 1"))
                {
                    strConnS1 = @"Data Source=" + txtInstanciaS1.Text + " ;Initial Catalog=" + txtDatabaseS1.Text + ";Persist Security Info=True;User ID= " + txtUsuarioS1.Text + ";Password= " + txtSenhaS1.Text;
                    backWorkerLimpaEscopo.RunWorkerAsync(strConnS1);
                }
                else
                {
                    strConnS2 = @"Data Source=" + txtInstanciaS2.Text + " ;Initial Catalog=" + txtDatabaseS2.Text + ";Persist Security Info=True;User ID= " + txtUsuarioS2.Text + ";Password= " + txtSenhaS2.Text;
                    backWorkerLimpaEscopo.RunWorkerAsync(strConnS2);
                }



            }
        }

        private void btnConfigurarEscopo_Click(object sender, EventArgs e)
        {
            try
            {
                strScopo = cbEscopo.Text;
                tabelasIgnoradas = txtTabelasIgnoradas.Text;
                if (cbServer.Text.Equals("Server 1"))
                {
                    InitExecut("Configurando o escopo no " + cbServer.Text + "...");
                    strConnS1 = @"Data Source=" + txtInstanciaS1.Text + " ;Initial Catalog=" + txtDatabaseS1.Text + ";Persist Security Info=True;User ID= " + txtUsuarioS1.Text + ";Password= " + txtSenhaS1.Text;
                    backWorkerConfigEscopo.RunWorkerAsync(strConnS1);
                }
                else
                {
                    InitExecut("Configurando o escopo no " + cbServer.Text + "...");
                    strConnS2 = @"Data Source=" + txtInstanciaS2.Text + " ;Initial Catalog=" + txtDatabaseS2.Text + ";Persist Security Info=True;User ID= " + txtUsuarioS2.Text + ";Password= " + txtSenhaS2.Text;
                    backWorkerConfigEscopo.RunWorkerAsync(strConnS2);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSincronizar_Click(object sender, EventArgs e)
        {
            strDirection = cbAcao.Text;

            if (btnSincronizar.Text.Equals("Sincronizar"))
            {
                InitExecut("Testando conexão e escopo...");
                TestarConexaoEEscopos();
            }
            else if (btnSincronizar.Text.Equals("Cancelar"))
            {
                statusLabel.Text = "Cancelando...";
                btnSincronizar.Enabled = false;
                SyncHelper.orchestrator.Cancel();
                backWorkSincronizar.CancelAsync();
            }
        }

        private void btnPrimConfig_Click(object sender, EventArgs e)
        {
            strDirection = "Primeira_Configuracao";

            if (btnSincronizar.Text.Equals("Sincronizar"))
            {
                InitExecut("Testando conexão e escopo...");
                TestarConexaoEEscopos();
            }
            else if (btnSincronizar.Text.Equals("Cancelar"))
            {
                statusLabel.Text = "Cancelando...";
                btnSincronizar.Enabled = false;
                SyncHelper.orchestrator.Cancel();
                backWorkSincronizar.CancelAsync();
            }
        }

        #endregion

        #region Methods

        private void TestarConexaoEEscopos()
        {

            strConnS1 = @"Data Source=" + txtInstanciaS1.Text + " ;Initial Catalog=" + txtDatabaseS1.Text + ";Persist Security Info=True;User ID= " + txtUsuarioS1.Text + ";Password= " + txtSenhaS1.Text;
            strConnS2 = @"Data Source=" + txtInstanciaS2.Text + " ;Initial Catalog=" + txtDatabaseS2.Text + ";Persist Security Info=True;User ID= " + txtUsuarioS2.Text + ";Password= " + txtSenhaS2.Text;

            strScopo = cbEscopo.Text;

            backWorkerTestaConexaoSync.RunWorkerAsync();
        }

        private void Sincronizar()
        {
            try
            {
                numSync = 2;

                XmlDocument xmlConfigDoc = new XmlDocument();
                xmlConfigDoc.Load("SyncDatabaseConfig.xml");
                String tempoMedioStr = xmlConfigDoc["SyncDatabase"]["TempoMedio"]["minutos"].InnerText;

                txtInformacoes.Text = "Sincronização iniciada às " + DateTime.Now.Hour.ToString("00") + ":" +
                                     DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00") +
                                     Environment.NewLine;

                if (tempoMedioStr.Equals("0"))
                {
                    txtInformacoes.Text += "Tempo médio: menos de 50 segundos";
                }
                else if (tempoMedioStr.Equals("1"))
                {
                    txtInformacoes.Text += "Tempo médio: 1 minuto";
                }
                else
                {
                    txtInformacoes.Text += "Tempo médio: " + tempoMedioStr + " minutos";
                }


                InitExecut("Sincronizando, aguarde por favor...");
                btnSincronizar.Enabled = true;
                btnSincronizar.Text = "Cancelar";
                btnSincronizar.Image = SyncDatabase.Properties.Resources.cross;
                strResultado += "Ação: " + cbAcao.Text;
                backWorkSincronizar.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensagem: " + ex.Message);
                EndExecut();
            }
        }

        private void SalvarXML()
        {
            XmlDocument xmlConfigDoc = new XmlDocument();
            xmlConfigDoc.Load("SyncDatabaseConfig.xml");
            xmlConfigDoc["SyncDatabase"]["SyncConfig"]["Escopo"].InnerText = cbEscopo.Text;
            xmlConfigDoc["SyncDatabase"]["SyncConfig"]["Informacoes"].InnerText = txtInformacoes.Text;
            xmlConfigDoc["SyncDatabase"]["SyncConfig"]["TabelasIgnoradas"].InnerText = txtTabelasIgnoradas.Text;

            xmlConfigDoc["SyncDatabase"]["Server1"]["Instancia"].InnerText = txtInstanciaS1.Text;
            xmlConfigDoc["SyncDatabase"]["Server1"]["Database"].InnerText = txtDatabaseS1.Text;
            xmlConfigDoc["SyncDatabase"]["Server1"]["Usuario"].InnerText = txtUsuarioS1.Text;
            xmlConfigDoc["SyncDatabase"]["Server1"]["Senha"].InnerText = txtSenhaS1.Text.EncryptSHA1();

            xmlConfigDoc["SyncDatabase"]["Server2"]["Instancia"].InnerText = txtInstanciaS2.Text;
            xmlConfigDoc["SyncDatabase"]["Server2"]["Database"].InnerText = txtDatabaseS2.Text;
            xmlConfigDoc["SyncDatabase"]["Server2"]["Usuario"].InnerText = txtUsuarioS2.Text;
            xmlConfigDoc["SyncDatabase"]["Server2"]["Senha"].InnerText = txtSenhaS2.Text.EncryptSHA1();

            xmlConfigDoc["SyncDatabase"]["TempoMedio"]["minutos"].InnerText = tempoMedioMinutos.ToString();

            xmlConfigDoc.Save("SyncDatabaseConfig.xml");
        }

        private void CarregarXML()
        {
            try
            {
                XmlDocument xmlConfigDoc = new XmlDocument();
                xmlConfigDoc.Load("SyncDatabaseConfig.xml");
                cbEscopo.Text = xmlConfigDoc["SyncDatabase"]["SyncConfig"]["Escopo"].InnerText;
                txtInformacoes.Text = xmlConfigDoc["SyncDatabase"]["SyncConfig"]["Informacoes"].InnerText;
                txtTabelasIgnoradas.Text = xmlConfigDoc["SyncDatabase"]["SyncConfig"]["TabelasIgnoradas"].InnerText;

                txtInstanciaS1.Text = xmlConfigDoc["SyncDatabase"]["Server1"]["Instancia"].InnerText;
                txtDatabaseS1.Text = xmlConfigDoc["SyncDatabase"]["Server1"]["Database"].InnerText;
                txtUsuarioS1.Text = xmlConfigDoc["SyncDatabase"]["Server1"]["Usuario"].InnerText;
                txtSenhaS1.Text = xmlConfigDoc["SyncDatabase"]["Server1"]["Senha"].InnerText.DecryptSHA1();

                txtInstanciaS2.Text = xmlConfigDoc["SyncDatabase"]["Server2"]["Instancia"].InnerText;
                txtDatabaseS2.Text = xmlConfigDoc["SyncDatabase"]["Server2"]["Database"].InnerText;
                txtUsuarioS2.Text = xmlConfigDoc["SyncDatabase"]["Server2"]["Usuario"].InnerText;
                txtSenhaS2.Text = xmlConfigDoc["SyncDatabase"]["Server2"]["Senha"].InnerText.DecryptSHA1();

            }
            catch (System.IO.FileNotFoundException)
            {

                XmlDocument xmlConfigDoc = new XmlDocument();

                String xmlStr = "<?xml version=\"1.0\" encoding=\"utf-8\" ?> " + Environment.NewLine +
                                "<SyncDatabase>" + Environment.NewLine +
                                  "<SyncConfig>" + Environment.NewLine +
                                    "<Escopo>Enviar_exames</Escopo>" + Environment.NewLine +
                                    "<Informacoes></Informacoes>" + Environment.NewLine +
                                    "<TabelasIgnoradas></TabelasIgnoradas>" + Environment.NewLine +
                                  "</SyncConfig>" + Environment.NewLine +
                                  "<Server1>" + Environment.NewLine +
                                    "<Instancia>Server\\Instance</Instancia>" + Environment.NewLine +
                                    "<Database></Database>" + Environment.NewLine +
                                    "<Usuario></Usuario>" + Environment.NewLine +
                                    "<Senha>/lHIeGq2OHUw7w5lJ+Gj3A==</Senha>" + Environment.NewLine +
                                    "<TabelasIgnoradas></TabelasIgnoradas> " + Environment.NewLine +
                                  "</Server1>" + Environment.NewLine +
                                  "<Server2>" + Environment.NewLine +
                                    "<Instancia>Server\\Instance</Instancia>" + Environment.NewLine +
                                    "<Database></Database>" + Environment.NewLine +
                                    "<Usuario></Usuario>" + Environment.NewLine +
                                    "<Senha>/lHIeGq2OHUw7w5lJ+Gj3A==</Senha>" + Environment.NewLine +
                                    "<TabelasIgnoradas></TabelasIgnoradas> " + Environment.NewLine +
                                  "</Server2>" + Environment.NewLine +
                                  "<TempoMedio>" + Environment.NewLine +
                                   "<minutos>0</minutos>" + Environment.NewLine +
                                  "</TempoMedio>" + Environment.NewLine +
                                "</SyncDatabase>";

                xmlConfigDoc.Load(new StringReader(xmlStr));

                xmlConfigDoc.Save("SyncDatabaseConfig.xml");

                CarregarXML();
            }


        }



        #endregion

        #region BackgroudWorker

        private void InitExecut(string mensagemLabel)
        {
            tpSync.DesabilitarComExcessoes();
            tpServer1.DesabilitarComExcessoes();
            tpServer2.DesabilitarComExcessoes();
            tpConfig.DesabilitarComExcessoes();

            statusLabel.Text = mensagemLabel;
            radWSync.StartWaiting();
            radWSync.Visible = true;

        }

        private void EndExecut()
        {
            tpSync.Habilitar();
            tpServer1.Habilitar();
            tpServer2.Habilitar();
            tpConfig.Habilitar();

            statusLabel.Text = "";
            radWSync.StartWaiting();
            radWSync.Visible = false;
        }

        private void backWorkerTestaConn_DoWork(object sender, DoWorkEventArgs e)
        {
            SqlConnection sqlConn = SyncHelper.TestarConexao(e.Argument.ToString());
        }

        private void backWorkerTestaConn_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EndExecut();
            if (e.Error == null)
            {
                SalvarXML();

                MessageBox.Show("Conexão efetuada com sucesso");
            }
            else
            {
                MessageBox.Show("Não foi possível se conectar ao servidor: " + Environment.NewLine + e.Error.Message);
            }
        }

        private void backWorkerLimpaEscopo_DoWork(object sender, DoWorkEventArgs e)
        {
            SyncHelper.LimparScopeProvisioning(new SqlConnection(e.Argument.ToString()), strScopo);
        }

        private void backWorkerLimpaEscopo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EndExecut();
            if (e.Error == null)
            {
                MessageBox.Show("Escopo excluído com sucesso");
            }
            else
            {
                MessageBox.Show("Erro ao excluir o escopo: " + e.Error.Message);
            }
        }

        private void backWorkerConfigEscopo_DoWork(object sender, DoWorkEventArgs e)
        {
            SyncHelper.ConfigurarScopo(new SqlSyncProvider(strScopo, new SqlConnection(e.Argument.ToString())), tabelasIgnoradas);
        }

        private void backWorkerConfigEscopo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EndExecut();
            if (e.Error == null)
            {
                MessageBox.Show("Escopo configurado com sucesso");
            }
            else
            {
                MessageBox.Show("Erro ao configurar o escopo: " + Environment.NewLine + e.Error.Message);
            }
        }

        private void backWorkerTestaConexaoSync_DoWork(object sender, DoWorkEventArgs e)
        {
            SqlConnection sqlConn = SyncHelper.TestarConexao(strConnS1);
            SqlConnection sqlConn2 = SyncHelper.TestarConexao(strConnS2);

            providerOrigem = SyncHelper.VerificarEscopo(strScopo, sqlConn);
            providerDestino = SyncHelper.VerificarEscopo(strScopo, sqlConn2);
        }

        private void backWorkerTestaConexaoSync_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                Sincronizar();
            }
            else
            {
                EndExecut();
                MessageBox.Show("Erro: " + e.Error.Message);

            }
        }

        private void backWorkSincronizar_DoWork(object sender, DoWorkEventArgs e)
        {
            SyncOperationStatistics[] syncOpTemp = new SyncOperationStatistics[numSync];

            for (int i = 0; i < numSync; i++)
            {
                syncOpTemp[i] = SyncHelper.Sincronizar(providerOrigem, providerDestino, strDirection);
            }


            int numTotal = numSync > 1 ? numSync - 1 : 0;

            strResultado = "Última Sincronização: " + syncOpTemp[0].SyncStartTime.ToString("dd/MM/yyyy") + Environment.NewLine +
                           "Ação: " + strDirection + Environment.NewLine +
                           "Início: " + syncOpTemp[0].SyncStartTime.ToString("hh:mm:ss") + Environment.NewLine +
                           "Término: " + syncOpTemp[numTotal].SyncEndTime.ToString("hh:mm:ss");

            int horaInicioFim = syncOpTemp[0].SyncStartTime.Hour - syncOpTemp[0].SyncEndTime.Hour;

            if (horaInicioFim < 0)
            {
                tempoMedioMinutos = (syncOpTemp[0].SyncEndTime.Minute + 60) - syncOpTemp[0].SyncStartTime.Minute;
            }
            else
            {
                tempoMedioMinutos = syncOpTemp[0].SyncEndTime.Minute - syncOpTemp[0].SyncStartTime.Minute;
            }

            XmlDocument xmlConfigDoc = new XmlDocument();
            xmlConfigDoc.Load("SyncDatabaseConfig.xml");
            String tempoMedioStr = xmlConfigDoc["SyncDatabase"]["TempoMedio"]["minutos"].InnerText;

            if (!tempoMedioStr.Equals("") && !tempoMedioMinutos.Equals(0) && !tempoMedioMinutos.Equals(1))
            {
                double tempoMediotemp = (tempoMedioMinutos + Int32.Parse(tempoMedioStr)) / 2;
                tempoMedioMinutos = Convert.ToInt32(tempoMediotemp);
            }
        }

        private void backWorkSincronizar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int numTentativas = 0;

            SalvarXML();

            EndExecut();

            tpSync.Habilitar();
            tpServer1.Habilitar();
            tpServer2.Habilitar();

            if (e.Error == null)
            {
                MessageBox.Show("Sincronização efetuada com sucesso!");
                txtInformacoes.Text = strResultado;
                btnSincronizar.Text = "Sincronizar";
                btnSincronizar.Image = SyncDatabase.Properties.Resources.arrow_refresh;
            }
            else if (e.Error.Message.Contains("E_ABORT"))
            {
                btnSincronizar.Text = "Sincronizar";
                btnSincronizar.Image = SyncDatabase.Properties.Resources.arrow_refresh;
                if (!strResultado.Contains("Erro ocorrido"))
                {
                    txtInformacoes.Text = DateTime.Now.ToString("dd/MM/yyyy - hh:mm:ss") + " - Cancelada";
                }
                else
                {
                    txtInformacoes.Text = strResultado;
                }
            }
            else
            {
                if (numTentativas == numSync)
                {
                    btnSincronizar.Text = "Sincronizar";
                    btnSincronizar.Image = SyncDatabase.Properties.Resources.arrow_refresh;
                    MessageBox.Show("Erro ocorrido na sincronização! Tente novamente." + Environment.NewLine + e.Error.Message);
                }
                else
                {
                    numTentativas++;
                    txtInformacoes.Text = "Tentativa " + numTentativas.ToString() + ": Falhou: " + e.Error.Message;
                    InitExecut("Tentativa 2. Testando conexão e escopo...");
                    TestarConexaoEEscopos();
                }
            }
        }

        #endregion        
    }
}
