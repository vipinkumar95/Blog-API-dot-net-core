using BlogAPI.Model;

namespace BlogAPI.ViewModel
{
    public class BlogViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public bool Isfeatured { get; set; }

        public int CategoryId { get; set; }
        
    }
}
