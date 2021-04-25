using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Windows.Speech;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainGrammerController : MonoBehaviour
{
    private string _Keyresponse = "";
    private string _response = "";
    private GrammarRecognizer gr;

     private void Start() {
        _response = "";
        _Keyresponse = "";
        // Load in the XML file
        gr = new GrammarRecognizer(Path.Combine(Application.streamingAssetsPath,  
        "Main.xml"), ConfidenceLevel.Low); 
        
        // Begin the Grammar Recogniser
        gr.OnPhraseRecognized += GR_OnPhraseRecognized;
        gr.Start();
        Debug.Log("Grammer Load and Recogniser Started!");

    }

    private void Update() {
        //Switch between the Words Spoken
        MenuCommands();
        
    }

       private void MenuCommands(){
        if(_Keyresponse == "menu"){
            switch (_response)
            {
                // Menu Rules
                case "start":
                    SceneManager.LoadScene(1);
                    break;
                case "exit":
                    Application.Quit();
                    Debug.Log("Game is exiting");
                    break;
                default:
                    _response = "";
                    break;
            }
            _response = "";
        }
    }

      private void GR_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        StringBuilder message = new StringBuilder();
        //Read the semantic meanings from the args passed in
        SemanticMeaning[] meanings = args.semanticMeanings;
        //use foreach to get all the meanings.
        foreach (SemanticMeaning meaning in meanings)
        {
            // Get the Key and Value Strings from Input if matches.
            string keyString = meaning.key.Trim();
            var valueString = meaning.values[0].Trim();

            message.Append("Key " + keyString + "Value " + valueString + " ");

            // Assign the Inputs to new Values for future use.
            _response = valueString;
            _Keyresponse = keyString;
        }
        //use a string builder to create the string and out to the user.
        Debug.Log(message);
    }
    // Called in Button to go to New Scene
    public void SceneLoader(int level){
        SceneManager.LoadScene(level);
    }
    //Called when button is active
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
    // Stops the Grammer Recognizer
    private void OnApplicationQuit()
    {
        if (gr == null || !gr.IsRunning) return;
        gr.OnPhraseRecognized -= GR_OnPhraseRecognized;
        gr.Stop();
    }
    // When Destroy then stop Grammer Recognizer
    private void OnDestroy()
    {
        if (gr != null)
        {
            gr.Stop();
            gr.OnPhraseRecognized -= GR_OnPhraseRecognized;
            gr.Dispose();
            gr = null; 
        }
    }
}
