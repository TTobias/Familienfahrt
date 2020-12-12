using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuFunctions : MonoBehaviour
{
    public Text startBtn;
    public Text engBtn;
    public Text gerBtn;
    public Text saarBtn;

    public Text storyTxt;
    public Text creditTxt;
    public Text controlText;

    public void Start() {
        changeLanguage(0);
    }


    public void updateGui() {
        startBtn.text = Language.getText(Language.startGame);
        engBtn.text = Language.LanguageNames[0];
        gerBtn.text = Language.LanguageNames[1];
        saarBtn.text = Language.LanguageNames[2];

        storyTxt.text = Language.getText(Language.story);
        creditTxt.text = Language.getText(Language.credits);
        controlText.text = Language.getText(Language.controls);
    }

    public void changeLanguage(int l) {
        Language.language = l;

        updateGui();
    }

    public void startGame() {
        SceneManager.LoadScene("");
    }
}
