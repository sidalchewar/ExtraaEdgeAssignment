using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ExtraaEdgeAssignment.Models
{
    public class MobileSales
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }= DateTime.Now;
        public int NumberOfMobileSales { get; set; }

        [JsonIgnore]
        public float TotalPrice { get; set; }
       
        public int MobileId { get; set; }

        [JsonIgnore]
        public Mobile? Mob { get; set; }
    }
}
