
using ComplicadaMente.Components.Models;
using Microsoft.JSInterop;
using System.Text.Json;
using System.Threading.Tasks;

namespace ComplicadaMente.StateManagement
{
    public class LocalStorageService
    {
        private readonly IJSRuntime _jsRuntime;


        public event Action OnChange;
        public LocalStorageService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        // Set a value in localStorage
        public async Task SetItemAsync(string key, string value)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", key, value);
            NotifyStateChanged();
        }

        // Get a value from localStorage
        public async Task<string> GetItemAsync(string key)
        {
            return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);
        }

        // Remove a value from localStorage
        public async Task RemoveItemAsync(string key)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
            NotifyStateChanged();
        }

        // Clear all items from localStorage
        public async Task ClearAsync()
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.clear");
        }
        public async Task<Cliente> GetLoginUser()
        {
            // Retrieve the JSON string from localStorage
            var jsonValue = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "LoginUser");

            // Check if the value exists and deserialize it to the specified type
            return jsonValue != null ? JsonSerializer.Deserialize<Cliente>(jsonValue) : default;
        }
        public async Task<T?> GetItemAsync<T>(string key)
        {
            // Retrieve the JSON string from localStorage
            var jsonValue = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);

            // Check if the value exists and deserialize it to the specified type
            return jsonValue != null ? JsonSerializer.Deserialize<T>(jsonValue) : default;
        }
        private void NotifyStateChanged() { OnChange?.Invoke(); }
    }

}
