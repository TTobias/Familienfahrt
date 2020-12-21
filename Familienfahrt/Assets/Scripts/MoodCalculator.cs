using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;

public class MoodCalculator : MonoBehaviour {

    public int score = 0;
    public Text scoreText;

    public GameObject boom;
    public CinemachineVirtualCamera deathCam;
    public GameObject gui;
    public Rigidbody body;
    public AudioSource aSource;
    public AudioClip megaBoomClip;
    public AudioClip ohNoClip;


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
            CheckMoodType();
        }


        if(mood < 0f) {
            gameIsOver();
            mood = 0f;
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

    public void carCrashed() {
        gameIsOver();
    }

    public void gameIsOver() {
        if (gameOver == true)
            return;
        gameOver = true;

        gameOverLay.SetActive(true);
        gameOverLay.transform.GetChild(0).GetComponent<Text>().text = Language.getText(Language.GameOver);
        gameOverLay.transform.GetChild(1).GetComponent<Text>().text = Language.getText(Language.score) + score;
        gameOverLay.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = Language.getText(Language.retryGame);
        gameOverLay.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = Language.getText(Language.toMenu);
        StartCoroutine("Boom");
    }

    IEnumerator Boom ()
    {
        deathCam.Priority = 99999999;
        gui.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        body.mass = 20f;
        GameObject.Instantiate(boom, transform.position, Quaternion.identity);
        body.AddExplosionForce(4000f, new Vector3(transform.position.x, transform.position.y -1f, transform.position.z-.3f), 5f);
        aSource.PlayOneShot(megaBoomClip);
        aSource.PlayOneShot(ohNoClip);
        yield return new WaitForSeconds(5.5f);
        GameObject.Instantiate(boom, transform.position, Quaternion.identity);
        body.AddExplosionForce(60000f, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z+.3f), 5f);
        body.angularVelocity = new Vector3(Random.Range(0f, 5f), Random.Range(0f, 5f), Random.Range(0f, 5f)) ;
        aSource.PlayOneShot(megaBoomClip);
    }


    [Header("Mood")]

    public Text moodInspector;
    public float mood = 100f;

    public Image iHappy;
    public Image iNeutral;
    public Image iAnnoyed;

    private MoodType lastMood = MoodType.Init;
    /*
    public float boy_mood = 100f;
    public float girl_mood = 100f;
    public float wife_mood = 100f;
    */

    public int moodCooldown = 100;
    public void DefaultMoodDecline() {
        moodCooldown--;
        if (moodCooldown < 0) {
            moodCooldown = 100;

            mood -= 0.5f;

            /*
            boy_mood -= 0.5f;
            girl_mood -= 0.5f;
            wife_mood -= 0.3f;
            */

            score += 1;
        }
    }

    public void showMoodGUI() {
        //moodInspector.text = "Mood  \n"+(int)mood;
        moodInspector.text = "" + (int)mood;
    }

    public void CheckMoodType()
    {
        MoodType curMood = MoodType.Init;

        if (mood >= 70f)
            curMood = MoodType.Happy;
        else if (mood >= 40f)
            curMood = MoodType.Neutral;
        else
            curMood = MoodType.Annoyed;

        if (curMood != lastMood)
        {
            switch (curMood)
            {
                case MoodType.Happy:
                    iHappy.gameObject.SetActive(true);
                    iNeutral.gameObject.SetActive(false);
                    iAnnoyed.gameObject.SetActive(false);
                    break;
                case MoodType.Neutral:
                    iHappy.gameObject.SetActive(false);
                    iNeutral.gameObject.SetActive(true);
                    iAnnoyed.gameObject.SetActive(false);
                    break;
                case MoodType.Annoyed:
                    iHappy.gameObject.SetActive(false);
                    iNeutral.gameObject.SetActive(false);
                    iAnnoyed.gameObject.SetActive(true);
                    break;
                default:
                    break;
            }
        }

        lastMood = curMood;
    }

    enum MoodType
    {
        Init, Happy, Neutral, Annoyed
    }


    [Header("SPEECH")]
    public float girlSpeechChance = 3f;
    public float boySpeechChance = 3f;
    public float wifeSpeechChance = 3f;


    public void girlEvents() {
        if(Random.Range(0f,10000f) < girlSpeechChance + girlSpeechChance * (100f / mood) * 0.3f) {
            if(mood > 70) {
                int r = (int)Mathf.Floor(Random.Range(0f, 2.99f) );
                if( r == 0) {
                    createSpeechObject(Language.getText(Language.girlSpeechHappy1));
                }else if (r == 1) {
                    createSpeechObject(Language.getText(Language.girlSpeechHappy2));
                }
                else {
                    createSpeechObject(Language.getText(Language.girlSpeechHappy3));
                }
            }
            else if(mood > 40) {
                int r = (int)Mathf.Floor(Random.Range(0f, 3.99f) );
                if (r == 0) {
                    createSpeechObject(Language.getText(Language.girlSpeechMedium1));
                }
                else if (r == 1) {
                    createSpeechObject(Language.getText(Language.girlSpeechMedium2));
                }
                else if (r == 2) {
                    createSpeechObject(Language.getText(Language.girlSpeechMedium3));
                }
                else {
                    createSpeechObject(Language.getText(Language.girlSpeechMedium4));
                }
            }
            else {
                int r = (int) Mathf.Floor( Random.Range(0f, 5.99f) );
                if (r == 0) {
                    createSpeechObject(Language.getText(Language.girlSpeechAngry1));
                }
                else if (r == 1) {
                    createSpeechObject(Language.getText(Language.girlSpeechAngry2));
                }
                else if (r == 2) {
                    createSpeechObject(Language.getText(Language.girlSpeechAngry3));
                }
                else if (r == 3) {
                    createSpeechObject(Language.getText(Language.girlSpeechAngry4));
                }
                else if (r == 4) {
                    createSpeechObject(Language.getText(Language.girlSpeechAngry5));
                }
                else {
                    createSpeechObject(Language.getText(Language.girlSpeechAngry6));
                }
            }


        }

    }
    public void boyEvents() {
        if (Random.Range(0f, 10000f) < boySpeechChance + boySpeechChance * (100f / mood) * 0.3f) {


            if (mood > 70) {
                int r = (int)Mathf.Floor(Random.Range(0f, 2.99f));
                if (r == 0) {
                    createSpeechObject(Language.getText(Language.boySpeechHappy1));
                }
                else if (r == 1) {
                    createSpeechObject(Language.getText(Language.boySpeechHappy2));
                }
                else {
                    createSpeechObject(Language.getText(Language.boySpeechHappy3));
                }
            }
            else if (mood > 40) {
                int r = (int)Mathf.Floor(Random.Range(0f, 3.99f));
                if (r == 0) {
                    createSpeechObject(Language.getText(Language.boySpeechMedium1));
                }
                else if (r == 1) {
                    createSpeechObject(Language.getText(Language.boySpeechMedium2));
                }
                else if (r == 2) {
                    createSpeechObject(Language.getText(Language.boySpeechMedium3));
                }
                else {
                    createSpeechObject(Language.getText(Language.boySpeechMedium4));
                }
            }
            else {
                int r = (int)Mathf.Floor(Random.Range(0f, 5.99f));
                if (r == 0) {
                    createSpeechObject(Language.getText(Language.boySpeechAngry1));
                }
                else if (r == 1) {
                    createSpeechObject(Language.getText(Language.boySpeechAngry2));
                }
                else if (r == 2) {
                    createSpeechObject(Language.getText(Language.boySpeechAngry3));
                }
                else if (r == 3) {
                    createSpeechObject(Language.getText(Language.boySpeechAngry4));
                }
                else if (r == 4) {
                    createSpeechObject(Language.getText(Language.boySpeechAngry5));
                }
                else {
                    createSpeechObject(Language.getText(Language.boySpeechAngry6));
                }
            }

        }

    }
    public void wifeEvents() {
        if (Random.Range(0f, 10000f) < wifeSpeechChance + wifeSpeechChance * (100f / mood) * 0.3f) {

            if (mood > 70) {
                int r = (int)Mathf.Floor(Random.Range(0f, 2.99f));
                if (r == 0) {
                    createSpeechObject(Language.getText(Language.wifeSpeechHappy1));
                }
                else if (r == 1) {
                    createSpeechObject(Language.getText(Language.wifeSpeechHappy2));
                }
                else {
                    createSpeechObject(Language.getText(Language.wifeSpeechHappy3));
                }
            }
            else if (mood > 40) {
                int r = (int)Mathf.Floor(Random.Range(0f, 3.99f));
                if (r == 0) {
                    createSpeechObject(Language.getText(Language.wifeSpeechMedium1));
                }
                else if (r == 1) {
                    createSpeechObject(Language.getText(Language.wifeSpeechMedium2));
                }
                else if (r == 2) {
                    createSpeechObject(Language.getText(Language.wifeSpeechMedium3));
                }
                else {
                    createSpeechObject(Language.getText(Language.wifeSpeechMedium4));
                }
            }
            else {
                int r = (int)Mathf.Floor(Random.Range(0f, 5.99f));
                if (r == 0) {
                    createSpeechObject(Language.getText(Language.wifeSpeechAngry1));
                }
                else if (r == 1) {
                    createSpeechObject(Language.getText(Language.wifeSpeechAngry2));
                }
                else if (r == 2) {
                    createSpeechObject(Language.getText(Language.wifeSpeechAngry3));
                }
                else if (r == 3) {
                    createSpeechObject(Language.getText(Language.wifeSpeechAngry4));
                }
                else if (r == 4) {
                    createSpeechObject(Language.getText(Language.wifeSpeechAngry5));
                }
                else {
                    createSpeechObject(Language.getText(Language.wifeSpeechAngry6));
                }
            }

        }

    }


    public GameObject speechObject;
    public Transform speechSpace;

    public void createSpeechObject(string txt) {
        GameObject tmp = Instantiate(speechObject,speechSpace);
        tmp.GetComponent<SpeechObjectBehavior>().create(txt);
    }
}
