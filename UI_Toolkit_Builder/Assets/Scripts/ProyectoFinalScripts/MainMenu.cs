using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    private void OnEnable() {
        UIDocument uiDoc = GetComponent<UIDocument>();
        VisualElement root = uiDoc.rootVisualElement;

        VisualElement play_button = root.Q<VisualElement>("Play");
        VisualElement exit_button = root.Q<VisualElement>("Exit");
        VisualElement fade_in = GetComponent<UIDocument>().rootVisualElement.Q<VisualElement>("FadeIn");

        fade_in.style.opacity = 0;
        fade_in.style.display = DisplayStyle.None;

        play_button.RegisterCallback<ClickEvent>(e => {
            StartCoroutine(LoadScene("Game"));
        });

        exit_button.RegisterCallback<ClickEvent>(e => {
            Application.Quit();
        });
    }

    IEnumerator LoadScene(string sceneName)
    {
        VisualElement fade_in = GetComponent<UIDocument>().rootVisualElement.Q<VisualElement>("FadeIn");
        fade_in.style.display = DisplayStyle.Flex;

        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            fade_in.style.opacity = i;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}
