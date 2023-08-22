using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Tracing;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ExtraaEdgeAssignment.Models
{
    public class MobileBrand
    {
        [Key]
        public int Id {  get; set; }
        public string BrandName { get; set; }

        [InverseProperty("MobileBrand")]
        [JsonIgnore]
        public List<Mobile> MobileId { get; set; }=new List<Mobile>();

    }
}
