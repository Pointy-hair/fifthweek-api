﻿namespace Fifthweek.Api.Persistence
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Fifthweek.Api.Core;

    [AutoConstructor, AutoEqualityMembers, AutoSql]
    public partial class Post
    {
        public Post()
        {
        }

        [Required, Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ChannelId { get; set; }

        [Required, Optional, NonEquatable]
        public Channel Channel { get; set; }

        [Optional]
        public Guid? CollectionId { get; set; }

        [Optional, NonEquatable]
        public Collection Collection { get; set; }

        [Optional]
        public Guid? FileId { get; set; }

        [Optional, NonEquatable]
        public File File { get; set; }

        [Optional]
        public Guid? ImageId { get; set; }

        [Optional, NonEquatable]
        public File Image { get; set; }

        [Optional]
        [MaxLength(280)] // See: ValidNote.MaxLength
        public string Comment { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}