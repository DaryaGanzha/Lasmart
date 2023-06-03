using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Lasmart.Models
{
    public class Comment
    {
        [Key]
        public Guid CommentID { get; set; }
        [NotNull]
        public string CommentText { get; set; }
        [MaybeNull]
        public string? BackgroundColor { get; set; }
        public Guid PointId { get; set; }
        public Point? Point { get; set; }
        public Comment()
        {
            this.CommentID = Guid.NewGuid();
            this.BackgroundColor = "White";
        }
    }
}
