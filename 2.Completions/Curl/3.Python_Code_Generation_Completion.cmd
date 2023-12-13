curl "https://enterprisedata-openai.openai.azure.com/openai/deployments/gpt-35-turbo/chat/completions?api-version=2023-07-01-preview" \
  -H "Content-Type: application/json" \
  -H "api-key: YOUR_API_KEY" \
  -d "{
  \"messages\": [{\"role\":\"system\",\"content\":\"You are a Python developer.\"},{\"role\":\"user\",\"content\":\"Write a Python function named Multiply that multiplies two numeric parameters.\"},{\"role\":\"assistant\",\"content\":\"Here's the Python function that multiplies two numeric parameters:\n\n```python\ndef Multiply(a, b):\n    return a * b\n```\n\nYou can call this function by passing in two numeric values as arguments:\n\n```python\nresult = Multiply(5, 10)\nprint(result) # Output: 50\n```\n\nIn the example above, we're calling the `Multiply` function with arguments `5` and `10` and storing the result in a variable called `result`. The `print` function is then used to output the value of `result` which is `50`.\"}],
  \"max_tokens\": 800,
  \"temperature\": 0.7,
  \"frequency_penalty\": 0,
  \"presence_penalty\": 0,
  \"top_p\": 0.95,
  \"stop\": null }"



