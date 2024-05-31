using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIFloat : MonoBehaviour
{
    private TMP_Text textComponent;

    private float timeModY;
    private float timeModX;

    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<TMP_Text>();

        timeModY = Random.Range(3.4f, 3.8f);
        timeModX = Random.Range(2.4f, 2.8f);
    }

    // Update is called once per frame
    void Update()
    {
        textComponent.ForceMeshUpdate();

        var textInfo = textComponent.textInfo;

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            var charInfo = textInfo.characterInfo[i];

            if (!charInfo.isVisible)
            {
                continue;
            }

            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

            for (int j = 0; j < 4; j++)
            {
                var orig = verts[charInfo.vertexIndex + j];
                //verts[charInfo.vertexIndex + j] = orig + new Vector3(0, Mathf.Sin(Time.time * 2f + orig.x * 0.01f) * 10f, 0);
                verts[charInfo.vertexIndex + j] = orig + new Vector3(Mathf.Sin(Time.time * timeModY ), Mathf.Cos(Time.time * timeModX) * 10f, 0);
            }
        }

        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            textComponent.UpdateGeometry(meshInfo.mesh, i);
        }
    }
}
