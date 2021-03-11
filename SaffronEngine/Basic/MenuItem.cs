using System;
using System.ComponentModel.DataAnnotations;

namespace SaffronEngine.Basic
{
    public class MenuItem
    {
        public Guid Id { get; set; }
        [Required]
        public string DisplayText { get; set; }
        [Required]
        public string Href { get; set; } = "#";
        public string Icon { get; set; }
    }
}
