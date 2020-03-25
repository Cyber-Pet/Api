using CyberPet.Api.Models.Interfaces;
using MassTransit;
using System;
using System.ComponentModel.DataAnnotations;

namespace CyberPet.Api.Models.Base
{
    public class CoreModel : ICoreModel
    {
        protected CoreModel()
        {
            Id = NewId.NextGuid();
        }
        [Key]
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
