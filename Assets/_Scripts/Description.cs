using UnityEngine;
using UnityEngine.EventSystems;

public class Description : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject dropDown;
    public void OnPointerEnter(PointerEventData eventData)
    {
        dropDown.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        dropDown.SetActive(false);
    }

    void Start()
    {
        
    }
}
