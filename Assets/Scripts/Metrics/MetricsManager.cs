﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomStats {
    public float timeSpentInRoom;
    public int totalNumInteractions;
    public int numInteractions;
}

public class AllGameStats {

    // General Stats
    public Dictionary<string, RoomStats> roomStatsDict; 

    // Minigames
    public float bhicken_sorted_score;
    public float bhicken_orderliness;

    public float thiefScore;

    public float animalSavingScore;
    public float animalSavingTime;

    public float matchingScore;
    public float matchingTime;

    public float mazeScore;
    public float mazeTime;
}

public class MetricsManager
{
    static MetricsManager singleton;
    public static MetricsManager Singleton() {
        if (singleton == null) {
            singleton = new MetricsManager();
        }
        return singleton;
    }

    public AllGameStats stats;

    public void Initialize() {
        if (singleton == null) {
            singleton = this;
            stats = new AllGameStats();
            stats.roomStatsDict = new Dictionary<string, RoomStats>();
        } else {
            //Destroy(this);
        }
    }

    public void AddRoomTime(string sceneName, float time) {
        if (!stats.roomStatsDict.ContainsKey(sceneName)) {
            stats.roomStatsDict[sceneName] = new RoomStats();
        }
        stats.roomStatsDict[sceneName].timeSpentInRoom = stats.roomStatsDict[sceneName].timeSpentInRoom + time;
        Debug.Log("Time spent in " + sceneName + ": " + stats.roomStatsDict[sceneName].timeSpentInRoom);
    }
}
