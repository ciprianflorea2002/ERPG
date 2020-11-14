using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public static EndScreen endScreen;
    public GameObject lost;
    public GameObject won;
    void Start()
    {
        endScreen = this;
        gameObject.SetActive(false);
    }

    public void End(bool _won){
        gameObject.SetActive(true);
        lost.SetActive(!_won);
        won.SetActive(_won);
    }
}
