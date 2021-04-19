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
    public GameObject camaraArturo;
    public GameObject fuenteLuzArturo;
    public GameObject pixelInterésArturo;
    public GameObject esferaArturo;
    // Declaración del diccionario donde se insertarán los valores
    Dictionary<string, float> valoresArturo;
    // Declaración del diccionario donde se insertarán los vectores
    Dictionary<string, Vector3> vectoresArturo;


    // Declaración del diccionario donde se insertarán los valores
    Dictionary<string, float> valoresÓscar;
    // Declaración del diccionario donde se insertarán los vectores
    Dictionary<string, Vector3> vectoresÓscar;

    GameObject[] gameObjectsArturo;

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
            {"kar", 0.23448f},
            {"kag", 0.25065f},
            {"kab", 0.26652f},
            {"kdr", 0.19057f},
            {"kdg", 0.89685f},
            {"kdb", 0.05534f},
            {"ksr", 0.13970f},
            {"ksg", 0.20013f},
            {"ksb", 0.29298f},
            {"iar", 0.89028f},
            {"iag", 0.82704f},
            {"iab", 0.94053f},
            {"idr", 0.98687f},
            {"idg", 0.83322f},
            {"idb", 0.86470f},
            {"isr", 0.98115f},
            {"isg", 0.98242f},
            {"isb", 0.90059f},
            {"i",41.0f * Mathf.Deg2Rad},
            {"a",256.0f * Mathf.Deg2Rad},
            {"seni", Mathf.Sin(41.0f)},
            {"sena", Mathf.Sin(256.0f)},
            {"cosa", Mathf.Cos(256.0f)},
            {"cosi", Mathf.Sin(41.0f)},
            {"radioReal", 0.50331f * 2 },
            {"radio", 0.50331f },
            {"anguloRotación", -5.3f },
            { "alpha", 173.0f }
        };
        vectoresArturo = new Dictionary<string, Vector3>
        {
            {"pivote",  new Vector3(-0.93603f, 0.10976f,-0.79936f)},
            {"puntoA",  new Vector3(-1.92074f, 0.63037f,-0.18652f)},
            {"ratioTraslado",  new Vector3(-0.09952f, 0.97853f,-0.10627f)},
            {"centroEsfera", new Vector3()},
            {"pixelDeInterés", new Vector3()},
            {"vectorNormal", new Vector3()},
            {"vectorLuz", new Vector3()},
            {"vectorVisión", new Vector3()},
            {"posiciónCámara", new Vector3(-4.15632f, 4.22037f, 1.74927f)},
            {"posiciónFuenteDeLuz", new Vector3(-3.98077f, 3.32047f,-3.64001f)},
        };
        gameObjectsArturo = new GameObject[]{
            camaraArturo,
            fuenteLuzArturo,
            pixelInterésArturo,
            esferaArturo
        };
        
    }  
    void Update()
    {
        // Arturo
        calculosIlu(vectoresArturo, valoresArturo, gameObjectsArturo);
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

        Vector3 puntoA = new Vector3(vectores["puntoA"].x, vectores["puntoA"].y, vectores["puntoA"].z);
        Vector3 ratioDeTraslado = new Vector3(vectores["ratioTraslado"].x, vectores["ratioTraslado"].y, vectores["ratioTraslado"].z);
        Matrix4x4 mT = Matriz.TranslateM(ratioDeTraslado.x, ratioDeTraslado.y, ratioDeTraslado.z);
        Vector4 aPrima = puntoA;
        aPrima.w = 1;
        aPrima = mT * aPrima;

        Matrix4x4 mR = Matriz.RotateM(valores["anguloRotación"], Matriz.AXIS.AX_X);
        Matrix4x4 mP = Matriz.TranslateM(vectores["pivote"].x, vectores["pivote"].y, vectores["pivote"].z);
        Matrix4x4 mP_1 = Matriz.TranslateM(-1*vectores["pivote"].x, -1 * vectores["pivote"].y, -1 * vectores["pivote"].z);

        Debug.Log("Valor de aPrima: " + aPrima.x + ", " + aPrima.y + ", " + aPrima.z + ", ");

        Vector4 sphereCenter = mP * mR * mP_1 * aPrima;
        Vector3 centroEsfera = new Vector3(sphereCenter.x, sphereCenter.y, sphereCenter.z);
        vectores["centroEsfera"] = centroEsfera;
        Debug.Log("Valor del centro de Esfera: " + centroEsfera);

        pixelDeInterés = new Vector3(
            vectores["centroEsfera"].x + (valores["radio"] * valores["seni"] * valores["sena"]),
            vectores["centroEsfera"].y + (valores["radio"] * valores["cosi"]),
            vectores["centroEsfera"].z + (valores["radio"] * valores["seni"] * valores["cosa"])
         );
        vectores["pixelDeInterés"] =  pixelDeInterés;

        // Rellenamos vectorLuz, vectorVisión, vectorNormal, vectorLuzReflejo
        vectorNormal = new Vector3(
            vectores["pixelDeInterés"].x + vectores["centroEsfera"].x,
            vectores["pixelDeInterés"].y + vectores["centroEsfera"].y,
            vectores["pixelDeInterés"].z + vectores["centroEsfera"].z
         );
        vectores["vectorNormal"] = vectorNormal;

        vectorLuz = vectores["posiciónFuenteDeLuz"] - pixelDeInterés;
        vectores["vectorLuz"] = vectorLuz;

        vectorVisión = vectores["posiciónCámara"] - pixelDeInterés;
        vectores["vectorVisión"] = vectorVisión;

        Debug.Log("Pixel de interés: [Representado en Escena una esfera pequeña] " + "( " + pixelDeInterés[0] + ", " + pixelDeInterés[1] + ", " + pixelDeInterés[2] + ")");
        Debug.Log("Vector Normal: [Representado en Escena como vector de Color CYAN]" + vectorNormal);
        Debug.Log("Vector Luz: [Representado en Escena como vector de Color AMARILLO]" + vectorLuz);
        Debug.Log("Vector Visión: [Representado en Escena como vector de Color BLANCO] " + vectorVisión);

        vectorNormalNormalizado = Math.Normalization(vectorNormal);
        
        Debug.Log("Normal normalizado: " + vectorNormalNormalizado);
        vectorLuzNormalizado = Math.Normalization(vectorLuz);
        

        vectorVisiónNormalizado = Math.Normalization(vectorVisión);
       

        float productoPuntoNU = Math.ProductoPunto(vectorNormalNormalizado, vectorLuz);
        Vector3 vectorParalelo = Math.Magnitud(vectorNormalNormalizado, productoPuntoNU);
        Vector3 vectorOrtogonal = vectorLuz - vectorParalelo;
        vectorLuzReflejo = vectorParalelo - vectorOrtogonal;
        vectorLuzReflejoNormalizado = Math.Normalization(vectorLuzReflejo);

        gameObjects[0].transform.position = new Vector3(vectores["posiciónCámara"].x, vectores["posiciónCámara"].y, vectores["posiciónCámara"].z);
        gameObjects[1].transform.position = new Vector3(vectores["posiciónFuenteDeLuz"].x, vectores["posiciónFuenteDeLuz"].y, vectores["posiciónFuenteDeLuz"].z);
        gameObjects[2].transform.position = pixelDeInterés;
        gameObjects[3].transform.position = new Vector3(vectores["centroEsfera"].x, vectores["centroEsfera"].y, vectores["centroEsfera"].z);

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
        float DRojo = (valores["kdr"] * valores["idr"] * (Math.ProductoPunto(vectorNormalNormalizado, vectorLuzNormalizado)));
        float SRojo = (valores["ksr"] * valores["isr"] * Mathf.Pow(Math.ProductoPunto(vectorVisiónNormalizado, vectorLuzReflejoNormalizado), valores["alpha"]));



        float totalRojo = (ARojo + DRojo + SRojo);
        Debug.Log("IR: " + totalRojo);
        // Calculamos Conjunto A D S de Verde
        float AVerde = ((valores["kag"] * valores["iag"]));
        float DVerde = ((valores["kdg"] * valores["idg"] * (Math.ProductoPunto(vectorNormalNormalizado, vectorLuzNormalizado))));

        float SVerde = (valores["ksg"] * valores["isg"] * Mathf.Pow(Math.ProductoPunto(vectorVisiónNormalizado, vectorLuzReflejoNormalizado), valores["alpha"]));

        float totalVerde = (AVerde + DVerde + SVerde);
        Debug.Log("IG: " + totalVerde);

        // Calculamos Conjunto A D S de Azul
        float AAzul = ((valores["kab"] * valores["iab"]));
        float DAzul = (valores["kdb"] * valores["idb"] * (Math.ProductoPunto(vectorNormalNormalizado, vectorLuzNormalizado)));
        float SAzul = (valores["ksb"] * valores["isb"] * Mathf.Pow(Math.ProductoPunto(vectorVisiónNormalizado, vectorLuzReflejoNormalizado) , valores["alpha"]));


        float totalAzul = (AAzul + DAzul + SAzul);
        Debug.Log("IBl: " + totalAzul);


        Debug.DrawLine(pixelDeInterés, vectores["posiciónCámara"], Color.white);
        Debug.DrawLine(pixelDeInterés, vectores["posiciónFuenteDeLuz"], Color.yellow);
        Debug.DrawLine(pixelDeInterés, vectorNormal, Color.cyan);
        Debug.DrawLine(pixelDeInterés, vectorLuzReflejo, Color.green);
        Debug.DrawLine(pixelDeInterés, vectorLuz, Color.magenta);

    }
}
