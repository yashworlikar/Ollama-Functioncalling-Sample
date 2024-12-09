using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.Ollama;
using OllamaSample;

var builder = Kernel.CreateBuilder();
var modelId = "llama3.2";
var endpoint = new Uri("http://localhost:11434");

builder.Services.AddOllamaChatCompletion(modelId, endpoint);

// // Default plugins 
// builder.Plugins
//     .AddFromType<MyTimePlugin>()
//     .AddFromObject(new MyLightPlugin(turnedOn: true))
//     .AddFromObject(new MyAlarmPlugin("11"));

builder.Plugins.AddFromType<LightsPluginV2>();

builder.Services.AddLogging(x => { x.AddConsole(); x.SetMinimumLevel(LogLevel.Information); });
var kernel = builder.Build();
var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
var settings = new OllamaPromptExecutionSettings { FunctionChoiceBehavior = FunctionChoiceBehavior.Auto() };

Console.WriteLine("""
    Ask questions or give instructions to the copilot such as:
    - Give me the available lamps?
    - Turn on the lamp with id 1.
    """);

Console.Write("> ");

string? input = null;
while ((input = Console.ReadLine()) is not null)
{
    Console.WriteLine();

    try
    {
        ChatMessageContent chatResult = await chatCompletionService.GetChatMessageContentAsync(input, settings, kernel);
        Console.Write($"\n>>> Result: {chatResult}\n\n> ");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}\n\n> ");
    }
}


