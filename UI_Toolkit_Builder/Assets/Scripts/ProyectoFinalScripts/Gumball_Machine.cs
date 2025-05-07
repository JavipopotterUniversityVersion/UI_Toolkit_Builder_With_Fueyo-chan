using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Gumball_Machine : MonoBehaviour
{
    DocumentsManager _documentsManager;
    VisualElement _palElement;
    PalData _lastPalData;
    [SerializeField] UIDocument _gameViewDocument;

    string[] _palNames = new string[] { "Fueyo", "Andy", "Guillermo", "Diego", "Mika", "Chicho", "Hugo", "Marco", "Jordi", "Itadori", "Choso", "Mayte", "Anna", "Mariel", "Muxu", "Alex", "Alec", "David", "Marc", "Carlos", "Joaquín", "Manolo", "Héctor", "Samir", "Federico", "Jaime", "Miguel", "Alejandro", "Carlos León", "León", "María", "Laurentina", "Amiel", "Ariel", "Isabelle", "Cayetano", "Laura", "Eunice", "Cristal", "Berenice", "Gwendolyn", "Wenceslavo", "Martín", "Martina", "Cayetana", "Luis", "Kesia", "Sara", "Luisa", "Lucía", "Andrea", "Marta", "Alejandra", "Inmaculada", "Rosa", "Elsa", "Elena", "María del Mar", "María del Carmen", "María de los Ángeles", "María de la Luz", "María de la Esperanza", "María de la Paz", "María de la Soledad", "María de la Asunción", "María de la Consolación", "María de la Inmaculada Concepción", "María de la Encarnación" };
    string[] _palSurnames = new string[] { "Itadori", "Llinares", "Balatrez", "Robles Durán", "Gonzalez", "Rodríguez", "Sánchez", "García", "", "Rodero", "Gómez", "Fernández", "Salvador", "Tormos", "Estaca", "Montenegro", "Caballero", "Gallardo", "Genaim", "Peinado", "Romero", "León", "Sosa Casasola", "Soto", "Coronado", "Ruíz", "Mora", "Coca", "Valenzuela", "Valor", "Godoy", "Colomina", "Pato", "Villalba", "Torres", "Cervantes", "Van Goh", "Einstein", "Newton", "Galileo", "Copérnico", "Darwin", "Curie", "Tesla", "Hawking", "Feynman", "Bohr", "Pauli", "Heisenberg", "Planck", "Lorentz", "Ohm" };
    string[] _palDescriptions = {
        "Una persona muy inteligente,",
        "Una persona graciosa,",
        "Es homosexual,",
        "Tiene una gran imaginación,",
        "Suele ser muy curiosa,",
        "Es bastante introvertida,",
        "Tiene una energía contagiosa,",
        "Es muy empática,",
        "Le encanta aprender cosas nuevas,",
        "Tiene un gran sentido de la estética,",
        "Tiene una perspectiva única,",
        "Le cuesta expresar lo que siente,",
        "Posee una gran memoria,",
        "Es increíblemente resiliente,",
        "Se comunica con claridad,",
        "Tiene un humor peculiar,",
        "Le interesa el comportamiento humano,",
        "Suele perderse en sus pensamientos,",
        "Disfruta del silencio,",
        "Siente una fuerte conexión con la naturaleza,",
        "Es muy observadora,",
        "Busca constantemente la verdad,",
        "Le cuesta confiar en los demás,",
        "Tiene ideas poco convencionales,",
        "Le intrigan los misterios del universo,",
        "Encuentra belleza en lo cotidiano,",
        "A veces actúa por instinto,",
        "Se siente cómoda en la soledad,",
        "Tiene una actitud rebelde,",
        "Se adapta fácilmente a los cambios,"
    };

    string[] _palDescriptions2 = {
        "le gusta el ajedrez.",
        "disfruta de los videojuegos retro.",
        "le apasiona la música clásica.",
        "colecciona objetos curiosos.",
        "pasa mucho tiempo leyendo ciencia ficción.",
        "suele escribir poesía en su tiempo libre.",
        "le gusta explorar lugares abandonados.",
        "es fan del cine experimental.",
        "dedica tiempo al activismo social.",
        "le interesa la inteligencia artificial.",
         "colecciona piedras con formas extrañas.",
        "le interesan los insectos.",
        "tiene una rutina nocturna muy marcada.",
        "sueña con vivir en otro planeta.",
        "toma fotografías de la ciudad vacía.",
        "escucha podcasts de filosofía.",
        "tiene un diario encriptado.",
        "practica meditación cada mañana.",
        "le encanta ver la lluvia caer.",
        "camina durante horas sin rumbo.",
        "participa en debates en línea.",
        "cultiva plantas exóticas.",
        "arma rompecabezas imposibles.",
        "modifica tecnología antigua.",
        "lee sobre teorías conspirativas.",
        "colecciona cartas escritas a mano.",
        "estudia lenguas extintas.",
        "investiga fenómenos paranormales.",
        "crea música con sonidos encontrados.",
        "dibuja en servilletas de papel."
    };

    Sprite[] _palsShapes;
    Sprite[] _palsFaces;

    private void Awake() {
        _documentsManager = GetComponentInParent<DocumentsManager>();
        _palsShapes = Resources.LoadAll<Sprite>("Pals");
        _palsFaces = Resources.LoadAll<Sprite>("PalFaces");
    }


    PalData CreatePalData() {
        PalData newPal = new PalData();
        newPal.name = _palNames[Random.Range(0, _palNames.Length)] + " " + _palSurnames[Random.Range(0, _palSurnames.Length)];
        newPal.description = _palDescriptions[Random.Range(0, _palDescriptions.Length)] + " " + _palDescriptions2[Random.Range(0, _palDescriptions2.Length)];
        newPal.shape = _palsShapes[Random.Range(0, _palsShapes.Length)];
        newPal.face = _palsFaces[Random.Range(0, _palsFaces.Length)];
        newPal.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        _lastPalData = newPal;
        return newPal;
    }

    [ContextMenu("Create Pal")]
    public void CreatePal() {
        PalData newPal = CreatePalData();
        _palElement.style.backgroundImage = new StyleBackground(PalData.GetPalTexture(newPal));

        Resources.Load<InventoryData>("Inventory").AddPal(newPal);
    }

    IEnumerator PalAnimationRoutine() {
        _palElement.style.display = DisplayStyle.Flex;
        _palElement.style.opacity = 1f;

        _palElement.style.translate = new StyleTranslate(new Translate(0, 15));
        _palElement.style.scale = new StyleScale(new Scale(new Vector2(0.1f, 0.1f)));

        float time = 0.5f;
        float elapsedTime = 0f;
        Vector3 targetScale = new Vector3(0.7f, 0.7f, 0.7f);
        Vector3 targetPos = Vector3.zero;

        _documentsManager.Notify(_lastPalData.name, _lastPalData.description, () => {
            StartCoroutine(SavePalTween());
        });

        while (elapsedTime < time) {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / time;

            _palElement.style.scale = new StyleScale(Vector3.Lerp(Vector3.zero, targetScale, t));

            Vector3 currentPos = Vector3.Lerp(new Vector3(0,15,0), targetPos, t);
            _palElement.style.translate = new StyleTranslate(new Translate(currentPos.x, currentPos.y));

            yield return new WaitForEndOfFrame();
        }

        _palElement.style.scale = new StyleScale(new Scale(targetScale));
        _palElement.style.translate = new StyleTranslate(new Translate(targetPos.x, targetPos.y));

        yield return new WaitForSeconds(1f);
    }

    IEnumerator SavePalTween() {
        const float TIME = 0.5f;
        float elapsedTime = 0f;

        const float START_OPACITY = 1f;
        const float TARGET_OPACITY = 0f;


        while (elapsedTime < TIME) {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / TIME;

            _palElement.style.opacity = Mathf.Lerp(START_OPACITY, TARGET_OPACITY, t);

            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(1f);
        _palElement.style.display = DisplayStyle.None;
    }

     private void OnEnable() 
     {
        UIDocument uiDoc = GetComponent<UIDocument>();
        VisualElement root = uiDoc.rootVisualElement;

        VisualElement buy_button = root.Q<VisualElement>("Buy");
        buy_button.RegisterCallback<ClickEvent>(e => {
            CreatePal();
            StopAllCoroutines();
            StartCoroutine(PalAnimationRoutine());
        });

        VisualElement palDex_button = root.Q<VisualElement>("PalDex");
        palDex_button.RegisterCallback<ClickEvent>(e => {
            _documentsManager.OpenInventoryDocument();
        });

        _palElement = _gameViewDocument.rootVisualElement.Q("pal");
        _palElement.style.display = DisplayStyle.None;
     }
}
