using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoodCalculator : MonoBehaviour {

    public int score = 0;
    public Text scoreText;


    [Header("Game Over")]
    public bool gameOver = false;
    public GameObject gameOverLay;

    public void FixedUpdate() {
        if (gameOver) {
            Cursor.lockState = CursorLockMode.None;

        }
        else {
            showMoodGUI();
            EventManagement();
            showScore();
        }
    }


    public void showScore() {
        scoreText.text = "Score\n"+ score;
    }

    public void EventManagement() {
        DefaultMoodDecline();

        girlEvents();
        boyEvents();
        wifeEvents();
    }


    public void retryBtn() {
        SceneManager.LoadScene("Citymap");
    }

    public void menuBtn() {
        SceneManager.LoadScene("MainMenu");
    }

    public void gameIsOver() {
        gameOver = true;

        gameOverLay.SetActive(true);
        gameOverLay.transform.GetChild(0).GetComponent<Text>().text = Language.getText(Language.GameOver);
        gameOverLay.transform.GetChild(1).GetComponent<Text>().text = Language.getText(Language.score) + score;
        gameOverLay.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = Language.getText(Language.retryGame);
        gameOverLay.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = Language.getText(Language.toMenu);
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


            score += 1;
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
        if(Random.Range(0f,10000f) < girlSpeechChance + girlSpeechChance * (100f / girl_mood) * 0.3f) {
            createSpeechObject(Language.getText(Language.tmpGirlSpeech));
        }

    }
    public void boyEvents() {
        if (Random.Range(0f, 10000f) < boySpeechChance + boySpeechChance * (100f / boy_mood) * 0.3f) {
            createSpeechObject(Language.getText(Language.tmpBoySpeech));
        }

    }
    public void wifeEvents() {
        if (Random.Range(0f, 10000f) < wifeSpeechChance + wifeSpeechChance * (100f / wife_mood) * 0.3f) {
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
