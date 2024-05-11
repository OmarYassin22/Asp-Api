using Talabat.presentations.DTOs;

namespace Talabat.presentations.Helpers
{
    public class Pagination<T> 
    {
        public Pagination(IReadOnlyList<T> data, int pageIndex, int pageSize,int count)
        {
            Data = data;
            Index = pageIndex;
            Size = pageSize;
            Count = count;
        }

        public int Index { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}
