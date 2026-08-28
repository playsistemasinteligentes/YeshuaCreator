using Dominio.Migration;
using Migration.Dominio.Schemas.CQRS;

namespace Yeshua.Studio.APS.ADM.Migrations;

[Migration(000003)]
public class M000003 : MigrationBase
{
    public override void Up()
    {
        AddEntity("Relatorios").LegacySource("T_RELATORIOS").AddModule("APSADM")
            .AddColumn("REL_ID", "REL ID").Int().Incremento().Key().NotNull().LegacyColumn("REL_ID", "int")
            .AddColumn("REL_NOME_RELATORIO", "REL NOME RELATORIO").Varchar(30).LegacyColumn("REL_NOME_RELATORIO", "varchar(30)")
            .AddColumn("REL_NOME_CAMPO", "REL NOME CAMPO").Varchar(100).NotNull().LegacyColumn("REL_NOME_CAMPO", "varchar(100)")
            .AddColumn("REL_TIPO_CAMPO", "REL TIPO CAMPO").Varchar(50).NotNull().LegacyColumn("REL_TIPO_CAMPO", "varchar(50)")
            .AddColumn("REL_POS_X", "REL POS X").Int().LegacyColumn("REL_POS_X", "int")
            .AddColumn("REL_POS_Y", "REL POS Y").Int().LegacyColumn("REL_POS_Y", "int")
            .AddColumn("REL_TAMANHO_FONTE", "REL TAMANHO FONTE").Int().LegacyColumn("REL_TAMANHO_FONTE", "int");

        AddEntity("InspecaoVisual").LegacySource("T_INSPECAO_VISUAL").AddModule("APSADM")
            .AddColumn("IPV_ID", "IPV ID").Int().Incremento().Key().NotNull().LegacyColumn("IPV_ID", "int")
            .AddColumn("IPV_VALOR", "IPV VALOR").Varchar(10).LegacyColumn("IPV_VALOR", "varchar(10)")
            .AddColumn("IPV_ID_OPERADOR", "IPV ID OPERADOR").Int().LegacyColumn("IPV_ID_OPERADOR", "int")
            .AddColumn("IPV_ID_LIBERACAO", "IPV ID LIBERACAO").Int().LegacyColumn("IPV_ID_LIBERACAO", "int")
            .AddColumn("IPV_OBS", "IPV OBS").Varchar(100).LegacyColumn("IPV_OBS", "varchar(100)")
            .AddColumn("IPV_DATA_COLETA", "IPV DATA COLETA").DateTime().LegacyColumn("IPV_DATA_COLETA", "datetime")
            .AddColumn("IPV_DATA_AVAL", "IPV DATA AVAL").DateTime().LegacyColumn("IPV_DATA_AVAL", "datetime")
            .AddColumn("TIV_ID", "TIV ID").Int().LegacyColumn("TIV_ID", "int")
            .AddColumn("TURN_ID", "TURN ID").FK("Turno", "Id").RelationTab("InspecaoVisual", "InspecaoVisual").Varchar(10).LegacyColumn("TURN_ID", "varchar(10)")
            .AddColumn("TURM_ID", "TURM ID").FK("Turma", "Id").RelationTab("InspecaoVisual", "InspecaoVisual").Varchar(10).LegacyColumn("TURM_ID", "varchar(10)")
            .AddColumn("ORD_ID", "ORD ID").Varchar(60).LegacyColumn("ORD_ID", "varchar(60)")
            .AddColumn("ROT_PRO_ID", "ROT PRO ID").Varchar(30).LegacyColumn("ROT_PRO_ID", "varchar(30)")
            .AddColumn("ROT_MAQ_ID", "ROT MAQ ID").Varchar(30).LegacyColumn("ROT_MAQ_ID", "varchar(30)")
            .AddColumn("ROT_SEQ_TRANSFORMACAO", "ROT SEQ TRANSFORMACAO").Int().LegacyColumn("ROT_SEQ_TRANSFORMACAO", "int")
            .AddColumn("FPR_SEQ_REPETICAO", "FPR SEQ REPETICAO").Int().LegacyColumn("FPR_SEQ_REPETICAO", "int")
            .AddColumn("IPV_STATUS_LIBERACAO", "IPV STATUS LIBERACAO").Varchar(30).LegacyColumn("IPV_STATUS_LIBERACAO", "varchar(30)")
            .AddColumn("IPV_VALOR_MEDIDA", "IPV VALOR MEDIDA").Decimal(18, 6).LegacyColumn("IPV_VALOR_MEDIDA", "float", "float_to_decimal_18_6");

        AddEntity("TemplateTipoInspecaoVisual").LegacySource("T_TEMPLATE_TIPO_INSPECAO_VISUAL").AddModule("APSADM")
            .AddColumn("TTI_ID", "TTI ID").Int().Incremento().Key().NotNull().LegacyColumn("TTI_ID", "int")
            .AddColumn("TIV_ID", "TIV ID").Int().LegacyColumn("TIV_ID", "int")
            .AddColumn("TEM_ID", "TEM ID").FK("TemplateDeTestes", "Id").RelationTab("TemplateTipoInspecaoVisual", "TemplateTipoInspecaoVisual").Int().LegacyColumn("TEM_ID", "int");

        AddEntity("TemplateTipoTeste").LegacySource("T_TEMPLATE_TIPO_TESTE").AddModule("APSADM")
            .AddColumn("TTT_ID", "TTT ID").Int().Incremento().Key().NotNull().LegacyColumn("TTT_ID", "int")
            .AddColumn("TT_ID", "TT ID").FK("TipoTeste", "TT_ID").RelationTab("TemplateTipoTeste", "TemplateTipoTeste").Int().NotNull().LegacyColumn("TT_ID", "int")
            .AddColumn("TEM_ID", "TEM ID").FK("TemplateDeTestes", "Id").RelationTab("TemplateTipoTeste", "TemplateTipoTeste").Int().NotNull().LegacyColumn("TEM_ID", "int");

        AddEntity("TipoAvaliacao").LegacySource("T_TIPO_AVALIACAO").AddModule("APSADM")
            .AddColumn("TA_ID", "TA ID").Int().Incremento().Key().NotNull().LegacyColumn("TA_ID", "int")
            .AddColumn("TA_DESC", "TA DESC").Varchar(50).NotNull().LegacyColumn("TA_DESC", "varchar(50)");

        AlterEntity("TipoTeste")
            .AddColumn("TT_ID", "TT ID").Int().Incremento().Key().NotNull().LegacyColumn("TT_ID", "int")
            .AddColumn("TT_NOME", "TT NOME").Varchar(50).NotNull().LegacyColumn("TT_NOME", "varchar(50)")
            .AddColumn("TT_DESC", "TT DESC").Varchar(200).NotNull().LegacyColumn("TT_DESC", "varchar(200)")
            .AddColumn("TT_TOL_MAIS", "TT TOL MAIS").Decimal(18, 6).LegacyColumn("TT_TOL_MAIS", "float", "float_to_decimal_18_6")
            .AddColumn("TT_TOL_MENOS", "TT TOL MENOS").Decimal(18, 6).LegacyColumn("TT_TOL_MENOS", "float", "float_to_decimal_18_6")
            .AddColumn("TT_NORMA", "TT NORMA").Varchar(50).LegacyColumn("TT_NORMA", "varchar(50)")
            .AddColumn("TT_INICIO_PROCESSO", "TT INICIO PROCESSO").Varchar(1).NotNull().LegacyColumn("TT_INICIO_PROCESSO", "char(1)")
            .AddColumn("TA_ID", "TA ID").FK("TipoAvaliacao", "TA_ID").RelationTab("TipoTeste", "TipoTeste").Int().NotNull().LegacyColumn("TA_ID", "int")
            .AddColumn("UNI_ID", "UNI ID").Varchar(30).NotNull().LegacyColumn("UNI_ID", "varchar(30)")
            .AddColumn("TT_N_AMOSTRAS_P_TESTE", "TT N AMOSTRAS P TESTE").Int().LegacyColumn("TT_N_AMOSTRAS_P_TESTE", "int")
            .AddColumn("TT_MAX_DEF_CRITICO", "TT MAX DEF CRITICO").Int().LegacyColumn("TT_MAX_DEF_CRITICO", "int")
            .AddColumn("TT_MAX_DEF_GRAVE", "TT MAX DEF GRAVE").Int().LegacyColumn("TT_MAX_DEF_GRAVE", "int");

        AlterEntity("TipoInspecaoVisual")
            .AddColumn("TIV_NOME", "TIV NOME").Varchar(60).LegacyColumn("TIV_NOME", "varchar(60)")
            .AddColumn("TIV_DESCRICAO", "TIV DESCRICAO").Varchar(120).LegacyColumn("TIV_DESCRICAO", "varchar(120)")
            .AddColumn("TIV_FECHAMENTO", "TIV FECHAMENTO").Varchar(1).LegacyColumn("TIV_FECHAMENTO", "char(1)")
            .AddColumn("TIV_AMOSTRA_ALEATORIA", "TIV AMOSTRA ALEATORIA").Varchar(1).LegacyColumn("TIV_AMOSTRA_ALEATORIA", "char(1)")
            .AddColumn("TIV_N_AMOSTRAS", "TIV N AMOSTRAS").Int().LegacyColumn("TIV_N_AMOSTRAS", "int")
            .AddColumn("TIV_MEDIDA", "TIV MEDIDA").Varchar(1).LegacyColumn("TIV_MEDIDA", "char(1)")
            .AddColumn("TIV_ESPECIFICACAO", "TIV ESPECIFICACAO").Decimal(18, 6).LegacyColumn("TIV_ESPECIFICACAO", "float", "float_to_decimal_18_6")
            .AddColumn("TIV_TOL_MAIS", "TIV TOL MAIS").Decimal(18, 6).LegacyColumn("TIV_TOL_MAIS", "float", "float_to_decimal_18_6")
            .AddColumn("TIV_TOL_MENOS", "TIV TOL MENOS").Decimal(18, 6).LegacyColumn("TIV_TOL_MENOS", "float", "float_to_decimal_18_6");

        AlterEntity("CorridasOnduladeira")
            .AddColumn("COR_ID", "COR ID").Int().Incremento().Key().NotNull().LegacyColumn("COR_ID", "int")
            .AddColumn("COR_STATUS", "COR STATUS").Varchar(3).LegacyColumn("COR_STATUS", "varchar(3)")
            .AddColumn("COR_STATUS_INTERFACE", "COR STATUS INTERFACE").Varchar(3).LegacyColumn("COR_STATUS_INTERFACE", "varchar(3)")
            .AddColumn("MAQ_ID", "MAQ ID").Varchar(30).LegacyColumn("MAQ_ID", "varchar(30)")
            .AddColumn("COR_ID_INTERFACE", "COR ID INTERFACE").Int().LegacyColumn("COR_ID_INTERFACE", "int")
            .AddColumn("COR_SEQUENCIA", "COR SEQUENCIA").Int().LegacyColumn("COR_SEQUENCIA", "int")
            .AddColumn("COR_SEQUENCIA_ORIGEM", "COR SEQUENCIA ORIGEM").Int().LegacyColumn("COR_SEQUENCIA_ORIGEM", "int")
            .AddColumn("ORD_ID", "ORD ID").Varchar(60).LegacyColumn("ORD_ID", "varchar(60)")
            .AddColumn("FPR_SEQ_REPETICAO", "FPR SEQ REPETICAO").Int().LegacyColumn("FPR_SEQ_REPETICAO", "int")
            .AddColumn("ROT_SEQ_TRANFORMACAO", "ROT SEQ TRANFORMACAO").Int().LegacyColumn("ROT_SEQ_TRANFORMACAO", "int")
            .AddColumn("COR_FACAO", "COR FACAO").Int().LegacyColumn("COR_FACAO", "int")
            .AddColumn("COR_FORMATO_BOBINA", "COR FORMATO BOBINA").Int().LegacyColumn("COR_FORMATO_BOBINA", "int")
            .AddColumn("COR_INICIO_PREVISTO", "COR INICIO PREVISTO").DateTime().LegacyColumn("COR_INICIO_PREVISTO", "datetime")
            .AddColumn("COR_FIM_PREVISTO", "COR FIM PREVISTO").DateTime().LegacyColumn("COR_FIM_PREVISTO", "datetime")
            .AddColumn("PRO_ID", "PRO ID").Varchar(30).LegacyColumn("PRO_ID", "varchar(30)")
            .AddColumn("COR_QTD_PLANEJADO", "COR QTD PLANEJADO").Int().LegacyColumn("COR_QTD_PLANEJADO", "int")
            .AddColumn("PRO_QTD_PACAS", "PRO QTD PACAS").Int().LegacyColumn("PRO_QTD_PACAS", "int")
            .AddColumn("COR_PECAS_LARGURA", "COR PECAS LARGURA").Int().LegacyColumn("COR_PECAS_LARGURA", "int");

        AlterEntity("PendenciasInterface")
            .AddColumn("PEN_ID", "PEN ID").Int().Incremento().Key().NotNull().LegacyColumn("PEN_ID", "int");

        AlterEntity("PlanoAmostralTeste")
            .AddColumn("PAT_ID", "PAT ID").Int().Incremento().Key().NotNull().LegacyColumn("PAT_ID", "int")
            .AddColumn("PAT_QTD_CAIXAS_DE", "PAT QTD CAIXAS DE").Int().LegacyColumn("PAT_QTD_CAIXAS_DE", "int")
            .AddColumn("PAT_QTD_CAIXAS_ATE", "PAT QTD CAIXAS ATE").Int().LegacyColumn("PAT_QTD_CAIXAS_ATE", "int")
            .AddColumn("PAT_N_AMOSTRAGEM", "PAT N AMOSTRAGEM").Int().LegacyColumn("PAT_N_AMOSTRAGEM", "int")
            .AddColumn("PAT_PERCENT_ESPECIF", "PAT PERCENT ESPECIF").Decimal(18, 6).LegacyColumn("PAT_PERCENT_ESPECIF", "float", "float_to_decimal_18_6");
    }
}
