using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Prefabs Instantiated at Start
    public PlayerCharacter PlayerCharacterPrefab;
    public MainUI MainUIPrefab;

    static GameManager singleton;
    public static GameManager Singleton() {return singleton;}
    MetricsManager metricsManager;

    // Instances of those prefabs
    public PlayerCharacter ActivePlayerCharacter;
    MainUI MainUI;

    // Seconds before the game forcibly ends
    public float gameTimeoutTime = 300;
    float timeSinceGameStart;

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

        metricsManager = new MetricsManager();
        metricsManager.Initialize();

        MapLayout.LoadMapFile();
    }

    public static MainUI GetMainUI()
    {
        return singleton.MainUI;
    }

    void Update() {
        timeSinceGameStart += Time.deltaTime;

        if (timeSinceGameStart > gameTimeoutTime) {
            Debug.Log("Time over!");
            EndGame();
        }
    }

    void EndGame() {
        Debug.Log("Ending Game");
    }
}
