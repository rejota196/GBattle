using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;

public class QuestionDB : MonoBehaviour
{
    private string dbName = "URI=file:questions.db";
    void Start()
    {
        CreateDB();
        AddQuestion("¿Dónde nació Martín Miguel de Güemes?", "Buenos Aires","Córdoba","Salta", "Mendoza","Respuesta correcta: Salta", "Descripción: Martín Miguel de Güemes nació en Salta, Argentina.");
        AddQuestion("¿Cuál era la estrategia de guerra que Güemes utilizó para resistir a las fuerzas realistas?", "Batallas convencionales","Guerrilla y movilidad","Asedios a fortalezas", "Diplomacia pacífica","Respuesta correcta: Guerrilla y movilidad", "Descripción: Güemes empleó tácticas de guerrilla y movilidad para resistir a las fuerzas realistas, utilizando la agilidad y rapidez de los gauchos en el terreno.");
        AddQuestion("¿Qué papel desempeñó Güemes en la Guerra de la Independencia Argentina?", "Pintor","Músico","Líder militar", "Agricultor", "Respuesta correcta: Líder militar", "Descripción: Güemes desempeñó un papel crucial como líder militar en la Guerra de la Independencia Argentina, organizando la resistencia en el noroeste del país.");
        AddQuestion("¿En qué fecha Martín Miguel de Güemes fue asesinado?", "9 de julio de 1816","17 de junio de 1821","25 de mayo de 1810", "20 de febrero de 1806","Respuesta correcta: 17 de junio de 1821", "Descripción: Güemes fue asesinado el 17 de junio de 1821, marcando un trágico final para su vida.");
        AddQuestion("¿Cuál es el apodo que recibe Martín Miguel de Güemes por su liderazgo en la Guerra Gaucha?", "El Libertador","El Patriota","El Héroe Gaucho", "El Estratega Silencioso", "Respuesta correcta: El Héroe Gaucho", "Descripción: Güemes es conocido como El héroe gaucho debido a su valentía y liderazgo durante la guerra gaucha, resistiendo las invasiones realistas en el noroeste argentino.");
        AddQuestion("¿Qué táctica de guerra implementó Güemes para desgastar a las fuerzas realistas?", "Batallas navales","Guerras de trincheras","Guerrilla y hostigamiento constante", "Estrategias de emboscada", "Respuesta correcta: Guerrilla y hostigamiento constante", "Descripción: Güemes empleó tácticas de guerrilla, que consistían en ataques rápidos y sorpresivos, movilidad constante y hostigamiento continuo, lo que resultó efectivo para desgastar a las fuerzas realistas sin enfrentarse en batallas convencionales.");
        AddQuestion("¿Cuál fue el mes y el año de nacimiento de Martín Miguel de Güemes?", "Febrero de 1785","Mayo de 1810","Septiembre de 1821", "Diciembre de 1799", "Respuesta correcta: Febrero de 1785", "Descripción: Martín Miguel de Güemes nació el 8 de febrero de 1785 en Salta, Argentina.");
        AddQuestion("¿Quién nombró a Güemes líder de los gauchos y comandante del Ejército del Norte?", "José de San Martín", "Manuel Belgrano", "Juan Manuel de Rosas", "Simón Bolívar", "Respuesta correcta: Manuel Belgrano", "Descripción: Manuel Belgrano nombró a Güemes líder de los gauchos y comandante del Ejército del Norte durante la lucha por la independencia de Argentina.");
        AddQuestion("¿Cuál es la fecha en la que se celebra el Día de la Muerte del General Güemes en Argentina?", "25 de mayo", "17 de junio", "9 de julio", "8 de febrero", "Respuesta correcta: 17 de junio", "Descripción: El 17 de junio se celebra en Argentina el Día de la Muerte del General Güemes, en conmemoración a su fallecimiento en 1821.");
        AddQuestion("¿Qué caracteriza la Guerra Gaucha liderada por Güemes?", "Batallas convencionales", "Estrategias diplomáticas", "Tácticas de guerrilla", "Uso de armas de fuego modernas", "Respuesta correcta: Tácticas de guerrilla", "Descripción: La guerra gaucha liderada por Güemes se caracterizó por el uso de tácticas de guerrilla, donde los gauchos utilizaban su movilidad y conocimiento del terreno para resistir las invasiones realistas.");    
        AddQuestion("¿Cuál era la actividad principal de los gauchos liderados por Güemes?", "Agricultura", "Ganadería", "Minería", "Comercio", "Respuesta correcta: Ganadería", "Descripción: Los gauchos liderados por Güemes se dedicaban principalmente a la ganadería, criando y cuidando ganado en las vastas llanuras de la región.");
        AddQuestion("¿En qué región de Argentina tuvo lugar la 'Gesta Gaucha' liderada por Güemes?", "Pampa Húmeda", "Patagonia", "Noroeste", "Litoral", "Respuesta correcta: Noroeste", "Descripción: La 'Gesta Gaucha' liderada por Güemes tuvo lugar en la región del Noroeste argentino, especialmente en Salta y sus alrededores.");
        AddQuestion("¿Qué tipo de música era popular entre los gauchos durante la época de Güemes?", "Tango", "Cueca", "Samba", "Flamenco", "Respuesta correcta: Cueca", "Descripción: La cueca era una danza y música tradicional que gozaba de popularidad entre los gauchos durante la época de Güemes.");
        AddQuestion("¿Cuál era la importancia del Fuerte Güemes en la estrategia de resistencia liderada por Martín Miguel de Güemes?", "Centro cultural y educativo", "Punto estratégico de comercio", "Base militar y centro de operaciones", "Refugio para artistas y poetas", "Respuesta correcta: Base militar y centro de operaciones", "Descripción: El Fuerte Güemes cumplió un papel crucial como base militar y centro de operaciones desde donde Güemes organizaba la resistencia gaucha, coordinaba estrategias y planificaba acciones contra las fuerzas realistas.");
        AddQuestion("¿En qué año asumió Güemes como gobernador de Salta?", "1800", "1820", "1812", "1795", "Respuesta correcta: 1820", "Descripción: Martín Miguel de Güemes asumió como gobernador de Salta en el año 1820.");
        AddQuestion("¿Qué tipo de terreno caracteriza la región donde Güemes lideró la resistencia gaucha?", "Selva tropical", "Desierto", "Montañas", "Pampas", "Respuesta correcta: Montañas", "Descripción: La región del Noroeste argentino, donde Güemes lideró la resistencia, está caracterizada por montañas y terrenos accidentados.");
        AddQuestion("¿Cuál era el principal medio de transporte utilizado por los gauchos en la época de Güemes?", "Automóvil", "Tren", "Caballo", "Barco", "Respuesta correcta: Caballo", "Descripción: Los gauchos se desplazaban principalmente a caballo, siendo estos animales esenciales para su estilo de vida nómada.");
        AddQuestion("¿En qué batalla Güemes logró una importante victoria contra las fuerzas realistas?", "Batalla de Salta", "Batalla de Tucumán", "Batalla de Jujuy", "Batalla de Córdoba", "Respuesta correcta: Batalla de Jujuy", "Descripción: Güemes logró una importante victoria en la Batalla de Jujuy, resistiendo las invasiones realistas en el noroeste argentino.");
        AddQuestion("¿Cuál era el arma principal utilizada por los gauchos durante la guerra gaucha?", "Espada", "Mosquete", "Lanza", "Cañón", "Respuesta correcta: Lanza", "Descripción: La lanza era el arma característica de los gauchos, siendo hábiles jinetes y expertos en su uso.");
        AddQuestion("¿En qué año murió Martín Miguel de Güemes?", "1815", "1825", "1835", "1845", "Respuesta correcta: 1825", "Descripción: Martín Miguel de Güemes falleció el 17 de junio de 1825.");
        AddQuestion("¿Cuál era el color distintivo de la vestimenta de los gauchos liderados por Güemes?", "Rojo", "Azul", "Negro", "Verde", "Respuesta correcta: Rojo", "Descripción: La vestimenta tradicional de los gauchos incluía prendas de color rojo, que a menudo simbolizaban su valentía.");
        AddQuestion("¿Qué significa el término 'gauchada' en la cultura gaucha?", "Comida típica", "Baile tradicional", "Hazaña valiente", "Celebración religiosa", "Respuesta correcta: Hazaña valiente", "Descripción: 'Gauchada' se refiere a una acción valiente o hazaña típica de los gauchos.");
        AddQuestion("¿Cuál era el principal enemigo de Güemes durante la guerra gaucha?", "España", "Chile", "Brasil", "Bolivia", "Respuesta correcta: España", "Descripción: Güemes enfrentó a las fuerzas realistas enviadas por España durante la guerra gaucha.");
        AddQuestion("¿Qué celebración en Argentina conmemora la muerte de Güemes?", "Día de la Bandera", "Día de la Independencia", "Día del Trabajo", "Día de la Soberanía Nacional", "Respuesta correcta: Día de la Bandera", "Descripción: En Argentina, el 17 de junio se celebra el Día de la Bandera en conmemoración a la muerte de Güemes.");
        AddQuestion("¿Cuál era el rango militar de Güemes durante la Guerra de la Independencia?", "Capitán", "Coronel", "General", "Comandante", "Respuesta correcta: Coronel", "Descripción: Martín Miguel de Güemes alcanzó el rango de coronel en el Ejército del Norte.");
        AddQuestion("¿Cuál era el objetivo principal de Güemes en la guerra gaucha?", "Conquistar territorios", "Establecer un gobierno autónomo", "Defender la monarquía", "Expandir la esclavitud", "Respuesta correcta: Establecer un gobierno autónomo", "Descripción: Güemes luchó por la autonomía y la independencia de la región del Noroeste argentino.");
        AddQuestion("¿Qué tradición gaucha aún perdura en la actualidad en Argentina?", "El mate", "El tango", "La siesta", "La caña con ruda", "Respuesta correcta: El mate", "Descripción: El mate, una bebida tradicional, sigue siendo una parte importante de la cultura argentina, incluyendo la herencia gaucha.");
        AddQuestion("¿Cómo se llamaba el fuerte donde Güemes organizó la resistencia gaucha?", "Fuerte Apache", "Fuerte San Martín", "Fuerte Belgrano", "Fuerte Güemes", "Respuesta correcta: Fuerte Güemes", "Descripción: Güemes estableció el Fuerte Güemes como centro de operaciones para la resistencia gaucha.");
        AddQuestion("¿Qué significa la palabra 'gaucho' en la cultura argentina?", "Héroe nacional", "Hombre de campo", "Guerrero tribal", "Miembro del gobierno", "Respuesta correcta: Hombre de campo", "Descripción: La palabra 'gaucho' se refiere a un hombre de campo o vaquero en la cultura argentina.");
        AddQuestion("¿Cuál era el medio de comunicación más rápido utilizado por Güemes para coordinar con otros líderes?", "Teléfono", "Telégrafo", "Paloma mensajera", "Señales de humo", "Respuesta correcta: Paloma mensajera", "Descripción: En ausencia de tecnologías modernas, Güemes utilizó palomas mensajeras para comunicarse rápidamente con otros líderes durante la guerra gaucha.");
    }   

