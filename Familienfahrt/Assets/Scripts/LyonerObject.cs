using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LyonerObject : MonoBehaviour
{
    public Transform player;
    public MoodCalculator mood;

    public GameObject lyoner;
    public GameObject specialLyoner;
    
    public float cooldown = 90f;
    public float cooldownMax = 3000f;

    public bool isSpecial = false;
    public bool exists = false;
    
    public void FixedUpdate() {
        if (exists) {
            if(Vector3.Distance(player.position,this.transform.position) < 3f) {
                if (isSpecial) {
                    mood.score += 250;
                    mood.mood += 20;
                }
                else {
                    mood.score += 100;
                    mood.mood += 10;
                }

                exists = false;
                cooldown = cooldownMax;
                lyoner.SetActive(false);
                specialLyoner.SetActive(false);
            }

            if (isSpecial) {
                specialLyoner.transform.Rotate(new Vector3(0f, 0f, 4f));
            }
            else {
                lyoner.transform.Rotate(new Vector3(0f, 0f, 4f));
            }
        }
        else {
            if(cooldown > 0) {
                cooldown -= Time.deltaTime * 5f;
            }
            else {
                isSpecial = Random.Range(0f, 10f) > 9f;
                exists = true;
                cooldown = 0;
                if (isSpecial) {
                    specialLyoner.SetActive(true);
                }
                else {
                    lyoner.SetActive(true);
                }
            }
        }
    }
}
