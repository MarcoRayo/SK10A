using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    void Start()
    {
        string levelToLoad = LevelLoader.nextLevel;
        StartCoroutine(this.MakeTheLoad(levelToLoad));
    }

    IEnumerator MakeTheLoad(string level) {
        AsyncOperation operation = SceneManager.LoadSceneAsync(level);
        while (operation.isDone == false) { 
            yield return null;
        }
    }

    
}
