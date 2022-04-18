namespace TesteLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remover_Data : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Jogos", "Data");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jogos", "Data", c => c.String());
        }
    }
}
