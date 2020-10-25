using System.Threading.Tasks;

namespace myweb.Services.Interfaces
{
    public interface IRepostory
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> Save();
    }
}
