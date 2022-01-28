using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FunctionTimer
{
    private Action action;
    private float timer;

    public FunctionTimer(Action action, float timer){
        this.action = action;
        this.timer = timer;
    }

    private void Update() {
        timer -= Time.deltaTime;
        if(timer < 0){
            action();
        }
    }
}
