namespace Lab_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tokens", "User_ID", "dbo.Users");
            DropIndex("dbo.Tokens", new[] { "User_ID" });
            DropTable("dbo.Tokens");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 50),
                        User_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.Tokens", "User_ID");
            AddForeignKey("dbo.Tokens", "User_ID", "dbo.Users", "ID", cascadeDelete: true);
        }
    }
}
