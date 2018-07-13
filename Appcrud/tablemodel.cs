using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Appcrud
{
    [Table("Tablemodel")]
    class tablemodel
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }
        [MaxLength(25)]

        [Column("name")]
        public string Name { get; set; }
        [MaxLength(25)]

        [Column("phone")]
        public int Phone { get; set; }
        [MaxLength(10)]

        [Column("place")]
        public string Place { get; set; }
        
    }
}