using UnityEngine;

public class Client : MonoBehaviour
{
    [SerializeField] private Food _food;
    [SerializeField] private ClientMover _clientMover;

    public void ShowFood()
    {
        _food.gameObject.SetActive(true);
        _clientMover.GoExit();
    }

    public void OffFood()
    {
        _food.gameObject.SetActive(false);
    }
}