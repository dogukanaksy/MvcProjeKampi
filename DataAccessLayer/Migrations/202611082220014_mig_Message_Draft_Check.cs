namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_Message_Draft_Check : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "IsDraft", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "IsDraft");
        }
    }
}
