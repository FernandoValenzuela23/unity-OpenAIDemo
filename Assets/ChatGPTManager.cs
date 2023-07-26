using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenAI;

public class ChatGPTManager : MonoBehaviour
{
    private OpenAIApi openAI = new OpenAIApi();
    private List<ChatMessage> messages = new List<ChatMessage>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void AskChatGPT(string text)
    {
        ChatMessage msg = new ChatMessage();
        msg.Content = text;
        msg.Role = "user";
        
        messages.Add(msg);
        
        CreateChatCompletionRequest request = new CreateChatCompletionRequest(); 
        request.Messages = messages;
        request.Model = "gpt-3.5-turbo";

        var response = await openAI.CreateChatCompletion(request);
        if(response.Choices != null && response.Choices.Count > 0)
        {
            var chatResp = response.Choices[0].Message;
            messages.Add(chatResp);
            Debug.Log(chatResp.Content);
        }

    }
}
