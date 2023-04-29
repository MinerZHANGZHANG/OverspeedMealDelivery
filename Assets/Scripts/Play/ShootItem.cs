using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootItem : MonoBehaviour
{
    public List<GameObject> ItemList = new();
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShootRandomItem();
        }
    }

    void ShootRandomItem()
    {
        Vector2 mousePos= Input.mousePosition;
        Ray ray=Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            var bullet=  Instantiate(ItemList[Random.Range(0, ItemList.Count)]);
            bullet.transform.position = transform.position;
            bullet.transform.LookAt(hit.point);
        }
    }
}
