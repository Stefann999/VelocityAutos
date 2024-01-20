﻿using System.ComponentModel.DataAnnotations;
using static VelocityAutos.Common.EntityValidationConstants.Extra;

namespace VelocityAutos.Data.Models
{
    public class ExtraType
    {
        public ExtraType()
        {
            this.Extras = new HashSet<Extra>();
        }
        public int Id { get; init; }

        [Required]
        [MinLength(ExtraNameMinLength)]
        [MaxLength(ExtraNameMaxLength)]
        public string ExtraTypeName { get; set; } = null!;

        public ICollection<Extra> Extras { get; set; }
    }
}
