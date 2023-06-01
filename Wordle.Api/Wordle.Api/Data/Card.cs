using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wordle.Api.Data
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        public string? Suit { get; set; }
        public int CardValue { get; set; }
    }
}
