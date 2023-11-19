using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class contscore : MonoBehaviour
{

    public Text score;
    public Text HighscoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = GameManager.Instance.contscore.ToString();
        HighscoreText.text = ("HighestScore: " + PlayerPrefs.GetInt("Highestscore"));
    }
}
