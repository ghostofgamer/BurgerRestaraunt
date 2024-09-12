using UnityEngine;
using Zenject;

namespace CameraContent
{
    public class LookingCamera : MonoBehaviour
    {
        [Inject]private Camera _camera;
    
        private void Update()
        {
            transform.LookAt(_camera.transform.position);
        }
    }
}
