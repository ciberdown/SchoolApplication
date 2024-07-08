namespace SchoolApplication.src.Dtos
{
    public abstract class ResDtoBase<T>
    {
        public int TotalCount { get; set; }
        public List<T> Items { get; set; } = null!;

    }
}
