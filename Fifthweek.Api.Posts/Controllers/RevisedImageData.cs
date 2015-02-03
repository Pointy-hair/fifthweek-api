﻿namespace Fifthweek.Api.Posts.Controllers
{
    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.Api.FileManagement.Shared;
    using Fifthweek.Api.Posts.Shared;
    using Fifthweek.CodeGeneration;

    [AutoConstructor, AutoEqualityMembers]
    public partial class RevisedImageData
    {
        public RevisedImageData()
        {
        }

        public CollectionId CollectionId { get; set; }

        public FileId ImageFileId { get; set; }
        
        [Optional]
        [Parsed(typeof(ValidComment))]
        public string Comment { get; set; }
    }
}