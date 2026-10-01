using UnityEngine;
using UnityEngine.InputSystem;

public class RhythmInputTester : MonoBehaviour
{
    [Header("Indicadores Visuales")]
    public GameObject leftTarget;
    public GameObject rightTarget;

    [Header("Configuración de Escala")]
    public float pressedScale = 1.5f;
    public float normalScale = 1.0f;
    public float transitionSpeed = 15f;

    void Update()
    {
        bool isLeftHeld = IsLeftHeld();
        bool isRightHeld = IsRightHeld();

        if (IsLeftPressedThisFrame())
        {
            Debug.Log("<color=green>[INPUT] Guante IZQUIERDO</color>");
        }

        if (IsRightPressedThisFrame())
        {
            Debug.Log("<color=green>[INPUT] Guante DERECHO</color>");
        }

        UpdateTargetScale(leftTarget, isLeftHeld);
        UpdateTargetScale(rightTarget, isRightHeld);
    }

    private bool IsLeftHeld()
    {
        bool keyboard = Keyboard.current != null &&
            (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed);

        bool gamepad = Gamepad.current != null &&
            (Gamepad.current.buttonWest.isPressed || Gamepad.current.leftShoulder.isPressed);

        return keyboard || gamepad;
    }

    private bool IsRightHeld()
    {
        bool keyboard = Keyboard.current != null &&
            (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed);

        bool gamepad = Gamepad.current != null &&
            (Gamepad.current.buttonEast.isPressed || Gamepad.current.rightShoulder.isPressed);

        return keyboard || gamepad;
    }

    private bool IsLeftPressedThisFrame()
    {
        bool keyboard = Keyboard.current != null &&
            (Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.leftArrowKey.wasPressedThisFrame);

        bool gamepad = Gamepad.current != null &&
            (Gamepad.current.buttonWest.wasPressedThisFrame || Gamepad.current.leftShoulder.wasPressedThisFrame);

        return keyboard || gamepad;
    }

    private bool IsRightPressedThisFrame()
    {
        bool keyboard = Keyboard.current != null &&
            (Keyboard.current.dKey.wasPressedThisFrame || Keyboard.current.rightArrowKey.wasPressedThisFrame);

        bool gamepad = Gamepad.current != null &&
            (Gamepad.current.buttonEast.wasPressedThisFrame || Gamepad.current.rightShoulder.wasPressedThisFrame);

        return keyboard || gamepad;
    }

    private void UpdateTargetScale(GameObject target, bool isPressed)
    {
        if (target == null) return;

        float targetSize = isPressed ? pressedScale : normalScale;
        Vector3 desiredScale = Vector3.one * targetSize;

        target.transform.localScale = Vector3.Lerp(
            target.transform.localScale,
            desiredScale,
            Time.deltaTime * transitionSpeed
        );
    }
}

