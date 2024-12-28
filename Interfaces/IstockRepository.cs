using System;
using finshark.Dtos.Stock;
using finshark.Models;


namespace finshark.Interfaces;

public interface IstockRepository
{
    Task<List<Stock>> GetAllAsync();
    Task<Stock?> GetByIdAsync(int id);
    Task<Stock> CreateAsync(Stock stockModel);
    Task<Stock?> DeleteAsync(int id);
    Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto);
}
