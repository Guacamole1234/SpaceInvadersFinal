using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private float transitionTime;
    [SerializeField] private Image transitionObject;
    
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
}
