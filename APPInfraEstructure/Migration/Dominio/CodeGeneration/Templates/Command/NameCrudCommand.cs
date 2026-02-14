//aqui é uma template que foi usada pelo CrudComandGeneration para replicar codigo 


//namespace Command.Write
//{
//    public class CrudCommand : ICommand
//    {
//        public int? Id { get; set; }
//        public string Nome { get; set; }
//        public string Endereco { get; set; }
//        public string Telefone { get; set; }
//        public int? TenantID { get; set; }
//        public bool? Deleted { get; set; }
//        public DateTime? Changed { get; set; }
//        public int? UserId { get; set; }
//    }
//}


///*  aqui é como chamar a geração de codigo 
//        {

//            #region Migrations 
//            var generator = new CommandSimpleGenerator();

//            foreach (var entity in migration.Entitys)
//            {
//                var code = generator.Generate(entity, CommandType.Crud, "");
//                File.WriteAllText(
//                    $"c:\\temp\\source\\{entity.EntityName}Commands.cs",
//                    code);
//            }

