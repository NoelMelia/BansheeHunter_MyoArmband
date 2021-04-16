using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Windows.Speech;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GrammerController : MonoBehaviour
{
    private string _Keyresponse = "";
    private string _response = "";
    private PauseMenu pauseMenu;
    private SetVolume setVolume; 
    private Player player;
    [SerializeField]private Text results;
    private GrammarRecognizer gr;
    private Health health;

    private void Start() {
        _response = "";
        _Keyresponse = "";
        // Load in the XML file
        gr = new GrammarRecognizer(Path.Combine(Application.streamingAssetsPath,  
        "MainMenu.xml"), ConfidenceLevel.Low); 
        
        // Begin the Grammar Recogniser
        gr.OnPhraseRecognized += GR_OnPhraseRecognized;
        gr.Start();
        Debug.Log("Grammer Load and Recogniser Started!");

        pauseMenu = FindObjectOfType<PauseMenu>();
        setVolume = FindObjectOfType<SetVolume>();
        player = FindObjectOfType<Player>();
        health = FindObjectOfType<Health>();
    }
    private void Update() {
        //Switch between the Words Spoken
        RestartCommand();
        PauseGameCommands();
        VolumeCommands();
        PauseCommands();
        MovementCommands();
        MenuCommands();
        
    }
    // Checking that game is not paused and Command to pause game
    private void PauseGameCommands(){
        // Each Key has an action assign and is called to determine the different phrases said
        if(_Keyresponse == "pause" && !PauseMenu.IsPaused){
            switch (_response)
            {
                // Pause the Game Rule
                case "pause the game":
                    pauseMenu.Pause();
                    break;
            }
            results.text = "Game Paused " + _response;
            _response = "";
        }
    }
    // Volume Commands for Sound of App 
    private void VolumeCommands(){
        if(_Keyresponse == "volume" && PauseMenu.IsPaused){
            switch (_response)
            {
                // Volume Rules
                case "decrease":
                    setVolume.Volume(-0.1f);   
                    break;
                case "increase":
                    setVolume.Volume(0.1f);   
                    break;
                default:
                    _response = "";
                    break;
            }
            results.text = "In Volume " + _response;
            _response = "";
        }
    }
    // Voice Control for Pause Menu
    private void PauseCommands(){
        if(_Keyresponse == "pause" && PauseMenu.IsPaused ){
            switch (_response)
            {
                // Pause Menu Rules
                case "continue":
                    pauseMenu.Resume();
                    break;
                case "restart":
                    pauseMenu.RestartLevel();
                    break;
                case "quit":
                    pauseMenu.BackToMenu(); 
                    break;
                default:
                    _response = "";
                    break;
            }
            results.text = "In Pause Menu " + _response;
            _response = "";
        }
        
    }
    // Voice Control for when the game is over and gameover  
    // screen is active
    private void RestartCommand(){
        if(Health.active){
            switch (_response)
            {
                case "restart":
                    pauseMenu.RestartLevel();
                    break;
                case "quit":
                    pauseMenu.BackToMenu(); 
                    break;
                default:
                    _response = "";
                    break;
            }
            results.text = "In Pause Menu " + _response;
            _response = "";
        }
    }
    private void MovementCommands(){
        if(_Keyresponse == "movement" && !PauseMenu.IsPaused){
            
            switch (_response)
            {
                // Player Rules
                case "up":
                    player.UpSpeech();
                    break;
                case "fire":
                    player.AtackSpeech();
                    break;
                case "stop fire":
                    player.StopAtackSpeech();
                    break;
                case "down":
                    player.DownSpeech();
                    break;
                default:
                    _response = "";
                    break;
            }
            results.text = "In Movement " + _response;
            _response = "";
        }      
    }
    // Menu Comand when in Main Menu
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
            results.text = "In Menu " + _response;
            _response = "";
        }
    }

    // Determine the phrases match the user input from the XML file.  
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
