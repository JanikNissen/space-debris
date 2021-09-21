using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tether : MonoBehaviour
{
    public Transform droneConnector;
    public Transform motherShipConnector;
    private LineRenderer line;
    public float maxLength = 100f;
    public Color midLengthColor;
    public Color maxLengthColor;
    public Gradient colorGradient;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        line = transform.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        line.colorGradient = makeNewGradient();
        line.SetPositions(new Vector3[] { droneConnector.position, motherShipConnector.position });
    }


    private Gradient makeNewGradient()
    {
        Color gradientColor = colorGradient.Evaluate((motherShipConnector.position - droneConnector.position).magnitude / maxLength);
        Gradient newGradient = new Gradient();
        GradientColorKey[] colors = new GradientColorKey[] { new GradientColorKey(gradientColor, 0f), new GradientColorKey(gradientColor, 1f) };
        GradientAlphaKey[] alphas = new GradientAlphaKey[] { new GradientAlphaKey(255f,0f), new GradientAlphaKey(255f,1f)};
        newGradient.colorKeys = colors;
        newGradient.alphaKeys = alphas;
        return newGradient;
    }
}