    public void CreateDB(){
        using(var connection = new SqliteConnection (dbName)){
            connection.Open();
            using(var command = connection.CreateCommand()){
                command.CommandText = "CREATE TABLE IF NOT EXISTS preguntas (question VARCHAR(100), option1 VARCHAR(50), option2 VARCHAR(50), option3 VARCHAR(50), option4 VARCHAR(50), answer VARCHAR(100), description VARCHAR(300));";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
        
    }

    public void AddQuestion(string q, string op1, string op2, string op3, string op4, string correctAnswer, string description){
        using(var connection = new SqliteConnection(dbName)){
            connection.Open();
            int existingCount = GetQuestionCountByQuestion(q);
            if(existingCount > 0){
                Debug.Log("La pregunta ya existe en la base de datos. No se insertará de nuevo.");
                connection.Close();
                return;
            }
            using(var command = connection.CreateCommand()){
                command.CommandText = "INSERT INTO preguntas (question, option1, option2, option3, option4, answer, description) VALUES (@question, @option1, @option2, @option3, @option4, @answer, @description);";
                command.Parameters.Add(new SqliteParameter("@question", q));
                command.Parameters.Add(new SqliteParameter("@option1", op1));
                command.Parameters.Add(new SqliteParameter("@option2", op2));
                command.Parameters.Add(new SqliteParameter("@option3", op3));
                command.Parameters.Add(new SqliteParameter("@option4", op4));
                command.Parameters.Add(new SqliteParameter("@answer", correctAnswer));
                command.Parameters.Add(new SqliteParameter("@description", description));
                command.ExecuteNonQuery();                
            }
            connection.Close();
        }
    }

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

    public int GetQuestionCountByQuestion(string questionText){
        int count = 0;
        using (var connection = new SqliteConnection(dbName)){
            connection.Open();
            using( var command = connection.CreateCommand()){
                command.CommandText = "SELECT COUNT(*) FROM preguntas WHERE question = @questionText;";
                command.Parameters.Add(new SqliteParameter("@questionText", questionText));
                count = Convert.ToInt32(command.ExecuteScalar());
            }
            connection.Close();
        }
        return count;
    }
}
