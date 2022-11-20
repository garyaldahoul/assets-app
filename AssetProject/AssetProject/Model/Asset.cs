using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetProject.Model
{
	public class Asset
	{
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Brand { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Model { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Country { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        [Column(TypeName = "Int")]
        public int Price { get; set; }


    }
}

