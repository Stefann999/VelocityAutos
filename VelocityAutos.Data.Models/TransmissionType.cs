﻿using System.ComponentModel.DataAnnotations;
using static VelocityAutos.Common.EntityValidationConstants.Car;

namespace VelocityAutos.Data.Models
{
    public class TransmissionType
    {
        public TransmissionType()
        {
            this.Cars = new HashSet<Car>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(TransmissionTypeMinLength)]
        [MaxLength(TransmissionTypeMaxLength)]
        public string TransmissionTypeName { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
