using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoodCalculator : MonoBehaviour {

   

    public void FixedUpdate() {
        showMoodGUI();
        EventManagement();
    }

    public void EventManagement() {
        DefaultMoodDecline();

        girlEvents();
        boyEvents();
        wifeEvents();
    }








    [Header("Mood")]

    public Text moodInspector;

    public float boy_mood = 100f;
    public float girl_mood = 100f;
    public float wife_mood = 100f;

    public int moodCooldown = 100;
    public void DefaultMoodDecline() {
        moodCooldown--;
        if (moodCooldown < 0) {
            moodCooldown = 100;

            boy_mood -= 0.5f;
            girl_mood -= 0.5f;
            wife_mood -= 0.3f;

        }
    }

    public void showMoodGUI() {
        moodInspector.text = "Mood  \nBoy : " + (int)boy_mood + "\nGirl: " + (int)girl_mood + "\nWife: " + (int)wife_mood;
    }


    [Header("SPEECH")]
    public float girlSpeechChance = 3f;
    public float boySpeechChance = 3f;
    public float wifeSpeechChance = 3f;


    public void girlEvents() {
        if(Random.Range(0f,10000f) < girlSpeechChance) {
            createSpeechObject(Language.getText(Language.tmpGirlSpeech));
        }

    }
    public void boyEvents() {
        if (Random.Range(0f, 10000f) < boySpeechChance) {
            createSpeechObject(Language.getText(Language.tmpBoySpeech));
        }

    }
    public void wifeEvents() {
        if (Random.Range(0f, 10000f) < wifeSpeechChance) {
            createSpeechObject(Language.getText(Language.tmpWifeSpeech));
        }

    }


    public GameObject speechObject;
    public Transform speechSpace;

    public void createSpeechObject(string txt) {
        GameObject tmp = Instantiate(speechObject,speechSpace);
        tmp.GetComponent<SpeechObjectBehavior>().create(txt);
    }
}
