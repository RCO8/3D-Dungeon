using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusUI : MonoBehaviour
{
    public Status hp;
    public Status sp;
    public Status exp;


    void Update()
    {
        
    }

    public void RecoverHealth(float amount) => hp.Add(amount);
    public void RecoverSkill(float amount) => sp.Add(amount);
    public void IncreaseExp(float amount) => exp.Add(amount);
}
