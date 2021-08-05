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
        SceneManager.LoadScene("BlueTestScene");
        Debug.Log("TPing to blue");
    }

    public void LoadMain(){
        StartCoroutine(LoadMainScene());
    }

}
