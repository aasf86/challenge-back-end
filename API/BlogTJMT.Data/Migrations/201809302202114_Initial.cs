namespace BlogTJMT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 40),
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menu", t => t.MenuId, cascadeDelete: true)
                .ForeignKey("dbo.PerfilPermicao", t => t.PerfilPermicaoId, cascadeDelete: true)
                .Index(t => t.MenuId)
                .Index(t => t.PerfilPermicaoId);
            
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
                "dbo.PerfilPermicao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PerfilId = c.Int(nullable: false),
                        PermicaoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Perfil", t => t.PerfilId, cascadeDelete: true)
                .ForeignKey("dbo.Permicao", t => t.PermicaoId, cascadeDelete: true)
                .Index(t => t.PerfilId)
                .Index(t => t.PermicaoId);
            
            CreateTable(
                "dbo.Perfil",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 120),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permicao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 120),
                        Enum = c.Int(nullable: false),
                        Perfil_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Perfil", t => t.Perfil_Id)
                .Index(t => t.Perfil_Id);
            
            CreateTable(
                "dbo.PostComentario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 350),
                        UsuarioId = c.Int(nullable: false),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .Index(t => t.UsuarioId)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 60),
                        Descricao = c.String(nullable: false, maxLength: 120),
                        Conteudo = c.String(nullable: false, maxLength: 650),
                        Visualizacoes = c.Int(nullable: false),
                        Curtidas = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        ImagemDestaque = c.String(),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Sobrenome = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 120),
                        DataNascimento = c.DateTime(nullable: false),
                        Descricao = c.String(),
                        Senha = c.String(nullable: false, maxLength: 32),
                        PerfilId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Perfil", t => t.PerfilId, cascadeDelete: true)
                .Index(t => t.PerfilId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostComentario", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.PostComentario", "PostId", "dbo.Post");
            DropForeignKey("dbo.Post", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "PerfilId", "dbo.Perfil");
            DropForeignKey("dbo.Post", "CategoriaId", "dbo.Categoria");
            DropForeignKey("dbo.MenuPermicao", "PerfilPermicaoId", "dbo.PerfilPermicao");
            DropForeignKey("dbo.PerfilPermicao", "PermicaoId", "dbo.Permicao");
            DropForeignKey("dbo.PerfilPermicao", "PerfilId", "dbo.Perfil");
            DropForeignKey("dbo.Permicao", "Perfil_Id", "dbo.Perfil");
            DropForeignKey("dbo.MenuPermicao", "MenuId", "dbo.Menu");
            DropIndex("dbo.Usuario", new[] { "PerfilId" });
            DropIndex("dbo.Post", new[] { "CategoriaId" });
            DropIndex("dbo.Post", new[] { "UsuarioId" });
            DropIndex("dbo.PostComentario", new[] { "PostId" });
            DropIndex("dbo.PostComentario", new[] { "UsuarioId" });
            DropIndex("dbo.Permicao", new[] { "Perfil_Id" });
            DropIndex("dbo.PerfilPermicao", new[] { "PermicaoId" });
            DropIndex("dbo.PerfilPermicao", new[] { "PerfilId" });
            DropIndex("dbo.MenuPermicao", new[] { "PerfilPermicaoId" });
            DropIndex("dbo.MenuPermicao", new[] { "MenuId" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Post");
            DropTable("dbo.PostComentario");
            DropTable("dbo.Permicao");
            DropTable("dbo.Perfil");
            DropTable("dbo.PerfilPermicao");
            DropTable("dbo.Menu");
            DropTable("dbo.MenuPermicao");
            DropTable("dbo.Categoria");
        }
    }
}
