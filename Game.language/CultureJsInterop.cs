using Microsoft.JSInterop;

namespace Game.language
{
    public class CultureJsInterop : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;
        private readonly Lazy<IJSObjectReference> moduleSync;

        public CultureJsInterop(IJSRuntime jsRuntime)
        {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/Game.language/cultureJsInterop.js").AsTask());
            //var js = (IJSInProcessRuntime)jsRuntime;
            //moduleSync = new(() => js.Invoke<IJSObjectReference>("import", "./_content/Game.language/cultureJsInterop.js"));
        }

        public async Task UpdateCSSVariable(string name, string value)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("updateCSSVariable", name, value);
        }
        public async Task SetPageDirection(string direction)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("setPageDirection", direction);
        }
        public async Task SetPageLanguage(string language)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("setPageLanguage", language);
        }
        public async Task ChangeBootstrapTheme(string theme)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("changeBootstrapTheme", theme);
        }
        public void SetBlazorCulture(string message)
        {
            var module = moduleTask.Value.Result;
            module.InvokeVoidAsync("setBlazorCulture", message);
        }
        public async ValueTask<string> GetBlazorCulture()
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<string>("getBlazorCulture");
        }

        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}