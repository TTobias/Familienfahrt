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

        this.GetComponent<RectTransform>().position = new Vector3(Random.Range(20, 380), Random.Range(20, 180), Random.Range(-5, 5));
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(Random.Range(100, 300), Random.Range(40, 100));

    }



    public void remove() {
        Destroy(this.gameObject);
        //if (img.color.a > 0) img.f
    }
}
