using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechObjectBehavior : MonoBehaviour
{
    Text text;
    Button btn;
    Image img;

    public string speechString;

    public void create(string speech) {
        text = this.transform.GetChild(0).GetComponent<Text>();
        btn = this.GetComponent<Button>();
        img = this.GetComponent<Image>();


        speechString = speech;
        this.transform.GetChild(0).GetComponent<Text>().text = speechString;
        this.GetComponent<RectTransform>().position = new Vector3(Random.Range(Screen.width*0.1f, Screen.width*0.9f), Random.Range(Screen.height*0.1f, Screen.height*0.9f), Random.Range(-5, 5));
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(Random.Range(Screen.width * 0.08f, Screen.width * 0.26f), Random.Range(Screen.height * 0.04f, Screen.height * 0.15f));

    }



    public void remove() {
        Destroy(this.gameObject);
        //if (img.color.a > 0) img.f
    }
}
