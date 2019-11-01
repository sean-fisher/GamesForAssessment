using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexacoMeasurer : IPersonalityMeasurer
{
    // Weights for calculating HEXACO values from game stats
    [Range(0.0f, 1.0f)]
    public float bhicken_sorted_weight = .5f;
    [Range(0.0f, 1.0f)]
    public float bhicken_orderliness_weight = .5f;

    [Range(0.0f, 1.0f)]
    public float thiefScore_weight = .5f;

    [Range(0.0f, 1.0f)]
    public float animalSavingScore_weight = .5f;
    [Range(0.0f, 1.0f)]
    public float animalSavingTime_weight = .5f;

    [Range(0.0f, 1.0f)]
    public float matchingScore_weight = .5f;
    [Range(0.0f, 1.0f)]
    public float matchingTime_weight = .5f;

    [Range(0.0f, 1.0f)]
    public float mazeScore_weight = .5f;
    [Range(0.0f, 1.0f)]
    public float mazeTime_weight = .5f;


    // HEXACO Values

    float honestyHumilityScore;
    float emotionalityScore;
    float extraversionScore;
    float agreeablenessScore;
    float conscientiousnessScore;
    float opennessScore;

    public override void CalculateResults(AllGameStats stats) {

        int totalNumInteractionsAcrossAllRooms = 0;
        int totalNumRoomsVisited = 0;
        List<float> timeSpendInRoomsList = new List<float>();

        foreach (string roomNameKey in stats.roomStatsDict.Keys) {
            RoomStats rs = stats.roomStatsDict[roomNameKey];
            totalNumInteractionsAcrossAllRooms += rs.numInteractions;

            if (rs.timeSpentInRoom > 0) {
                totalNumRoomsVisited++;
                timeSpendInRoomsList.Add(rs.timeSpentInRoom);
            }
        }

        // calculate the mean and standard deviation for time spent in rooms
        // mean
        float totalTimeSpentInAllRooms = 0;
        for (int i = 0; i < totalNumRoomsVisited; i++) {
            totalTimeSpentInAllRooms += timeSpendInRoomsList[i];
        }
        float avgRoomTime = totalTimeSpentInAllRooms / totalNumRoomsVisited;

        // Standard Deviation
        float stdevSum = 0;
        for (int i = 0; i < totalNumRoomsVisited; i++) {
            stdevSum += Mathf.Pow((timeSpendInRoomsList[i] - avgRoomTime), 2);
        }
        float roomTimeStandardDeviation = Mathf.Sqrt(stdevSum / (totalNumRoomsVisited - 1));
        

        honestyHumilityScore = 0;
        emotionalityScore = 0;
        extraversionScore = 0;
        agreeablenessScore = 0;
        conscientiousnessScore = 
            stats.bhicken_sorted_score * bhicken_sorted_weight
            + stats.bhicken_orderliness * bhicken_orderliness_weight;
        opennessScore = avgRoomTime;
    }
    public override string GetResultsAsString() {
        return "Hexaco not implemented";
    }
}
