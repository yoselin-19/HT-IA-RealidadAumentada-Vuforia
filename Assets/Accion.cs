using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Accion : MonoBehaviour
{
    public GameObject esfera;
    public GameObject boton;
    private bool bandera = false;
    int contador = 0;
    int contador2 = 4;
    public TextMesh texto;

    public void OnButtonPressed(VirtualButtonBehaviour vb){
        bandera = !bandera;
        texto.text = "R " + bandera;
        Debug.Log("presionado " + bandera);
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb){
        Debug.Log("Deje de presionar");
    }

    // Start is called before the first frame update
    void Start()
    {
        boton = GameObject.Find("VirtualButton");
        boton.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        boton.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);
        bandera = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(bandera){
            if(contador <= 4){
                esfera.transform.Translate(Vector3.right * Time.deltaTime);
                contador++;
            } else {
                if(contador2 >= 0){
                    esfera.transform.Translate(Vector3.left * Time.deltaTime);
                    contador2--;
                } else {
                    contador = 0;
                    contador2 = 4;
                }
            }
        }
    }

}
