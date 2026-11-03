using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    [Header("Player Input Values")]
    public bool shoot;

    public void OnShoot(InputValue value)
    {
        ShootInput(value.isPressed);
    }

    public void ShootInput(bool newShootState)
    {
        shoot = newShootState;
    }
}