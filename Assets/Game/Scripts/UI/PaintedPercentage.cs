using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PaintedPercentage : MonoBehaviour
{   
    private Text text;

    private void Start() {
        text = GetComponent<Text>();
        text.enabled = false;
        GameManager.Instance.OnPlayerFinished += OnPlayerFinished;
    }

    private void Update() {
        if(text.enabled == false) return;
        int percentagePainted = GameManager.Instance.GetPercentagePainted();
        text.text = percentagePainted + "% Painted";
    }

    private void OnPlayerFinished(object sender, GameManager.OnPlayerFinishedEventArgs e){
        Invoke("Activate", e.activationDelay);
    }

    private void Activate(){
        text.enabled = true;
    }
}
