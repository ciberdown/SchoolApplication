namespace SchoolApplication.src.Dtos
{
    public abstract class PaginationQueryObject
    {
        public int? MaxResultCount { get; set; }
        public int? SkipCount { get; set; }

        protected PaginationQueryObject()
        {
            MaxResultCount = 10;
            SkipCount = 0;
        }
    }
}
