using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ClientDestroy : MonoBehaviour
{
    [Inject]private ClientCounter _clientCounter;

    public void OffActive()
    {
        _clientCounter.RemoveClient();
        gameObject.SetActive(false);
    }
}
