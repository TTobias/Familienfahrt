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
        moodInspector.text = "Mood:\nBoy : " + (int)boy_mood + "\nGirl: " + (int)girl_mood + "\nWife: " + (int)wife_mood;
    }







    public void EventManagement() {
        DefaultMoodDecline();


    }




    int moodCooldown = 100;
    public void DefaultMoodDecline() {
        moodCooldown--;
        if (moodCooldown < 0) {
            moodCooldown = 100;

            boy_mood -= 0.5f;
            girl_mood -= 0.5f;
            wife_mood -= 0.3f;

        }
    }



    public void FixedUpdate() {
        showMoodGUI();
        EventManagement();
    }
}
