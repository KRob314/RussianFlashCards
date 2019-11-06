using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RussianFlashCards.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
        Task<IEnumerable<T>> GetWordsAsync();
        Task<IEnumerable<T>> GetPhrasesAsync();
        Task<IEnumerable<T>> GetWeekdaysAsync();
        Task<IEnumerable<T>> GetNumbersAsync();
    }
}
