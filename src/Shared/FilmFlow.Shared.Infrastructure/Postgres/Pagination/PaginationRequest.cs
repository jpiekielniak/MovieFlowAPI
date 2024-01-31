namespace FilmFlow.Shared.Infrastructure.Postgres.Pagination;

public class PaginationRequest
{
    private int _pageNumber;

    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = value >= 1 ? value : 1;
    }

    private int _pageSize;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value >= 1 ? value <= 100 ? value : 25 : 25;
    }

    public string OrderBy { get; set; }
    public string SortOrder { get; set; }

    public PaginationRequest()
    {
        _pageNumber = 1;
        _pageSize = 25;
    }

    public PaginationRequest(int pageNumber, int pageSize, string orderBy, string sortOrder)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        OrderBy = orderBy;
        SortOrder = sortOrder;
    }
}