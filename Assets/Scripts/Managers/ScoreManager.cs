using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    static int score;
    Text text;

    void Awake ()
    {
        text = GetComponent <Text> ();
        score = 0;
    }

    void Update ()
    {
        text.text = string.Format("Score: {0}", score);
    }

    public static void Score(int amount)
    {
        score += amount;
    }
}
