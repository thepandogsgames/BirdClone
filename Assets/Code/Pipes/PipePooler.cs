using System.Collections.Generic;
using UnityEngine;

namespace Code.Pipes
{
    public class PipePooler : MonoBehaviour
    {
        [SerializeField] private GameObject pipePrefab;
        [SerializeField] private GameObject pipePrefabMobile;
        [SerializeField] private int poolSize;

        private List<GameObject> _pipesPool;
        private void Awake()
        {
            _pipesPool = new List<GameObject>();

            for (int i = 0; i < poolSize; i++)
            {
                GameObject pipe;
                if (Application.isMobilePlatform)
                {
                    pipe = Instantiate(pipePrefabMobile);
                }
                else
                {
                    pipe = Instantiate(pipePrefab);
                }
                pipe.GetComponent<Pipe>().Reset();
                _pipesPool.Add(pipe);
            }
        }

        public GameObject GetPooledPipes()
        {
            foreach (GameObject pipe in _pipesPool)
            {
                if (!pipe.activeSelf)
                {
                    return pipe;
                }
            }
            return null;
        }
    }
}
