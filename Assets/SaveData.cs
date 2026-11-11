using UnityEngine;

//Esto nos permite que la clase sea serializable:
//(Se pueden convertir los datos a un formato que se puede guardar en un archivo)
[System.Serializable]
public class SaveData
{
    public Vector3 playerPosition;
    public string mapBoundary; //El nombre del mapa en donde estamos (la zona)
}
