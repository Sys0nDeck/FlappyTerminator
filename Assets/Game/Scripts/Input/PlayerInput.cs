using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Gun _gun;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _mover.Jump();

        if (Input.GetKeyDown(KeyCode.F))
            _gun.Shoot();
    }
}
