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

    [Range(0.0f, 1.0f)]
    public float fastText_weight = .5f;

    [Range(0.0f, 1.0f)]
    public float avgRoomTime_weight = .5f;

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
        float roomTimeScore = 1 - (roomTimeStandardDeviation / avgRoomTime);
        
        float fastTextScore = 1 - Mathf.Clamp(ScrollingTextBox.numTimesAdvancedText / 50.0f, 0f, 1f);


        honestyHumilityScore = (stats.thiefScore * thiefScore_weight) / (thiefScore_weight);
        emotionalityScore = (stats.thiefScore * thiefScore_weight) / (thiefScore_weight);
        extraversionScore = ((1 - fastTextScore) * fastText_weight) / (fastText_weight);
        agreeablenessScore = (fastTextScore * fastText_weight) / (fastText_weight);
        conscientiousnessScore = (stats.mazeScore * mazeScore_weight +
            stats.bhicken_sorted_score * bhicken_sorted_weight
            + stats.bhicken_orderliness * bhicken_orderliness_weight)
            / (bhicken_sorted_weight + bhicken_orderliness_weight + mazeScore_weight);

        opennessScore = (Mathf.Abs(stats.matchingScore) * matchingScore_weight +
            Mathf.Abs(roomTimeScore) * avgRoomTime_weight) / (matchingScore_weight + avgRoomTime_weight);

        // for the purposes of demoing, we fake values if they have come out to be 0
        // This may happen if the player doesn't do everything
        float randValCap = .45f;
        if ((Mathf.Abs(honestyHumilityScore) < .1f))   honestyHumilityScore = Random.Range(.1f, randValCap);
        if ((Mathf.Abs(emotionalityScore) < .1f))      emotionalityScore = Random.Range(.1f, randValCap);
        if ((Mathf.Abs(extraversionScore) < .1f))      extraversionScore = Random.Range(.1f, randValCap);
        if ((Mathf.Abs(agreeablenessScore) < .1f))     agreeablenessScore = Random.Range(.1f, randValCap);
        if ((Mathf.Abs(conscientiousnessScore) < .1f)) conscientiousnessScore = Random.Range(.1f, randValCap);
        if ((Mathf.Abs(opennessScore) < .1f))          opennessScore = Random.Range(.1f, randValCap);
    }
    public override string GetResultsAsString() {

        CalculateResults(MetricsManager.Singleton().stats);

        float[] scoreArray = {
            honestyHumilityScore,
            emotionalityScore,
            extraversionScore,
            agreeablenessScore,
            conscientiousnessScore,
            opennessScore
        };

        string results = string.Format(
            "Honesty/Humility: {0}\nEmotionality: {1}\nExtraversion: {2}\nAgreeableness: {3}\nConscientiousness: {4}\nOpenness to Experience: {5}",
            honestyHumilityScore, emotionalityScore, extraversionScore, agreeablenessScore, conscientiousnessScore, opennessScore);

        return results;
    }
}
