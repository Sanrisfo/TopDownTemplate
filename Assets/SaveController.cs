using System.IO;
using Unity.Cinemachine;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    private string saveLocation;
    void Start()
    {
        //Definimos el path donde se guardará el archivo .json
        saveLocation = Path.Combine(Application.persistentDataPath, "saveData.json");
        LoadGame();
    }

    public void SaveGame()
    {
        //Los atributos de la clase los asignamos a lo que queremos guardar
        SaveData saveDatos = new SaveData
        {
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position,
            mapBoundary = FindFirstObjectByType<CinemachineConfiner2D>().BoundingShape2D.gameObject.name,
        };

        //Ahora escbrimimos los datos en un archivo json
        File.WriteAllText(saveLocation, JsonUtility.ToJson(saveDatos));
    }

    public void LoadGame()
    {
        if (File.Exists(saveLocation))
        {
            //La clase SaveData le asignamos los valores que hay en saveLocation a la variable saveDatos
            SaveData saveDatos = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveLocation));

            //Asignamos la posicíón del objeto con el tag player a el atributo dentro de saveDatos llamado player Position
            GameObject.FindGameObjectWithTag("Player").transform.position = saveDatos.playerPosition;

            //Lo mismo, pero ahora asignamos el nombre del mapBoundry a la casilla del cinemachine
            FindFirstObjectByType<CinemachineConfiner2D>().BoundingShape2D = GameObject.Find(saveDatos.mapBoundary).GetComponent<PolygonCollider2D>();
        }
        else
        {
            SaveGame();
        }
    }
}
