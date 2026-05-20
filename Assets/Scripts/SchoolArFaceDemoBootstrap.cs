using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

/// <summary>
/// Windows Editor school demo: show a static <c>AR Default Face</c> instance with props at a fixed world pose.
/// Disables <see cref="ARFaceManager"/> and <see cref="ARCameraBackground"/> in the Editor — the camera background
/// often draws full-screen and hides all opaque geometry when no AR camera texture is available.
/// On device builds, this script does nothing — normal AR face spawning applies.
/// </summary>
[DefaultExecutionOrder(-320)]
public sealed class SchoolArFaceDemoBootstrap : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Optional parent for the demo face. If null, a root object is created.")]
    Transform demoRoot;

    [SerializeField]
    GameObject arDefaultFacePrefab;

    [SerializeField]
    GameObject propsCrazyEyesPrefab;

    [SerializeField]
    Vector3 faceWorldPosition = new Vector3(0f, 0f, 1f);

    [SerializeField]
    Quaternion faceWorldRotation = Quaternion.identity;

    [SerializeField]
    Vector3 faceLocalScale = new Vector3(10f, 10f, 10f);

    [SerializeField]
    Vector3 propsLocalPosition = new Vector3(0f, 0.006f, 0.012f);

    [SerializeField]
    Vector3 propsLocalEuler = new Vector3(5f, 180f, 0f);

    [SerializeField]
    Vector3 propsLocalScale = new Vector3(1f, 1f, 1f);

    void Awake()
    {
        if (!Application.isEditor)
            return;

        foreach (var faceManager in FindObjectsOfType<ARFaceManager>(true))
            faceManager.enabled = false;

        // Critical in Editor: this component often composites a full-screen effect and occludes the scene.
        foreach (var camBg in FindObjectsOfType<ARCameraBackground>(true))
            camBg.enabled = false;

        Transform root = demoRoot;
        if (root == null)
        {
            var go = new GameObject("School Demo Face (Editor)");
            root = go.transform;
            demoRoot = root;
        }

        root.SetPositionAndRotation(faceWorldPosition, faceWorldRotation);
        root.localScale = Vector3.one;
    }

    void Start()
    {
        if (!Application.isEditor)
            return;
        StartCoroutine(EditorDemoSetup());
    }

    IEnumerator EditorDemoSetup()
    {
        Transform root = demoRoot;
        if (root == null)
            yield break;

        if (arDefaultFacePrefab == null || propsCrazyEyesPrefab == null)
        {
            Debug.LogWarning($"{nameof(SchoolArFaceDemoBootstrap)}: Assign AR Default Face and Props_CrazyEyes prefabs.", this);
            yield break;
        }

        for (int i = root.childCount - 1; i >= 0; i--)
            Destroy(root.GetChild(i).gameObject);

        yield return null;

        var face = Instantiate(arDefaultFacePrefab, root);
        face.name = "AR Default Face";
        face.transform.localPosition = Vector3.zero;
        face.transform.localRotation = Quaternion.identity;
        face.transform.localScale = faceLocalScale;

        DisableArFoundationBehaviours(face);

        var props = Instantiate(propsCrazyEyesPrefab, face.transform);
        props.name = "Props_CrazyEyes";
        props.transform.localPosition = propsLocalPosition;
        props.transform.localRotation = Quaternion.Euler(propsLocalEuler);
        props.transform.localScale = propsLocalScale;
    }

    static void DisableArFoundationBehaviours(GameObject root)
    {
        foreach (var mb in root.GetComponentsInChildren<MonoBehaviour>(true))
        {
            if (mb == null)
                continue;
            var ns = mb.GetType().Namespace;
            if (ns != null && ns.StartsWith("UnityEngine.XR.ARFoundation"))
                mb.enabled = false;
        }
    }
}
