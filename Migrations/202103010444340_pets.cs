namespace PetAnimals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CurrentOwners",
                c => new
                    {
                        CurrentId = c.Int(nullable: false, identity: true),
                        PetId = c.Int(nullable: false),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CurrentId)
                .ForeignKey("dbo.Owners", t => t.OwnerId, cascadeDelete: true)
                .ForeignKey("dbo.Pets", t => t.PetId, cascadeDelete: true)
                .Index(t => t.PetId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        OwnerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Gender = c.String(),
                        DateRegistration = c.DateTime(nullable: false),
                        Mobile = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.OwnerId);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        PetId = c.Int(nullable: false, identity: true),
                        PetName = c.String(),
                        Arrival = c.DateTime(nullable: false),
                        PetSex = c.String(),
                        Weight = c.Double(nullable: false),
                        AdaptionDate = c.DateTime(nullable: false),
                        AdoptionStatus = c.Boolean(nullable: false),
                        SpecieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PetId)
                .ForeignKey("dbo.Species", t => t.SpecieId, cascadeDelete: true)
                .Index(t => t.SpecieId);
            
            CreateTable(
                "dbo.Species",
                c => new
                    {
                        SpecieId = c.Int(nullable: false, identity: true),
                        SpecieName = c.String(),
                    })
                .PrimaryKey(t => t.SpecieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CurrentOwners", "PetId", "dbo.Pets");
            DropForeignKey("dbo.Pets", "SpecieId", "dbo.Species");
            DropForeignKey("dbo.CurrentOwners", "OwnerId", "dbo.Owners");
            DropIndex("dbo.Pets", new[] { "SpecieId" });
            DropIndex("dbo.CurrentOwners", new[] { "OwnerId" });
            DropIndex("dbo.CurrentOwners", new[] { "PetId" });
            DropTable("dbo.Species");
            DropTable("dbo.Pets");
            DropTable("dbo.Owners");
            DropTable("dbo.CurrentOwners");
        }
    }
}
