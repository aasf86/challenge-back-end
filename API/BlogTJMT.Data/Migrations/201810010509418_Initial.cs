namespace BlogTJMT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MenuPermicao", "MenuId", "dbo.Menu");
            DropForeignKey("dbo.MenuPermicao", "PerfilPermicaoId", "dbo.PerfilPermicao");
            DropIndex("dbo.MenuPermicao", new[] { "MenuId" });
            DropIndex("dbo.MenuPermicao", new[] { "PerfilPermicaoId" });
            DropTable("dbo.MenuPermicao");
            DropTable("dbo.Menu");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 40),
                        Enum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MenuPermicao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuId = c.Int(nullable: false),
                        PerfilPermicaoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.MenuPermicao", "PerfilPermicaoId");
            CreateIndex("dbo.MenuPermicao", "MenuId");
            AddForeignKey("dbo.MenuPermicao", "PerfilPermicaoId", "dbo.PerfilPermicao", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MenuPermicao", "MenuId", "dbo.Menu", "Id", cascadeDelete: true);
        }
    }
}
