using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;


public class AchievementDB : MonoBehaviour
{
    private string dbName = "URI=file:achievement.db";
    void Start(){
        CreateDB();
        AddAchievement("Martín Miguel", "a1.png");
        AddAchievement("De cuna militar", "a2.png");
        AddAchievement("Cosas de la infancia", "a3.png");
        AddAchievement("Recuerdos", "a4.png");
        AddAchievement("La educación", "a5.png");
        AddAchievement("De nuevo en casa", "a6.png");
        AddAchievement("Corazón de los valles", "a7.png");
        AddAchievement("Tesorería real", "a8.png");
        AddAchievement("¡Hola papá!", "a9.png");
        AddAchievement("¡Hola mamá!", "a10.png");
        AddAchievement("Mujeres de acción", "a11.png");
        AddAchievement("¡Infernales!", "a12.png");
        AddAchievement("¡Con gloria morir...!", "a13.png");
        AddAchievement("¡Medicina colonial!", "a14.png");
        AddAchievement("¡General herido!", "a15.png");
        AddAchievement("¡Equipados!", "a16.png");
        AddAchievement("El cadete", "a17.png");
        AddAchievement("Territorio", "a18.png");
        AddAchievement("¡Guerrillas!", "a19.png");
        AddAchievement("¡De gala!", "a20.png");
        AddAchievement("¡Protegidos 2", "a21.png");
        AddAchievement("¿Infernales azules?", "a22.png");
        AddAchievement("¡A caballo!", "a23.png");
        AddAchievement("¡Legado!", "a24.png");
        AddAchievement("¡Equipados 2!", "a25.png");
        AddAchievement("Tejeda/Texada", "a26.png");
        AddAchievement("Equipados 3", "a27.png");
        AddAchievement("Equipados 4", "a28.png");
        AddAchievement("Equipados 5", "a29.png");
        AddAchievement("Protegidos", "a30.png");
        AddAchievement("Infernales 2", "a31.png");


    }

    private void CreateDB(){
        using(var connection = new SqliteConnection (dbName)){
            connection.Open();
            using(var command = connection.CreateCommand()){
                command.CommandText = "CREATE TABLE IF NOT EXISTS logros (achievement_name VARCHAR(50), achievement_image_name VARCHAR(50), achievement_pos INT DEFAULT 0);";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    private void AddAchievement(string aName, string aImageName){
        using(var connection = new SqliteConnection(dbName)){
            connection.Open();
            int existingCount = GetAchievementCountByAchievement(aName);
            if(existingCount > 0){
                Debug.Log("El logro que se intenta ingresar ya existe");
                connection.Close();
                return;
            }
            using(var command = connection.CreateCommand()){
                command.CommandText = "INSERT INTO logros (achievement_name, achievement_image_name) VALUES (@achievement_name, @achievement_image_name);";
                command.Parameters.Add(new SqliteParameter("@achievement_name", aName));
                command.Parameters.Add(new SqliteParameter("@achievement_image_name", aImageName));                
                command.ExecuteNonQuery();                
            }
            connection.Close();
        }
    }
    private int GetAchievementCountByAchievement(string aName){
        int count = 0;
        using (var connection = new SqliteConnection(dbName)){
            connection.Open();
            using( var command = connection.CreateCommand()){
                command.CommandText = "SELECT COUNT(*) FROM logros WHERE achievement_name = @achievement_name;";
                command.Parameters.Add(new SqliteParameter("@achievement_name", aName));
                count = Convert.ToInt32(command.ExecuteScalar());
            }
            connection.Close();
        }
        return count;
    }

    public void SetAchievementPosition() {
        using( var connection = new SqliteConnection(dbName)){
            connection.Open();
            using (var command = connection.CreateCommand()){
                command.CommandText = "UPDATE logros SET achievement_pos = @new_achievement_pos WHERE achievement_pos = 0 AND ROWID = (SELECT ROWID FROM logros WHERE achievement_pos = 0 LIMIT 1);";
                command.Parameters.Add(new SqliteParameter("@new_achievement_pos", 1));
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    

    
}
