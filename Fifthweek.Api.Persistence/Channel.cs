﻿namespace Fifthweek.Api.Persistence
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Fifthweek.CodeGeneration;

    [AutoConstructor, AutoEqualityMembers, AutoSql]
    public partial class Channel
    {
        public Channel()
        {
        }

        [Required, Key]
        public Guid Id { get; set; }

        [Required, Index]
        public Guid BlogId { get; set; }

        [Required, Optional, NonEquatable]
        public Blog Blog { get; set; }

        [Required]
        [MaxLength(50)] // See: ValidChannelName.MaxLength
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public bool IsVisibleToNonSubscribers { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public DateTime PriceLastSetDate { get; set; }

        [Required]
        public bool IsDiscoverable { get; set; }
    }
}