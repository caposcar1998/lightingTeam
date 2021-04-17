using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Illumination
 *  Gerardo Arturo Miranda A01338074
 */
public class Pixel : MonoBehaviour
{
    /* Declaración de gameobject para arrastrar.
    *   En este caso:
    *          a1 = camara
    *          a2 = fuente de luz
    *          a3 = pixel de interés
    */
    public GameObject a1;
    public GameObject a2;
    public GameObject a3;
    // Declaración del diccionario donde se insertarán los valores
    Dictionary<string, float> valoresArturo;
    // Declaración del diccionario donde se insertarán los vectores
    Dictionary<string, Vector3> vectoresArturo;
    // Declaración del diccionario donde se insertarán los valores
    Dictionary<string, float> valoresÓscar;
    // Declaración del diccionario donde se insertarán los vectores
    Dictionary<string, Vector3> vectoresÓscar;
    // Declaración del diccionario donde se insertarán los valores
    Dictionary<string, float> valoresManu;
    // Declaración del diccionario donde se insertarán los vectores
    Dictionary<string, Vector3> vectoresManu;
    // Declaración del diccionario donde se insertarán los valores
    Dictionary<string, float> valoresMoni;
    // Declaración del diccionario donde se insertarán los vectores
    Dictionary<string, Vector3> vectoresMoni;
    // Declaración de la clase Math, en esta se harán los cálculos de vectores
    Math matemáticasVectores = new Math();
    // A L P H A    M A T E R I A L
    void Start()
    {
        valoresArturo = new Dictionary<string, float>
        {
            {"kar", 0.26745f},
            {"kag", 0.24242f},
            {"kab", 0.10780f},
            {"kdr", 0.80546f},
            {"kdg", 0.15167f},
            {"kdb", 0.12917f},
            {"ksr", 0.27178f},
            {"ksg", 0.10497f},
            {"ksb", 0.42052f},
            {"iar", 0.82206f},
            {"iag", 0.89428f},
            {"iab", 0.99763f},
            {"idr", 0.85311f},
            {"idg", 0.89643f},
            {"idb", 0.80652f},
            {"isr", 0.87775f},
            {"isg", 0.80048f},
            {"isb", 0.86281f},
            {"alpha", 88.0f},
            {"i",130.0f * Mathf.Deg2Rad},
            {"a",105.0f * Mathf.Deg2Rad},
            { "radio", 0.98261f }

        };
        vectoresArturo = new Dictionary<string, Vector3>
        {
            {"posiciónCámara", new Vector3( 3.70597f,-3.47684f,-4.01459f)},
            {"posiciónFuenteDeLuz", new Vector3( 5.11790f,-4.23381f, 2.43237f)},
        };

        GameObject camara = a1;
        GameObject luz = a2;
        GameObject pixelGO = a3;
    }  
    void Update()
    {
        // Arturo
        calculosIlu();
        // Óscar
        // Manu
        // Moni
    }

