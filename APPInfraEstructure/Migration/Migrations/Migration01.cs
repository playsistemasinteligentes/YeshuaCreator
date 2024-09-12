using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Dapper;
using Dominio.Migration;
using Microsoft.Data.SqlClient;

namespace Migrations
{

    [Migration(000001)]
    public class M000001 : MigrationBase
    {
        public override void Up()
        {
            AddEntity("Clinica");
            AddColumn("Id", "ID").Int().Incremento().Key();
            AddColumn("RazaoSocial").Varchar(100);
            AddColumn("NomeReduzido").Varchar(100);

            AddEntity("Paciente");
            AddColumn("Id").Int().Incremento();
            AddColumn("RazaoSocial", "Razão Social").Varchar(100);
            AddColumn("NomeReduzido").Varchar(100);
        }
    }


    [Migration(000002)]
    public class M000002 : MigrationBase
    {
        public override void Up()
        {
            AddEntity("ExecoesCalendario").
            AddColumn("Id").Int().Incremento().Key();
            AddColumn("teste").Int();
        }
    }



    [Migration(000003)]
    public class M000003 : MigrationBase
    {
        public override void Up()
        {
            AlterEntity("ExecoesCalendario")
                .AddColumn("De").DateTime()
                .AddColumn("Ate").DateTime()
                .DropColumn("teste");
            //.GPT("quero metodo que calcula desconto baseado na classe x ")
        }

    }
    [Migration(000004)]
    public class M000004 : MigrationBase
    {
        public override void Up()
        {
            AlterEntity("Clinica")
                .AddColumn("Endereco").Varchar(100);
            //.GPT("quero metodo que calcula desconto baseado na classe x ")
        }

    }
}


/*
 
 //////////////////////////////
///using FluentMigrator;

namespace Migrations.Migrations
{
    [Migration(9066)]
    public class M09066 : Migration
    {
        public override void Down()
        {
        }

        public override void Up()
        {

            if (!Schema.Table("T_BIDDING_CHECKLIST").Column("TCL_TIPO_PREENCHIMENTO_CHECKLIST").Exists())
                Create.Column("TCL_TIPO_PREENCHIMENTO_CHECKLIST").OnTable("T_BIDDING_CHECKLIST").AsInt32().Nullable();
        }
    }
}



namespace FluentMigrator;

public abstract class Migration : MigrationBase
{
    public IDeleteExpressionRoot Delete => new DeleteExpressionRoot(_context);

    public IExecuteExpressionRoot Execute => new ExecuteExpressionRoot(_context);

    public IUpdateExpressionRoot Update => new UpdateExpressionRoot(_context);
}
#if false // Decompilation log











public abstract class MigrationBase : IMigration
{
    internal IMigrationContext _context;

    private readonly object _mutex = new object();

    //
    // Summary:
    //     The arbitrary application context passed to the task runner.
    public object ApplicationContext { get; protected set; }

    //
    // Summary:
    //     Connection String that is used to execute migrations.
    public string ConnectionString { get; protected set; }

    public IAlterExpressionRoot Alter => new AlterExpressionRoot(_context);

    public ICreateExpressionRoot Create => new CreateExpressionRoot(_context);

    public IRenameExpressionRoot Rename => new RenameExpressionRoot(_context);

    public IInsertExpressionRoot Insert => new InsertExpressionRoot(_context);

    public ISchemaExpressionRoot Schema => new SchemaExpressionRoot(_context);

    public abstract void Up();

    public abstract void Down();

    public void ApplyConventions(IMigrationContext context)
    {
        foreach (IMigrationExpression expression in context.Expressions)
        {
            expression.ApplyConventions(context.Conventions);
        }
    }

    public virtual void GetUpExpressions(IMigrationContext context)
    {
        lock (_mutex)
        {
            _context = context;
            ApplicationContext = context.ApplicationContext;
            ConnectionString = context.Connection;
            Up();
            _context = null;
        }
    }

    public virtual void GetDownExpressions(IMigrationContext context)
    {
        lock (_mutex)
        {
            _context = context;
            ApplicationContext = context.ApplicationContext;
            ConnectionString = context.Connection;
            Down();
            _context = null;
        }
    }

    public IIfDatabaseExpressionRoot IfDatabase(params string[] databaseType)
    {
        return new IfDatabaseExpressionRoot(_context, databaseType);
    }
}



#region Assembly FluentMigrator, Version=1.6.1.0, Culture=neutral, PublicKeyToken=aacfc7de5acabf05
// C:\Users\AngeloRFontana.AzureAD\Documents\Projetos\Migrations\packages\FluentMigrator.1.6.1\lib\40\FluentMigrator.dll
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using FluentMigrator.Infrastructure;

namespace FluentMigrator;

public interface IMigration
{
    //
    // Summary:
    //     The arbitrary application context passed to the task runner.
    object ApplicationContext { get; }

    string ConnectionString { get; }

    void GetUpExpressions(IMigrationContext context);

    void GetDownExpressions(IMigrationContext context);
}
#if false // Decompilation log

 
 */