using UnityEngine;

public class TitilarGUINODER: MonoBehaviour
{
    public float blinkInterval = 0.5f;
    public bool isEnabled = false; // Default to off
    private MeshRenderer beaconRenderer;
    private float timer;
    public Controller controller;
    public TitilarGUINOIZQ TITILARGUINOIZQ;
    public TitilarBALIZA TITILARBALIZA;

    private void Start()
    {
        beaconRenderer = GetComponent<MeshRenderer>();
        timer = 0f;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow) && !TITILARGUINOIZQ.isEnabled && !TITILARBALIZA.isEnabled)
        {
            if (isEnabled == true)
            {

                isEnabled = false;

            }
            else
            {
                isEnabled = true;
            }
            Debug.Log("arriba");
        }
        if (isEnabled) // Check if hazard lights are active
        {
            timer += Time.deltaTime;
            if (timer >= blinkInterval)
            {
                beaconRenderer.enabled = !beaconRenderer.enabled;
                timer = 0f;
            }
        }
        else
        {
            beaconRenderer.enabled = false;
        }
    }
}
