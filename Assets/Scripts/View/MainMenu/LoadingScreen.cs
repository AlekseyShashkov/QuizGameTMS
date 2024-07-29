using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] Slider progressBar;

    private void Awake()
    {
        canvas.enabled = false;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(int indexScene)
    {
        StartCoroutine(LoadSceneCorutine(indexScene));
    }

    private IEnumerator LoadSceneCorutine(int indexScene)
    {
        canvas.enabled = true;
        var async = SceneManager.LoadSceneAsync(indexScene);
        while (!async.isDone)
        {
            progressBar.value = async.progress;
            yield return null;
        }

        progressBar.value = 1f;
        yield return new WaitForSecondsRealtime(2f);
        canvas.enabled = false;
    } 
}