    void calculosIlu(Dictionary<string, Vector3> vectores, Dictionary<string, float> valores, GameObject[] gameObjects) {

        Vector3 pixelDeInterés;
        Vector3 vectorLuz;
        Vector3 vectorLuzReflejo;
        Vector3 vectorNormal;
        Vector3 vectorLuzNormalizado;
        Vector3 vectorVisiónNormalizado;
        Vector3 vectorNormalNormalizado;
        Vector3 vectorLuzReflejoNormalizado;
        Vector3 vectorVisión;

        valores.Add("seni", Mathf.Sin(valores["i"]));
        valores.Add("sena", Mathf.Sin(valores["a"]));
        valores.Add("cosa", Mathf.Cos(valores["a"]));
        valores.Add("cosi", Mathf.Cos(valores["i"]));
        valores.Add("radioReal", valores["radio"] * 2);

        Vector3 puntoA = new Vector3(1.21125f, -0.93532f, -0.68137f);
        Vector3 ratioDeTraslado = new Vector3(0.68083f, -0.44254f, -0.08132f);
        Matrix4x4 mT = Matriz.TranslateM(ratioDeTraslado.x, ratioDeTraslado.y, ratioDeTraslado.z);
        Vector4 aPrima = puntoA;
        aPrima.w = 1;
        aPrima = mT * aPrima;

        Matrix4x4 mR = Matriz.RotateM(-8.5f, Matriz.AXIS.AX_X);
        Matrix4x4 mP = Matriz.TranslateM(0.08668f, -0.61589f, -0.70765f);
        Matrix4x4 mP_1 = Matriz.TranslateM(-0.08668f, 0.61589f, 0.70765f);

        Debug.Log("Valor de aPrima: " + aPrima.x + ", " + aPrima.y + ", " + aPrima.z + ", ");

        Vector4 sphereCenter = mP * mR * mP_1 * aPrima;
        Vector3 centroEsfera = new Vector3(sphereCenter.x, sphereCenter.y, sphereCenter.z);
        this.vectores.Add("centroEsfera", centroEsfera);
        Debug.Log("Valor del centro de Esfera: " + centroEsfera);

        pixelDeInterés = new Vector3(
            this.vectores["centroEsfera"].x + (valores["radio"] * valores["seni"] * valores["sena"]),
            this.vectores["centroEsfera"].y + (valores["radio"] * valores["cosi"]),
            this.vectores["centroEsfera"].z + (valores["radio"] * valores["seni"] * valores["cosa"])
         );
        this.vectores.Add("pixelDeInterés", pixelDeInterés);

        // Rellenamos vectorLuz, vectorVisión, vectorNormal, vectorLuzReflejo
        vectorNormal = new Vector3(
            this.vectores["pixelDeInterés"].x + this.vectores["centroEsfera"].x,
            this.vectores["pixelDeInterés"].y + this.vectores["centroEsfera"].y,
            this.vectores["pixelDeInterés"].z + this.vectores["centroEsfera"].z
         );
        this.vectores.Add("vectorNormal", vectorNormal);

        vectorLuz = this.vectores["posiciónFuenteDeLuz"] - pixelDeInterés;
        vectores.Add("vectorLuz", vectorLuz);

        vectorVisión = this.vectores["posiciónCámara"] - pixelDeInterés;
        vectores.Add("vectorVisión", vectorVisión);

        Debug.Log("Pixel de interés: [Representado en Escena una esfera pequeña] " + "( " + pixelDeInterés[0] + ", " + pixelDeInterés[1] + ", " + pixelDeInterés[2] + ")");
        Debug.Log("Vector Normal: [Representado en Escena como vector de Color CYAN]" + vectorNormal);
        Debug.Log("Vector Luz: [Representado en Escena como vector de Color AMARILLO]" + vectorLuz);
        Debug.Log("Vector Visión: [Representado en Escena como vector de Color BLANCO] " + vectorVisión);

        vectorNormalNormalizado = matemáticasVectores.Normalization(vectorNormal);
        this.vectores.Add("vectorNormalNormalizado", vectorNormalNormalizado);
        Debug.Log("Normal normalizado: " + vectorNormalNormalizado);
        vectorLuzNormalizado = matemáticasVectores.Normalization(vectorLuz);
        vectores.Add("vectorLuzNormalizado", vectorLuzNormalizado);

        vectorVisiónNormalizado = matemáticasVectores.Normalization(vectorVisión);
        vectores.Add("vectorVisiónNormalizado", vectorVisiónNormalizado);

        float productoPuntoNU = matemáticasVectores.ProductoPunto(vectorNormalNormalizado, vectorLuz);
        Vector3 vectorParalelo = matemáticasVectores.Magnitud(vectorNormalNormalizado, productoPuntoNU);
        Vector3 vectorOrtogonal = vectorLuz - vectorParalelo;
        vectorLuzReflejo = vectorParalelo - vectorOrtogonal;
        vectorLuzReflejoNormalizado = matemáticasVectores.Normalization(vectorLuzReflejo);

        gameObjects[0].transform.position = new Vector3(vectores["posiciónCámara"].x, vectores["posiciónCámara"].y, vectores["posiciónCámara"].z);
        gameObjects[1].transform.position = new Vector3(vectores["posiciónFuenteDeLuz"].x, vectores["posiciónFuenteDeLuz"].y, vectores["posiciónFuenteDeLuz"].z);
        gameObjects[2].transform.position = pixelDeInterés;
        gameObjects[3].transform.position = new Vector3(
            vectores["centroEsfera"].x,
            vectores["centroEsfera"].y,
            vectores["centroEsfera"].z
        );

        gameObjects[3].transform.localScale = new Vector3(
            valores["radio"],
            valores["radio"],
            valores["radio"]
         );

        Debug.Log("Vector Normal (NORMALIZED): " + vectorNormalNormalizado);
        Debug.Log("Vector Luz (NORMALIZED): " + vectorLuzNormalizado);
        Debug.Log("Vector Visión (NORMALIZED): " + vectorVisiónNormalizado);
        Debug.Log("Vector Reflejo [Representado en Escena como vector de Color VERDE]: " + vectorLuzReflejoNormalizado);


        // Calculamos Conjunto A D S de Rojo
        float ARojo = ((valores["kar"] * valores["iar"]));
        float DRojo = (valores["kdr"] * valores["idr"] * (matemáticasVectores.ProductoPunto(vectorNormalNormalizado, vectorLuzNormalizado)));
        float SRojo = (valores["ksr"] * valores["isr"] * 0.3028909917f);

        valores.Add("ARojo", ARojo);
        valores.Add("DRojo", DRojo);
        valores.Add("SRojo", SRojo);

        float totalRojo = (ARojo + DRojo + SRojo);
        Debug.Log("IR: " + totalRojo);
        // Calculamos Conjunto A D S de Verde
        float AVerde = ((valores["kag"] * valores["iag"]));
        float DVerde = ((valores["kdg"] * valores["idg"] * (matemáticasVectores.ProductoPunto(vectorNormalNormalizado, vectorLuzNormalizado))));

        float SVerde = (valores["ksg"] * valores["isg"] * 0.3028909917f);

        valores.Add("AVerde", AVerde);
        valores.Add("DVerde", DVerde);
        valores.Add("SVerde", SVerde);

        float totalVerde = (AVerde + DVerde + SVerde);
        Debug.Log("IG: " + totalVerde);

        // Calculamos Conjunto A D S de Azul
        float AAzul = ((valores["kab"] * valores["iab"]));
        float DAzul = (valores["kdb"] * valores["idb"] * (matemáticasVectores.ProductoPunto(vectorNormalNormalizado, vectorLuzNormalizado)));
        float SAzul = (valores["ksb"] * valores["isb"] * 0.3028909917f);

        valores.Add("AAzul", AAzul);
        valores.Add("DAzul", DAzul);
        valores.Add("SAzul", SAzul);

        float totalAzul = (AAzul + DAzul + SAzul);
        Debug.Log("IBl: " + totalAzul);


        Debug.DrawLine(pixelDeInterés, vectores["posiciónCámara"], Color.white);
        Debug.DrawLine(pixelDeInterés, vectores["posiciónFuenteDeLuz"], Color.yellow);
        Debug.DrawLine(pixelDeInterés, vectorNormal, Color.cyan);
        Debug.DrawLine(pixelDeInterés, vectorLuzReflejo, Color.green);
        Debug.DrawLine(pixelDeInterés, vectorLuz, Color.magenta);

    }
}
