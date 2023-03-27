using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SlotSelector : MonoBehaviour
{
    private RectTransform navigator;

    PlayerInputManager inputManager = new PlayerInputManager();
    int navPos = 0;
    Vector2 movement = Vector2.zero;

    public RectTransform[] slots = new RectTransform[4];



    void OnMove(InputValue val)
    {
        movement = val.Get<Vector2>();
        if (movement.x > 0)
        {
            MoveNav(1);
        }
        if (movement.x < 0)
        {
            MoveNav(-1);
        }
    }

    void MoveNav(int change)
    {
        if (change > 0)
        {
            if (navPos + change < slots.Length - 1)
            {
                navPos += change;
            }
            else
            {
                navPos = slots.Length - 1;
            }
        }
        else
        {
            if (navPos + change >= 0)
            {
                navPos += change;
            }
            else
            {
                navPos = 0;
            }
        }
        navigator.position = slots[navPos].position;
    }
}