using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class VoskResultText : MonoBehaviour 
{
    public VoskSpeechToText VoskSpeechToText;
    public SpeechLevelControl speechLevel;

    private StringBuilder resultBuilder;
    void Awake()
    {
        resultBuilder = new StringBuilder();
        VoskSpeechToText.OnTranscriptionResult += OnTranscriptionResult;
    }

    private void OnTranscriptionResult(string obj)
    {
        Debug.Log(obj);
        var result = new RecognitionResult(obj);
        for (int i = 0; i < result.Phrases.Length; i++)
        {
            resultBuilder.Append(result.Phrases[i].Text);
        }

        sendSpeechResult(resultBuilder.ToString());
    }

    private void sendSpeechResult(string result)
    {
        speechLevel.isSuccessSpeech(result);
    }
}
