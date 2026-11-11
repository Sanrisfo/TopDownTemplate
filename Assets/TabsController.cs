using UnityEngine;
using UnityEngine.UI;

public class TabsController : MonoBehaviour
{
    public Image[] tabUi;
    public GameObject[] pageUi;
    void Start()
    {
        ActivateTab(0);
    }

    public void ActivateTab(int numeroTab)
    {
        for (int i = 0; i < tabUi.Length; i++)
        {
            //pintamos todas las tabs de la lista de gris
            //desactivamos todas las paginas
            tabUi[i].color = Color.gray;
            pageUi[i].SetActive(false);
        }
        //pintamos la tab seleccionada de blanco
        //activamos la pagina asignada a la tab seleccionada
        tabUi[numeroTab].color = Color.white;
        pageUi[numeroTab].SetActive(true);
    }
}
