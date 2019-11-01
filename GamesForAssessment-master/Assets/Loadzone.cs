using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class Loadzone : MonoBehaviour
{
    public string SceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerCharacter>())
        {
            if (SceneToLoad != "")
            {
                SceneSwitcher.Singleton().SwitchToScene(SceneToLoad);
            } else
            {
                Debug.Log("Scene to Load has not been set!");
            }
        } else
        {
            Debug.Log("Non player character entered load zone");
        }
    }
}
