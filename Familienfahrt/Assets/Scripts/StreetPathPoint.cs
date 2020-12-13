using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//[ExecuteInEditMode]
public class StreetPathPoint : MonoBehaviour
{
    public List<StreetPathPoint> next;
    public float localSpeed = 50f;

    /*
    public bool add = false;
    public void Update() {
        if (add) {
            add = false;
            GameObject tmp = Instantiate(this.gameObject, this.transform.parent);
            next.Add(tmp.GetComponent<StreetPathPoint>());
            tmp.name = this.name;
        }

        for(int i = 0; i< next.Count; i++) {
            Debug.DrawLine(this.transform.position, next[i].transform.position, Color.red);
        }
    }*/
}
