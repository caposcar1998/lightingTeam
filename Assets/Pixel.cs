using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pixel : MonoBehaviour
{
    Matrix4x4 mR;
    public GameObject camaraArturo;
    public GameObject fuenteLuzArturo;
    public GameObject pixelInterésArturo;
    public GameObject esferaArturo;
    // Declaración del diccionario donde se insertarán los valores
    Dictionary<string, float> valoresArturo;
    // Declaración del diccionario donde se insertarán los vectores
    Dictionary<string, Vector3> vectoresArturo;

    public GameObject camaraOscar;
    public GameObject fuenteLuzOscar;
    public GameObject pixelInterésOscar;
    public GameObject esferaOscar;
    GameObject[] gameObjectsÓscar;


    // Declaración del diccionario donde se insertarán los valores
    Dictionary<string, float> valoresÓscar;
    // Declaración del diccionario donde se insertarán los vectores
    Dictionary<string, Vector3> vectoresÓscar;

    GameObject[] gameObjectsArturo;

    public GameObject camaraManu;
    public GameObject fuenteLuzManu;
    public GameObject pixelInterésManu;
    public GameObject esferaManu;
    GameObject[] gameObjectsManu;

    // Declaración del diccionario donde se insertarán los valores
    Dictionary<string, float> valoresManu;
    // Declaración del diccionario donde se insertarán los vectores
    Dictionary<string, Vector3> vectoresManu;

    public GameObject camaraMoni;
    public GameObject fuenteLuzMoni;
    public GameObject pixelInterésMoni;
    public GameObject esferaMoni;
    GameObject[] gameObjectsMoni;

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
        valoresÓscar = new Dictionary<string, float>
        {
            {"kar", 0.12529f},
            {"kag", 0.28801f},
            {"kab", 0.25311f},
            {"kdr", 0.18104f},
            {"kdg", 0.98831f},
            {"kdb", 0.04684f},
            {"ksr", 0.35753f},
            {"ksg", 0.39207f},
            {"ksb", 0.36912f},
            {"iar", 0.83664f},
            {"iag", 0.87404f},
            {"iab", 0.85723f},
            {"idr", 0.98746f},
            {"idg", 0.99539f},
            {"idb", 0.80289f},
            {"isr", 0.85272f},
            {"isg", 0.89772f},
            {"isb", 0.95995f},
            {"i",40.0f * Mathf.Deg2Rad},
            {"a",286.0f * Mathf.Deg2Rad},
            {"seni", Mathf.Sin(40.0f)},
            {"sena", Mathf.Sin(286.0f)},
            {"cosa", Mathf.Cos(286.0f)},
            {"cosi", Mathf.Sin(40.0f)},
            {"radioReal", 0.93293f * 2 },
            {"radio", 0.93293f },
            {"anguloRotación", -1.1f },
            { "alpha", 162.0f }
        };

        vectoresÓscar = new Dictionary<string, Vector3>
        {
            {"pivote",  new Vector3(-0.38091f, 0.85841f, 0.70222f)},
            {"puntoA",  new Vector3(-0.95327f, 0.67593f, 0.53050f)},
            {"ratioTraslado",  new Vector3(0.38091f, 0.85841f, 0.70222f)},
            {"centroEsfera", new Vector3()},
            {"pixelDeInterés", new Vector3()},
            {"vectorNormal", new Vector3()},
            {"vectorLuz", new Vector3()},
            {"vectorVisión", new Vector3()},
            {"posiciónCámara", new Vector3(-4.66113f, 4.89948f,-3.95601f)},
            {"posiciónFuenteDeLuz", new Vector3(-3.10624f, 3.07567f, 3.46960f)},
        };
        gameObjectsÓscar = new GameObject[]{
            camaraOscar,
            fuenteLuzOscar,
            pixelInterésOscar,
            esferaOscar
        };
        valoresMoni = new Dictionary<string, float>
        {
            {"kar", 0.18308f},
            {"kag", 0.22376f},
            {"kab", 0.28071f},
            {"kdr", 0.04166f},
            {"kdg", 0.08266f},
            {"kdb", 0.69165f},
            {"ksr", 0.26315f},
            {"ksg", 0.48600f},
            {"ksb", 0.13866f},
            {"iar", 0.95039f},
            {"iag", 0.81666f},
            {"iab", 0.87679f},
            {"idr", 0.88845f},
            {"idg", 0.96903f},
            {"idb", 0.99164f},
            {"isr", 0.80899f},
            {"isg", 0.94072f},
            {"isb", 0.91297f},
            {"i",32.0f * Mathf.Deg2Rad},
            {"a",76.0f * Mathf.Deg2Rad},
            {"seni", Mathf.Sin(32.0f)},
            {"sena", Mathf.Sin(76.0f)},
            {"cosa", Mathf.Cos(76.0f)},
            {"cosi", Mathf.Sin(32.0f)},
            {"radioReal", 0.72715f * 2 },
            {"radio", 0.72715f },
            {"anguloRotación", -6.3f },
            { "alpha", 12.0f }
        };
        vectoresMoni = new Dictionary<string, Vector3>{
            {"pivote",  new Vector3(0.08237f, 0.42610f, 0.47587f)},
            {"puntoA",  new Vector3(1.77421f, 0.33465f, 0.78895f)},
            {"ratioTraslado",  new Vector3(0.42531f, 0.53589f, 0.73183f)},
            {"centroEsfera", new Vector3()},
            {"pixelDeInterés", new Vector3()},
            {"vectorNormal", new Vector3()},
            {"vectorLuz", new Vector3()},
            {"vectorVisión", new Vector3()},
            {"posiciónCámara", new Vector3(4.57361f, 4.43741f,-4.87721f)},
            {"posiciónFuenteDeLuz", new Vector3(3.34361f, 3.24041f, 4.28955f)},
        };
        gameObjectsMoni = new GameObject[]{
            camaraMoni,
            fuenteLuzMoni,
            pixelInterésMoni,
            esferaMoni
        };
        valoresManu = new Dictionary<string, float>
        {
            {"kar", 0.17621f},
            {"kag", 0.23565f},
            {"kab", 0.13663f},
            {"kdr", 0.02143f},
            {"kdg", 0.73391f},
            {"kdb", 0.20671f},
            {"ksr", 0.38060f},
            {"ksg", 0.32190f},
            {"ksb", 0.37019f},
            {"iar", 0.98697f},
            {"iag", 0.89042f},
            {"iab", 0.82559f},
            {"idr", 0.84460f},
            {"idg", 0.91196f},
            {"idb", 0.88007f},
            {"isr", 0.86206f},
            {"isg", 0.94546f},
            {"isb", 0.92229f},
            {"i",156.0f * Mathf.Deg2Rad},
            {"a",74.0f * Mathf.Deg2Rad},
            {"seni", Mathf.Sin(156.0f)},
            {"sena", Mathf.Sin(74.0f)},
            {"cosa", Mathf.Cos(74.0f)},
            {"cosi", Mathf.Sin(156.0f)},
            {"radioReal", 0.89540f * 2 },
            {"radio", 0.89540f },
            {"anguloRotación", 9.5f },
            { "alpha", 114.0f }
        };
        vectoresManu = new Dictionary<string, Vector3>{
            {"pivote",  new Vector3(0.38638f,-0.90402f, 0.80185f)},
            {"puntoA",  new Vector3(1.88701f,-1.94309f, 0.27726f)},
            {"ratioTraslado",  new Vector3(.72493f,-0.08369f, 0.98777f)},
            {"centroEsfera", new Vector3()},
            {"pixelDeInterés", new Vector3()},
            {"vectorNormal", new Vector3()},
            {"vectorLuz", new Vector3()},
            {"vectorVisión", new Vector3()},
            {"posiciónCámara", new Vector3(4.42065f,-4.92961f,-5.87322f)},
            {"posiciónFuenteDeLuz", new Vector3(3.01049f,-3.24177f, 4.84087f)},
        };
        gameObjectsManu = new GameObject[]{
            camaraManu,
            fuenteLuzManu,
            pixelInterésManu,
            esferaManu
        };

    }
    void Update()
    {
        // Arturo
        calculosIlu(vectoresArturo, valoresArturo, gameObjectsArturo, 0);
        // Óscar
        calculosIlu(vectoresÓscar, valoresÓscar, gameObjectsÓscar, 1);
        // Manu
        calculosIlu(vectoresManu, valoresManu, gameObjectsManu, 1);
        // Moni
        calculosIlu(vectoresMoni, valoresMoni, gameObjectsMoni, 2);

    }

    void calculosIlu(Dictionary<string, Vector3> vectores, Dictionary<string, float> valores, GameObject[] gameObjects, int eje)
    {

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
        
        if (eje == 0){mR = Matriz.RotateM(valores["anguloRotación"], Matriz.AXIS.AX_X); }
        if (eje == 1) { mR = Matriz.RotateM(valores["anguloRotación"], Matriz.AXIS.AX_Y); }
        if (eje == 2) { mR = Matriz.RotateM(valores["anguloRotación"], Matriz.AXIS.AX_Z); }

        Matrix4x4 mP = Matriz.TranslateM(vectores["pivote"].x, vectores["pivote"].y, vectores["pivote"].z);
        Matrix4x4 mP_1 = Matriz.TranslateM(-1 * vectores["pivote"].x, -1 * vectores["pivote"].y, -1 * vectores["pivote"].z);

        Debug.Log("Valor de aPrima: " + aPrima.x + ", " + aPrima.y + ", " + aPrima.z + ", ");

        Vector4 sphereCenter = mP * this.mR * mP_1 * aPrima;
        Vector3 centroEsfera = new Vector3(sphereCenter.x, sphereCenter.y, sphereCenter.z);
        vectores["centroEsfera"] = centroEsfera;
        Debug.Log("Valor del centro de Esfera: " + centroEsfera);

        pixelDeInterés = new Vector3(
            vectores["centroEsfera"].x + (valores["radio"] * valores["seni"] * valores["sena"]),
            vectores["centroEsfera"].y + (valores["radio"] * valores["cosi"]),
            vectores["centroEsfera"].z + (valores["radio"] * valores["seni"] * valores["cosa"])
         );
        vectores["pixelDeInterés"] = pixelDeInterés;

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
        float SAzul = (valores["ksb"] * valores["isb"] * Mathf.Pow(Math.ProductoPunto(vectorVisiónNormalizado, vectorLuzReflejoNormalizado), valores["alpha"]));


        float totalAzul = (AAzul + DAzul + SAzul);
        Debug.Log("IBl: " + totalAzul);


        Debug.DrawLine(pixelDeInterés, vectores["posiciónCámara"], Color.white);
        Debug.DrawLine(pixelDeInterés, vectores["posiciónFuenteDeLuz"], Color.yellow);
        Debug.DrawLine(pixelDeInterés, vectorNormal, Color.cyan);
        Debug.DrawLine(pixelDeInterés, vectorLuzReflejo, Color.green);
        Debug.DrawLine(pixelDeInterés, vectorLuz, Color.magenta);

    }
}
