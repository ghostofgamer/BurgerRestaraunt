using UnityEngine;

namespace CharacterContent.PlayerContent
{
    public class PlayerParameters : MonoBehaviour
    {
        [SerializeField]private float _speedMove = 3;
        [SerializeField]private float _speedRotation = 6;
        [SerializeField] private float _factorIncreaseSpeed;
        
        public float SpeedMove => _speedMove;
        public float SpeedRotation => _speedRotation;

        public void UpgradeParameters()
        {
            _speedMove *= _factorIncreaseSpeed;
        }
    }
}
