using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Initialising Level button 
    private Button _levelButton;
  
    //levelName should be addded to move for the particular level 
    [SerializeField]
    private string levelName;
    [SerializeField]
    private int levelIndex;

    void Awake()
    {
        //Getting the component of the Button GameObject
        _levelButton = GetComponent<Button>();
        // adding listener to the level Buttons
      //  _levelButton.onClick.AddListener(onClickLevel);

        //

       
    }
    // function to load scene with given string
   /* private void onClickLevel()
    {
        SceneManager.LoadScene(levelName);
        Debug.Log(levelName);
    }*/
    public void onClickLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
        Debug.Log(levelIndex);
        Debug.Log("from scene controller");
    }

}
/*

 public string parameterValue;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ButtonClick);
    }

    private void ButtonClick()
    {
        Debug.Log("Button clicked with parameter: " + parameterValue);

        // You can use the parameter value here for specific actions.
    } 
 */