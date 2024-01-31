namespace FilmFlow.Shared.Infrastructure.Postgres;

public class SortParam
{
    public string Field { get; set; }
    public string Dir { get; set; }


    public SortParam()
    {
    }

    public SortParam(string field, string dir)
    {
        Field = field;
        Dir = dir;
    }
}