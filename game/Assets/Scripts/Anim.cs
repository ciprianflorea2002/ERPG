using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Anim : MonoBehaviour {

    [SerializeField] private Sprite[] frames;
    [SerializeField] private  float fps = 10.0f;

    private SpriteRenderer mat;

    void Start () {
        mat = (SpriteRenderer) GetComponent<SpriteRenderer> ();
    }

    void FixedUpdate () {
        int index = (int)(Time.time * fps);
        index = index % frames.Length;
        mat.sprite = frames[index];
    }
}