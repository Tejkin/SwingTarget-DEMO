using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    [Header("Score Variables")]
    public int targetDestroyed = 0;
    public int totalTargets;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Target: " + targetDestroyed.ToString() + "/" + totalTargets.ToString();
    }

    public void Score()
    {
        targetDestroyed += 1;
    }
}
