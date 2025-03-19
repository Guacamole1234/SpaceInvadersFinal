using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    public static InGameUI instance;
    
    [SerializeField] private float transitionTime;
    [SerializeField] private Image transitionObject;

    [SerializeField] private GameObject restartGameCanvas;

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

    private void Start()
    {
        LoadAnimation();
    }

    private void LoadAnimation()
    {
        LeanTween.value(gameObject, 1f, 0f, transitionTime)
            .setOnUpdate((float val) =>
            {
                Color newColor = transitionObject.color;
                newColor.a = val;
                transitionObject.color = newColor;
            });
    }

    public void ExitGameAnim()
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

    public void RestartCanvas()
    {
        restartGameCanvas.SetActive(true);
    }
}
