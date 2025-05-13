using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WeatherApp;
using MudBlazor.Services;
using System.Net.Http;
using Supabase;
using Blazored.LocalStorage;





var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();


//SUPABSE
var supabaseUrl = "https://aklzdetoonchewhzrskx.supabase.co";
var supabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImFrbHpkZXRvb25jaGV3aHpyc2t4Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDI1MzExMDYsImV4cCI6MjA1ODEwNzEwNn0.wlpZ8TJPvlNrsKQ9S47UQfLvNY2TSm-ohFB959Dg_b4";
var supabaseOptions = new Supabase.SupabaseOptions();
builder.Services.AddSingleton(new Supabase.Client(supabaseUrl, supabaseKey, supabaseOptions));


await builder.Build().RunAsync();


