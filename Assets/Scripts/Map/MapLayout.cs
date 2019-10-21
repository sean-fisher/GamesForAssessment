using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Cardinal {
    EAST,
    NORTH,
    WEST,
    SOUTH
}

public class MapLayout : MonoBehaviour
{
    static string[,] roomArray;

    public static void LoadMapFile() {
        var textFile = Resources.Load<TextAsset>("Map");

        if (textFile == null) {
            Debug.LogError("Map file was null!");
        } else {

            List<List<string>> rooms = new List<List<string>>();

            string text = textFile.text;

            var lines = text.Split('\n');

            int r = 0;
            int maxWidth = 0;
            foreach (string line in lines) {
                int c = 0;
                string[] roomNames = line.Split('\t');
                foreach (string roomName in roomNames) {

                    if (rooms.Count - 1 < r) {
                        rooms.Add(new List<string>());
                    }

                    rooms[r].Add(roomName);
                    c++;
                }
                if (c > maxWidth) {
                    maxWidth = c;
                }
                r++;
            }

            roomArray = new string[r, maxWidth];

            r = 0;
            foreach (var row in rooms) {
                int c = 0;
                foreach (var room in row) {
                    roomArray[r,c] = room;
                    c++;
                }
                r++;
            }

            Debug.Log("Loaded map successfully!");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static string GetRoomNextTo(string currentRoomName, Cardinal directionOfNextRoom) {
        for (int r = 0; r < roomArray.Length; r++) {
            for (int c = 0; c < roomArray.GetLength(1); c++) {
                if (roomArray[r,c] == currentRoomName) {

                    switch (directionOfNextRoom) {
                        case (Cardinal.EAST):
                        if (c < roomArray.GetLength(1) - 1) {
                            return roomArray[r, c+1];
                        }
                        break;
                        case (Cardinal.NORTH):
                        if (r > 0) {
                            return roomArray[r-1, c];
                        }
                        break;
                        case (Cardinal.WEST):
                        if (c > 0) {
                            return roomArray[r, c-1];
                        }
                        break;
                        case (Cardinal.SOUTH):
                        if (r < roomArray.GetLength(0) - 1) {
                            return roomArray[r+1, c];
                        }
                        break;
                    }
                    return "";
                }
            }
        }
        return "";
    }
}
