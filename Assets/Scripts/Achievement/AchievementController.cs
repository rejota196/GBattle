using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;
using UnityEngine.UI;

public class AchievementController : MonoBehaviour
{
    public Achievement[] bAchievement;
    public Image achievementImagePanel;

    void Start(){
        List<int> posActivated = new List<int>();
        posActivated = GetPosActivated();
        for(int i=0; i<posActivated.Count; i++){
            bAchievement[posActivated[i]-1].UpdateButton();            
        }
    }

    private List<int> GetPosActivated(){
        using (var connection = new SqliteConnection("URI=file:achievement.db")) {
            connection.Open();

            var rowNumbers = new List<int>();

            using (var command = connection.CreateCommand()) {
                command.CommandText = "SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS numero_fila FROM logros WHERE achievement_pos = 1;";

                using (var reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        int rowNumber = Convert.ToInt32(reader["numero_fila"]);
                        rowNumbers.Add(rowNumber);
                    }
                }
            }

            connection.Close();
            return rowNumbers;
            
        }
    }

}
