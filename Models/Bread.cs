using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DotnetBakery.Models
{

    public enum BreadType
    {
        Sourdough, 
        Focaccia,
        Rye, 
        White, 
    }
    public class Bread 
    {

        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }
    
        public int count { get; set; }

        // id of baker who baked this bread

        [ForeignKey("bakedBy")]
        public int bakedById { get; set; }

        // while bakedByiD is an int with the baker's id, 
        // this field is an actual baker object
        // this will allow us to next the baker object
        // inside our bread response from GET /api/breads
        public Baker bakedBy { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BreadType type { get; set; }
    }
}
