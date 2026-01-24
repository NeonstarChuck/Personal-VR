using UnityEngine;
// using UnityEngine.InputSystem;

public abstract class InteractivePuzzlePieceXR<TComponent> : BaseInteractivePuzzlePieceXR
where TComponent : Component
{
    public TComponent physicsComponent;
}


public abstract class BaseInteractivePuzzlePieceXR : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.Space;
    // public InputActionReference interactActionReference;

    public Rigidbody rb;
    public AudioClip activateSound;
    public AudioClip deactivateSound;
    public AudioSource puzzleAudioSource;

    bool m_IsControlable;

    protected void FixedUpdate ()
    {
        if (Input.GetKey(interactKey) && m_IsControlable)
        // if(interactActionReference.action.IsPressed() && m_IsControlable)
        {
            ApplyActiveState ();
        }
        else
        {
            ApplyInactiveState ();
        }
    }
    
    void Update()
    {
        if (deactivateSound != null && Input.GetKeyUp(interactKey))
        // if(deactivateSound != null && interactActionReference.action.WasReleasedThisFrame())
        {
            puzzleAudioSource.pitch = Random.Range(0.8f, 1.2f);
            puzzleAudioSource.PlayOneShot(deactivateSound);
        }
        if (activateSound != null && Input.GetKeyDown(interactKey))
        // if (activateSound != null && interactActionReference.action.WasPressedThisFrame())
        {
            puzzleAudioSource.pitch = Random.Range(0.8f, 1.2f);
            puzzleAudioSource.PlayOneShot(activateSound);
        }
    }

    protected abstract void ApplyActiveState ();

    protected abstract void ApplyInactiveState ();

    public void EnableControl ()
    {
        m_IsControlable = true;
    }
}