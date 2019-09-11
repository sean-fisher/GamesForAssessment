using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Prefabs Instantiated at Start
    public PlayerCharacter PlayerCharacterPrefab;
    public MainUI MainUIPrefab;

    static GameManager singleton;

    // Instances of those prefabs
    PlayerCharacter ActivePlayerCharacter;
    MainUI MainUI;

    // Start is called before the first frame update
    void Start()
    {

        if (singleton == null)
        {
            singleton = this;
        } else
        {
            Destroy(this.gameObject);
            return;
        }

        if (ActivePlayerCharacter == null)
        {
            ActivePlayerCharacter = FindObjectOfType<PlayerCharacter>();
            if (ActivePlayerCharacter == null)
            {
                ActivePlayerCharacter = GameObject.Instantiate(PlayerCharacterPrefab);

                // Do any player initialization here
            }
        }
        if (MainUI == null)
        {
            MainUI = FindObjectOfType<MainUI>();
            if (MainUI == null)
            {
                MainUI = GameObject.Instantiate(MainUIPrefab);

                // Do any UI initialization here
            }
        }
    }

    public static MainUI GetMainUI()
    {
        return singleton.MainUI;
    }
}
