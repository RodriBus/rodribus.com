namespace RodriBusCom.Models.Content
{
    public partial class Navigation
    {
        public Page GetBySlug(string slug)
        {
            if (Root.Slug == slug) return Root;
            if (Resume.Slug == slug) return Resume;
            if (Portfolio.Slug == slug) return Portfolio;
            return null;
        }
    }
}