﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPersonalityMeasurer : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void CalculateResults(AllGameStats stats) {

    }

    public virtual string GetResultsAsString() {
        return "Not implemented yet";
    }
}
