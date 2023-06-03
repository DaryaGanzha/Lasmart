using Lasmart.Data;
using Lasmart.Models;

namespace Lasmart.Services
{
    public class PointService
    {
        private readonly ApplicationContext _context;
        public PointService()
        {
            _context = new ApplicationContext();
        }
        public bool CreatePoint(Point point)
        {
            try
            {
                _context.Points.Add(point);
                _context.SaveChanges();
            } catch
            {
                throw new Exception("Point not created.");
            }
            return true;
        }
        public List<Point> GetAllPoins()
        {
            var points = _context.Points.ToList();
            return points;
        }

        public bool CreateComment(Comment comment)
        {
            try
            {
                _context.Comments.Add(comment);
                _context.SaveChanges();
            } catch
            {
                throw new Exception("Comment not created");
            }
            return true;
        }

        public List<Comment> GetCommentsByPoint(Guid pointId)
        {
            var comments = _context.Comments.Where(c => c.PointId == pointId).ToList();
            return comments;
        }

        public List<Comment> GetAllComments()
        {
            return _context.Comments.ToList();
        }

        //public List<Comment> GetAll

        public bool SetRemovalTime(Guid pointID)
        {
            try
            {
                var point = _context.Points.FirstOrDefault(p => p.PointID == pointID);
                if (point != null)
                {
                    point.LastDeletionTime = DateTime.Now;
                    _context.SaveChanges();
                }
            } catch
            {
                throw new Exception("The deletion date has not been updated.");
            }
            return true;
        }

    }
}
