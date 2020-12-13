﻿using System.Collections;
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


    public static string[] wifeSpeechHappy1 = { "Please drive careful", "Bitte fahr vorsichtig", "Fahrena aba wei auch vorsichtg" };
    public static string[] wifeSpeechHappy2 = { "It's nice to have a family trip together", "Schön so ein Familienausflug, oder?", "Eiretlich n guddn tach um zu schwenken, net?" };
    public static string[] wifeSpeechHappy3 = { "What do you wanna have for dinner, darling?", "Was sollen wir danach zu Abend essen?", "Hole ma nachher nochn Fleischkäsweck?" };

    public static string[] wifeSpeechMedium1 = { "Don't drive that fast!", "Nicht so schnell fahren", "" };
    public static string[] wifeSpeechMedium2 = { "No such risky maneuvers please...", "Mit fahr doch weniger riskant", "" };
    public static string[] wifeSpeechMedium3 = { "And why do you decide where to go?", "Und warum entscheidest du wohin wir fahren?", "" };
    public static string[] wifeSpeechMedium4 = { "Let me have that map now, i think we're heading the wrong way", "", "" };

    public static string[] wifeSpeechAngry1 = { "Now drive carefully", "Jetzt fahr schon vorsichtig", "" };
    public static string[] wifeSpeechAngry2 = { "No more risks or we'll walk home!", "Wenn du nicht sicherer fährst laufen wir besser!", "" };
    public static string[] wifeSpeechAngry3 = { "You have no idea where we are, right?", "Du hast keine Ahnung wo wir sind, oder?", "" };
    public static string[] wifeSpeechAngry4 = { "I never should've agreed to this", "Ich hätte dem nie zustimmen sollen...", "" };
    public static string[] wifeSpeechAngry5 = { "We'd be happier without you", "Ohne dich wäre der Ausflug angenehmer", "" };
    public static string[] wifeSpeechAngry6 = { "How long do you wanna keep driving like this?", "Wie lange wollen wir eigentlich noch planlos durch die Gegend fahren", "" };


    public static string[] girlSpeechHappy1 = { "And afterwards i wanna visit the horses :D", "Und danach will ich Pferde sehen", "" };
    public static string[] girlSpeechHappy2 = { "... and then when we came from school ... and they told ... great day ...", "", "" };
    public static string[] girlSpeechHappy3 = { "Let's make a picknick somwhere ^^", "", "" };

    public static string[] girlSpeechMedium1 = { "When will we arrive?", "", "" };
    public static string[] girlSpeechMedium2 = { "How long will this keep going?", "", "" };
    public static string[] girlSpeechMedium3 = { "I am bored", "", "" };
    public static string[] girlSpeechMedium4 = { "My brother is getting on my nerves again.", "", "" };

    public static string[] girlSpeechAngry1 = { "Can't we drive home now?", "", "" };
    public static string[] girlSpeechAngry2 = { "I don't enjoy this anymore", "", "" };
    public static string[] girlSpeechAngry3 = { "This is a horrible family trip", "", "" };
    public static string[] girlSpeechAngry4 = { "Just admit that we got lost.", "", "" };
    public static string[] girlSpeechAngry5 = { "How did you even get that driving license?", "", "" };
    public static string[] girlSpeechAngry6 = { "...", "...", "Unn nu?" };


    public static string[] boySpeechHappy1 = { "Nice to see you have some time for us", "", "" };
    public static string[] boySpeechHappy2 = { "Great weather today, ain't it?", "", "" };
    public static string[] boySpeechHappy3 = { "We should repeat this somewhen", "", "" };

    public static string[] boySpeechMedium1 = { "This is boring", "", "" };
    public static string[] boySpeechMedium2 = { "I'm in a bad mood now", "", "" };
    public static string[] boySpeechMedium3 = { "Lets grab sth to eat", "", "" };
    public static string[] boySpeechMedium4 = { "Some Lyoner would be good now", "", "" };

    public static string[] boySpeechAngry1 = { "I'd prefer to stay at home next time", "", "" };
    public static string[] boySpeechAngry2 = { "Can we grab sth to eat?", "", "" };
    public static string[] boySpeechAngry3 = { "I'm hungry", "", "" };
    public static string[] boySpeechAngry4 = { "Just try not to crash the car", "Bau doch einfach keine Unfälle", "" };
    public static string[] boySpeechAngry5 = { "I wanna get home now", "Ich will nach Hause", "Eich wolln hemm" };
    public static string[] boySpeechAngry6 = { "Thats annoying", "Das nervt total", "" };


    public static string[] startGame = {"Start game", "Spiel starten", "Stard'e ma mo wei"};
    public static string[] LanguageNames = { "English", "Deutsch", "Saarlännich'" };
    public static string[] controls = { "- Car Control: WASD \n- Leftmouse to interact \n- Rightmouse to move cursor freely",
        "- Fahrzeugsteuerung: WASD \n- Linke Maustaste zum interagieren \n- Rechte Maustaste um den Cursor frei zu bewegen",
        "- Wägelche: WASD \n- Linka Maustrikka fürs interagier'e \n- Rechtn Maustrikka für en Zeicher frei zu bewe'chen" };
    public static string[] story = { "You are making a family trip on your free day. Keep everyone in a good mood and be careful not to crash the car.",
        "Du genießt einen Familienausflug mit Frau und Kinder. Gehe sicher das jeder den Tag genießt und baue keinen Autounfall.",
        "N Autofahrd midda gansa Famill', da sollde doch jeden in na guddn laune sinn. En Autounfall soll da wei bloß fott bleiwe" };
    public static string[] credits = { "Created by: Kiwi Tobi (Jen)",
        "Created by: Kiwi Tobi (Jen)",
        "Gemoh'n von em Kiwi, em Tobi (un em Jen)" };


    public static string[] retryGame = { "Retry", "Erneut versuchen", "Nommo retour" };
    public static string[] toMenu = { "To the Menu", "Zum Menü", "Ins Meni" };
    public static string[] score = { "Score: ", "Punktestand: ", "Punkt'stann: " };
    public static string[] GameOver = { "Game Over \nYour family trip was a disaster", "Game Over \nDein Familienausflug war ein Reinfall", "Game Over \nSo gifft'det wei lo nix mit dem Ausfluch lo" };
}
