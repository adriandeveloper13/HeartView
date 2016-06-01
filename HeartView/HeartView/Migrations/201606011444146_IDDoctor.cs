namespace HeartView.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDDoctor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IDDoctor", c => c.Guid());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IDDoctor");
        }
    }
}
