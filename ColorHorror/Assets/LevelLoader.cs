using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public void LoadNextLevel()
    {
        StartCoroutine (LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelndex)
    {
        //Play Animation
        transition.SetTrigger("Start");
        //Wait for anitmation 
        yield return new WaitForSeconds(transitionTime);
        //Load scene
        SceneManager.LoadScene(levelndex);
    }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void LoadBlueScene()
    {
        StartCoroutine(LoadBlue());
    }

     IEnumerator LoadBlue()
    {
        //Play Animation
        transition.SetTrigger("Start");
        //Wait for anitmation 
        yield return new WaitForSeconds(transitionTime);
        //Load scene
        SceneManager.LoadScene("BlueTestScene");
        Debug.Log("TPing to blue");
    }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    IEnumerator LoadMainScene()
    {
        //Play Animation
        transition.SetTrigger("Start");
        //Wait for anitmation 
        yield return new WaitForSeconds(transitionTime);
        //Load scene
        SceneManager.LoadScene("DefaultRoom");
        Debug.Log("TPing to main room");
    }

    public void LoadMain(){
        StartCoroutine(LoadMainScene());
    }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void LoadRedScene()
    {
        StartCoroutine(LoadRed());
    }

    IEnumerator LoadRed()
    {
        //Play Animation
        transition.SetTrigger("Start");
        //Wait for anitmation 
        yield return new WaitForSeconds(transitionTime);
        //Load scene
        SceneManager.LoadScene("RedSceneNew");
        Debug.Log("TPing to red room");
    }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void LoadYellowScene()
    {
        StartCoroutine(LoadYellow());
    }

    IEnumerator LoadYellow()
    {
        //Play Animation
        transition.SetTrigger("Start");
        //Wait for anitmation 
        yield return new WaitForSeconds(transitionTime);
        //Load scene
        SceneManager.LoadScene("YellowTestScene");
        Debug.Log("TPing to yellow room");
    }
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void LoadDeathScene()
    {
        StartCoroutine(LoadDeath());
    }

    IEnumerator LoadDeath()
    {
        //Play Animation
        transition.SetTrigger("Start");
        //Wait for anitmation 
        yield return new WaitForSeconds(transitionTime);
        //Load scene
        SceneManager.LoadScene("DeathScene");
        Debug.Log("Loading Death Scene");
    }
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void LoadMainMenu()
    {
        StartCoroutine(LoadMenu());
    }

    IEnumerator LoadMenu()
    {
        //Play Animation
        transition.SetTrigger("Start");
        //Wait for anitmation 
        yield return new WaitForSeconds(transitionTime);
        //Load scene
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Loading Main Menu");
    }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
     public void CompleteGame()
    {
        StartCoroutine(LoadCompletionScreen());
    }

    IEnumerator LoadCompletionScreen()
    {
        //Play Animation
        transition.SetTrigger("Start");
        //Wait for anitmation 
        yield return new WaitForSeconds(transitionTime);
        //Load scene
        SceneManager.LoadScene("EscapedScene");
        Debug.Log("Loading Escaped Scene");
    }

}
