using UnityEngine;
//аниматор контролер 
namespace Move
{
    public class AnimationController : MonoBehaviour
    {
        private Animator _animator;
        private Move _moveScript;

        private void Start()
        {
            
            _animator = GetComponent<Animator>();
            _moveScript = GetComponent<Move>();

            
        
        }

        private void Update()
        {
            if (_animator != null && _moveScript != null)
            {
               
                float currentSpeed = Mathf.Abs(_moveScript.Speed);

                
                _animator.SetFloat("speed", currentSpeed);
            }
        }
    }
}


