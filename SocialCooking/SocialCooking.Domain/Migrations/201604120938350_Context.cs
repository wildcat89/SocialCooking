namespace SocialCooking.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Context : DbMigration
    {
        public override void Up()
        {
            
            AddColumn("dbo.UsersExtensions", "ImageThumbPath", c => c.String());

        }
        
        public override void Down()
        {
        }
    }
}
