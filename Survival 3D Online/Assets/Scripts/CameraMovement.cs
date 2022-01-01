using UnityEngine;

public class CameraMovement : PlayerInputs
{
    public bool IsControl { get; set; } = true;

    [SerializeField] private float _sensetivity;
    [SerializeField] private float _angleXRotation;
    [SerializeField] private Transform _player;

    private float _xRotation;

    private void Update()
    {
        float mouseX = MouseX;
        float mouseY = MouseY;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -_angleXRotation, _angleXRotation);

        if (IsControl == true)
        {
            transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
            _player.Rotate(0, mouseX, 0);
        }
    }
}