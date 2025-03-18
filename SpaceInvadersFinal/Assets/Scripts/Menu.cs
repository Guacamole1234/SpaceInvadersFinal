using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static Menu instance;

    [SerializeField] private Image transitionObject;
    [SerializeField] private float transitionTime;

    [SerializeField] private GameObject menuCanvas;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void StartGame()
    {
        menuCanvas.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void LoadGame()
    {
        LeanTween.value(gameObject, 0f, 1f, transitionTime)
            .setOnUpdate((float val) =>
            {
                Color newColor = transitionObject.color;
                newColor.a = val;
                transitionObject.color = newColor;
            })
            .setOnComplete(() =>
            {
                SceneManager.LoadScene("Game");
            });
    }
}
