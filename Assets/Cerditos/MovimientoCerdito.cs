using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCerdito : MonoBehaviour
{
    public Transform[] puntos;
    public float velocidad = 2f;
    public float tiempoQuietoMin = 3f;
    public float tiempoQuietoMax = 5f;
    public float radioPunto = 0.2f;

    public Animator animator;
    public string animacionAndar = "Andar";
    public string animacionQuieto = "Quieto";

    private Transform puntoActual;
    private bool enMovimiento;
    private float tiempoQuieto;

    private void Start()
    {
        ElegirSiguientePunto();
        enMovimiento = true;
        animator.SetBool(animacionAndar, true);
    }

    private void Update()
    {
        if (enMovimiento)
        {
            // Orienta el objeto hacia el punto actual
            Vector3 direccion = puntoActual.position - transform.position;
            Quaternion rotacion = Quaternion.LookRotation(direccion);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotacion, velocidad * Time.deltaTime);

            // Mueve el objeto hacia el punto actual
            transform.position = Vector3.MoveTowards(transform.position, puntoActual.position, velocidad * Time.deltaTime);

            // Comprueba si ha llegado al punto actual
            if (transform.position == puntoActual.position)
            {
                enMovimiento = false;
                animator.SetBool(animacionAndar, false);
                animator.SetBool(animacionQuieto, true);
                tiempoQuieto = Random.Range(tiempoQuietoMin, tiempoQuietoMax);
                Invoke("ElegirSiguientePunto", tiempoQuieto);
            }
        }
    }

    private void ElegirSiguientePunto()
    {
        int indicePunto = Random.Range(0, puntos.Length);
        puntoActual = puntos[indicePunto];
        enMovimiento = true;
        animator.SetBool(animacionAndar, true);
        animator.SetBool(animacionQuieto, false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        foreach (var punto in puntos)
        {
            Gizmos.DrawSphere(punto.position, radioPunto);
        }
    }
}
