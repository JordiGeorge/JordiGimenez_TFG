using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace Bauhaus
{
    public class DissolveController : MonoBehaviour
    {
        public MeshRenderer exampleMesh;
        public VisualEffect vfxGraphDissolve;
        private Material exampleMeshMat;
        public float dissolveRate = 0.0125f;
        public float refreshRate = 0.025f;

        // Start is called before the first frame update
        void Start()
        {
            if(exampleMesh != null)
            {
                exampleMeshMat = exampleMesh.material;
            }
        
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(DissolveCoroutine());
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                dissolveRate = 0;
            }
        }

        IEnumerator DissolveCoroutine()
        {
            if (vfxGraphDissolve != null)
            {
                vfxGraphDissolve.Play();
            }

            //if(exampleMeshMat)
            float counter = 0;

            while(exampleMeshMat.GetFloat("_DissolveAmount") < 1)
            {
                counter += dissolveRate;

                exampleMeshMat.SetFloat("_DissolveAmount", counter);
                yield return new WaitForSeconds(refreshRate);

            }

            exampleMeshMat.SetFloat("_DissolveAmount", dissolveRate);

        }
    }
}
