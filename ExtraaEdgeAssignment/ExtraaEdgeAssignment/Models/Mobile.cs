using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ExtraaEdgeAssignment.Models
{
    public class Mobile
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int NumberOfMobiles { get; set; }

        public int MobileBrandId { get; set; }

        [JsonIgnore]
        public MobileBrand? MobileBrand { get; set; }

        [InverseProperty("Mob")]
        [JsonIgnore]
        public List<MobileSales> MobilesId { get; set; }=new List<MobileSales>();


    }
}
