// Install the .NET library via NuGet: dotnet add package Azure.AI.OpenAI --prerelease
//Azure.AI.OpenAI Version 2.1.0
using System.Text.Json;
using Azure;
using Azure.AI.OpenAI;
using OpenAI.Chat;
using static System.Environment;

async Task RunAsync()
{
    // Retrieve the OpenAI endpoint from environment variables
    var endpoint =
        GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT", EnvironmentVariableTarget.User)
        ?? "https://demobiplobazureopenai.openai.azure.com/";
    if (string.IsNullOrEmpty(endpoint))
    {
        Console.WriteLine("Please set the AZURE_OPENAI_ENDPOINT environment variable.");
        return;
    }

    var key = GetEnvironmentVariable("AZURE_OPENAI_KEY", EnvironmentVariableTarget.User);
    if (string.IsNullOrEmpty(key))
    {
        Console.WriteLine("Please set the AZURE_OPENAI_KEY environment variable.");
        return;
    }

    AzureKeyCredential credential = new AzureKeyCredential(key);

    // Initialize the AzureOpenAIClient
    AzureOpenAIClient azureClient = new(new Uri(endpoint), credential);

    string deploymentName = "gpt-35-turbo";
    // Initialize the ChatClient with the specified deployment name
    ChatClient chatClient = azureClient.GetChatClient(deploymentName);

    // Create a list of chat messages
    var messages = new List<ChatMessage>
    {
        new SystemChatMessage("You are an AI assistant that helps people find information."),
    };

    Console.WriteLine("Welcome to the Azure OpenAI Chat! Type 'exit' to quit.");

    // Create chat completion options

    var options = new ChatCompletionOptions
    {
        Temperature = (float)0.7,
        MaxOutputTokenCount = 800,

        TopP = (float)0.95,
        FrequencyPenalty = (float)0,
        PresencePenalty = (float)0,
    };

    while (true)
    {
        Console.Write("You: ");
        string userInput = Console.ReadLine();
        if (
            string.IsNullOrWhiteSpace(userInput)
            || userInput.Equals("exit", StringComparison.OrdinalIgnoreCase)
        )
        {
            Console.WriteLine("Exiting chat. Goodbye!");
            break;
        }
        // Add user input to the chat messages
        messages.Add(new UserChatMessage(userInput));

        try
        {
            // Create the chat completion request
            ChatCompletion completion = await chatClient.CompleteChatAsync(messages, options);

            // Print the response
            if (completion != null)
            {
                Console.WriteLine("Chatbot: " + completion.Content.FirstOrDefault()?.Text);

                // Add the assistant's response to the conversation history
                messages.Add(new AssistantChatMessage(completion.Content.FirstOrDefault()?.Text));
            }
            else
            {
                Console.WriteLine("No response received.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

await RunAsync();
