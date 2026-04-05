using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    // SerializeField exposes this value to the Editor, but not to other Scripts!
    // It is "pseudo public"
    // HorizontalPlayerAcceleration indicates how fast we accelerate Horizontally
    [SerializeField]
    private float f_horPlayAccel = 5000f;
    private Rigidbody2D OURRigidbody;

    void Start()
    {
        // Get OurRigidbodyComponent once at the start of the game and store a reference to it
        // This means that we don't need to call GetComponent more than once! This makes our game faster. (GetComponent is SLOW)
        OURRigidbody = GetComponent<Rigidbody2D>();
    }
   
    // Update is called once per frame
    public void MovePlayer(float HorizontalInput)
    {
        Vector2 ForceToAdd = Vector2.right * HorizontalInput * f_horPlayAccel * Time.deltaTime;
        OURRigidbody.AddForce(ForceToAdd);
    }
}
