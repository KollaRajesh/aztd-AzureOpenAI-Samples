
1.  Add following packages 

```sh 
pip install openai==1.2.0
```

2.  Add following values for below list of keys of *Azure Open AI* in *.env*
    1. AZURE_OAI_ENDPOINT
    2. AZURE_OAI_KEY
    3. AZURE_OAI_MODEL

- **Notes**

1. Configure app to access Azure OpenAI resource
```py 
import openai

openai.api_key = '<YOUR_API_KEY>'
openai.api_base =  '<YOUR_ENDPOINT_NAME>' 
openai.api_type = 'azure' # Necessary for using the OpenAI library with Azure OpenAI
openai.api_version = '20xx-xx-xx' # Latest / target version of the API

deployment_name = '<YOUR_DEPLOYMENT_NAME>' # SDK calls this "engine", but naming
                                           # it "deployment_name" for clarity
```

- 2. If using Prompt Completion, sending the prompt is following way .
```py 
    prompt = 'What is Azure OpenAI?'
    response = openai.Completion.create(engine=deployment_name, prompt=prompt)

    print(response.choices[0].text)
```

- 23 If using Prompt Completion, sending the prompt is following way .
```py 
    response = openai.ChatCompletion.create(
    engine=deployment_name,
    messages=[
            {"role": "system", "content": "You are a helpful assistant."},
            {"role": "user", "content": "What is Azure OpenAI?"}
            ]
)

    print(response['choices'][0]['message']['content'])
```