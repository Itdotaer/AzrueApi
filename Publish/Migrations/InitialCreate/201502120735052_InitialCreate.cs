namespace Publish.Migrations.InitialCreate
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BlobName = c.String(),
                        Description = c.String(),
                        UploadedDate = c.DateTime(nullable: false),
                        UploadedBy = c.String(),
                        LastUpdatedDate = c.DateTime(nullable: false),
                        LastUpdatedBy = c.String(),
                        BlobUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetailInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sex = c.String(),
                        Age = c.Int(nullable: false),
                        Tel = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        DisplayName = c.String(),
                        Email = c.String(),
                        DetailInfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DetailInfoes", t => t.DetailInfo_Id)
                .Index(t => t.DetailInfo_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "DetailInfo_Id", "dbo.DetailInfoes");
            DropIndex("dbo.Users", new[] { "DetailInfo_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.DetailInfoes");
            DropTable("dbo.Blobs");
        }
    }
}
