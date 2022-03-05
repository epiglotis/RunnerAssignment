using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private GameObject tapToStartEventTrigger;
    [SerializeField] private float dragSensitivity = 100f;

    [Header("Events")]
    [SerializeField] private VoidEvent onPointerDown;
    [SerializeField] private VoidEvent onPointerUp;
    [SerializeField] private Vector2Event onPointerDrag;
    [SerializeField] private VoidEvent onScreenCaptured;
    [Header("Variables")]
    [SerializeField] private BoolVariable isGameStarted;

    private void Awake() 
    {
        isGameStarted.SetValue(false);
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Print)) onScreenCaptured.Raise();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(tapToStartEventTrigger.activeInHierarchy)
        {
            tapToStartEventTrigger.GetComponent<EventTrigger>().OnPointerDown(eventData);
        }
        
        onPointerDown.Raise();
    }

    public void OnDrag(PointerEventData eventData)
    {
        onPointerDrag.Raise(eventData.delta / dragSensitivity);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        onPointerUp.Raise();
    }
}
