﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject progressPanel;
    [SerializeField] private Slider progressBar;
    [SerializeField] private Text progressValue;

    public void Awake()
    {
        progressPanel.SetActive(false);
    }


    public void LoadLevel(string levelName)
    {

        progressPanel.SetActive(true);
        StartCoroutine(LoadLevelAsync(levelName));
    }

    private IEnumerator LoadLevelAsync(string levelName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelName);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress);
            progressBar.value = progress;
            progressValue.text = (progress * 100f).ToString("F0") + "%";

            //Debug.Log(progress);

            yield return null;
        }
    }
}
