using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class MapTransation : MonoBehaviour
{
    [SerializeField] PolygonCollider2D mapBoundry;
    [SerializeField] private float incrementoPos = 2;
    [SerializeField] Direction direction;
    CinemachineConfiner2D confiner;
    enum Direction {Up,Down,Left,Right }

    private void Awake()
    {
        confiner = FindAnyObjectByType<CinemachineConfiner2D>();
    }

    // Se activa cuando otro objeto entra en el colisionador (trigger) de este GameObject.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            confiner.BoundingShape2D = mapBoundry;
            ActualizarPosicionJugador(collision.gameObject);
        }
    }

    private void ActualizarPosicionJugador(GameObject player)
    {
        Vector2 nuevaPos = player.transform.position;
        switch (direction)
        {
            case Direction.Up:
                nuevaPos.y += incrementoPos;
                break;
            case Direction.Down:
                nuevaPos.y -= incrementoPos;
                break;
            case Direction.Left:
                nuevaPos.x -= incrementoPos;
                break;
            case Direction.Right:
                nuevaPos.x += incrementoPos;
                break;
        }
        player.transform.position = nuevaPos;
    }
}
