using Replica.Shared.Table;

namespace Replica.Application.Interfaces
{
    public interface ITableRepository
    {
        Task<TableDto> Create(CreateTableDto entity);
        Task<TableDto> Delete(Guid id);
        Task<TableDto> Get(Guid id);
        Task<IEnumerable<TableDto>> GetAll();
        Task<IEnumerable<TableDto>> GetAllAvailable();
        Task<IEnumerable<TableDto>> GetAllUnavailable();
        Task<TableDto> Update(TableDto entity);
    }
}