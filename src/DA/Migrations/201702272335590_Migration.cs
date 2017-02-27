namespace Tesseract.DA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ArticleAuthors", newName: "AuthorArticles");
            DropPrimaryKey("dbo.AuthorArticles");
            AddPrimaryKey("dbo.AuthorArticles", new[] { "Author_Id", "Article_Id" });
        }
        
        public override void Down()
        {
            DropIndex("dbo.AuthorArticles", new[] { "Article_Id" });
            DropIndex("dbo.AuthorArticles", new[] { "Author_Id" });
            DropPrimaryKey("dbo.AuthorArticles");
            AddPrimaryKey("dbo.AuthorArticles", new[] { "Article_Id", "Author_Id" });
            RenameTable(name: "dbo.AuthorArticles", newName: "ArticleAuthors");
        }
    }
}
