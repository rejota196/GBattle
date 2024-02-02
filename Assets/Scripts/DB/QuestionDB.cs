using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;

public class QuestionDB : MonoBehaviour
{
    private string dbName = "URI=file:questions.db";
    

    public string[] GetQuestionById(int questionId){
        string[] selectedQuestion = new string[7];
        using( var connection = new SqliteConnection(dbName)){
            connection.Open();
            using(var command = connection.CreateCommand()){
                command.CommandText = "SELECT * FROM preguntas WHERE rowid = @questionId;";
                command.Parameters.Add(new SqliteParameter("@questionId", questionId));

                using ( var reader = command.ExecuteReader()){
                    if(reader.Read()){
                        selectedQuestion[0] = reader.GetString(0);
                        selectedQuestion[1] = reader.GetString(1);
                        selectedQuestion[2] = reader.GetString(2);
                        selectedQuestion[3] = reader.GetString(3);
                        selectedQuestion[4] = reader.GetString(4);
                        selectedQuestion[5] = reader.GetString(5);
                        selectedQuestion[6] = reader.GetString(6);                        
                    }
                    else{
                        Debug.Log("No se encontro la pregunta con el ID ingresado");
                    }
                }

            }
            connection.Close();            
        }
        return selectedQuestion;
    }

    public int GetQuestionCount(){
        int count = 0;
        using( var connection = new SqliteConnection(dbName)){
            connection.Open();
            
            using( var command = connection.CreateCommand()){
                command.CommandText = "SELECT COUNT(*) FROM preguntas;";
                count = Convert.ToInt32(command.ExecuteScalar());
            }
            connection.Close();
        }
        return count;
    }

    
}
