namespace LataPrzestepne.Interfaces;


public interface IFilter
{
    Task<string> GetName(string sth);
}
