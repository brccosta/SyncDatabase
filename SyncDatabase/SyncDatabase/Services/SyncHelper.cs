using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Synchronization.Data.SqlServer;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization;

namespace SyncDatabase
{
    public static class SyncHelper
    {

        public static SyncOrchestrator orchestrator;

        public static SyncOperationStatistics Sincronizar(SqlSyncProvider providerOrigem, SqlSyncProvider providerDestino, String strDirection)
        {
            try
            {
                orchestrator = new SyncOrchestrator();
                

                


                switch (strDirection)
                {
                    case "Enviar exames":
                        {
                            providerOrigem.ScopeName = "Enviar_Exames";
                            providerDestino.ScopeName = "Enviar_Exames";
                            orchestrator.LocalProvider = providerOrigem;
                            orchestrator.RemoteProvider = providerDestino;

                            orchestrator.Direction = SyncDirectionOrder.Upload;
                            break;
                        }
                    case "Atualizar solicitações":
                        {
                            providerOrigem.ScopeName = "Atualizar_Solicitacoes";
                            providerDestino.ScopeName = "Atualizar_Solicitacoes";
                            orchestrator.LocalProvider = providerOrigem;
                            orchestrator.RemoteProvider = providerDestino;

                            orchestrator.Direction = SyncDirectionOrder.UploadAndDownload;
                            break;
                        }
                    case "Primeira_Configuracao":
                        {
                            providerOrigem.ScopeName = "Enviar_Exames";
                            providerDestino.ScopeName = "Enviar_Exames";
                            orchestrator.LocalProvider = providerOrigem;
                            orchestrator.RemoteProvider = providerDestino;

                            orchestrator.Direction = SyncDirectionOrder.UploadAndDownload;
                            break;
                        }
                    default:
                        {
                            break;
                        }

                }

                SyncOperationStatistics syncStat = orchestrator.Synchronize();

                return syncStat;
            }
            catch (Exception ex)
            {
                throw new Exception("Mensagem: " + ex.Message + " | Inner Exception: " + ex.InnerException);
            }


        }


        public static SqlConnection TestarConexao(string strConexao)
        {
            SqlConnection sqlConn = new SqlConnection(strConexao);
            try
            {
                sqlConn.Open();
                if (sqlConn.State.Equals(ConnectionState.Open))
                {
                    return sqlConn;
                }
                else
                {
                    throw new Exception("Não foi possível se conectar ao servidor, verifique.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public static void LimparScopeProvisioning(SqlConnection sqlConn, String nomeEscopo)
        {
            SqlSyncScopeDeprovisioning objSqlSyncScopeDeprovisioning = new SqlSyncScopeDeprovisioning(sqlConn);

            objSqlSyncScopeDeprovisioning.DeprovisionScope(nomeEscopo);
            objSqlSyncScopeDeprovisioning.DeprovisionStore();
        }

        public static SqlSyncProvider ConfigurarScopo(this SqlSyncProvider provider, string tabelasIgnoradas)
        {
            try
            {
                if (provider != null)
                {
                    DbSyncScopeDescription scopeDesc = new DbSyncScopeDescription(provider.ScopeName);
                    SqlSyncScopeProvisioning serverConfig = new SqlSyncScopeProvisioning((System.Data.SqlClient.SqlConnection)provider.Connection);



                    if (!serverConfig.ScopeExists(provider.ScopeName))
                    {
                        ConnectionManager objConnectionManager = new ConnectionManager();
                        String strSql = "SELECT Table_Name FROM Information_Schema.Tables WHERE Table_Name != 'sysdiagrams' AND Table_Name not like('vw%') ";

                        if (!tabelasIgnoradas.Trim().Equals(""))
                        {
                            strSql += "AND Table_Name not in(" + tabelasIgnoradas + ")";
                        }


                        DataTable dtTabelas = objConnectionManager.retornarTabela(strSql, "Tabelas", provider.Connection.ConnectionString);

                        foreach (DataRow row in dtTabelas.Rows)
                        {
                            String str = row["Table_Name"].ToString();
                            scopeDesc.Tables.Add(SqlSyncDescriptionBuilder.GetDescriptionForTable(row["Table_Name"].ToString(), (System.Data.SqlClient.SqlConnection)provider.Connection));
                        }


                        serverConfig.PopulateFromScopeDescription(scopeDesc);
                        serverConfig.SetCreateTableDefault(DbSyncCreationOption.Skip);

                        serverConfig.Apply();
                    }
                }

                return provider;
            }
            catch (Exception ex)
            {
                throw new Exception("Mensagem: " + ex.Message);
            }
        }

        public static SqlSyncProvider VerificarEscopo(string nomeEscopo, SqlConnection sqlConn)
        {
            SqlSyncScopeProvisioning serverConfig = new SqlSyncScopeProvisioning(sqlConn);

            if (serverConfig.ScopeExists(nomeEscopo))
            {
                return new SqlSyncProvider(nomeEscopo, sqlConn);
            }
            else
            {
                throw new Exception("O Escopo ainda não foi configurado!");
            }
        }
    }
}
