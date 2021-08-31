using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections;
  
public class Reel : MonoBehaviour
{
    public Graphic UI_Element;

    RectTransform rectT;
    public Vector2 centerPoint;
  
    public float max = 200f;
    public float wheelSpeed = 200f;
  
    public float wheelAngle = 0f;
    public float wheelPrevAngle = 0f;
  
    bool wheelBegin = false;
  
    void Start()
    {
        rectT = UI_Element.rectTransform;
        InitEventsSystem();
    }
  
    void Update()
    {
        if( !wheelBegin && !Mathf.Approximately( 0f, wheelAngle ) )
        {
            float deltaAngle = wheelSpeed * Time.deltaTime;
            if( Mathf.Abs( deltaAngle ) > Mathf.Abs( wheelAngle ) )
                wheelAngle = 0f;
            else if( wheelAngle > 0f )
                wheelAngle -= deltaAngle;
            else
                wheelAngle += deltaAngle;
        }
  
        rectT.localEulerAngles = Vector3.back * wheelAngle;
         
        //Debug.Log("Steering Value: " + GetClampedValue());
    }
  
    void InitEventsSystem()
    {
        EventTrigger events = UI_Element.gameObject.GetComponent<EventTrigger>();
  
        if( events == null )
            events = UI_Element.gameObject.AddComponent<EventTrigger>();
  
        if( events.triggers == null )
            events.triggers = new System.Collections.Generic.List<EventTrigger.Entry>();
  
        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.TriggerEvent callback = new EventTrigger.TriggerEvent();
        UnityAction<BaseEventData> functionCall = new UnityAction<BaseEventData>( PressEvent );
        callback.AddListener( functionCall );
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback = callback;
  
        events.triggers.Add( entry );
  
        entry = new EventTrigger.Entry();
        callback = new EventTrigger.TriggerEvent();
        functionCall = new UnityAction<BaseEventData>( DragEvent );
        callback.AddListener( functionCall );
        entry.eventID = EventTriggerType.Drag;
        entry.callback = callback;
  
        events.triggers.Add( entry );
  
        entry = new EventTrigger.Entry();
        callback = new EventTrigger.TriggerEvent();
        functionCall = new UnityAction<BaseEventData>( ReleaseEvent );//
        callback.AddListener( functionCall );
        entry.eventID = EventTriggerType.PointerUp;
        entry.callback = callback;
  
        events.triggers.Add( entry );
    }
  
    public void PressEvent( BaseEventData eventData )
    {

        Vector2 pointerPos = ( (PointerEventData) eventData ).position;
  
        wheelBegin = true;
        centerPoint = RectTransformUtility.WorldToScreenPoint( ( (PointerEventData) eventData ).pressEventCamera, rectT.position );
        wheelPrevAngle = Vector2.Angle( Vector2.up, pointerPos - centerPoint );
    }
  
    public void DragEvent( BaseEventData eventData )
    {

        Vector2 pointerPos = ( (PointerEventData) eventData ).position;
  
        float wheelNewAngle = Vector2.Angle( Vector2.up, pointerPos - centerPoint );

        if( Vector2.Distance( pointerPos, centerPoint ) > 20f )
        {
            if( pointerPos.x > centerPoint.x )
                wheelAngle += wheelNewAngle - wheelPrevAngle;
            else
                wheelAngle -= wheelNewAngle - wheelPrevAngle;
        }

        wheelAngle = Mathf.Clamp( wheelAngle, -max, max );
        wheelPrevAngle = wheelNewAngle;
    }
  
    public void ReleaseEvent( BaseEventData eventData )
    {
        DragEvent( eventData );
  
        wheelBegin = false;
    }
    public float GetClampedValue()
    {
        return wheelAngle / max;
    }

    public float GetAngle()
    {
        return wheelAngle;
    }
}
