namespace BookReview.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        Isbn = c.String(),
                        Cover = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Reviewer = c.String(),
                        Body = c.String(),
                        Book_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .Index(t => t.Book_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Reviews", new[] { "Book_Id" });
            DropForeignKey("dbo.Reviews", "Book_Id", "dbo.Books");
            DropTable("dbo.Reviews");
            DropTable("dbo.Books");
        }
    }
}
