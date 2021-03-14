using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

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
        public MenuType MenuType { get; set; }
        public List<MenuItem> SubMenu { get; set; }
    }
    public enum MenuType
    {

    }
}
