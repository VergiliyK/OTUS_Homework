using Assets.Scripts;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(IMoving))]
public class ChatacterMovingAnimatorController : MonoBehaviour
{
    private Animator _animator;
    private IMoving _movingComponent;
    
    private static readonly int _movinParameter = Animator.StringToHash("isMoving");

    private void Awake()
    {
        this._animator = this.GetComponent<Animator>();
        this._movingComponent = this.GetComponent<IMoving>();
    }

    private void Update()
    {
        _animator.SetBool(_movinParameter, this._movingComponent.Moving);
    }
}
