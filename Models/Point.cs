using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Lasmart.Models
{
    public class Point
    {
        [Key]
        public Guid PointID { get; set; }
        [NotNull]
        public double XCoordinate { get; set; }
        [NotNull]
        public double YCoordinate { get; set; }
        [NotNull]
        public double Radius { get; set; }
        [MaybeNull]
        public string? Color { get; set; }
        //public bool? DisplayStatus { get; set; }
        public DateTime? LastDeletionTime { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public Point()
        {
            this.PointID = Guid.NewGuid();
            this.Color = "Black";
            //this.DisplayStatus = true;
            this.LastDeletionTime = null;
        }
    }
}
