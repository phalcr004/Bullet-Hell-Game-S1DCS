using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayNextCommand : Command {
    // Keep track of when the command should end
    private float endTime;

    private bool isFinished = false;

    public DelayNextCommand(float startTime, float delayTime) {
        endTime = startTime + delayTime;
        Debug.Log("Begun timer");
    }

    public void RunCommand() {
        if(Time.time > endTime) {
            isFinished = true;
            Debug.Log("Timer finished");
        }
    }
    public bool CheckIsFinished() {
        return isFinished;
    }
}
