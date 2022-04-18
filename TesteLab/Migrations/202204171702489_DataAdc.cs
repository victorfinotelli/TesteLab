namespace TesteLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAdc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jogos", "Data", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jogos", "Data");
        }
    }
}
