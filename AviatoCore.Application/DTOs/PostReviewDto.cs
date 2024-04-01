using AviatoCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Application.DTOs
{
    public class PostReviewDto
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int ServiceId { get; set; }

    }
}
