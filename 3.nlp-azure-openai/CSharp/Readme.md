
1.  Add following packages 

```sh 
dotnet add Microsoft.Extensions.Configuration  --version 7.0.0
dotnet add package  Microsoft.Extensions.Configuration.Json  --version 7.0.0
dotnet add package Azure.AI.OpenAI --version 1.0.0-beta.9
```

2.  Add following values for below list of keys of *Azure Open AI* in *appsettings.cs*
    1. AzureOAIEndpoint
    2. AzureOAIKey
    3. AzureOAIModelName

- **Notes**
    1. Configure app to access Azure OpenAI resource
```csharp 
    // Add OpenAI library
    using Azure.AI.OpenAI;

    // Define parameters and initialize the client
    string endpoint = "<YOUR_ENDPOINT_NAME>";
    string key = "<YOUR_API_KEY>";
    string deploymentName = "<YOUR_DEPLOYMENT_NAME>"; //SDK calls this "engine", but naming
                                                    // it "deploymentName" for clarity

    OpenAIClient client = new OpenAIClient(new Uri(endpoint), new AzureKeyCredential(key));
```

- 2. If using Prompt Completion, sending the prompt is following way .
```csharp
    string prompt = "What is Azure OpenAI?";

    Response<Completions> completionsResponse = client.GetCompletions(deploymentName, prompt);

    string completion = completionsResponse.Value.Choices[0].Text;
    Console.WriteLine($"Chatbot: {completion}");
```

- 3. If using Prompt Completion, sending the prompt is following way .
```csharp
   
    // Build completion options object
    ChatCompletionsOptions chatCompletionsOptions = new ChatCompletionsOptions()
    {
        Messages = 
        {
            new ChatMessage(ChatRole.System, "You are a helpful AI bot."), 
            new ChatMessage(ChatRole.User, "What is Azure OpenAI?")
        }
    };

    // Send request to Azure OpenAI model
    ChatCompletions chatCompletionsResponse = client.GetChatCompletions(
        deploymentName, 
        chatCompletionsOptions);

    ChatMessage completion = chatCompletionsResponse.Choices[0].Message;
    Console.WriteLine($"Chatbot: {completion.Content}");

```