namespace Tesseract.DA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        ShortDescription = c.String(),
                        Year = c.Int(nullable: false),
                        Link = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArticleAuthors",
                c => new
                    {
                        Article_Id = c.Guid(nullable: false),
                        Author_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Article_Id, t.Author_Id })
                .ForeignKey("dbo.Articles", t => t.Article_Id, cascadeDelete: true)
                .ForeignKey("dbo.Authors", t => t.Author_Id, cascadeDelete: true)
                .Index(t => t.Article_Id)
                .Index(t => t.Author_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ArticleAuthors", new[] { "Author_Id" });
            DropIndex("dbo.ArticleAuthors", new[] { "Article_Id" });
            DropForeignKey("dbo.ArticleAuthors", "Author_Id", "dbo.Authors");
            DropForeignKey("dbo.ArticleAuthors", "Article_Id", "dbo.Articles");
            DropTable("dbo.ArticleAuthors");
            DropTable("dbo.Articles");
            DropTable("dbo.Authors");
        }
    }
}
