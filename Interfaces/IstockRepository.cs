using System;
using finshark.Dtos.Stock;
using finshark.Helpers;
using finshark.Models;


namespace finshark.Interfaces;

public interface IstockRepository
{
    Task<List<Stock>> GetAllAsync(QueryObject query);
    Task<Stock?> GetByIdAsync(int id);
    Task<Stock> CreateAsync(Stock stockModel);
    Task<Stock?> DeleteAsync(int id);
    Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto);

    Task<bool> StockExists(int id);
}
