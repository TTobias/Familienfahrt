using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Language {
    public static int language = 0;
    //0: ENG, 1:DEU, 2:SAAR

    public static string getText(string[] t) {
        return t[language];
    }

    public static string[] tmpGirlSpeech = { "TESTGIRL", "TESTMÄDCHEN", "TEST MÄDEL" };
    public static string[] tmpBoySpeech = { "TESTBOY", "TESTJUNGE", "TEST BIBBCHA" };
    public static string[] tmpWifeSpeech = { "TESTWIFE", "TESTFRAU", "TEST FRAA" };


    public static string[] startGame = {"Start game", "Spiel starten", "Stard'e ma mo wei"};
    public static string[] LanguageNames = { "English", "Deutsch", "Saarlännich'" };
    public static string[] controls = { "- Car Control: WASD \n- Leftmouse to interact \n- Rightmouse to move cursor freely",
        "- Fahrzeugsteuerung: WASD \n- Linke Maustaste zum interagieren \n- Rechte Maustaste um den Cursor frei zu bewegen",
        "- Wägelche: WASD \n- Linka Maustrikka fürs interagier'e \n- Rechtn Maustrikka für en Zeicher frei zu bewe'chen" };
    public static string[] story = { "Family Trip",
        "Autofahrt mit der ganzen Familie",
        "N Autofahrd midda gansa Famill'" };
    public static string[] credits = { "Created by: Kiwi Tobi Jen",
        "Created by: Kiwi Tobi Jen",
        "Gemoh'n von em Kiwi, em Tobi un em Jen" };
}
