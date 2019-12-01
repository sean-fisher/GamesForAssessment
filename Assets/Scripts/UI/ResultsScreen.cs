using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ResultsScreen : MonoBehaviour
{

    public TextMeshProUGUI resultsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayResults() {
        IPersonalityMeasurer pm = GameObject.FindObjectOfType<IPersonalityMeasurer>();
        string res = pm.GetResultsAsString();
        resultsText.text = res;
    }
}
