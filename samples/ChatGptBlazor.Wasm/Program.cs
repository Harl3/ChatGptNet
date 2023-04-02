using ChatGptBlazor.Wasm;
using ChatGptNet;
using ChatGptNet.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddChatGpt(options =>
{
    options.ApiKey = "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";
    options.DefaultModel = ChatGptModels.Gpt35Turbo;  // Default: ChatGptModels.Gpt35Turbo
    options.MessageLimit = 16;  // Default: 10
    options.MessageExpiration = TimeSpan.FromMinutes(5);    // Default: 1 hour
});

await builder.Build().RunAsync();
