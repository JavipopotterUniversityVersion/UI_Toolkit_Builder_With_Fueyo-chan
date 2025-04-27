using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Gumball_Machine : MonoBehaviour
{
    [SerializeField] Pal _palObject;
    [SerializeField] Transform _gachaPos;
    DocumentsManager _documentsManager;

    string[] _palNames = new string[] { "Fueyo", "Andy", "Guillermo", "Diego", "Mika", "Chicho", "Hugo", "Marco", "Jordi", "Itadori", "Choso", "Mayte", "Anna", "Mariel", "Muxu", "Alex" };
    string[] _palSurnames = new string[] { "Itadori", "Llinares", "Balatrez", "Robles Durán", "Gonzalez", "Rodríguez", "Sánchez", "García", ""};
    string[] _palDescriptions = new string[] { "A very smart guay,", "Silly and funny,", "It's gay," };
    string[] _palDescriptions2 = new string[] { "it likes playing chess", "it's a very good friend", "it likes to play with his friends", "hates fascism", "misogynist", "loves to play with his friends" };

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
        return newPal;
    }

    [ContextMenu("Create Pal")]
    public void CreatePal() {
        PalData newPal = CreatePalData();
        _palObject.SetPal(newPal);

        Resources.Load<InventoryData>("Inventory").AddPal(newPal);
    }

    IEnumerator PalAnimationRoutine() {
        _palObject.gameObject.SetActive(true);
        _palObject.transform.position = _gachaPos.position;
        _palObject.transform.localScale = Vector3.zero;
        _palObject.transform.rotation = Quaternion.Euler(0, 0, 0);

        float time = 0.5f;
        float elapsedTime = 0f;
        Vector3 targetScale = new Vector3(3, 3, 3);
        Vector3 targetPos = Vector3.zero;

        Quaternion targetRotation = Quaternion.Euler(0, 0, 360);
        
        _documentsManager.Notify(_palObject.PalData.name, _palObject.PalData.description, () => {
            StartCoroutine(SavePalTween());
        });

        while (elapsedTime < time) {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / time;

            _palObject.transform.localScale = Vector3.Lerp(Vector3.zero, targetScale, t);
            _palObject.transform.position = Vector3.Lerp(_gachaPos.position, targetPos, t);
            _palObject.transform.rotation = Quaternion.Slerp(Quaternion.Euler(0, 0, 0), targetRotation, t);

            yield return new WaitForEndOfFrame();
        }

        _palObject.transform.localScale = targetScale;
        _palObject.transform.position = targetPos;
        _palObject.transform.rotation = targetRotation;

        yield return new WaitForSeconds(1f);
    }

    IEnumerator SavePalTween() {
        //Go Up and out of screen
        float time = 0.5f;

        float targetY = 8;
        Vector3 targetPos = new Vector3(_palObject.transform.position.x, targetY, _palObject.transform.position.z);

        for (float elapsedTime = 0; elapsedTime < time; elapsedTime += Time.deltaTime) {
            float t = elapsedTime / time;
            _palObject.transform.position = Vector3.Lerp(_palObject.transform.position, targetPos, t);
            yield return new WaitForEndOfFrame();
        }
        print("SavePalTween");
        _palObject.transform.position = targetPos;
        _palObject.gameObject.SetActive(false);
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
     }
}
