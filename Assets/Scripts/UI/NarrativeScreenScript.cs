using ScObjects;
using TMPro;
using UI;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class NarrativeScreenScript : MonoBehaviour
{
    [SerializeField] private GameObject text1;
    [SerializeField] private GameObject text2;
    [SerializeField] private GameObject text3;
    [SerializeField] private GameObject text4;
    [SerializeField] private GameObject text5;
    [SerializeField] private GameObject text6;
    [SerializeField] private GameObject text7;
    [SerializeField] private GameObject text8;
    [SerializeField] private float text_timer;
    [SerializeField] private float text_timer_delay;

    private List<GameObject> texts;
    private int currentText;

    private void Start()
    {
        texts = new List<GameObject>() { text1, text2, text3, text4, text5, text6, text7, text8};
    }

    private void Update()
    {
        if (text_timer > 0 && currentText < texts.Count)
            text_timer -= Time.deltaTime;
        if (text_timer <= 0)
        {
            text_timer = text_timer_delay;
            texts[currentText].SetActive(true);
            currentText++;
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("Game scene");
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            text_timer = 0.1f;
            if (currentText >= texts.Count)
            {
                SceneManager.LoadScene("Game scene");
            }
        }
    }
}
