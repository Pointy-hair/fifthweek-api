// <auto-generated />
namespace Fifthweek.Api.Persistence.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.1.0-30225")]
    public sealed partial class AddIndexOnEncryptedRefreshTokenId : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(AddIndexOnEncryptedRefreshTokenId));
        
        string IMigrationMetadata.Id
        {
            get { return "201508301027155_AddIndexOnEncryptedRefreshTokenId"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
