// See https://aka.ms/new-console-template for more information


using Microsoft.CognitiveServices.Speech;

string speechKey = "70797edb947340979ca90a56e5253a0e";
string speechRegion = "eastus";


var speechConfig = SpeechConfig.FromSubscription(speechKey, speechRegion);
speechConfig.SpeechSynthesisVoiceName = "sv-SE-SofieNeural";

using (var speechSynthesizer = new SpeechSynthesizer(speechConfig))
{
    Console.WriteLine("Enter some text");
    string text = Console.ReadLine();

    var result = await speechSynthesizer.SpeakTextAsync(text);
    OutputSpeechSynyhesisResult(result, text);

}

Console.WriteLine("Press any key... ");
Console.ReadKey();




    static void OutputSpeechSynyhesisResult(SpeechSynthesisResult speechSynthesisResult, string text)
    {
        switch (speechSynthesisResult.Reason)
        {
            case ResultReason.SynthesizingAudioCompleted:
                Console.WriteLine($"Speech synthesized for text: [{text}]");
                break;

            default:
                break;
        }
    }

