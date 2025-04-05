﻿using DataAccess.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Domain
{
    public abstract class EntityBase : IEntity
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("STATUS")]
        public string? Status { get; set; }

        [Column("INACTIVE_DATE")]
        public DateTime? InactiveDate { get; set; }

        [Column("CREATED_BY")]
        public string? CreatedBy { get; set; }

        [Column("CREATION_DATE")]
        public DateTime CreationDate { get; set; }

        [Column("LAST_UPDATED_BY")]
        public string? LastUpdatedBy { get; set; }

        [Column("LAST_UPDATE_DATE")]
        public DateTime LastUpdateDate { get; set; }
    }
}
