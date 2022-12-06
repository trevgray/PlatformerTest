using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using System;

public class HighScoreManager : MonoBehaviour
{
    public List<float> scores;
    private string filename = "Highscore.txt";
    // Start is called before the first frame update
    void Start()
    {
        scores = new List<float>();
        string[] fileStrings = File.ReadAllLines(Application.dataPath + "/" + filename);
        foreach (string s in fileStrings)
        {
            scores.Add(float.Parse(s));
        }
    }

    
    public void SubmitNewScore(string newScore)
    {
        int numOfScores = 3;
        float newScoreInt = float.Parse(newScore);

        for (int scoreIterator = 0; scoreIterator < numOfScores; scoreIterator++)
        {
            if (newScoreInt < scores[scoreIterator])
            {
                scores.RemoveAt(numOfScores - 1);
                scores.Add(newScoreInt);
                scores.Sort();
                break;
            }
        }
        ///////////
        //foreach (int s in scores) {
        //    print(s);
        //}

        string[] fileStrings = new string[3];
        for (int scoreIterator = 0; scoreIterator < numOfScores; scoreIterator++)
        {
            fileStrings[scoreIterator] = scores[scoreIterator].ToString();
        }
        File.WriteAllLines(Application.dataPath + "/" + filename, fileStrings);
    }
}
