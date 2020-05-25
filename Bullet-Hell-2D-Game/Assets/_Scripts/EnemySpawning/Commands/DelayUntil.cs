using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayUntil : ICommand {
    // Keep track of when the command should end
    private float endTime;

    private bool isFinished = false;

    public DelayUntil(float endTime) {
        this.endTime = endTime;
    }

    public void RunCommand() {
        if(Time.time > endTime) {
            isFinished = true;
        }
    }
    public bool CheckIsFinished() {
        return isFinished;
    }
}
