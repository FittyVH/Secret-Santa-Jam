using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class SpaceShipCamera : MonoBehaviour
{
    [SerializeField] Transform spaceShip;
    EnterAtmosphere enterAtmosphere;

    bool isZoomed = false;

    void Start()
    {
        enterAtmosphere = spaceShip.GetComponent<EnterAtmosphere>();
    }

    void Update()
    {
        if (spaceShip != null)
        {
            if (enterAtmosphere.insdiePlanet)
            {
                transform.position = new Vector3(spaceShip.position.x, spaceShip.position.y, transform.position.z);
                transform.rotation = spaceShip.rotation;
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    isZoomed = !isZoomed;
                }

                if (isZoomed)
                {
                    GetComponent<Camera>().orthographicSize = 14f;
                }
                else
                {
                    GetComponent<Camera>().orthographicSize = 26.25f;
                }
            }
            else if (!enterAtmosphere.insdiePlanet)
            {
                GetComponent<Camera>().orthographicSize = 26.25f;
                transform.position = new Vector3(spaceShip.position.x, spaceShip.position.y, transform.position.z);
                transform.rotation = Quaternion.identity;
            }
        }
    }
}
