using UnityEngine;

namespace Code.Pipes
{
    public class PipeSpawner : MonoBehaviour
    {
        [SerializeField] private float spawnInterval;
        
        private PipePooler _pipePooler;

        private float _timer;

        private void Awake()
        {
            _pipePooler = GetComponent<PipePooler>();
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer > spawnInterval)
            {
                SpawnPipe();
                _timer = 0;
            }
        }

        private void SpawnPipe()
        {
            GameObject pipe = _pipePooler.GetPooledPipes();
            
            if (pipe is null) return;
            
            pipe.SetActive(true);
        }
    }
}
