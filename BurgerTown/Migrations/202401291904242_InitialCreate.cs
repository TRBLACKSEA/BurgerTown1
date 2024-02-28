namespace BurgerTown.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Masalar",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Masalar");
        }
    }
}
