using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Math : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    void Axes() {
        Vector3 origin = Vector3.zero;
        Vector3 i = new Vector3(10, 0, 0);
        Debug.DrawLine(origin, i, Color.red);

        Vector3 j = new Vector3(0, 10, 0);
        Debug.DrawLine(origin, j, Color.green);

        Vector3 k = new Vector3(0, 0, 10);
        Debug.DrawLine(origin, k, Color.blue);
    }

    internal float Magnitude(Vector3 entrada) {
        return Mathf.Sqrt((entrada.x * entrada.x) + (entrada.y * entrada.y) + (entrada.z * entrada.z));
    }
    internal Vector3 Normalization(Vector3 entrada) {
        float largo = Magnitude(entrada);
        return new Vector3(entrada.x / largo, entrada.y / largo, entrada.z / largo);
    }
    internal Vector3 Magnitud(Vector3 entrada, float escalar)
    {
        return new Vector3(entrada.x * escalar, entrada.y * escalar, entrada.z * escalar);
    }
    internal float ProductoPunto(Vector3 a, Vector3 b)
    {
        return (a.x * b.x) + (a.y * b.y) + (a.z * b.z);
    }
    internal float Ángulo(Vector3 a, Vector3 b)
    {
        Vector3 an = Normalization(a);
        Vector3 bn = Normalization(b);
        float pp = ProductoPunto(an, bn);
        return Mathf.Acos(pp);
    }
    internal Vector3 Distancia(float[] a, float[] b)
    {
        float xt = a[0] - b[0];
        float yt = a[1] - b[1];
        float zt = a[2] - b[2];
        return new Vector3(xt, yt, zt);
    }
    // Vector paralelo
    internal Vector3 ProductoCruz(Vector3 a, Vector3 b)
    {
        float app = ((a.y * b.z) - (a.z * b.y));
        float bpp = ((a.z * b.x) - (a.x * b.z));
        float cpp = ((a.x * b.y) - (a.y * b.x));
        return new Vector3(app, bpp, cpp);
    }
    // Update is called once per frame
    void Update()
    {

    }

}
