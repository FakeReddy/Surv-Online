using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public float Horizontal { get => Input.GetAxisRaw(GlobalStringsVars.HorizontalAxis); }
    public float Vertical { get => Input.GetAxisRaw(GlobalStringsVars.VerticalAxis); }
    public float MouseX { get => Input.GetAxisRaw(GlobalStringsVars.MouseX); }
    public float MouseY { get => Input.GetAxisRaw(GlobalStringsVars.MouseY); }
    public bool Escape { get => Input.GetKeyDown(KeyCode.Escape); }
    public bool Space { get => Input.GetKey(KeyCode.Space); }
    public bool Mouse0 { get => Input.GetKey(KeyCode.Mouse0); }
}