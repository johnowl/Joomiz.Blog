using System.Collections.ObjectModel;

public class PagedList<T> : Collection<T>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int ItemsTotal { get; set; }
    public bool HasNextPage
    {
        get
        {            
            if (this.PageNumber * this.PageSize < this.ItemsTotal)
                return true;

            return false;
        }
    }
    public bool HasPreviousPage
    {
        get
        {
            if (this.PageNumber > 1)
                return true;
            
            return false;
        }
    }

}