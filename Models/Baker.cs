using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DotnetBakery.Models
{
    public class Baker 
    {
        // all db fields need both a getter and a setter
        // id is special - EF knows it's a primary key and serial
        public int id { get; set; }

        [Required] // means this field is NOT NULL aka Required 
        //automatically sends back 400 if missing in request body
        public string name {get; set;}
    }

}
