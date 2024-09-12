using UnityEngine;

public class ClientCounter : MonoBehaviour
{
    [SerializeField] private int _maxAmountClients = 3;

    private int _currentClients = 0;
    public int MaxAmountClients => _maxAmountClients;
    
    public bool IsClientsLimit =>_currentClients >= _maxAmountClients;

    public void AddClient()
    {
        _currentClients++;
    }

    public void RemoveClient()
    {
        if (_currentClients <= 0)
            return;

        _currentClients--;
    }
}