using UnityEngine;

namespace Game
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField]
        private SkinnedMeshRenderer[] _meshes;

        public void SelectMesh(SkinnedMeshRenderer value)
        {
            foreach (var mesh in _meshes) 
                mesh.gameObject.SetActive(false);
            
            value.gameObject.SetActive(true);
        }
    }
}