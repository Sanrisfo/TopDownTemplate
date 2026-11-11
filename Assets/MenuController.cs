using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menu;
    
    void Start()
    {
        //Al iniciar el juego, el menu está desactivado
        menu.SetActive(false);
    }

    void Update()
    {
        //Al presionar la tecla Tab el menu cambia al estado contario al que tiene (activo o desactivo)
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            menu.SetActive(!menu.activeSelf);
        }
    }
}
