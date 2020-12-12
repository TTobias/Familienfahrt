using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoodCalculator : MonoBehaviour {

    public float boy_mood = 100f;
    public float girl_mood = 100f;
    public float wife_mood = 100f;

    public Text moodInspector;


    public void showMoodGUI() {
        moodInspector.text = "Mood:\nBoy : " + boy_mood + "\nGirl: " + girl_mood + "\nWife: " + wife_mood;
    }





    public void FixedUpdate() {
        showMoodGUI();
    }
}
