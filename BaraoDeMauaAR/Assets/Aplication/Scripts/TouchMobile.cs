using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMobile : MonoBehaviour
{

     void Start()
    {
       
    }
    void Update()
    {
        Debug.Log("Metodo Update");
    }

    private void MoveObjects()
    {
        //MOver os objetos com um toque
        //Vefifica toque na tela
        if (Input.touchCount > 0)
        {
            Debug.Log("Tocou na tela");
            //Armazena em uma variavel os toques
            TouchMobile primaryTouch = Input.TouchMobile(0);
            //Verificar toque de touce
            //verifica se existe o movimento do dedo
            if (primaryTouch.phase == TouchPhase.Moved)
            {
                Vector2 directionRotation = new Vector2(primaryTouch.deltaPosition.y, primaryTouch.deltaPosition.x *1);

                transform.Rotate(directionRotation * 5 * Time.deltaTime, Space.World);
            }
        }
    }

}
