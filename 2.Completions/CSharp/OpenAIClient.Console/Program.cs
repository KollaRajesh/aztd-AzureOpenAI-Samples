// See https://aka.ms/new-console-template for more information

using Azure;
using Azure.AI.OpenAI;

OpenAIClient client = new OpenAIClient(
	new Uri(Environment.GetEnvironmentVariable("AZURE_OPENAI_API")),
	new AzureKeyCredential(Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY")));


 // ### If streaming is selected
Response<StreamingChatCompletions> response = await client.GetChatCompletionsStreamingAsync(
	deploymentOrModelName: "gpt35",
	new ChatCompletionsOptions()
	{
		Messages =
		{
			new ChatMessage(ChatRole.System, @"You are an AI assistant that helps people find information."),
			new ChatMessage(ChatRole.User, @"hi"),
			new ChatMessage(ChatRole.Assistant, @"Hello! How can I assist you today?"),
			new ChatMessage(ChatRole.User, @"Fidelity vs Vanguard"),
			new ChatMessage(ChatRole.Assistant, @"Fidelity and Vanguard are both well-known investment management companies. Here are some points of comparison between the two:

1. Investment Options: Both Fidelity and Vanguard offer a wide range of investment options, including mutual funds, ETFs, stocks, bonds, and more. However, Vanguard is primarily known for its low-cost index funds.

2. Fees and Expenses: Vanguard is known for its low-cost investment options, with a focus on index funds that have low expense ratios. Fidelity also offers low-cost funds, but its fee structure may vary depending on the specific funds and account types.

3. Customer Service: Both companies have a strong reputation for customer service, although individual experiences may vary. Fidelity has a large network of physical branch locations, while Vanguard primarily operates online.

4. Research and Education: Fidelity provides a wide range of research tools and educational resources for investors, including market analysis, retirement planning tools, and investment calculators. Vanguard also offers research tools and educational materials, but its focus is primarily on long-term investing and passive index fund strategies.

5. Additional Services: Fidelity offers a range of additional services, including banking, credit cards, and financial planning tools. Vanguard primarily focuses on investment management and does not offer as many additional services.

Ultimately, the choice between Fidelity and Vanguard depends on your specific investment needs and preferences. It's important to consider factors such as fees, investment options, customer service, and additional services when making a decision."),
		},
		Temperature = (float)0.7,
		MaxTokens = 800,
		NucleusSamplingFactor = (float)0.95,
		FrequencyPenalty = 0,
		PresencePenalty = 0,
	});

using StreamingChatCompletions streamingChatCompletions = response.Value;

// ### If streaming is not selected
Response<ChatCompletions> responseWithoutStream = await client.GetChatCompletionsAsync(
	"gpt35",
	new ChatCompletionsOptions()
	{
		Messages =
		{
			new ChatMessage(ChatRole.System, @"You are an AI assistant that helps people find information."),
			new ChatMessage(ChatRole.User, @"hi"),
			new ChatMessage(ChatRole.Assistant, @"Hello! How can I assist you today?"),
			new ChatMessage(ChatRole.User, @"Fidelity vs Vanguard"),
			new ChatMessage(ChatRole.Assistant, @"Fidelity and Vanguard are both well-known investment management companies. Here are some points of comparison between the two:

1. Investment Options: Both Fidelity and Vanguard offer a wide range of investment options, including mutual funds, ETFs, stocks, bonds, and more. However, Vanguard is primarily known for its low-cost index funds.

2. Fees and Expenses: Vanguard is known for its low-cost investment options, with a focus on index funds that have low expense ratios. Fidelity also offers low-cost funds, but its fee structure may vary depending on the specific funds and account types.

3. Customer Service: Both companies have a strong reputation for customer service, although individual experiences may vary. Fidelity has a large network of physical branch locations, while Vanguard primarily operates online.

4. Research and Education: Fidelity provides a wide range of research tools and educational resources for investors, including market analysis, retirement planning tools, and investment calculators. Vanguard also offers research tools and educational materials, but its focus is primarily on long-term investing and passive index fund strategies.

5. Additional Services: Fidelity offers a range of additional services, including banking, credit cards, and financial planning tools. Vanguard primarily focuses on investment management and does not offer as many additional services.

Ultimately, the choice between Fidelity and Vanguard depends on your specific investment needs and preferences. It's important to consider factors such as fees, investment options, customer service, and additional services when making a decision."),
		},
		Temperature = (float)0.7,
		MaxTokens = 800,
		NucleusSamplingFactor = (float)0.95,
		FrequencyPenalty = 0, 
		PresencePenalty = 0,
	});

ChatCompletions completions = responseWithoutStream.Value;
Console.WriteLine(completions.Id);
Console.WriteLine($"Label {completions.Choices[0].Message.Role.Label}");
Console.WriteLine(completions.Choices[0].Message.Content);
Console.WriteLine(completions.Created);
//Console.ReadKey();