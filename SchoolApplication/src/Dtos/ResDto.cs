namespace SchoolApplication.src.Dtos
{
    public abstract class ResDtoBase<T>
    {
        public int TotalCount { get; set; }
        public IEnumerable<T> Items { get; set; } = null!;
    }
}
